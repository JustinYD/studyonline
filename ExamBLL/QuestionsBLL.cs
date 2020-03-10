using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类QuestionsBLL 的摘要说明。
	/// </summary>
	public class QuestionsBLL
	{
        private readonly QuestionsDAL dal = new QuestionsDAL();
		public QuestionsBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid QuestionGuid)
		{
			return dal.Exists(QuestionGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(QuestionsEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(QuestionsEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid QuestionGuid)
		{
			
			dal.Delete(QuestionGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QuestionsEntity GetModel(Guid QuestionGuid)
		{
			
			return dal.GetModel(QuestionGuid);
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
		public List<QuestionsEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<QuestionsEntity> DataTableToList(DataTable dt)
		{
			List<QuestionsEntity> modelList = new List<QuestionsEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				QuestionsEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new QuestionsEntity();
					if(dt.Rows[n]["QuestionGuid"].ToString()!="")
					{
						model.QuestionGuid=new Guid(dt.Rows[n]["QuestionGuid"].ToString());
					}
                    if (dt.Rows[n]["STKGuid"].ToString() != "")
                    {
                        model.STKGuid = new Guid(dt.Rows[n]["STKGuid"].ToString());
                    }
                    model.Number=dt.Rows[n]["Number"].ToString();
					model.QuestionName=dt.Rows[n]["QuestionName"].ToString();
					model.QuestionImg=dt.Rows[n]["QuestionImg"].ToString();
					if(dt.Rows[n]["QuestionOrder"].ToString()!="")
					{
						model.QuestionOrder=int.Parse(dt.Rows[n]["QuestionOrder"].ToString());
					}
                    if (dt.Rows[n]["QuestionScore"] + "" != "")
                    {
                        model.QuestionScore = decimal.Parse(dt.Rows[n]["QuestionScore"] + "");
                    }
                    if (dt.Rows[n]["QuestionType"] + "" != "")
                    {
                        model.QuestionType = int.Parse(dt.Rows[n]["QuestionType"] + "");
                    }
                    if (dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
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
	}
}

