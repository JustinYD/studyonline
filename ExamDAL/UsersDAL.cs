using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExamModel;

namespace ExamDAL
{
	/// <summary>
	/// 数据访问类UsersDAL。
	/// </summary>
	public class UsersDAL
	{
		public UsersDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid UserGuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Users");
			strSql.Append(" where UserGuid=@UserGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = UserGuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(UsersEntity model)
		{
			string strSql = "";
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql1.Append("insert into T_Users(");
			strSql2.Append(") values (");
			if (model.UserGuid != null)
			{
					strSql1.Append("UserGuid,");
					strSql2.Append("@UserGuid,");
					lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			}
			if (model.UserName != null)
			{
					strSql1.Append("UserName,");
					strSql2.Append("@UserName,");
					lst.Add(new SqlParameter("@UserName", model.UserName));
			}
			if (model.UserPwd != null)
			{
					strSql1.Append("UserPwd,");
					strSql2.Append("@UserPwd,");
					lst.Add(new SqlParameter("@UserPwd", model.UserPwd));
			}
			if (model.UserType != null)
			{
					strSql1.Append("UserType,");
					strSql2.Append("@UserType,");
					lst.Add(new SqlParameter("@UserType", model.UserType));
			}
			if (model.UserPhoto != null)
			{
					strSql1.Append("UserPhoto,");
					strSql2.Append("@UserPhoto,");
					lst.Add(new SqlParameter("@UserPhoto", model.UserPhoto));
			}
			if (model.UserTeacher != null)
			{
				strSql1.Append("UserTeacher,");
				strSql2.Append("@UserTeacher,");
				lst.Add(new SqlParameter("@UserTeacher", model.UserTeacher));
			}
			if (model.UserClass != null)
			{
				strSql1.Append("UserClass,");
				strSql2.Append("@UserClass,");
				lst.Add(new SqlParameter("@UserClass", model.UserClass));
			}
			if (!string.IsNullOrEmpty(model.LoginName))
			{
					strSql1.Append("LoginName,");
					strSql2.Append("@LoginName,");
					lst.Add(new SqlParameter("@LoginName", model.LoginName));
			}

            if (model.UserPhone != null)
            {
                strSql1.Append("UserPhone,");
                strSql2.Append("@UserPhone,");
                lst.Add(new SqlParameter("@UserPhone", model.UserPhone));
            }
            if (model.WeChatOpenId != null)
			{
					strSql1.Append("WeChatOpenId,");
					strSql2.Append("@WeChatOpenId,");
					lst.Add(new SqlParameter("@WeChatOpenId", model.WeChatOpenId));
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
		public void Update(UsersEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			List<SqlParameter> lst = new List<SqlParameter>();
			strSql.Append("update T_Users set ");
			if (model.UserName != null)
			{
					strSql.Append("UserName=@UserName,");
					lst.Add(new SqlParameter("@UserName", model.UserName));
			}
			if (model.UserPwd != null)
			{
					strSql.Append("UserPwd=@UserPwd,");
					lst.Add(new SqlParameter("@UserPwd", model.UserPwd));
			}
			if (model.UserType != null)
			{
					strSql.Append("UserType=@UserType,");
					lst.Add(new SqlParameter("@UserType", model.UserType));
			}
			if (model.UserTeacher != null)
			{
				strSql.Append("UserTeacher=@UserTeacher,");
				lst.Add(new SqlParameter("@UserTeacher", model.UserTeacher));
			}
			if (model.UserClass != null)
			{
				strSql.Append("UserClass=@UserClass,");
				lst.Add(new SqlParameter("@UserClass", model.UserClass));
			}
			if (model.UserPhoto != null)
			{
					strSql.Append("UserPhoto=@UserPhoto,");
					lst.Add(new SqlParameter("@UserPhoto", model.UserPhoto));
			}
			if (model.UserPhone != null)
			{
					strSql.Append("UserPhone=@UserPhone,");
					lst.Add(new SqlParameter("@UserPhone", model.UserPhone));
			}
            if (!string.IsNullOrEmpty(model.LoginName))
            {
                strSql.Append("LoginName=@LoginName,");
                lst.Add(new SqlParameter("@LoginName", model.LoginName));
            }
            if (model.WeChatOpenId != null)
			{
					strSql.Append("WeChatOpenId=@WeChatOpenId,");
					lst.Add(new SqlParameter("@WeChatOpenId", model.WeChatOpenId));
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
			strSql.Append(" where UserGuid=@UserGuid ");
			lst.Add(new SqlParameter("@UserGuid", model.UserGuid));
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			SqlParameter[] parameters = lst.ToArray();
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid UserGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Users ");
			strSql.Append(" where UserGuid=@UserGuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = UserGuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UsersEntity GetModel(Guid UserGuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 [UserGuid] ,[UserName]  ,[UserPwd] ,[UserType] ,[UserPhoto],[UserPhone] ,[UserTeacher],[UserClass]  ,[LoginName] ,[WeChatOpenId]  ,[CreateTime] ,[Status] from T_Users ");
			strSql.Append(" where UserGuid=@UserGuid ");
			SqlParameter[] parameters = { 
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = UserGuid;

			UsersEntity model=new UsersEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserGuid"].ToString()!="")
				{
					model.UserGuid=new Guid(ds.Tables[0].Rows[0]["UserGuid"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserPwd=ds.Tables[0].Rows[0]["UserPwd"].ToString();
				if(ds.Tables[0].Rows[0]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
				}
				model.UserPhoto=ds.Tables[0].Rows[0]["UserPhoto"].ToString();
				model.UserPhone=ds.Tables[0].Rows[0]["UserPhone"].ToString();
				model.UserClass = ds.Tables[0].Rows[0]["UserClass"].ToString();
				model.UserTeacher = ds.Tables[0].Rows[0]["UserTeacher"].ToString();
				model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.WeChatOpenId=ds.Tables[0].Rows[0]["WeChatOpenId"].ToString();
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
			strSql.Append("select * ");
			strSql.Append(" FROM T_Users ");
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
			strSql.Append(" UserGuid,UserName,UserPwd,UserType,UserPhoto,UserClass,UserTeacher,UserPhone,WeChatOpenId,CreateTime,Status ");
			strSql.Append(" FROM T_Users ");
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
			parameters[0].Value = "T_Users";
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
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总条数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public DataSet GetPageList(int pageIndex, int pageSize, string strWhere, string strOrder, string tableNames, string fileds,string mainFeilds)
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
		public UsersEntity GetModel(string strWhere ,params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [UserGuid] ,[UserName]  ,[UserPwd] ,[UserType] ,[UserPhoto],[UserPhone]   ,[UserTeacher],[UserClass] ,[LoginName] ,[WeChatOpenId]  ,[CreateTime] ,[Status] from T_Users ");
            strSql.Append(" where  "+ strWhere);

            UsersEntity model = new UsersEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserGuid"].ToString() != "")
                {
                    model.UserGuid = new Guid(ds.Tables[0].Rows[0]["UserGuid"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                model.UserPhoto = ds.Tables[0].Rows[0]["UserPhoto"].ToString();
                model.UserPhone = ds.Tables[0].Rows[0]["UserPhone"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
				model.UserTeacher = ds.Tables[0].Rows[0]["UserTeacher"].ToString();
				model.UserClass = ds.Tables[0].Rows[0]["UserClass"].ToString();
				model.WeChatOpenId = ds.Tables[0].Rows[0]["WeChatOpenId"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
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

        public bool Update(string strWhere, string files, params SqlParameter[] parameters) {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update T_Users set ");
                strSql.Append(files);
                strSql.Append(" WHERE " + strWhere);
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

