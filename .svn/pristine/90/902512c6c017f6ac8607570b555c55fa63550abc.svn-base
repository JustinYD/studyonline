using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类AnswersDAL。
	/// </summary>
	public class AnswersDAL
	{
		public AnswersDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid AnswerGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Answers");
			strSql.Append(" where AnswerGuid=@AnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = AnswerGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AnswersEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_Answers(");
			strSql2.Append(") values (");
			if (model.AnswerGuid != null)
			{
					strSql1.Append("AnswerGuid,");
					strSql2.Append("@AnswerGuid,");
					lst.Add(new SqlParameter("@AnswerGuid", model.AnswerGuid));
			}
			if (model.AnswerName != null)
			{
					strSql1.Append("AnswerName,");
					strSql2.Append("@AnswerName,");
					lst.Add(new SqlParameter("@AnswerName", model.AnswerName));
			}
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
			if (model.IsRightAnswer != null)
			{
					strSql1.Append("IsRightAnswer,");
					strSql2.Append("@IsRightAnswer,");
					lst.Add(new SqlParameter("@IsRightAnswer", model.IsRightAnswer));
			}
			if (model.AnswerOrder != null)
			{
					strSql1.Append("AnswerOrder,");
					strSql2.Append("@AnswerOrder,");
					lst.Add(new SqlParameter("@AnswerOrder", model.AnswerOrder));
			}
			if (model.CreateTime != null)
			{
					strSql1.Append("CreateTime,");
					strSql2.Append("@CreateTime,");
					lst.Add(new SqlParameter("@CreateTime", model.CreateTime));
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
		public void Update(AnswersEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_Answers set ");
			if (model.AnswerName != null)
			{
					strSql.Append("AnswerName=@AnswerName,");
					lst.Add(new SqlParameter("@AnswerName", model.AnswerName));
			}
			if (model.QuestionGuid != null)
			{
					strSql.Append("QuestionGuid=@QuestionGuid,");
					lst.Add(new SqlParameter("@QuestionGuid", model.QuestionGuid));
			}
			if (model.STKGuid != null)
			{
					strSql.Append("STKGuid=@STKGuid,");
					lst.Add(new SqlParameter("@STKGuid", model.STKGuid));
			}
			if (model.IsRightAnswer != null)
			{
					strSql.Append("IsRightAnswer=@IsRightAnswer,");
					lst.Add(new SqlParameter("@IsRightAnswer", model.IsRightAnswer));
			}
			if (model.AnswerOrder != null)
			{
					strSql.Append("AnswerOrder=@AnswerOrder,");
					lst.Add(new SqlParameter("@AnswerOrder", model.AnswerOrder));
			}
			if (model.CreateTime != null)
			{
					strSql.Append("CreateTime=@CreateTime,");
					lst.Add(new SqlParameter("@CreateTime", model.CreateTime));
			}
			strSql.Append(" where AnswerGuid=@AnswerGuid ");
			lst.Add(new SqlParameter("@AnswerGuid", model.AnswerGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid AnswerGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Answers ");
			strSql.Append(" where AnswerGuid=@AnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = AnswerGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AnswersEntity GetModel(Guid AnswerGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AnswerGuid,AnswerName,QuestionGuid,STKGuid,IsRightAnswer,AnswerOrder,CreateTime from T_Answers ");
			strSql.Append(" where AnswerGuid=@AnswerGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@AnswerGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = AnswerGuid;

			AnswersEntity model=new AnswersEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AnswerGuid"].ToString()!="")
				{
					model.AnswerGuid=new Guid(ds.Tables[0].Rows[0]["AnswerGuid"].ToString());
				}
				model.AnswerName=ds.Tables[0].Rows[0]["AnswerName"].ToString();
				if(ds.Tables[0].Rows[0]["QuestionGuid"].ToString()!="")
				{
					model.QuestionGuid=new Guid(ds.Tables[0].Rows[0]["QuestionGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["STKGuid"].ToString()!="")
				{
					model.STKGuid=new Guid(ds.Tables[0].Rows[0]["STKGuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRightAnswer"].ToString()!="")
				{
					model.IsRightAnswer=int.Parse(ds.Tables[0].Rows[0]["IsRightAnswer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AnswerOrder"].ToString()!="")
				{
					model.AnswerOrder=int.Parse(ds.Tables[0].Rows[0]["AnswerOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
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
			strSql.Append("select AnswerGuid,AnswerName,QuestionGuid,STKGuid,IsRightAnswer,AnswerOrder,CreateTime ");
			strSql.Append(" FROM T_Answers ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList(string strWhere,params SqlParameter[] param)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AnswerGuid,AnswerName,QuestionGuid,STKGuid,IsRightAnswer,AnswerOrder,CreateTime ");
            strSql.Append(" FROM T_Answers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), param);
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
			strSql.Append(" AnswerGuid,AnswerName,QuestionGuid,STKGuid,IsRightAnswer,AnswerOrder,CreateTime ");
			strSql.Append(" FROM T_Answers ");
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
			parameters[0].Value = "T_Answers";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  成员方法

        #region 自定义方法
        public bool Delete(string strWhere,params SqlParameter[] param) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Answers ");
            strSql.Append(" where ");
            if (!string.IsNullOrEmpty(strWhere)) {
                strSql.Append(strWhere);
            }

            return DbHelperSQL.ExecuteSql(strSql.ToString(), param) > 0;
        }
        #endregion
    }
}

