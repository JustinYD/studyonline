<%@ WebHandler Language="C#" Class="StudyHandler" %>

using System;
using System.Web;
using System.IO;
using System.Data.SqlClient;

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
            case "delstudylist":
                return DelStudyList();
            case "updatestudylist":
                return Updatestudylist();
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
    private string DelStudyList()
    {
        var jsonResult = new ExamCommon.JSONProcessor.studyResult();
        var fileurl = HttpContext.Current.Request.Params["fileurl"] + "";
        try
        {
            var bll = new ExamBLL.StudyBLL();
            if (ExamDAL.DbHelperSQL.ExecuteSql("DELETE T_Study  WHERE fileurl=@fileurl", new SqlParameter("@fileurl", fileurl)) > 0)
            {
                string URL = HttpContext.Current.Server.MapPath(fileurl);
                File.Delete(URL);
                jsonResult.msg = "删除成功";
            }
        }
        catch(Exception e)
        {
            jsonResult.msg = e.Message;
        }
        return ExamCommon.JSONProcessor.JsonSerialize(jsonResult);
    }
    private string Updatestudylist()
    {
        var jsonResult = new ExamCommon.JSONProcessor.studyResult();
        var fileurl = HttpContext.Current.Request.Params["fileurl"] + "";
        var oldfileurl = HttpContext.Current.Request.Params["oldfileurl"] + "";
        var time = HttpContext.Current.Request.Params["time"] + "";
        var title = HttpContext.Current.Request.Params["title"] + "";
        try
        {
            var bll = new ExamBLL.StudyBLL();
            if (ExamDAL.DbHelperSQL.ExecuteSql("UPDATE T_Study SET title=@title,fileurl=@fileurl,time=@time  WHERE fileurl=@oldfileurl", new SqlParameter("@title", title),new SqlParameter("@fileurl", fileurl),new SqlParameter("@time", time),new SqlParameter("@oldfileurl", oldfileurl)) > 0)
            {
                string URL = HttpContext.Current.Server.MapPath(oldfileurl);
                File.Delete(URL);
                jsonResult.msg = "更新成功";
            }
        }
        catch(Exception e)
        {
            jsonResult.msg = e.Message;
        }
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