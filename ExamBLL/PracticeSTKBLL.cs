using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;
using System.Data.SqlClient;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类STKBLL 的摘要说明。
	/// </summary>
	public class PracticeSTKBLL
	{
        private readonly PracticeSTKDAL dal = new PracticeSTKDAL();
		public PracticeSTKBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid STKGuid)
		{
			return dal.Exists(STKGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(STKEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(STKEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid STKGuid)
		{
			
			dal.Delete(STKGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STKEntity GetModel(Guid STKGuid)
		{
			
			return dal.GetModel(STKGuid);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<STKEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
            
        #region 自定义方法
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总条数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public DataSet GetPageList(int pageIndex, int pageSize, string strWhere, string strOrder, string tableNames, string fileds, string mainFeilds)
        {
            return dal.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableNames, fileds, mainFeilds);
        }
        /// <summary>
        /// 得到一个对象实体
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

