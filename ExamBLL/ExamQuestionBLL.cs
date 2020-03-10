using System;
using System.Data;
using System.Collections.Generic;
using ExamModel;
using ExamDAL;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类ExamQuestionBLL 的摘要说明。
	/// </summary>
	public class ExamQuestionBLL
	{
        private readonly ExamQuestionDAL dal = new ExamQuestionDAL();
		public ExamQuestionBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid EQGuid)///bool类型
		{
			return dal.Exists(EQGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamQuestionEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ExamQuestionEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid EQGuid)
		{
			
			dal.Delete(EQGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamQuestionEntity GetModel(Guid EQGuid)
		{
			
			return dal.GetModel(EQGuid);
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
		public List<ExamQuestionEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ExamQuestionEntity> DataTableToList(DataTable dt)
		{
			List<ExamQuestionEntity> modelList = new List<ExamQuestionEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ExamQuestionEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ExamQuestionEntity();
					if(dt.Rows[n]["EQGuid"].ToString()!="")
					{
						model.EQGuid=new Guid(dt.Rows[n]["EQGuid"].ToString());
					}
					if(dt.Rows[n]["ExamGuid"].ToString()!="")
					{
						model.ExamGuid=new Guid(dt.Rows[n]["ExamGuid"].ToString());
					}
					if(dt.Rows[n]["QuestionGuid"].ToString()!="")
					{
						model.QuestionGuid=new Guid(dt.Rows[n]["QuestionGuid"].ToString());
					}
					if(dt.Rows[n]["EQOrder"].ToString()!="")
					{
						model.EQOrder=int.Parse(dt.Rows[n]["EQOrder"].ToString());
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

