using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类ExamQuestionDAL。
	/// </summary>
	public class ExamQuestionDAL
	{
		public ExamQuestionDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid EQGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_ExamQuestion");
			strSql.Append(" where EQGuid=@EQGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EQGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EQGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamQuestionEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_ExamQuestion(");
			strSql2.Append(") values (");
			if (model.EQGuid != null)
			{
					strSql1.Append("EQGuid,");
					strSql2.Append("@EQGuid,");
					lst.Add(new SqlParameter("@EQGuid", model.EQGuid));
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
			if (model.EQOrder != null)
			{
					strSql1.Append("EQOrder,");
					strSql2.Append("@EQOrder,");
					lst.Add(new SqlParameter("@EQOrder", model.EQOrder));
			}
			int n = strSql1.ToString().LastIndexOf(",");
			strSql1.Remove(n, 1);
			int m = strSql2.ToString().LastIndexOf(",");
			strSql2.Remove(m, 1);
			strSql = strSql1.ToString() + strSql2.ToString() + ")";
            SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ExamQuestionEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_ExamQuestion set ");
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
			if (model.EQOrder != null)
			{
					strSql.Append("EQOrder=@EQOrder,");
					lst.Add(new SqlParameter("@EQOrder", model.EQOrder));
			}
			strSql.Append(" where EQGuid=@EQGuid ");
			lst.Add(new SqlParameter("@EQGuid", model.EQGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid EQGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ExamQuestion ");
			strSql.Append(" where EQGuid=@EQGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EQGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EQGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamQuestionEntity GetModel(Guid EQGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EQGuid,ExamGuid,QuestionGuid,EQOrder from T_ExamQuestion ");
			strSql.Append(" where EQGuid=@EQGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@EQGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = EQGuid;

			ExamQuestionEntity model=new ExamQuestionEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["EQGuid"].ToString()!="")
				{
					model.EQGuid=new Guid(ds.Tables[0].Rows[0]["EQGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExamGuid"].ToString()!="")
				{
					model.ExamGuid=new Guid(ds.Tables[0].Rows[0]["ExamGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuestionGuid"].ToString()!="")
				{
					model.QuestionGuid=new Guid(ds.Tables[0].Rows[0]["QuestionGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EQOrder"].ToString()!="")
				{
					model.EQOrder=int.Parse(ds.Tables[0].Rows[0]["EQOrder"].ToString());
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
			strSql.Append("select EQGuid,ExamGuid,QuestionGuid,EQOrder ");
			strSql.Append(" FROM T_ExamQuestion ");
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
			strSql.Append(" EQGuid,ExamGuid,QuestionGuid,EQOrder ");
			strSql.Append(" FROM T_ExamQuestion ");
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
			parameters[0].Value = "T_ExamQuestion";
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

