using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类ExamUserDAL。
	/// </summary>
	public class PracticeExamUserDAL
	{
		public PracticeExamUserDAL()
		{ }
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid EUGuid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from T_PracticeExamUser");
			strSql.Append(" where EUGuid=@EUGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EUGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EUGuid;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamUserEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_PracticeExamUser(");
			strSql2.Append(") values (");
			if (model.EUGuid != null)
			{
				strSql1.Append("EUGuid,");
				strSql2.Append("@EUGuid,");
				lst.Add(new SqlParameter("@EUGuid", model.EUGuid));
			}
			if (model.ExamGuid != null)
			{
				strSql1.Append("ExamGuid,");
				strSql2.Append("@ExamGuid,");
				lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			}
			if (model.UserGuid != null)
			{
				strSql1.Append("UserGuid,");
				strSql2.Append("@UserGuid,");
				lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			int n = strSql1.ToString().LastIndexOf(",");
			strSql1.Remove(n, 1);
			int m = strSql2.ToString().LastIndexOf(",");
			strSql2.Remove(m, 1);
			strSql = strSql1.ToString() + strSql2.ToString() + ")";
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ExamUserEntity model)
		{
			StringBuilder strSql = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_PracticeExamUser set ");
			if (model.ExamGuid != null)
			{
				strSql.Append("ExamGuid=@ExamGuid,");
				lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			}
			if (model.UserGuid != null)
			{
				strSql.Append("UserGuid=@UserGuid,");
				lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			strSql.Append(" where EUGuid=@EUGuid ");
			lst.Add(new SqlParameter("@EUGuid", model.EUGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid EUGuid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from T_PracticeExamUser ");
			strSql.Append(" where EUGuid=@EUGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EUGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EUGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamUserEntity GetModel(Guid EUGuid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 EUGuid,ExamGuid,UserGuid from T_PracticeExamUser ");
			strSql.Append(" where EUGuid=@EUGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EUGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EUGuid;

			ExamUserEntity model = new ExamUserEntity();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["EUGuid"].ToString() != "")
				{
					model.EUGuid = new Guid(ds.Tables[0].Rows[0]["EUGuid"].ToString());
				}
				if (ds.Tables[0].Rows[0]["ExamGuid"].ToString() != "")
				{
					model.ExamGuid = new Guid(ds.Tables[0].Rows[0]["ExamGuid"].ToString());
				}
				if (ds.Tables[0].Rows[0]["UserGuid"].ToString() != "")
				{
					model.UserGuid = new Guid(ds.Tables[0].Rows[0]["UserGuid"].ToString());
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
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select EUGuid,ExamGuid,UserGuid ");
			strSql.Append(" FROM T_PracticeExamUser ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" EUGuid,ExamGuid,UserGuid ");
			strSql.Append(" FROM T_PracticeExamUser ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
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
			parameters[0].Value = "T_ExamUser";
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

