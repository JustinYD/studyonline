using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;

namespace ExamBLL
{
	/// <summary>
	/// 业务逻辑类PaperBLL 的摘要说明。
	/// </summary>
	public class PaperBLL
	{
        private readonly PaperDAL dal = new PaperDAL();
		public PaperBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid PaperGuid)
		{
			return dal.Exists(PaperGuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(PaperEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(PaperEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid PaperGuid)
		{
			
			dal.Delete(PaperGuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PaperEntity GetModel(Guid PaperGuid)
		{
			
			return dal.GetModel(PaperGuid);
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
		public List<PaperEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PaperEntity> DataTableToList(DataTable dt)
		{
			List<PaperEntity> modelList = new List<PaperEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PaperEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PaperEntity();
					if(dt.Rows[n]["PaperGuid"].ToString()!="")
					{
						model.PaperGuid=new Guid(dt.Rows[n]["PaperGuid"].ToString());
					}
					if(dt.Rows[n]["UserGuid"].ToString()!="")
					{
						model.UserGuid=new Guid(dt.Rows[n]["UserGuid"].ToString());
					}
					if(dt.Rows[n]["ExamGuid"].ToString()!="")
					{
						model.ExamGuid=new Guid(dt.Rows[n]["ExamGuid"].ToString());
					}
					if(dt.Rows[n]["QuestionGuid"].ToString()!="")
					{
						model.QuestionGuid=new Guid(dt.Rows[n]["QuestionGuid"].ToString());
					}
					if(dt.Rows[n]["IsRight"].ToString()!="")
					{
						model.IsRight=int.Parse(dt.Rows[n]["IsRight"].ToString());
					}
					if(dt.Rows[n]["QuestionOrder"].ToString()!="")
					{
						model.QuestionOrder=decimal.Parse(dt.Rows[n]["QuestionOrder"].ToString());
					}
					if(dt.Rows[n]["Score"].ToString()!="")
					{
						model.Score=decimal.Parse(dt.Rows[n]["Score"].ToString());
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

