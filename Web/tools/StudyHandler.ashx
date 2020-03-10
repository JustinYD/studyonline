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
            case "getstudylist":
                return GetStudyList();
            default:
                return "{}";
        }
    }
    private string GetStudyList()
    {
        var jsonResult = new ExamCommon.JSONProcessor.studyResult();
        var title = HttpContext.Current.Request.Params["title"] + "";
        var content = HttpContext.Current.Request.Files[0];
        var time = HttpContext.Current.Request.Params["time"] + "";
        jsonResult.title = title;
        jsonResult.time = time;
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}