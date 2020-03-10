using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;
using ExamDAL;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类ExamsDAL。
	/// </summary>
	public class PracticeExamsDAL
	{
		public PracticeExamsDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid ExamGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_PracticeExams");
			strSql.Append(" where ExamGuid=@ExamGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ExamGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = ExamGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ExamsEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_PracticeExams(");
			strSql2.Append(") values (");
			if (model.ExamGuid != null)
			{
					strSql1.Append("ExamGuid,");
					strSql2.Append("@ExamGuid,");
					lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			}
			if (model.ExamName != null)
			{
					strSql1.Append("ExamName,");
					strSql2.Append("@ExamName,");
					lst.Add(new SqlParameter("@ExamName", model.ExamName));
			}
			if (model.ExamScore != null)
			{
					strSql1.Append("ExamScore,");
					strSql2.Append("@ExamScore,");
					lst.Add(new SqlParameter("@ExamScore", model.ExamScore));
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
			if (model.ActualCount != null)
			{
					strSql1.Append("ActualCount,");
					strSql2.Append("@ActualCount,");
					lst.Add(new SqlParameter("@ActualCount", model.ActualCount));
			}
			if (model.AvgScore != null)
			{
					strSql1.Append("AvgScore,");
					strSql2.Append("@AvgScore,");
					lst.Add(new SqlParameter("@AvgScore", model.AvgScore));
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
		public void Update(ExamsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_PracticeExams set ");
			if (model.ExamName != null)
			{
					strSql.Append("ExamName=@ExamName,");
					lst.Add(new SqlParameter("@ExamName", model.ExamName));
			}
			if (model.ExamScore != null)
			{
					strSql.Append("ExamScore=@ExamScore,");
					lst.Add(new SqlParameter("@ExamScore", model.ExamScore));
			}
			if (model.CreateTime != null)
			{
					strSql.Append("CreateTime=@CreateTime,");
					lst.Add(new SqlParameter("@CreateTime", model.CreateTime));
			}
			if (model.Status != null)
			{
					strSql.Append("Status=@Status,");
					lst.Add(new SqlParameter("@Status", model.Status));
			}
			if (model.ActualCount != null)
			{
					strSql.Append("ActualCount=@ActualCount,");
					lst.Add(new SqlParameter("@ActualCount", model.ActualCount));
			}
			if (model.AvgScore != null)
			{
					strSql.Append("AvgScore=@AvgScore,");
					lst.Add(new SqlParameter("@AvgScore", model.AvgScore));
			}
			strSql.Append(" where ExamGuid=@ExamGuid ");
			lst.Add(new SqlParameter("@ExamGuid", model.ExamGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid ExamGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_PracticeExams ");
			strSql.Append(" where ExamGuid=@ExamGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ExamGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = ExamGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ExamsEntity GetModel(Guid ExamGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ExamGuid,ExamName,ExamScore,CreateTime,Status,ActualCount,AvgScore from T_PracticeExams ");
			strSql.Append(" where ExamGuid=@ExamGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ExamGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = ExamGuid;

			ExamsEntity model=new ExamsEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ExamGuid"].ToString()!="")
				{
					model.ExamGuid=new Guid(ds.Tables[0].Rows[0]["ExamGuid"].ToString());
				}
				model.ExamName=ds.Tables[0].Rows[0]["ExamName"].ToString();
				if(ds.Tables[0].Rows[0]["ExamScore"].ToString()!="")
				{
					model.ExamScore=decimal.Parse(ds.Tables[0].Rows[0]["ExamScore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ActualCount"].ToString()!="")
				{
					model.ActualCount=int.Parse(ds.Tables[0].Rows[0]["ActualCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AvgScore"].ToString()!="")
				{
					model.AvgScore=decimal.Parse(ds.Tables[0].Rows[0]["AvgScore"].ToString());
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
			strSql.Append("select ExamGuid,ExamName,ExamScore,CreateTime,Status,ActualCount,AvgScore ");
			strSql.Append(" FROM T_PracticeExams ");
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
			strSql.Append(" ExamGuid,ExamName,ExamScore,CreateTime,Status,ActualCount,AvgScore ");
			strSql.Append(" FROM T_PracticeExams ");
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
			parameters[0].Value = "T_Exams";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  成员方法

        public bool Update(string strWhere, string files, params SqlParameter[] parameters)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update T_PracticeExams set ");
                strSql.Append(files);
                strSql.Append(" WHERE " + strWhere);
                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

