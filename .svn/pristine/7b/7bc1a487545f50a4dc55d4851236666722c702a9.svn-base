using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类QuestionsDAL。
	/// </summary>
	public class QuestionsDAL
	{
		public QuestionsDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid QuestionGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Questions");
			strSql.Append(" where QuestionGuid=@QuestionGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuestionGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = QuestionGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(QuestionsEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_Questions(");
			strSql2.Append(") values (");
			if (model.QuestionGuid != null)
			{
					strSql1.Append("QuestionGuid,");
					strSql2.Append("@QuestionGuid,");
					lst.Add(new SqlParameter("@QuestionGuid", model.QuestionGuid));
			}
            if (model.STKGuid != null)
            {
                strSql1.Append("STKGuid,");
                strSql2.Append("@STKGuid,");
                lst.Add(new SqlParameter("@STKGuid", model.STKGuid));
            }
            if (model.Number != null)
			{
					strSql1.Append("Number,");
					strSql2.Append("@Number,");
					lst.Add(new SqlParameter("@Number", model.Number));
			}
			if (model.QuestionName != null)
			{
					strSql1.Append("QuestionName,");
					strSql2.Append("@QuestionName,");
					lst.Add(new SqlParameter("@QuestionName", model.QuestionName));
			}
            if (model.QuestionScore != null)
            {
                strSql1.Append("QuestionScore,");
                strSql2.Append("@QuestionScore,");
                lst.Add(new SqlParameter("@QuestionScore", model.QuestionScore));
            }
            if (model.QuestionImg != null)
			{
					strSql1.Append("QuestionImg,");
					strSql2.Append("@QuestionImg,");
					lst.Add(new SqlParameter("@QuestionImg", model.QuestionImg));
			}
			if (model.QuestionOrder != null)
			{
					strSql1.Append("QuestionOrder,");
					strSql2.Append("@QuestionOrder,");
					lst.Add(new SqlParameter("@QuestionOrder", model.QuestionOrder));
			}
            if (model.QuestionType != null)
            {
                strSql1.Append("QuestionType,");
                strSql2.Append("@QuestionType,");
                lst.Add(new SqlParameter("@QuestionType", model.QuestionType));
            }
            if (model.CreateTime != null)
			{
					strSql1.Append("CreateTime,");
					strSql2.Append("@CreateTime,");
					lst.Add(new SqlParameter("@CreateTime", model.CreateTime));
			}
			if (model.Status != null)
			{
					strSql1.Append("Status,");
					strSql2.Append("@Status,");
					lst.Add(new SqlParameter("@Status", model.Status));
			}
			int n = strSql1.ToString().LastIndexOf(",");
			strSql1.Remove(n, 1);
			int m = strSql2.ToString().LastIndexOf(",");
			strSql2.Remove(m, 1);
			strSql = strSql1.ToString() + strSql2.ToString()+")";
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(QuestionsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_Questions set ");
			if (model.Number != null)
			{
					strSql.Append("Number=@Number,");
					lst.Add(new SqlParameter("@Number", model.Number));
			}
			if (model.QuestionName != null)
			{
					strSql.Append("QuestionName=@QuestionName,");
					lst.Add(new SqlParameter("@QuestionName", model.QuestionName));
			}
			if (model.QuestionImg != null)
			{
					strSql.Append("QuestionImg=@QuestionImg,");
					lst.Add(new SqlParameter("@QuestionImg", model.QuestionImg));
			}
			if (model.QuestionOrder != null)
			{
					strSql.Append("QuestionOrder=@QuestionOrder,");
					lst.Add(new SqlParameter("@QuestionOrder", model.QuestionOrder));
			}
			if (model.CreateTime != null)
			{
					strSql.Append("CreateTime=@CreateTime,");
					lst.Add(new SqlParameter("@CreateTime", model.CreateTime));
			}
            if (model.QuestionScore != null)
            {
                strSql.Append("QuestionScore=@QuestionScore,");
                lst.Add(new SqlParameter("@QuestionScore", model.QuestionScore));
            }
            if (model.Status != null)
			{
					strSql.Append("Status=@Status,");
					lst.Add(new SqlParameter("@Status", model.Status));
			}
			strSql.Append(" where QuestionGuid=@QuestionGuid ");
			lst.Add(new SqlParameter("@QuestionGuid", model.QuestionGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid QuestionGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Questions ");
			strSql.Append(" where QuestionGuid=@QuestionGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuestionGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = QuestionGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QuestionsEntity GetModel(Guid QuestionGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 QuestionGuid,STKGuid,Number,QuestionName,QuestionScore,QuestionImg,QuestionType,QuestionOrder,CreateTime,Status from T_Questions ");
			strSql.Append(" where QuestionGuid=@QuestionGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuestionGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = QuestionGuid;

			QuestionsEntity model=new QuestionsEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["QuestionGuid"].ToString()!="")
				{
					model.QuestionGuid=new Guid(ds.Tables[0].Rows[0]["QuestionGuid"].ToString());
				}
                if (ds.Tables[0].Rows[0]["STKGuid"].ToString() != "")
                {
                    model.STKGuid = new Guid(ds.Tables[0].Rows[0]["STKGuid"].ToString());
                }
                model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				model.QuestionName=ds.Tables[0].Rows[0]["QuestionName"].ToString();
                if (ds.Tables[0].Rows[0]["QuestionScore"] + "" != "") {
                    model.QuestionScore = decimal.Parse(ds.Tables[0].Rows[0]["QuestionScore"] + "");
                }
				model.QuestionImg=ds.Tables[0].Rows[0]["QuestionImg"].ToString();
                if (ds.Tables[0].Rows[0]["QuestionType"] + "" != "")
                {
                    model.QuestionType = int.Parse(ds.Tables[0].Rows[0]["QuestionType"] + "");
                }
                if (ds.Tables[0].Rows[0]["QuestionOrder"].ToString()!="")
				{
					model.QuestionOrder=int.Parse(ds.Tables[0].Rows[0]["QuestionOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append("select QuestionGuid,STKGuid,Number,QuestionScore,QuestionType,QuestionName,QuestionImg,QuestionOrder,CreateTime,Status ");
			strSql.Append(" FROM T_Questions ");
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
			strSql.Append(" QuestionGuid,STKGuid,Number,QuestionName,QuestionImg,QuestionOrder,CreateTime,Status ");
			strSql.Append(" FROM T_Questions ");
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
			parameters[0].Value = "T_Questions";
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

