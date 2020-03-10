using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;

namespace ExamBLL
{
	/// <summary>
	/// ҵ���߼���UserAnswerBLL ��ժҪ˵����
	/// </summary>
	public class UserAnswerBLL
	{
        private readonly UserAnswerDAL dal = new UserAnswerDAL();
		public UserAnswerBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Guid PaperAnswerGuid)
		{
			return dal.Exists(PaperAnswerGuid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(UserAnswerEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(UserAnswerEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Guid PaperAnswerGuid)
		{
			
			dal.Delete(PaperAnswerGuid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public UserAnswerEntity GetModel(Guid PaperAnswerGuid)
		{
			
			return dal.GetModel(PaperAnswerGuid);
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
		public List<UserAnswerEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<UserAnswerEntity> DataTableToList(DataTable dt)
		{
			List<UserAnswerEntity> modelList = new List<UserAnswerEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserAnswerEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new UserAnswerEntity();
					if(dt.Rows[n]["PaperAnswerGuid"].ToString()!="")
					{
						model.PaperAnswerGuid=new Guid(dt.Rows[n]["PaperAnswerGuid"].ToString());
					}
					if(dt.Rows[n]["PaperGuid"].ToString()!="")
					{
						model.PaperGuid=new Guid(dt.Rows[n]["PaperGuid"].ToString());
					}
					if(dt.Rows[n]["UserGuid"].ToString()!="")
					{
						model.UserGuid=new Guid(dt.Rows[n]["UserGuid"].ToString());
					}
					if(dt.Rows[n]["SelectAnswerGuid"].ToString()!="")
					{
						model.SelectAnswerGuid=new Guid(dt.Rows[n]["SelectAnswerGuid"].ToString());
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
	}
}

