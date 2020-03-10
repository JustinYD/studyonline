using System;
using System.Data;
using System.Collections.Generic;
using ExamDAL;
using ExamModel;
using System.Data.SqlClient;

namespace ExamBLL
{
    /// <summary>
    /// 业务逻辑类UsersBLL 的摘要说明。
    /// </summary>
    public class UsersBLL
    {
        private readonly UsersDAL dal = new UsersDAL();
        public UsersBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid UserGuid)
        {
            return dal.Exists(UserGuid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(UsersEntity model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(UsersEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(Guid UserGuid)
        {

            dal.Delete(UserGuid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersEntity GetModel(Guid UserGuid)
        {

            return dal.GetModel(UserGuid);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersEntity> DataTableToList(DataTable dt)
        {
            List<UsersEntity> modelList = new List<UsersEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UsersEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new UsersEntity();
                    if (dt.Rows[n]["UserGuid"].ToString() != "")
                    {
                        model.UserGuid = new Guid(dt.Rows[n]["UserGuid"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.UserPwd = dt.Rows[n]["UserPwd"].ToString();
                    if (dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = int.Parse(dt.Rows[n]["UserType"].ToString());
                    }
                    model.UserPhoto = dt.Rows[n]["UserPhoto"].ToString();
                    model.UserPhone = dt.Rows[n]["UserPhone"].ToString();
                    model.LoginName = dt.Rows[n]["LoginName"].ToString();
                    model.UserClass = dt.Rows[n]["UserClass"].ToString();
                    model.UserTeacher = dt.Rows[n]["UserTeacher"].ToString();
                    model.WeChatOpenId = dt.Rows[n]["WeChatOpenId"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
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

        #region 自定义方法
        public DataSet GetPageList(int pageIndex, int pageSize, string strWhere, string strOrder, string tableNames, string fileds, string mainFeilds)
        {
            return dal.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableNames, fileds, mainFeilds);
        }

        public UsersEntity GetModel(string strWhere, params SqlParameter[] parameters)
        {
            return dal.GetModel(strWhere, parameters);
        }

        public bool Update(string strWhere, string files, params SqlParameter[] parameters)
        {
            return dal.Update(strWhere, files, parameters);
        }

            #endregion
        }
}

