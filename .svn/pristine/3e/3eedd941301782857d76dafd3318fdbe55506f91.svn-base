using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections.Specialized;
using System.Security.AccessControl;

namespace ExamCommon
{
    public static class PublicFunction
    {
        /// <summary>
        /// 自定义不可逆加密模块（MD5内核）
        /// </summary>
        /// <param name="SourcePassword">待加密字符串</param>
        /// <returns>返回密文</returns>
        public static string PasswordEncode(string SourcePassword)
        {
            string Return_PasswordEncode = "";
            try
            {
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(SourcePassword + "1", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile("3" + Return_PasswordEncode, "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "8", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "8", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile("8" + Return_PasswordEncode, "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "1", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile("2" + Return_PasswordEncode, "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "2", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile("2" + Return_PasswordEncode, "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "6", "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile("8" + Return_PasswordEncode, "MD5");
                Return_PasswordEncode = FormsAuthentication.HashPasswordForStoringInConfigFile(Return_PasswordEncode + "@", "MD5");
            }
            catch
            {
                Return_PasswordEncode = "";
            }
            return Return_PasswordEncode;
        }


        /// <summary>
        /// 获取客户端的IP，可以取到代理后的IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            string strIp = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                strIp = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);

            if (string.IsNullOrEmpty(strIp))
                strIp = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return strIp;
        }
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
        /// 新文件名
        /// </summary>
        /// <returns></returns>
        public static string GetNewFileName()
        {
            return DateTime.Now.ToString("MMddhhmmss") + Number(6);
        }
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public static string Number(int Length)
        {
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
        /// <summary>
        /// 取得文件扩展名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        static public string GetFileExt(string filename)
        {
            int pos = filename.LastIndexOf(".");
            return filename.Substring(pos + 1).ToLower();
        }
       
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="filename">文件名</param>
        static public string CeartFile(string path, string filename)
        {
            string newpath = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                    }
                    newpath = path + "/" + filename;
                    newpath = HttpContext.Current.Server.MapPath(newpath);
                }
            }
            catch { return string.Empty; }

            return newpath;

        }
       

        #region=======截取字符串=============
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static String SubString(string str, int length)
        {
            string result = "";
            try
            {
                int lg = str.ToString().Trim().Length;
                if (lg > length)
                {
                    result = str.ToString().Trim().Substring(0, length);
                }
                else
                {
                    result = str.ToString().Trim();
                }
            }
            catch (Exception)
            {
                return str;
            }
            return result;
        }
        /// <summary>
        /// 截取内容字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static String SubContentString(object str, int length)
        {
            string result = "";
            try
            {
                int lg = str.ToString().Trim().Length;
                if (lg > length)
                {
                    result = str.ToString().Trim().Substring(0, length);
                }
                else
                {
                    result = str.ToString().Trim();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <returns>截取后的字符串</returns>
        public static string CutString(string str, int length)//文字省略
        {
            int Zj = 0, Hc = 0, Qs = 0;
            bool Jz = false;
            string NewString = "", Tstr = "";
            string[] XinXi = new string[2];
            // XinXi = str.Split(new char[3] { ' ', '/r', '/n' });//去掉换行、回车、空格
            for (int Qd = 0; Qd < XinXi.Length; Qd++)//重新组合
            { Tstr += XinXi[Qd].ToString(); }
            int i = System.Text.Encoding.Default.GetBytes(Tstr).Length;//混合长度
            int j = Tstr.Length;//本身长度

            if (Tstr != "")
            {
                if (i / j == 2 || i == j || j < length) { Hc = length; }//纯中文、纯英文、本身长度小于
                else//混合字符串
                {
                    for (int Hh = 0; Hh < Tstr.Length; Hh++)
                    {
                        int Zz = System.Text.Encoding.Default.GetBytes(Tstr.Substring(Hh, 1)).Length;
                        if (length == 1)
                        {
                            Qs = System.Text.Encoding.Default.GetBytes(Tstr.Substring(Hh - 1, 1)).Length;
                            if (Qs == 1 && Zz == 1) { Jz = true; } //前后都是英文的特殊处理
                        }
                        if (Zz == 2) { length = length - 1; }
                        if (Zz == 1) { Zj++; if (Zj % 2 == 0) { length = length - 1; } }//逢二减一
                        if (length == 0) //特殊处理
                        {
                            if (Zj % 2 == 0 && Zz == 2) { Hc = Hh + 1; break; } else { Hc = Hh; break; }//逢偶补一
                        }
                    }
                }
                if (j > Hc) { NewString = Tstr.Substring(0, Hc) + "..."; } else { NewString = Tstr; }
            }
            return NewString;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="l">截取长度</param>
        /// <returns>截取后的字符串</returns>
        public static string getStr(string str, int subLength)
        {
            string temp = str;
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "", RegexOptions.IgnoreCase).Length <= subLength)
            {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i);
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "", RegexOptions.IgnoreCase).Length <= subLength - 3)
                {
                    return temp + "";
                }
            }
            return "";
        }

