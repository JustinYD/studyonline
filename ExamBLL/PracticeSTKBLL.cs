using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;
using System.Data.SqlClient;

namespace ExamBLL
{
	/// <summary>
	/// ҵ���߼���STKBLL ��ժҪ˵����
	/// </summary>
	public class PracticeSTKBLL
	{
        private readonly PracticeSTKDAL dal = new PracticeSTKDAL();
		public PracticeSTKBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Guid STKGuid)
		{
			return dal.Exists(STKGuid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(STKEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(STKEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Guid STKGuid)
		{
			
			dal.Delete(STKGuid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public STKEntity GetModel(Guid STKGuid)
		{
			
			return dal.GetModel(STKGuid);
		}

	
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<STKEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<STKEntity> DataTableToList(DataTable dt)
		{
			List<STKEntity> modelList = new List<STKEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				STKEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new STKEntity();
                    if (dt.Rows[n]["STKID"].ToString() != "")
                    {
                        model.STKID = int.Parse(dt.Rows[n]["STKID"].ToString());
                    }
                    if (dt.Rows[n]["STKGuid"].ToString()!="")
					{
						model.STKGuid=new Guid(dt.Rows[n]["STKGuid"].ToString());
					}
					model.STKName=dt.Rows[n]["STKName"].ToString();
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=dt.Rows[n]["CreateTime"].ToString();
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
            
        #region �Զ��巽��
        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageSize">������</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="parameters">�����б�</param>
        /// <returns></returns>
        public DataSet GetPageList(int pageIndex, int pageSize, string strWhere, string strOrder, string tableNames, string fileds, string mainFeilds)
        {
            return dal.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableNames, fileds, mainFeilds);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public STKEntity GetModel(string strWhere, params SqlParameter[] parameters)
        {
            return dal.GetModel(strWhere, parameters);
        }
        public bool Update(string strWhere, string files, params SqlParameter[] parameters)
        {
            return dal.Update(strWhere, files, parameters);
        }
            #endregion
        }
}

