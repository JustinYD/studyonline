using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类PaperDAL。
	/// </summary>
	public class PaperDAL
	{
		public PaperDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid PaperGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Paper");
			strSql.Append(" where PaperGuid=@PaperGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(PaperEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_Paper(");
			strSql2.Append(") values (");
			if (model.PaperGuid != null)
			{
					strSql1.Append("PaperGuid,");
					strSql2.Append("@PaperGuid,");
					lst.Add(new SqlParameter("@PaperGuid", model.PaperGuid));
			}
			if (model.UserGuid != null)
			{
					strSql1.Append("UserGuid,");
					strSql2.Append("@UserGuid,");
					lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			if (model.ExamGuid != null)
			{
					strSql1.Append("ExamGuid,");
					strSql2.Append("@ExamGuid,");
					lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			}
			if (model.QuestionGuid != null)
			{
					strSql1.Append("QuestionGuid,");
					strSql2.Append("@QuestionGuid,");
					lst.Add(new SqlParameter("@QuestionGuid", model.QuestionGuid));
			}
			if (model.IsRight != null)
			{
					strSql1.Append("IsRight,");
					strSql2.Append("@IsRight,");
					lst.Add(new SqlParameter("@IsRight", model.IsRight));
			}
			if (model.QuestionOrder != null)
			{
					strSql1.Append("QuestionOrder,");
					strSql2.Append("@QuestionOrder,");
					lst.Add(new SqlParameter("@QuestionOrder", model.QuestionOrder));
			}
			if (model.Score != null)
			{
					strSql1.Append("Score,");
					strSql2.Append("@Score,");
					lst.Add(new SqlParameter("@Score", model.Score));
			}
			int n = strSql1.ToString().LastIndexOf(",");
			strSql1.Remove(n, 1);
			int m = strSql2.ToString().LastIndexOf(",");
			strSql2.Remove(m, 1);
			strSql = strSql1.ToString() + strSql2.ToString();
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(PaperEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_Paper set ");
			if (model.UserGuid != null)
			{
					strSql.Append("UserGuid=@UserGuid,");
					lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			if (model.ExamGuid != null)
			{
					strSql.Append("ExamGuid=@ExamGuid,");
					lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			}
			if (model.QuestionGuid != null)
			{
					strSql.Append("QuestionGuid=@QuestionGuid,");
					lst.Add(new SqlParameter("@QuestionGuid", model.QuestionGuid));
			}
			if (model.IsRight != null)
			{
					strSql.Append("IsRight=@IsRight,");
					lst.Add(new SqlParameter("@IsRight", model.IsRight));
			}
			if (model.QuestionOrder != null)
			{
					strSql.Append("QuestionOrder=@QuestionOrder,");
					lst.Add(new SqlParameter("@QuestionOrder", model.QuestionOrder));
			}
			if (model.Score != null)
			{
					strSql.Append("Score=@Score,");
					lst.Add(new SqlParameter("@Score", model.Score));
			}
			strSql.Append(" where PaperGuid=@PaperGuid ");
			lst.Add(new SqlParameter("@PaperGuid", model.PaperGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid PaperGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Paper ");
			strSql.Append(" where PaperGuid=@PaperGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PaperEntity GetModel(Guid PaperGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PaperGuid,UserGuid,ExamGuid,QuestionGuid,IsRight,QuestionOrder,Score from T_Paper ");
			strSql.Append(" where PaperGuid=@PaperGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperGuid;

			PaperEntity model=new PaperEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PaperGuid"].ToString()!="")
				{
					model.PaperGuid=new Guid(ds.Tables[0].Rows[0]["PaperGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserGuid"].ToString()!="")
				{
					model.UserGuid=new Guid(ds.Tables[0].Rows[0]["UserGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExamGuid"].ToString()!="")
				{
					model.ExamGuid=new Guid(ds.Tables[0].Rows[0]["ExamGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuestionGuid"].ToString()!="")
				{
					model.QuestionGuid=new Guid(ds.Tables[0].Rows[0]["QuestionGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRight"].ToString()!="")
				{
					model.IsRight=int.Parse(ds.Tables[0].Rows[0]["IsRight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuestionOrder"].ToString()!="")
				{
					model.QuestionOrder=decimal.Parse(ds.Tables[0].Rows[0]["QuestionOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Score"].ToString()!="")
				{
					model.Score=decimal.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PaperGuid,UserGuid,ExamGuid,QuestionGuid,IsRight,QuestionOrder,Score ");
			strSql.Append(" FROM T_Paper ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PaperGuid,UserGuid,ExamGuid,QuestionGuid,IsRight,QuestionOrder,Score ");
			strSql.Append(" FROM T_Paper ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Paper";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

