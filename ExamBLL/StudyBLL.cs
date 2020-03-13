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
	public class StudyBLL
	{
		private readonly StudyDAL dal = new StudyDAL();
		public StudyBLL()
		{ }
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudyEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(StudyEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string title)
		{

			dal.Delete(title);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudyEntity GetModel(string title)
		{

			return dal.GetModel(title);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList()
		{
			return dal.GetList();
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetStudyList()
		{
			return dal.GetStudyList();
		}
		public StudyEntity GetStudyModel(string title)
		{
			return dal.GetStudyModel(title);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudyEntity> GetModelList()
		{
			DataSet ds = dal.GetList();
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<StudyEntity> DataTableToList(DataTable dt)
		{
			List<StudyEntity> modelList = new List<StudyEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				StudyEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new StudyEntity();
					model.title = dt.Rows[n]["STKName"].ToString();
					model.fileurl = dt.Rows[n]["fileurl"].ToString();
					model.time = dt.Rows[n]["time"].ToString();
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
			return GetList();
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
		public StudyEntity GetModel(string title, params SqlParameter[] parameters)
		{
			return dal.GetModel(title, parameters);
		}
		public bool Update(string title, string fileurl, params SqlParameter[] parameters)
		{
			return dal.Update(title,fileurl, parameters);
		}
		#endregion
	}
}

