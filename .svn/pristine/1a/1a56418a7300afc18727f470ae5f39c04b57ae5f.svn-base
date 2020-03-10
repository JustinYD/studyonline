<%@ WebHandler Language="C#" Class="UserPaperHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class UserPaperHandler : IHttpHandler
{

    private string Action { get { return HttpContext.Current.Request.Params["action"] + ""; } }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(UserPapeRequest());
        context.Response.End();
    }

    private string UserPapeRequest()
    {
        switch (Action)
        {
            case "kclist":
                return GetKcList();
            case "getpaper":
                return GetDetail();
            case "submitpaper":
                return SubmitPaper();
            default:
                return "{}";
        }
    }

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
            var userGuid = HttpContext.Current.Request.Params["uid"] + "";
            var pageIndex = !string.IsNullOrEmpty(page) ? int.Parse(page) : 1;
            var pageSize = !string.IsNullOrEmpty(limit) ? int.Parse(limit) : 10;
            var t = HttpContext.Current.Request.Params["t"] + "";
            var bll = new ExamBLL.UsersBLL();
            var strWhere = " [Status]=" + t;
            strWhere += "AND exam.ExamGuid IN (SELECT ExamGuid FROM T_ExamUser WHERE UserGuid='" + userGuid + "')";
            var strOrder = " CreateTime desc";
            var tableName = " T_Exams exam LEFT JOIN T_ExamUser exUser ON exUser.ExamGuid=exam.ExamGuid AND exUser.UserGuid='" + userGuid + "'";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " exam.ExamId,exam.ExamGuid,ExamName,ExamScore,CONVERT(varchar(100),CreateTime,120) AS AddTime,Status,ActualCount, exUser.IsAnswered,exUser.UserScore", "exam.ExamGuid");
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

    #region 获取详情
    private string GetDetail()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "获取试卷详情失败";
        try
        {
            var examGuid = HttpContext.Current.Request.Params["id"] + "";
            var userGuid = HttpContext.Current.Request.Params["uid"] + "";
            if (!string.IsNullOrEmpty(examGuid))
            {
                var paperGuid = ExamDAL.DbHelperSQL.GetSingle("SELECT PaperGuid FROM T_ExamPager WHERE ExamGuid=@ExamGuid", new SqlParameter("@ExamGuid", examGuid)) + "";
                if (!string.IsNullOrEmpty(paperGuid))
                {
                    var paperDs = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_Paper WHERE PaperGuid=@PaperGuid", new SqlParameter("@PaperGuid", paperGuid));
                    if (paperDs != null && paperDs.Tables.Count > 0)
                    {
                        var paperList = ExamCommon.ConvertUtility.ToList<ExamModel.PaperQuestionModel>(paperDs.Tables[0]);
                        if (paperList != null && paperList.Count > 0)
                        {
                            var paperModel = paperList[0];
                            var qDs = ExamDAL.DbHelperSQL.Query("SELECT Number,STKGuid,QuestionName,QuestionScore,QuestionImg,QuestionType,QuestionGuid FROM T_Questions WHERE QuestionGuid IN (SELECT QuestionGuid FROM T_PaperQuestion WHERE PaperGuid=@PaperGuid) ", new SqlParameter("@PaperGuid", paperGuid));
                            if (qDs != null && qDs.Tables.Count > 0)
                            {
                                paperModel.QuestionList = ExamCommon.ConvertUtility.ToList<ExamModel.QuestionModel>(qDs.Tables[0]);
                                if (paperModel.QuestionList != null && paperModel.QuestionList.Count > 0)
                                {
                                    var answerBll = new ExamBLL.AnswersBLL();
                                    var isAnswered = ExamDAL.DbHelperSQL.GetSingle("SELECT IsAnswered FROM T_ExamUser WHERE ExamGuid=@ExamGuid AND UserGuid=@UserGuid", new SqlParameter("@ExamGuid", examGuid), new SqlParameter("@UserGuid", userGuid)) + "";
                                    paperModel.IsAnswered = int.Parse(isAnswered);
                                    if (paperModel.IsAnswered == 1) {
                                        paperModel.UserScore =double.Parse(ExamDAL.DbHelperSQL.GetSingle("SELECT UserScore FROM T_ExamUser WHERE ExamGuid=@ExamGuid AND UserGuid=@UserGuid", new SqlParameter("@ExamGuid", examGuid), new SqlParameter("@UserGuid", userGuid)) + "");
                                    }
                                    for (int i = 0; i < paperModel.QuestionList.Count; i++)
                                    {
                                        var qModel = paperModel.QuestionList[i];
                                        var answerList = answerBll.GetModelList(" QuestionGuid=@QuestionGuid order by AnswerOrder asc", new SqlParameter("@QuestionGuid", qModel.QuestionGuid));
                                        paperModel.QuestionList[i].AnswerItem = answerList;
                                        paperModel.QuestionList[i].RightAnswerGuid = new List<string>();
                                        paperModel.QuestionList[i].SelectAnswerGuid = new List<string>();
                                        paperModel.QuestionList[i].IsRight = 0;
                                        if (isAnswered.Equals("1"))
                                        {//已作答
                                            var selectStr = @"SELECT RightAnswerGuid,SelectAnswerGuid,IsRight FROM T_UserAnswer WHERE ExamGuid=@ExamGuid AND PaperGuid=@PaperGuid AND UserGuid=@UserGuid AND QuestionGuid=@QuestionGuid";
                                            var ds = ExamDAL.DbHelperSQL.Query(selectStr,
                                                new SqlParameter("@ExamGuid", examGuid),
                                               new SqlParameter("@PaperGuid", paperModel.PaperGuid),
                                               new SqlParameter("@UserGuid", userGuid),
                                               new SqlParameter("@QuestionGuid", qModel.QuestionGuid));
                                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                            {
                                                var dr = ds.Tables[0].Rows[0];
                                                paperModel.QuestionList[i].RightAnswerGuid = new List<string>((dr["RightAnswerGuid"] + "").Split(';'));
                                                paperModel.QuestionList[i].SelectAnswerGuid = new List<string>((dr["SelectAnswerGuid"] + "").Split(';'));
                                                paperModel.QuestionList[i].IsRight = int.Parse(dr["IsRight"] + "");
                                            }
                                        }
                                    }
                                    jsonResult.total = paperModel.QuestionList.Count;
                                    jsonResult.code = 0;
                                    jsonResult.status = 1;
                                    jsonResult.data = paperModel;
                                }
                            }
                        }
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

    #region 保存用户答题信息
    private string SubmitPaper()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "试卷提交失败";
        try
        {
            var json = HttpContext.Current.Request.Params["json"] + "";
            if (!string.IsNullOrEmpty(json))
            {
                var jSerializer = new JavaScriptSerializer();
                var paperModel = jSerializer.Deserialize<ExamModel.UserPaperInfoModel>(json);
                if (paperModel != null)
                {
                    var paperGuid = ExamDAL.DbHelperSQL.GetSingle("SELECT PaperGuid FROM T_ExamPager WHERE ExamGuid=@ExamGuid", new SqlParameter("@ExamGuid", paperModel.ExamGuid)) + "";
                    paperModel.UserGuid = HttpContext.Current.Request.Params["uid"] + "";
                    paperModel.PaperGuid = paperGuid;
                    var qDs = ExamDAL.DbHelperSQL.Query("SELECT Number,STKGuid,QuestionName,QuestionScore,QuestionImg,QuestionType,QuestionGuid FROM T_Questions WHERE QuestionGuid IN (SELECT QuestionGuid FROM T_PaperQuestion WHERE PaperGuid=@PaperGuid) ", new SqlParameter("@PaperGuid", paperGuid));
                    if (qDs != null && qDs.Tables.Count > 0)
                    {
                        var questionList = ExamCommon.ConvertUtility.ToList<ExamModel.QuestionModel>(qDs.Tables[0]);
                        ExamDAL.DbHelperSQL.ExecuteSql("DELETE FROM T_UserAnswer WHERE ExamGuid=@ExamGuid AND PaperGuid=@PaperGuid AND UserGuid=@UserGuid", new SqlParameter("@ExamGuid", paperModel.ExamGuid), new SqlParameter("@PaperGuid", paperGuid), new SqlParameter("@UserGuid", paperModel.UserGuid));
                        if (questionList != null && questionList.Count > 0)
                        {
                            var insertStr = @"INSERT INTO [T_UserAnswer]
                                                       ([PaperAnswerGuid]
                                                       ,[ExamGuid]
                                                       ,[PaperGuid]
                                                       ,[UserGuid]
                                                       ,[QuestionGuid]
                                                       ,[RightAnswerGuid]
                                                       ,[SelectAnswerGuid]
                                                       ,[IsRight]
                                                       ,[Score]
                                                       ,[CreateTime])
                                                 VALUES
                                                       (NEWID()
                                                       ,@ExamGuid
                                                       ,@PaperGuid
                                                       ,@UserGuid
                                                       ,@QuestionGuid
                                                       ,''
                                                       ,''
                                                       ,0
                                                       ,@Score
                                                       ,GETDATE())";
                            foreach (var item in questionList)
                            {
                                ExamDAL.DbHelperSQL.ExecuteSql(insertStr,
                                    new SqlParameter("@ExamGuid", paperModel.ExamGuid),
                                    new SqlParameter("@PaperGuid", paperModel.PaperGuid),
                                    new SqlParameter("@UserGuid", paperModel.UserGuid),
                                    new SqlParameter("@QuestionGuid", item.QuestionGuid),
                                    new SqlParameter("@Score", item.QuestionScore));
                            }

                        }
                    }
                    var updateStr = @"UPDATE T_UserAnswer SET RightAnswerGuid=@RightAnswerGuid,SelectAnswerGuid=@SelectAnswerGuid,IsRight=@IsRight WHERE ExamGuid=@ExamGuid AND PaperGuid=@PaperGuid AND UserGuid=@UserGuid AND QuestionGuid=@QuestionGuid";

                    foreach (var item in paperModel.Questions)
                    {
                        ExamDAL.DbHelperSQL.ExecuteSql(updateStr,
                            new SqlParameter("@RightAnswerGuid", string.Join(";", item.RightAnswerGuid)),
                            new SqlParameter("@SelectAnswerGuid", string.Join(";", item.SelectAnswerGuid)),
                            new SqlParameter("@IsRight", item.IsRight),
                           new SqlParameter("@ExamGuid", paperModel.ExamGuid),
                           new SqlParameter("@PaperGuid", paperGuid),
                           new SqlParameter("@UserGuid", paperModel.UserGuid),
                           new SqlParameter("@QuestionGuid", item.QuestionGuid)
                            );
                    }
                    var sumStr = "SELECT SUM(Score) FROM T_UserAnswer WHERE IsRight=1 AND ExamGuid=@ExamGuid AND PaperGuid=@PaperGuid AND UserGuid=@UserGuid";
                    var totalScore = ExamDAL.DbHelperSQL.GetSingle(sumStr, new SqlParameter("@ExamGuid", paperModel.ExamGuid), new SqlParameter("@PaperGuid", paperGuid), new SqlParameter("@UserGuid", paperModel.UserGuid));
                    ExamDAL.DbHelperSQL.ExecuteSql("UPDATE T_ExamUser SET IsAnswered=1,UserScore=@UserScore WHERE ExamGuid=@ExamGuid AND UserGuid=@UserGuid", new SqlParameter("@ExamGuid", paperModel.ExamGuid), new SqlParameter("@UserGuid", paperModel.UserGuid), new SqlParameter("@UserScore", (totalScore == null ? 0d : double.Parse(totalScore + ""))));
                    jsonResult.status = 1;
                    jsonResult.msg = "试卷提交成功，得分：" + (totalScore == null ? "0" : totalScore + "") + "分";

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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}