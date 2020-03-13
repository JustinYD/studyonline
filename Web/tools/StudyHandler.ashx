<%@ WebHandler Language="C#" Class="StudyHandler" %>

using System;
using System.Web;

public class StudyHandler : IHttpHandler {
    private string Action { get { return HttpContext.Current.Request.Params["action"] + ""; } }
    public void ProcessRequest (HttpContext context) {
        context.Response.ClearContent();
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.Write(StudyRequest());
        context.Response.End();
    }
    private string StudyRequest()
    {
        switch (Action)
        {
            case "addstudylist":
                return AddStudyList();
            case "getstudylist":
                return GetStudyList();
            default:
                return "{}";
        }
    }
    private string AddStudyList()
    {
        var title1 = HttpContext.Current.Request.Params["title"] + "";
        var fileurl1 = HttpContext.Current.Request.Params["fileurl"] + "";
        var time1 = HttpContext.Current.Request.Params["time"] + "";
        var jsonResult = new ExamCommon.JSONProcessor.fileResult();
        var model = new ExamModel.StudyEntity
        {
            title = title1,
            fileurl = fileurl1,
            time = time1
        };
        var bll = new ExamBLL.StudyBLL();
        bll.Add(model);
        jsonResult.title = title1;
        jsonResult.fileurl = fileurl1;
        jsonResult.time = time1;
        jsonResult.msg = "操作成功";


        jsonResult.fileurl = fileurl1;
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    private string GetStudyList()
    {
        var jsonResult = new ExamCommon.JSONProcessor.studyResult();
        try
        {
            var bll = new ExamBLL.StudyBLL();
            var ds = bll.GetStudyList();
            jsonResult.data = ExamCommon.ConvertUtility.ToList<ExamModel.StudyListModel>(ds.Tables[0]);
            jsonResult.msg = "成功";
        }
        catch(Exception e)
        {
            jsonResult.msg = e.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}