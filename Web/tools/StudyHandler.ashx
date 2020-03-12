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
        var title = HttpContext.Current.Request.Params["title"] + "";
        var fileurl = HttpContext.Current.Request.Params["fileurl"] + "";
        var time = HttpContext.Current.Request.Params["time"] + "";
        jsonResult.title = title;
        jsonResult.fileurl = fileurl;
        jsonResult.time = time;
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}