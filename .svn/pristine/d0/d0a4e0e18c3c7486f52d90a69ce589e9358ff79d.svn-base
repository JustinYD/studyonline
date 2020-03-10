using System;
using System.Data;
using System.Collections.Generic;
using ExamModel;
using ExamDAL;
using System.Data.SqlClient;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类AnswersBLL 的摘要说明。
	/// </summary>
	public class AnswersBLL
	{
        private readonly AnswersDAL dal = new AnswersDAL();
		public AnswersBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid AnswerGuid)
		{
			return dal.Exists(AnswerGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AnswersEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(AnswersEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid AnswerGuid)
		{
			
			dal.Delete(AnswerGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AnswersEntity GetModel(Guid AnswerGuid)
		{
			
			return dal.GetModel(AnswerGuid);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetList(string strWhere, params SqlParameter[] param)
        {
            return dal.GetList(strWhere,param);
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
		public List<AnswersEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<AnswersEntity> GetModelList(string strWhere,params SqlParameter[] param)
        {
            DataSet ds = dal.GetList(strWhere,param);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AnswersEntity> DataTableToList(DataTable dt)
		{
			List<AnswersEntity> modelList = new List<AnswersEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				AnswersEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AnswersEntity();
					if(dt.Rows[n]["AnswerGuid"].ToString()!="")
					{
						model.AnswerGuid=new Guid(dt.Rows[n]["AnswerGuid"].ToString());
					}
					model.AnswerName=dt.Rows[n]["AnswerName"].ToString();
					if(dt.Rows[n]["QuestionGuid"].ToString()!="")
					{
						model.QuestionGuid=new Guid(dt.Rows[n]["QuestionGuid"].ToString());
					}
					if(dt.Rows[n]["STKGuid"].ToString()!="")
					{
						model.STKGuid=new Guid(dt.Rows[n]["STKGuid"].ToString());
					}
					if(dt.Rows[n]["IsRightAnswer"].ToString()!="")
					{
						model.IsRightAnswer=int.Parse(dt.Rows[n]["IsRightAnswer"].ToString());
					}
					if(dt.Rows[n]["AnswerOrder"].ToString()!="")
					{
						model.AnswerOrder=int.Parse(dt.Rows[n]["AnswerOrder"].ToString());
					}
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
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
        public bool Delete(string strWhere, params SqlParameter[] param)
        {
            return dal.Delete(strWhere, param);
        }
        #endregion
    }
}