        /// <summary>
        /// 截取中英混合的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">要截取的长度</param>
        /// <param name="appendStr">省略字符</param>
        public static string GetString(string str,int length,string appendStr)
        {
            if (str == null) return string.Empty;

            int len = length * 2;
            //aequilateLength为中英文等宽长度,cutLength为要截取的字符串长度
            int aequilateLength = 0, cutLength = 0;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            string cutStr = str.ToString();
            int strLength = cutStr.Length;
            byte[] bytes;
            for (int i = 0; i < strLength; i++)
            {
                bytes = encoding.GetBytes(cutStr.Substring(i, 1));
                if (bytes.Length == 2)//不是英文
                    aequilateLength += 2;
                else
                    aequilateLength++;

                if (aequilateLength <= len) cutLength += 1;

                if (aequilateLength > len)
                    return cutStr.Substring(0, cutLength) + appendStr;
            }
            return cutStr;
        }


        #endregion=================




        /// <summary>
        /// 获取第一个汉字的首字母，只能输入汉字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetPYChar(string c)
        {
            string str = "";
            if (c.Length >1)
            {
                for (int k = 0; k < c.Length;k++ )
                {
                    byte[] array = new byte[2];
                    array = System.Text.Encoding.Default.GetBytes(c[k].ToString());
                    int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
                    if (i < 0xB0A1) { str += "*";continue;}
                    if (i < 0xB0C5) { str += "A"; continue; }
                    if (i < 0xB2C1) { str += "B"; continue; }
                    if (i < 0xB4EE) { str += "C"; continue; }
                    if (i < 0xB6EA) { str += "D"; continue; }
                    if (i < 0xB7A2) { str += "E"; continue; }
                    if (i < 0xB8C1) { str += "F"; continue; }
                    if (i < 0xB9FE) { str += "G"; continue; }
                    if (i < 0xBBF7) { str += "H"; continue; }
                    if (i < 0xBFA6) { str += "J"; continue; }
                    if (i < 0xC0AC) { str += "K"; continue; }
                    if (i < 0xC2E8) { str += "L"; continue; }
                    if (i < 0xC4C3) { str += "M"; continue; }
                    if (i < 0xC5B6) { str += "N"; continue; }
                    if (i < 0xC5BE) { str += "O"; continue; }
                    if (i < 0xC6DA) { str += "P"; continue; }
                    if (i < 0xC8BB) { str += "Q"; continue; }
                    if (i < 0xC8F6) { str += "R"; continue; }
                    if (i < 0xCBFA) { str += "S"; continue; }
                    if (i < 0xCDDA) { str += "T"; continue; }
                    if (i < 0xCEF4) { str += "W"; continue; }
                    if (i < 0xD1B9) { str += "X"; continue; }
                    if (i < 0xD4D1) { str += "Y"; continue; }
                    if (i < 0xD7FA) { str += "Z"; continue; }
                }
            }
            return str;
        }





