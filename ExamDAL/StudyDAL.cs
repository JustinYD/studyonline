using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
    public class StudyDAL
    {
        public StudyDAL() { }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(StudyEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_Study(");
			strSql2.Append(") values (");
			if (model.title!= null)
			{
				strSql1.Append("title,");
				strSql2.Append("@title,");
				lst.Add(new SqlParameter("@title", model.title));
			}
			if (model.time != null)
			{
				strSql1.Append("time,");
				strSql2.Append("@time,");
				lst.Add(new SqlParameter("@time", model.time));
			}
			if (model.fileurl != null)
			{
				strSql1.Append("fileurl,");
				strSql2.Append("@fileurl,");
				lst.Add(new SqlParameter("@fileurl", model.fileurl));
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
		public void Update(StudyEntity model)
		{
			StringBuilder strSql = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_Study set ");
			if (model.title != null)
			{
				strSql.Append("title=@title,");
				lst.Add(new SqlParameter("@title", model.title));
			}
			if (model.time != null)
			{
				strSql.Append("time=@time,");
				lst.Add(new SqlParameter("@time", model.time));
			}
			if (model.fileurl != null)
			{
				strSql.Append("fileurl=@fileurl,");
				lst.Add(new SqlParameter("@fileurl", model.fileurl));
			}
			strSql.Append(" where title=@title ");
			lst.Add(new SqlParameter("@title", model.title));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string title)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from T_Study ");
			strSql.Append(" where title=@title ");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = title;

			DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STKEntity GetModel(Guid STKGuid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 STKGuid,STKName,CreateTime,Status from T_STK ");
			strSql.Append(" where STKGuid=@STKGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@STKGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = STKGuid;

			STKEntity model = new STKEntity();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["STKGuid"].ToString() != "")
				{
					model.STKGuid = new Guid(ds.Tables[0].Rows[0]["STKGuid"].ToString());
				}
				model.STKName = ds.Tables[0].Rows[0]["STKName"].ToString();
				if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
				{
					model.CreateTime = ds.Tables[0].Rows[0]["CreateTime"].ToString();
				}
				if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
		public DataSet GetList(string title)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select title,fileurl,time ");
			strSql.Append(" FROM T_Study");
			if (title.Trim() != "")
			{
				strSql.Append(" where " + title);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(string title,string fileurl,string time)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" title,fileurl,time");
			strSql.Append(" FROM T_Study");
			if (title.Trim() != "")
			{
				strSql.Append(" where " + title);
			}
			strSql.Append(" order by " + fileurl);
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
			parameters[0].Value = "T_STK";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


		#region 自定义方法
		/// <summary>
		/// 分页方法
		/// </summary>
		/// <param name="pageIndex">当前页</param>
		/// <param name="pageSize">总条数</param>
		/// <param name="strWhere">查询条件</param>
		/// <param name="parameters">参数列表</param>
		/// <returns></returns>
		public DataSet GetPageList(int pageIndex, int pageSize, string strWhere, string strOrder, string tableNames, string fileds, string mainFeilds)
		{
			string strTbName = " " + tableNames + "  ";
			string strFeilds = " " + fileds + " ";
			SqlParameter[] parameters = new SqlParameter[] {
			new SqlParameter("@strTbName ",SqlDbType.NVarChar,400),
			new SqlParameter("@strFeilds",SqlDbType.NVarChar,400),
			new SqlParameter("@strOrder",SqlDbType.NVarChar,200),
			new SqlParameter("@strWhere",SqlDbType.NVarChar,400),
			new SqlParameter("@PageSize",SqlDbType.Int,4),
			new SqlParameter("@PageIndex",SqlDbType.Int,4),
			new SqlParameter("@masterFeilds",SqlDbType.NVarChar,50),
			new SqlParameter("@OrderType",SqlDbType.Int,4),
			new SqlParameter("@RecordCount",SqlDbType.Int,4),
			new SqlParameter("@totalPage",SqlDbType.Int,4)

			};
			parameters[0].Value = strTbName;
			parameters[1].Value = strFeilds;
			parameters[2].Value = strOrder;
			parameters[3].Value = strWhere;
			parameters[4].Value = pageSize;
			parameters[5].Value = pageIndex;
			parameters[6].Value = mainFeilds;
			parameters[7].Value = 0;
			parameters[8].Value = 0;
			parameters[9].Value = 0;
			return DbHelperSQL.RunProcedure("p_GeneralTablePage", parameters, "PersonnelExtendPager");
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public StudyEntity GetModel(string title, params SqlParameter[] parameters)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 [title] ,[fileurl] ,[time] from T_STK ");
			strSql.Append(" where  " + title);

			StudyEntity model = new StudyEntity();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				model.title = ds.Tables[0].Rows[0]["title"].ToString();
				if (ds.Tables[0].Rows[0]["title"].ToString() != "")
				{
					model.title = ds.Tables[0].Rows[0]["title"].ToString();
				}
				if (ds.Tables[0].Rows[0]["fileurl"].ToString() != "")
				{
					model.fileurl = ds.Tables[0].Rows[0]["fileurl"].ToString();
				}
				if (ds.Tables[0].Rows[0]["time"].ToString() != "")
				{
					model.time = ds.Tables[0].Rows[0]["time"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		public bool Update(string title, string fileurl, params SqlParameter[] parameters)
		{
			try
			{
				StringBuilder strSql = new StringBuilder();
				strSql.Append("update T_Study set ");
				strSql.Append(fileurl);
				strSql.Append(" WHERE " + title);
				return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		#endregion
	}
}
