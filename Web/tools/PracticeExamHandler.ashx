<%@ WebHandler Language="C#" Class="PracticeExamHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

public class PracticeExamHandler : IHttpHandler
{
    private string Action { get { return HttpContext.Current.Request.Params["action"] + ""; } }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(ExamRequest());
        context.Response.End();
    }

    private string ExamRequest()
    {
        switch (Action)
        {
            case "stk":
                return STKOP();
            case "stklist":
                return GetSTKList();
            case "delete":
                return Delete();
            case "kcop":
                return KCOp();
            case "kclist":
                return GetKcList();
            case "kcdetail":
                return KcDetail();
            case "kcdelete":
                return KcUpdataStatus();
            case "getkcuserlist":
                return GetExamUserList();
            default:
                return "{}";
        }
    }
    #region 试题库新增/更新操作
    private string STKOP()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "操作失败";
        try
        {
            var guid = HttpContext.Current.Request.Params["id"] + "";
            var stkName = HttpContext.Current.Request.Params["stkName"] + "";
            var model = new ExamModel.STKEntity
            {
                Status = 1,
                STKGuid = Guid.NewGuid(),
                STKName = HttpUtility.UrlDecode(stkName)
            };
            var bll = new ExamBLL.PracticeSTKBLL();
            if (!string.IsNullOrEmpty(guid))
            {
                model.STKGuid = Guid.Parse(guid);
                bll.Update(model);
                jsonResult.status = 1;
                jsonResult.msg = "操作成功";
            }
            else
            {
                bll.Add(model);
                jsonResult.status = 1;
                jsonResult.msg = "操作成功";
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

    #region 分页获取试题库列表
    private string GetSTKList()
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
            var bll = new ExamBLL.PracticeSTKBLL();
            var strWhere = " [Status] =1";
            if (!string.IsNullOrEmpty(kw))
            {
                strWhere += " AND STKName like '%" + kw + "%'";
            }
            var strOrder = " CreateTime desc";
            var tableName = " T_PracticeSTK ";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " STKID,STKGuid,STKName,CONVERT(varchar(100),CreateTime,120) AS CreateTime,Status ", "STKID");
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

    #region 删除
    private string Delete()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "试题库删除失败";
        try
        {
            var stkGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(stkGuid))
            {
                var bll = new ExamBLL.PracticeSTKBLL();
                if (bll.Update(" STKGuid=@STKGuid ", " Status=0", new SqlParameter("@STKGuid", stkGuid)))
                {
                    jsonResult.status = 1;
                    jsonResult.msg = "试题库删除成功";
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

    #region 新增/编辑场次
    private string KCOp()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "操作失败";
        try
        {
            var jSerializer = new JavaScriptSerializer();
            var json = HttpContext.Current.Request.Params["json"];
            var examModel = jSerializer.Deserialize<ExamModel.ExamsEntity>(json);
            var paperGuid = HttpContext.Current.Request.Params["paperGuid"];
            var examBll = new ExamBLL.PracticeExamsBLL();
            var isAll = HttpContext.Current.Request.Params["isAll"];//是否是所有人
            if (examModel != null)
            {
                var tag = "ADD";
                var userArr = new List<string>();
                if (isAll.Equals("1"))
                {
                    var userBll = new ExamBLL.UsersBLL();
                    var userList = userBll.GetModelList("  UserType=2 AND [Status] = 1");
                    if (userList != null && userList.Count > 0)
                    {
                        foreach (var item in userList)
                        {
                            userArr.Add(item.UserGuid + "");
                        }
                    }
                }
                else
                {
                    var tempUserGuids = HttpContext.Current.Request.Params["userGuids"];
                    if (!string.IsNullOrEmpty(tempUserGuids)) userArr = tempUserGuids.TrimStart(';').Split(';').ToList();
                }

                if (!examModel.ExamGuid.Equals(Guid.Empty))
                {//编辑
                    ExamDAL.DbHelperSQL.ExecuteSql("DELETE FROM T_PracticeExamUser WHERE ExamGuid=@ExamGuid", new SqlParameter("@ExamGuid", examModel.ExamGuid));
                    ExamDAL.DbHelperSQL.ExecuteSql("DELETE FROM T_PracticeExamPager WHERE ExamGuid = @ExamGuid", new SqlParameter("@ExamGuid", examModel.ExamGuid));
                    tag = "EDITOR";
                }
                else
                {
                    examModel.ExamGuid = Guid.NewGuid();
                    tag = "ADD";
                }

                var examUserBll = new ExamBLL.PracticeExamUserBLL();
                //新增人员和考次的关系
                foreach (var userGuid in userArr)
                {
                    var examUserModel = new ExamModel.ExamUserEntity
                    {
                        EUGuid = Guid.NewGuid(),
                        ExamGuid = examModel.ExamGuid,
                        UserGuid = Guid.Parse(userGuid)
                    };
                    examUserBll.Add(examUserModel);
                }
                //新增考次和试卷的关系
                var strSql = @"INSERT INTO [T_PracticeExamPager] ([EQGuid] ,[ExamGuid] ,[PaperGuid] ,[Status] ,[CreateTime])VALUES (NEWID() ,@ExamGuid ,@PaperGuid ,1 ,GETDATE())";
                ExamDAL.DbHelperSQL.ExecuteSql(strSql, new SqlParameter("@ExamGuid", examModel.ExamGuid), new SqlParameter("@PaperGuid", paperGuid));

                examModel.ActualCount = userArr.Count;
                examModel.CreateTime = DateTime.Now;
                if (tag.Equals("EDITOR"))
                {
                    examBll.Update(examModel);
                    jsonResult.msg = "编辑成功";
                }
                else
                {
                    examBll.Add(examModel);
                    jsonResult.msg = "新增成功";
                }
                jsonResult.status = 1;
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

    #region 获取考次列表
    private string GetKcList()
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
            var t = HttpContext.Current.Request.Params["t"] + "";
            var bll = new ExamBLL.UsersBLL();
            var strWhere = " [Status] IN (2,1,0)";
            if (!string.IsNullOrEmpty(kw))
            {
                strWhere += " AND ExamName like '%" + kw + "%'";
            }
            var strOrder = " CreateTime desc";
            var tableName = " T_PracticeExams ";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " ExamId,ExamGuid,ExamName,ExamScore,CONVERT(varchar(100),CreateTime,120) AS AddTime,Status,ActualCount ", "ExamGuid");
            if (ds != null && ds.Tables.Count == 2)
            {
                var tempRecords = ds.Tables[1].Rows[0]["RecordCount"] + "";
                jsonResult.count = !string.IsNullOrEmpty(tempRecords) ? int.Parse(tempRecords) : 0;
                jsonResult.code = 0;
                jsonResult.msg = "成功";
                jsonResult.data = ExamCommon.ConvertUtility.ToList<ExamModel.ExamModel>(ds.Tables[0]);
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

    #region 获取参考次详情
    private string KcDetail()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "操作失败";
        try
        {
            var examGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(examGuid))
            {
                var strSql = "SELECT * FROM T_PracticeExams WHERE ExamGuid=@ExamGuid";
                var examModelDs = ExamDAL.DbHelperSQL.Query(strSql, new SqlParameter("@ExamGuid", examGuid));
                if (examModelDs != null && examModelDs.Tables.Count > 0 && examModelDs.Tables[0].Rows.Count > 0)
                {
                    var examModel = ExamCommon.ConvertUtility.ToList<ExamModel.ExamModel>(examModelDs.Tables[0])[0];

                    var paperDs = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_PracticePaper WHERE PaperGuid in (SELECT PaperGuid FROM T_ExamPager WHERE ExamGuid=@ExamGuid)", new SqlParameter("@ExamGuid", examGuid));
                    if (paperDs != null && paperDs.Tables.Count > 0)
                    {
                        var paperList = ExamCommon.ConvertUtility.ToList<ExamModel.PaperQuestionModel>(paperDs.Tables[0]);
                        if (paperList != null && paperList.Count > 0)
                        {
                            var paperModel = paperList[0];
                            examModel.PaperGuid = paperModel.PaperGuid;
                            examModel.PaperName = paperModel.PaperName;
                        }
                    }
                    var bll = new ExamBLL.UsersBLL();
                    examModel.UserList = bll.GetModelList(string.Format(" UserGuid IN (SELECT UserGuid FROM T_PracticeExamUser WHERE ExamGuid='{0}' )", examGuid));
                    jsonResult.status = 1;
                    jsonResult.code = 0;
                    jsonResult.data = examModel;
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

    #region 考次删除（假删）
    private string KcUpdataStatus()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "操作失败";
        try
        {
            var examGuid = HttpContext.Current.Request.Params["id"] + "";
            var status = HttpContext.Current.Request.Params["s"] + "";
            if (!string.IsNullOrEmpty(examGuid))
            {
                var bll = new ExamBLL.PracticeExamsBLL();
                if (bll.Update(" ExamGuid=@ExamGuid ", " Status=@Status", new SqlParameter("@ExamGuid", examGuid), new SqlParameter("@Status", int.Parse(status))))
                {
                    jsonResult.status = 1;
                    var msg = "操作成功";
                    if (status.Equals("-1"))
                    {
                        msg = "考次信息删除成功";
                    }
                    else if (status.Equals("1"))
                    {
                        msg = "开启成功，考生可以开始考试";
                    }
                    else if (status.Equals("2"))
                    {
                        msg = "已成功关闭本轮考试";
                    }
                    jsonResult.msg = msg;
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

    #region 获取参考人员列表
    private string GetExamUserList()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "获取考生列表失败";
        try
        {
            var examGuid = HttpContext.Current.Request.Params["id"] + "";
            var page = HttpContext.Current.Request.Params["page"] + "";
            var limit = HttpContext.Current.Request.Params["limit"] + "";
            var kw = HttpContext.Current.Request.Params["kw"] + "";
            var pageIndex = !string.IsNullOrEmpty(page) ? int.Parse(page) : 1;
            var pageSize = !string.IsNullOrEmpty(limit) ? int.Parse(limit) : 10;
            var bll = new ExamBLL.UsersBLL();
            var strWhere = " exam.ExamGuid='" + examGuid + "' AND exam.[Status]=2  ";
            var strOrder = " exam.CreateTime desc";
            var tableName = " T_PracticeExams exam LEFT JOIN T_PracticeExamUser exUser ON exUser.ExamGuid=exam.ExamGuid LEFT JOIN T_Users TUSER ON TUSER.UserGuid=exUser.UserGuid";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " exam.ExamId,exam.ExamGuid,ExamName,ExamScore,CONVERT(varchar(100),exam.CreateTime,120) AS AddTime,exam.Status,ActualCount, exUser.IsAnswered,exUser.UserScore,TUSER.UserGuid,TUSER.UserName", "exam.ExamGuid");
            if (ds != null && ds.Tables.Count == 2)
            {
                var tempRecords = ds.Tables[1].Rows[0]["RecordCount"] + "";
                jsonResult.count = !string.IsNullOrEmpty(tempRecords) ? int.Parse(tempRecords) : 0;
                jsonResult.code = 0;
                jsonResult.msg = "成功";
                jsonResult.data = ExamCommon.ConvertUtility.ToList<ExamModel.ExamModel>(ds.Tables[0]);
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