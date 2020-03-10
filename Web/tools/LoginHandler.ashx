<%@ WebHandler Language="C#" Class="LoginHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

public class LoginHandler : IHttpHandler
{

    private string Action { get { return HttpContext.Current.Request.Params["action"] + ""; } }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(LoginRequest());
        context.Response.End();
    }

    private string LoginRequest()
    {
        switch (Action)
        {
            case "login":
                return Login(1);
            case "userlogin":
                return Login(2);
            case "checkaccount":
                return CheckAccount();
            case "accountbind":
                return AccountBind();
            case "unbindaccount":
                return UnbindAccount();
            default:
                return "{}";
        }
    }
    #region 用户登录
    private string Login(int type)
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "登录失败";
        try
        {
            var json = HttpContext.Current.Request.Params["json"] + "";
            if (!string.IsNullOrEmpty(json))
            {
                var jSerializer = new JavaScriptSerializer();
                var loginModel = jSerializer.Deserialize<LoginUserModel>(json);
                if (loginModel != null)
                {
                    var ds = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_Users WHERE LoginName=@LoginName AND UserPwd=@UserPwd AND UserType=@UserType",
                        new SqlParameter("@LoginName", loginModel.LoginName),
                        new SqlParameter("@UserPwd", ExamCommon.Utils2.MD5(loginModel.UserPwd)),
                        new SqlParameter("@UserType", type)
                        );
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        var userModelList = ExamCommon.ConvertUtility.ToList<ExamModel.UsersEntity>(ds.Tables[0]);
                        if (userModelList != null && userModelList.Count > 0)
                        {
                            jsonResult.status = 1;
                            jsonResult.data = userModelList[0];
                        }
                    }
                    else
                    {
                        jsonResult.status = 0;
                        jsonResult.msg = "登录失败，用户名或密码错误";
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

    private class LoginUserModel
    {
        public string LoginName { get; set; }
        public string UserPwd { get; set; }
    }

    #endregion

    #region 
    private string CheckAccount()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "账号检测失败";
        try
        {
            var uid = HttpContext.Current.Request.Params["uid"] + "";
            if (!string.IsNullOrEmpty(uid))
            {
                var ds = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_Users WHERE WeChatOpenId=@WeChatOpenId",
                        new SqlParameter("@WeChatOpenId", uid)
                        );
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var userModelList = ExamCommon.ConvertUtility.ToList<ExamModel.UsersEntity>(ds.Tables[0]);
                    if (userModelList != null && userModelList.Count > 0)
                    {
                        jsonResult.status = 1;
                        jsonResult.data = userModelList[0];
                    }
                }
                else
                {
                    jsonResult.status = -1;
                    jsonResult.msg = "未检测到关联账号";
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
    #region 账号绑定
    private string AccountBind()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "登录失败";
        try
        {
            var json = HttpContext.Current.Request.Params["json"] + "";
            if (!string.IsNullOrEmpty(json))
            {
                var jSerializer = new JavaScriptSerializer();
                var loginModel = jSerializer.Deserialize<LoginUserModel>(json);
                if (loginModel != null)
                {
                    var ds = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_Users WHERE LoginName=@LoginName AND UserPwd=@UserPwd AND UserType=@UserType",
                        new SqlParameter("@LoginName", loginModel.LoginName),
                        new SqlParameter("@UserPwd", ExamCommon.Utils2.MD5(loginModel.UserPwd)),
                        new SqlParameter("@UserType", 2)
                        );
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        var userModelList = ExamCommon.ConvertUtility.ToList<ExamModel.UsersEntity>(ds.Tables[0]);
                        if (userModelList != null && userModelList.Count > 0)
                        {
                            var uid = HttpContext.Current.Request.Params["uid"] + "";
                            if (!string.IsNullOrEmpty(uid))
                            {
                                if (ExamDAL.DbHelperSQL.ExecuteSql("UPDATE T_Users SET WeChatOpenId=@WeChatOpenId WHERE UserGuid=@UserGuid", new SqlParameter("@UserGuid", userModelList[0].UserGuid), new SqlParameter("@WeChatOpenId", uid)) > 0)
                                {
                                    jsonResult.status = 1;
                                    jsonResult.data = userModelList[0];
                                    jsonResult.msg = "账号绑定成功";
                                }
                                else
                                {
                                    jsonResult.status = 1;
                                    jsonResult.msg = "账号绑定失败";
                                }
                            }
                        }
                    }
                    else
                    {
                        jsonResult.status = 0;
                        jsonResult.msg = "登录失败，用户名或密码错误";
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

    #region 解绑微信
    private string UnbindAccount()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "账号解绑失败";
        try
        {
            var userGuid = HttpContext.Current.Request.Params["uid"] + "";
            if (!string.IsNullOrEmpty(userGuid))
            {
                var bll = new ExamBLL.UsersBLL();
                var model = bll.GetModel(Guid.Parse(userGuid));
                if (model != null)
                {
                    var tempWeChat = model.WeChatOpenId;
                    model.WeChatOpenId = "";
                    bll.Update(model);
                    jsonResult.status = 1;
                    jsonResult.msg = "账号解绑成功";
                    jsonResult.data = tempWeChat;
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