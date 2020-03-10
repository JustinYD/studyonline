using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类ExamUserBLL 的摘要说明。
	/// </summary>
	public class PracticeExamUserBLL
	{
		private readonly PracticeExamUserDAL dal = new PracticeExamUserDAL();
		public PracticeExamUserBLL()
		{ }
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid EUGuid)
		{
			return dal.Exists(EUGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamUserEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ExamUserEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid EUGuid)
		{

			dal.Delete(EUGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamUserEntity GetModel(Guid EUGuid)
		{

			return dal.GetModel(EUGuid);
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
		public List<ExamUserEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ExamUserEntity> DataTableToList(DataTable dt)
		{
			List<ExamUserEntity> modelList = new List<ExamUserEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ExamUserEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ExamUserEntity();
					if (dt.Rows[n]["EUGuid"].ToString() != "")
					{
						model.EUGuid = new Guid(dt.Rows[n]["EUGuid"].ToString());
					}
					if (dt.Rows[n]["ExamGuid"].ToString() != "")
					{
						model.ExamGuid = new Guid(dt.Rows[n]["ExamGuid"].ToString());
					}
					if (dt.Rows[n]["UserGuid"].ToString() != "")
					{
						model.UserGuid = new Guid(dt.Rows[n]["UserGuid"].ToString());
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
	}
}

