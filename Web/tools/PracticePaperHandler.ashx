<%@ WebHandler Language="C#" Class="PaperHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class PaperHandler : IHttpHandler
{

    private string Action { get { return HttpContext.Current.Request.Params["action"] + ""; } }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(PaperRequest());
        context.Response.End();
    }

    private string PaperRequest()
    {
        switch (Action)
        {
            case "paperop":
                return PaperOp();
            case "getlist":
                return GetList();
            case "delete":
                return Delete();
            case "detail":
                return GetDetail();
            default:
                return "{}";
        }
    }
    #region 试卷操作（新增，编辑）
    private string PaperOp()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "操作失败";
        try
        {
            var paperGuid = HttpContext.Current.Request.Params["paperGuid"] + "";
            var paperName = HttpUtility.UrlDecode(HttpContext.Current.Request.Params["paperName"] + "");
            var paperRemark = HttpUtility.UrlDecode(HttpContext.Current.Request.Params["remark"] + "");
            var score = HttpContext.Current.Request.Params["score"] + "";
            var questionGuid = HttpContext.Current.Request.Params["qguids"] + "";
            var bll = new ExamBLL.ProcedureBLL();
            if (bll.PracticePaperOp(paperGuid, paperName, decimal.Parse(score), paperRemark, questionGuid))
            {
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

    #region 获取列表
    private string GetList()
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
            var strWhere = " [Status] = 1";

            if (!string.IsNullOrEmpty(kw))
            {
                strWhere += " AND PaperName like '%" + kw + "%'";
            }

            var strOrder = " CreateTime desc";
            var tableName = " T_PracticePaper ";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " PaperGuid,PaperName,Score,Remark,CONVERT(varchar(100),CreateTime,120) AS CreateTime,Status ", "PaperGuid");
            if (ds != null && ds.Tables.Count == 2)
            {
                var tempRecords = ds.Tables[1].Rows[0]["RecordCount"] + "";
                jsonResult.count = !string.IsNullOrEmpty(tempRecords) ? int.Parse(tempRecords) : 0;
                jsonResult.code = 0;
                jsonResult.msg = "成功";
                jsonResult.data = ExamCommon.ConvertUtility.ToList<ExamModel.PaperModel>(ds.Tables[0]);
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

    #region 删除（改变状态）
    private string Delete()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = 0;
        jsonResult.msg = "操作失败";
        try
        {
            var paperGuid = HttpContext.Current.Request.Params["paperGuid"] + "";
            var bll = new ExamBLL.ProcedureBLL();
            if (ExamDAL.DbHelperSQL.ExecuteSql("UPDATE T_PracticePaper SET Status=0 WHERE PaperGuid=@PaperGuid", new SqlParameter("@PaperGuid", paperGuid)) > 0)
            {
                jsonResult.status = 1;
                jsonResult.msg = "试卷删除成功";
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
            var paperGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(paperGuid))
            {
                var paperDs = ExamDAL.DbHelperSQL.Query("SELECT * FROM T_PracticePaper WHERE PaperGuid=@PaperGuid", new SqlParameter("@PaperGuid", paperGuid));
                if (paperDs != null && paperDs.Tables.Count > 0)
                {
                    var paperList = ExamCommon.ConvertUtility.ToList<ExamModel.PaperQuestionModel>(paperDs.Tables[0]);
                    if (paperList != null && paperList.Count > 0)
                    {
                        var paperModel = paperList[0];
                        var qDs = ExamDAL.DbHelperSQL.Query("SELECT Number,STKGuid,QuestionName,QuestionScore,QuestionImg,QuestionType,QuestionGuid FROM T_PracticeQuestions WHERE QuestionGuid IN (SELECT QuestionGuid FROM T_PracticePaperQuestion WHERE PaperGuid=@PaperGuid) ", new SqlParameter("@PaperGuid", paperGuid));
                        if (qDs != null && qDs.Tables.Count > 0)
                        {
                            paperModel.QuestionList = ExamCommon.ConvertUtility.ToList<ExamModel.QuestionModel>(qDs.Tables[0]);
                            if (paperModel.QuestionList != null && paperModel.QuestionList.Count > 0)
                            {
                                var answerBll = new ExamBLL.AnswersBLL();
                                for (int i = 0; i < paperModel.QuestionList.Count; i++)
                                {
                                    var qModel = paperModel.QuestionList[i];
                                    var answerList = answerBll.GetModelList(" QuestionGuid=@QuestionGuid order by AnswerOrder asc", new SqlParameter("@QuestionGuid", qModel.QuestionGuid));
                                    paperModel.QuestionList[i].AnswerItem = answerList;
                                }
                                jsonResult.code = 0;
                                jsonResult.status = 1;
                                jsonResult.data = paperModel;
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



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }



}