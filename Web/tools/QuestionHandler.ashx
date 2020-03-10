<%@ WebHandler Language="C#" Class="QuestionHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Collections.Generic;

public class QuestionHandler : IHttpHandler
{

    private string Action { get { return HttpContext.Current.Request.Params["action"]; } }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(QuestionRequest());
        context.Response.End();
    }
    private string QuestionRequest()
    {
        switch (Action)
        {
            case "op":
                return QuestionOp();
            case "detail":
                return Detail();
            case "getlist":
                return GetList();
            case "delete":
                return Delete();
            default:
                return "{}";
        }
    }

    #region 试题新增/编辑操作
    private string QuestionOp()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "操作失败";
        try
        {
            var jSerializer = new JavaScriptSerializer();
            var json = HttpContext.Current.Request.Params["json"] + "";
            var questionModel = jSerializer.Deserialize<QuestionModel>(json);
            if (questionModel != null && questionModel.AnswerItem != null && questionModel.AnswerItem.Count > 0)
            {
                var answerBll = new ExamBLL.AnswersBLL();
                var questionBll = new ExamBLL.QuestionsBLL();
                if (questionModel.QuestionGuid.Equals(Guid.Empty))
                {
                    questionModel.QuestionGuid = Guid.NewGuid();
                    foreach (var item in questionModel.AnswerItem)
                    {
                        item.QuestionGuid = questionModel.QuestionGuid;
                        answerBll.Add(item);
                    }
                    questionModel.Status = 1;
                    questionBll.Add(questionModel);
                    jsonResult.status = 1;
                    jsonResult.msg = "保存成功";
                }
                else
                {
                    answerBll.Delete(" QuestionGuid=@QuestionGuid", new SqlParameter("@QuestionGuid", questionModel.QuestionGuid));
                    foreach (var item in questionModel.AnswerItem)
                    {
                        item.QuestionGuid = questionModel.QuestionGuid;
                        answerBll.Add(item);
                    }
                    questionModel.Status = 1;
                    questionModel.CreateTime = null; //避免被更新
                    questionBll.Update(questionModel);
                    jsonResult.status = 1;
                    jsonResult.msg = "更新成功";
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

    #region 获取试题详情
    private string Detail()
    {
        var jsonResult = new ExamCommon.JSONProcessor.JsonResult();
        jsonResult.status = -1;
        jsonResult.msg = "获取详情失败";
        try
        {
            var questionGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(questionGuid))
            {
                var questionBll = new ExamBLL.QuestionsBLL();
                var answerBll = new ExamBLL.AnswersBLL();
                var qModel = questionBll.GetModel(Guid.Parse(questionGuid));
                if (qModel != null)
                {
                    var answerList = answerBll.GetModelList(" QuestionGuid=@QuestionGuid order by AnswerOrder asc", new SqlParameter("@QuestionGuid", qModel.QuestionGuid));
                    if (answerList != null && answerList.Count > 0)
                    {
                        var model = new QuestionModel
                        {
                            CreateTime = qModel.CreateTime,
                            Number = qModel.Number,
                            QuestionGuid = qModel.QuestionGuid,
                            QuestionImg = qModel.QuestionImg,
                            QuestionName = qModel.QuestionName,
                            QuestionOrder = qModel.QuestionOrder,
                            QuestionScore = qModel.QuestionScore,
                            QuestionType = qModel.QuestionType,
                            Status = qModel.Status,
                            AnswerItem = answerList
                        };
                        jsonResult.data = model;
                        jsonResult.status = 1;
                        jsonResult.msg = "获取数据成功";
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
            var stkId = HttpContext.Current.Request.Params["stkId"] + "";
            var pageIndex = !string.IsNullOrEmpty(page) ? int.Parse(page) : 1;
            var pageSize = !string.IsNullOrEmpty(limit) ? int.Parse(limit) : 10;
            var bll = new ExamBLL.UsersBLL();
            var questionBll = new ExamBLL.QuestionsBLL();
            var strWhere = " [Status] = 1";
            if (!string.IsNullOrEmpty(stkId))
            {
                strWhere += " AND STKGuid ='" + stkId + "'";
            }
            if (!string.IsNullOrEmpty(kw))
            {
                strWhere += " AND QuestionName like '%" + kw + "%'";
            }

            var strOrder = " CreateTime desc";
            var tableName = " T_Questions ";
            var ds = bll.GetPageList(pageIndex, pageSize, strWhere, strOrder, tableName, " * ", "QuestionGuid");
            if (ds != null && ds.Tables.Count == 2)
            {
                var tempRecords = ds.Tables[1].Rows[0]["RecordCount"] + "";
                jsonResult.count = !string.IsNullOrEmpty(tempRecords) ? int.Parse(tempRecords) : 0;
                jsonResult.code = 0;
                jsonResult.msg = "成功";
                jsonResult.data =  questionBll.DataTableToList(ds.Tables[0]);
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
        jsonResult.msg = "删除失败";
        try
        {
            var questionGuid = HttpContext.Current.Request.Params["id"] + "";
            if (!string.IsNullOrEmpty(questionGuid))
            {
                var bll = new ExamBLL.QuestionsBLL();
                var model = bll.GetModel(Guid.Parse(questionGuid));
                model.Status = 0;
                bll.Update(model);
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

    private class QuestionModel : ExamModel.QuestionsEntity
    {
        public List<ExamModel.AnswersEntity> AnswerItem { get; set; }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}