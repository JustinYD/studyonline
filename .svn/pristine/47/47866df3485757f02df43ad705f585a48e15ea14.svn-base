<%@ WebHandler Language="C#" Class="UserHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

public class UserHandler : IHttpHandler
{

    private string Action { get { return HttpContext.Current.Request.Params["action"]; } }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(UserRequest(context));
        context.Response.End();
    }

    private string UserRequest(HttpContext context)
    {
        switch (Action)
        {
            case "save":
                return UserSave();
            case "getlist":
                return GetUserList();
            case "detail":
                return GetModel();
            case "delete":
                return Delete();
            case "resetpwd":
                return ResetPwd();
            case "editorpwd":
                return EditorPwd();
            default:
                return "{}";
        }
    }

    #region 保存/编辑
    private string UserSave()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "操作失败";
        var jSerializer = new JavaScriptSerializer();
        try
        {
            var json = HttpContext.Current.Request.Params["json"] + "";
            var entityModel = jSerializer.Deserialize<ExamModel.UsersEntity>(json);
            if (entityModel != null)
            {
                ExamBLL.UsersBLL bll = new ExamBLL.UsersBLL();
                if (entityModel.UserGuid.Equals(Guid.Empty))
                {//新增
                    if (!CheckLoginName(entityModel.LoginName, entityModel.UserGuid + ""))
                    {
                        entityModel.UserGuid = Guid.NewGuid();
                        entityModel.UserPwd = ExamCommon.Utils2.MD5(entityModel.UserPwd);
                        entityModel.Status = 1;
                        entityModel.UserType = 2; //1：管理员，2：普通用户

                        bll.Add(entityModel);
                        jsonResult.status = 1;
                        jsonResult.msg = "操作成功";
                    }
                    else
                    {
                        jsonResult.msg = "该登录名已被使用。";
                    }
                }
                else
                {
                    var oldPwd = HttpContext.Current.Request["oldPwd"] + "";
                    if (!string.IsNullOrEmpty(oldPwd) && !oldPwd.Equals(entityModel.UserPwd))
                    {
                        entityModel.UserPwd = ExamCommon.Utils2.MD5(entityModel.UserPwd);
                    }
                    if (!CheckLoginName(entityModel.LoginName, entityModel.UserGuid + ""))
                    {
                        bll.Update(entityModel);
                        jsonResult.status = 1;
                        jsonResult.msg = "操作成功";
                    }
                    else
                    {
                        jsonResult.msg = "该登录名已被使用。";
                    }
                }
            }

        }
        catch (Exception ex)
        {
            jsonResult.status = 0;
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }

    #endregion

    #region 检测登录名称是否重复
    private bool CheckLoginName(string loginName, string userGuid)
    {
        try
        {
            if (!string.IsNullOrEmpty(loginName))
            {
                var bll = new ExamBLL.UsersBLL();
                var model = bll.GetModel(" [Status]in(1,0) and LoginName=@LoginName", new SqlParameter("@LoginName", loginName));
                if (model != null && !(model.UserGuid + "").Equals(userGuid))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
        }
        return false;
    }
    #endregion

    #region 加载列表
    private string GetUserList()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.code = -1;
        jsonResult.msg = "操作失败";
        try
        {
            var page = HttpContext.Current.Request.Params["page"] + "";
            var limit = HttpContext.Current.Request.Params["limit"] + "";
            var kw = HttpContext.Current.Request.Params["kw"] + "";
            var pageIndex = !string.IsNullOrEmpty(page) ? int.Parse(page) : 1;
            var pageSize = !string.IsNullOrEmpty(limit) ? int.Parse(limit) : 10;
            var bll = new ExamBLL.UsersBLL();
            var strWhere = " UserType=2 AND [Status] = 1";
            if (!string.IsNullOrEmpty(kw))
            {
                strWhere += " AND UserName like '%" + kw + "%'";
            }
            var strOrder = " CreateTime desc";
            var tableName = " T_Users ";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " * ", "UserGuid");
            if (ds != null && ds.Tables.Count == 2)
            {
                var tempRecords = ds.Tables[1].Rows[0]["RecordCount"] + "";
                jsonResult.count = !string.IsNullOrEmpty(tempRecords) ? int.Parse(tempRecords) : 0;
                jsonResult.code = 0;
                jsonResult.msg = "成功";
                jsonResult.data = bll.DataTableToList(ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            jsonResult.status = 0;
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }

    #endregion

    #region 获取实体
    private string GetModel()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.code = -1;
        jsonResult.msg = "加载信息失败";
        try
        {
            var userGuid = HttpContext.Current.Request.Params["id"] + "";
            var bll = new ExamBLL.UsersBLL();
            var model = bll.GetModel(Guid.Parse(userGuid));
            if (model != null)
            {
                jsonResult.code = 0;
                jsonResult.data = model;
            }
        }
        catch (Exception ex)
        {
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);

    }
    #endregion

    #region 用户删除
    private string Delete()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "删除失败";
        try
        {
            var userGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(userGuid))
            {
                var bll = new ExamBLL.UsersBLL();
                bll.Delete(Guid.Parse(userGuid));
                jsonResult.status = 1;
                jsonResult.msg = "删除成功";
            }
        }
        catch (Exception ex)
        {
            jsonResult.status = -1;
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    #endregion

    #region 重置密码
    private string ResetPwd()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "密码重置失败";
        try
        {
            var userGuid = HttpContext.Current.Request.Params["id"] + "";
            var pwd = "a123456";
            var newPwd = ExamCommon.Utils2.MD5(pwd);
            if (!string.IsNullOrEmpty(userGuid))
            {
                var bll = new ExamBLL.UsersBLL();
                if (bll.Update(" UserGuid=@UserGuid ", " UserPwd=@UserPwd ", new SqlParameter("@UserGuid", userGuid), new SqlParameter("@UserPwd", newPwd)))
                {
                    jsonResult.status = 1;
                    jsonResult.msg = "密码重置成功";
                }
            }
        }
        catch (Exception ex)
        {
            jsonResult.status = -1;
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    #endregion

    #region 修改密码
    private string EditorPwd()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "密码修改失败";
        try
        {
            var userGuid = HttpContext.Current.Request.Params["uid"] + "";
            var oldPwd = HttpContext.Current.Request.Params["old"] + "";
            var newPwd1 = HttpContext.Current.Request.Params["n1"] + "";
            var newPwd2 = HttpContext.Current.Request.Params["n2"] + "";
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(oldPwd) && !string.IsNullOrEmpty(newPwd1) && !string.IsNullOrEmpty(newPwd2))
            {
                var bll = new ExamBLL.UsersBLL();
                var userModel = bll.GetModel(Guid.Parse(userGuid));
                if (userModel != null)
                {
                    var pwd = ExamCommon.Utils2.MD5(oldPwd);
                    if (pwd.Equals(userModel.UserPwd))
                    {
                        if (newPwd1.Equals(newPwd2))
                        {
                            var newPwd = ExamCommon.Utils2.MD5(newPwd2);
                            if (bll.Update(" UserGuid=@UserGuid ", " UserPwd=@UserPwd ", new SqlParameter("@UserGuid", userGuid), new SqlParameter("@UserPwd", newPwd)))
                            {
                                jsonResult.status = 1;
                                jsonResult.msg = "密码修改成功";
                            }
                        }
                        else
                        {
                            jsonResult.status = 0;
                            jsonResult.msg = "输入的两次新密码不一致";
                        }
                    }
                    else
                    {
                        jsonResult.status = 0;
                        jsonResult.msg = "原始密码错误";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            jsonResult.status = -1;
            jsonResult.msg = ex.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}