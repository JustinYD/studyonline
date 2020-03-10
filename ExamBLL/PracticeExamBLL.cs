using System;
using System.Data;
using System.Collections.Generic;
using ExamModel;
using ExamDAL;
using System.Data.SqlClient;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类ExamsBLL 的摘要说明。
	/// </summary>
	public class PracticeExamsBLL
	{
		private readonly PracticeExamsDAL dal = new PracticeExamsDAL();
		public PracticeExamsBLL()
		{ }
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid ExamGuid)
		{
			return dal.Exists(ExamGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamsEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ExamsEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid ExamGuid)
		{

			dal.Delete(ExamGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamsEntity GetModel(Guid ExamGuid)
		{

			return dal.GetModel(ExamGuid);
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
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ExamsEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ExamsEntity> DataTableToList(DataTable dt)
		{
			List<ExamsEntity> modelList = new List<ExamsEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ExamsEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ExamsEntity();
					if (dt.Rows[n]["ExamGuid"].ToString() != "")
					{
						model.ExamGuid = new Guid(dt.Rows[n]["ExamGuid"].ToString());
					}
					model.ExamName = dt.Rows[n]["ExamName"].ToString();
					if (dt.Rows[n]["ExamScore"].ToString() != "")
					{
						model.ExamScore = decimal.Parse(dt.Rows[n]["ExamScore"].ToString());
					}
					if (dt.Rows[n]["CreateTime"].ToString() != "")
					{
						model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if (dt.Rows[n]["Status"].ToString() != "")
					{
						model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if (dt.Rows[n]["ActualCount"].ToString() != "")
					{
						model.ActualCount = int.Parse(dt.Rows[n]["ActualCount"].ToString());
					}
					if (dt.Rows[n]["AvgScore"].ToString() != "")
					{
						model.AvgScore = decimal.Parse(dt.Rows[n]["AvgScore"].ToString());
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

		public bool Update(string strWhere, string files, params SqlParameter[] parameters)
		{
			return dal.Update(strWhere, files, parameters);
		}
	}
}