        ///   <summary>   
        ///   去除HTML标记   
        ///   </summary>   
        ///   <param   name="NoHTML">包括HTML的源码   </param>   
        ///   <returns>已经去除后的文字</returns>   
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpUtility.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
        /// <summary>
        /// 剔除指定的HTML标签
        /// </summary>
        /// <param name="ctx">文本内容</param>
        /// <param name="holdTags">保留标签</param>
        /// <returns></returns>
        public static string RemoveSpecifyHtml(string ctx, string[] holdTags)
        {
            //string[] holdTags = { "a", "img", "br", "strong", "b", "span", "li" };//保留的 tag 
            string regStr = string.Format(@"<(?!((/?\s?{0})))[^>]+>", string.Join(@"\b)|(/?\s?", holdTags));
            Regex reg = new Regex(regStr, RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return reg.Replace(ctx, "");
        }
        
       
        /// <summary>
        /// 得到Timestamp的时间格式       
        /// </summary>
        /// <returns></returns>
        public static string GenerateTimeStamp(DateTime dt)
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 8, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
        /// <summary>
        /// 取得与当前时间的间隔(MM月dd日 刚刚更新)
        /// 2013-08-01
        /// </summary>
        public static string getTimeEXPINSpan(DateTime time1)
        {
            string strTime = "";
            DateTime date1 = DateTime.Now;
            DateTime date2 = time1;
            TimeSpan dt = date1 - date2;

            // 相差天数
            int days = dt.Days;
            // 时间点相差小时数
            int hours = dt.Hours;
            // 相差总小时数
            double Minutes = dt.Minutes;
            // 相差总秒数
            int second = dt.Seconds;

            if (days == 0 && hours == 0 && Minutes == 0)
            {
                strTime = "刚刚更新";
            }
            else if (days == 0 && hours == 0)
            {
                strTime = Minutes + "分钟前";
            }
            else if (days == 0)
            {
                strTime = hours + "小时前";
            }
            else
            {
                strTime = time1.ToString("MM月dd日 hh:mm");
            }
            return strTime;
        }
        /// <summary>
        /// 反序列化时间
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string DeSerializeTime(string t)
        {
            try
            {
                if (t != null)
                {
                    DateTime dt = (new DateTime(1970, 1, 1, 8, 0, 0, 0)).AddMilliseconds(Int64.Parse(t));
                    return dt.ToString();
                }
                else
                {
                    return t;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        /// <summary>
        /// 根据日期生成文件路径
        /// </summary>
        /// <param name="htmlPath"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string CreateFilePath(DateTime date)
        {
            string path = "";

            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            path = year + "/" + month + "/" + day;
            return path;
        }
        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }

        #region 读取或写入cookie
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());

            return "";
        }
        #endregion

        public class JsonResult
        {
            private int _status = 0;
            private string _msg = "";
            private object _data = null;
            private float _total = 0f;
            private int _index;//专家编号 1-5
            private string _protypename;//项目类型 1-7
            private int _entype;//项目研究开发内容是否对环境有影响 0-2
            private int _projectid;//项目ID
            private string _proptypeid;

            public string proptypeid
            {
                get { return _proptypeid; }
                set { _proptypeid = value; }
            }

            public int projectid
            {
                get { return _projectid; }
                set { _projectid = value; }
            }
            public string protypename
            {
                get { return _protypename; }
                set { _protypename = value; }
            }
            public int entype
            {
                get { return _entype; }
                set { _entype = value; }
            }
            public int index
            {
                get { return _index; }
                set { _index = value; }
            }
            public int status
            {
                set { this._status = value; }
                get { return this._status; }
            }
            public string msg
            {
                set { this._msg = value; }
                get { return this._msg; }
            }
            public object data
            {
                set { this._data = value; }
                get { return this._data; }
            }
            public float total
            {
                set { this._total = value; }
                get { return this._total; }
            }
            
        }
    }
}
