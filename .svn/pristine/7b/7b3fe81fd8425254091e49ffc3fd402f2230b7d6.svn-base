using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类UserAnswerDAL。
	/// </summary>
	public class UserAnswerDAL
	{
		public UserAnswerDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid PaperAnswerGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_UserAnswer");
			strSql.Append(" where PaperAnswerGuid=@PaperAnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperAnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperAnswerGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(UserAnswerEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_UserAnswer(");
			strSql2.Append(") values (");
			if (model.PaperAnswerGuid != null)
			{
					strSql1.Append("PaperAnswerGuid,");
					strSql2.Append("@PaperAnswerGuid,");
					lst.Add(new SqlParameter("@PaperAnswerGuid", model.PaperAnswerGuid));
			}
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
			if (model.SelectAnswerGuid != null)
			{
					strSql1.Append("SelectAnswerGuid,");
					strSql2.Append("@SelectAnswerGuid,");
					lst.Add(new SqlParameter("@SelectAnswerGuid", model.SelectAnswerGuid));
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
		public void Update(UserAnswerEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_UserAnswer set ");
			if (model.PaperGuid != null)
			{
					strSql.Append("PaperGuid=@PaperGuid,");
					lst.Add(new SqlParameter("@PaperGuid", model.PaperGuid));
			}
			if (model.UserGuid != null)
			{
					strSql.Append("UserGuid=@UserGuid,");
					lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			if (model.SelectAnswerGuid != null)
			{
					strSql.Append("SelectAnswerGuid=@SelectAnswerGuid,");
					lst.Add(new SqlParameter("@SelectAnswerGuid", model.SelectAnswerGuid));
			}
			strSql.Append(" where PaperAnswerGuid=@PaperAnswerGuid ");
			lst.Add(new SqlParameter("@PaperAnswerGuid", model.PaperAnswerGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid PaperAnswerGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_UserAnswer ");
			strSql.Append(" where PaperAnswerGuid=@PaperAnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperAnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperAnswerGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserAnswerEntity GetModel(Guid PaperAnswerGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PaperAnswerGuid,PaperGuid,UserGuid,SelectAnswerGuid from T_UserAnswer ");
			strSql.Append(" where PaperAnswerGuid=@PaperAnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PaperAnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = PaperAnswerGuid;

			UserAnswerEntity model=new UserAnswerEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PaperAnswerGuid"].ToString()!="")
				{
					model.PaperAnswerGuid=new Guid(ds.Tables[0].Rows[0]["PaperAnswerGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PaperGuid"].ToString()!="")
				{
					model.PaperGuid=new Guid(ds.Tables[0].Rows[0]["PaperGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserGuid"].ToString()!="")
				{
					model.UserGuid=new Guid(ds.Tables[0].Rows[0]["UserGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SelectAnswerGuid"].ToString()!="")
				{
					model.SelectAnswerGuid=new Guid(ds.Tables[0].Rows[0]["SelectAnswerGuid"].ToString());
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
			strSql.Append("select PaperAnswerGuid,PaperGuid,UserGuid,SelectAnswerGuid ");
			strSql.Append(" FROM T_UserAnswer ");
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
			strSql.Append(" PaperAnswerGuid,PaperGuid,UserGuid,SelectAnswerGuid ");
			strSql.Append(" FROM T_UserAnswer ");
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
			parameters[0].Value = "T_UserAnswer";
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

