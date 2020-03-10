using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;

namespace ExamCommon
{
    public static class JSONProcessor
    {

        #region 请求返回值
        public class studyResult
        {
            private string _title = "";
            private string _time = "";
            public string time
            {
                set { this._time = value; }
                get { return this._time; }
            }
            public string title
            {
                set { this._title = value; }
                get { return this._title; }
            }
        }
        public class JsonResult
        {
            private string _title = "";
            private int _status = -1;
            private string _time = "";
            private string _msg = "";
            private int _code = -1;
            private string _name = "";
            private object _data = null;
            private object _parentdata = null;
            private int _total = 0;
            private int _count = 0;
            private int _page = 1;
            private int _size = 20;
            public int status
            {
                set { this._status = value; }
                get { return this._status; }
            }
            public string time
            {
                set { this._time = value; }
                get { return this._time; }
            }
            public string title
            {
                set { this._title = value; }
                get { return this._title; }
            }
            public string msg
            {
                set { this._msg = value; }
                get { return this._msg; }
            }
            public int code
            {
                set { this._code = value; }
                get { return this._code; }
            }
            public string name
            {
                set { this._name = value; }
                get { return this._name; }
            }
            public object data
            {
                set { this._data = value; }
                get { return this._data; }
            }
            public object parentdata
            {
                set { this._parentdata = value; }
                get { return this._parentdata; }
            }
            public int total
            {
                set { this._total = value; }
                get { return this._total; }
            }

            public int count
            {
                set { this._count = value; }
                get { return this._count; }
            }
            public int page
            {
                set { this._page = value; }
                get { return this._page; }
            }
            public int size
            {
                set { this._size = value; }
                get { return this._size; }
            }
        }
        #endregion 请求返回值

        /// <summary>  
        /// 将对象转换为 JSON 字符串。  
        /// </summary>  
        /// <param name="obj">要序列化的对象。</param>  
        /// <returns>序列化的 JSON 字符串。</returns>  
        public static string JsonSerialize(object obj)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(obj);
        }
        /// <summary>  
        /// 将指定的 JSON 字符串转换为 T 类型的对象。  
        /// </summary>  
        /// <typeparam name="T">所生成对象的类型。</typeparam>  
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>  
        /// <param name="def">反序列化失败时返回的默认值。</param>  
        /// <returns>反序列化的对象。</returns>  
        public static T JsonDeserialize<T>(string input, T def)
        {
            if (string.IsNullOrEmpty(input))
                return def;
            try
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                return jsSerializer.Deserialize<T>(input);
            }
            catch (InvalidOperationException)
            {
                return def;
            }
        }

        /// <summary>     
        /// Datatable转换为Json     
        /// </summary>    
        /// <param name="table">Datatable对象</param>     
        /// <returns>Json字符串</returns>     
        public static string ToJson(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return "[]";
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();

                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = String.Format(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + strValue.Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\r\n", "") + "\",");
                    }
                    else
                    {
                        jsonString.Append("\"" + strValue.Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\r\n", "") + "\"");
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
    }
}
