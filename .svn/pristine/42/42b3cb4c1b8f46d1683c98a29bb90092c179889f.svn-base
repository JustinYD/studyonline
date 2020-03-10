using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Web;

namespace ExamCommon
{
    public static class ConvertUtility
    {
        #region 基本值类型转换
        /// <summary>
        /// 字符串转换成byte类型（转换失败返回0）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成byte类型</returns>
        public static byte ToByte(this string input)
        {
            return input.ToByte(0);
        }
        /// <summary>
        /// 字符串转换成byte类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成byte类型</returns>
        public static byte ToByte(this string input, byte defaultValue)
        {
            byte iReturn;
            if (byte.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 字符串转换成short类型（转换失败返回0）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成short类型</returns>
        public static Int16 ToInt16(this string input)
        {
            return input.ToInt16(0);
        }
        /// <summary>
        /// 字符串转换成short类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成short类型</returns>
        public static Int16 ToInt16(this string input, Int16 defaultValue)
        {
            Int16 iReturn;
            if (Int16.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 字符串转换成int类型（转换失败返回0）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成int类型</returns>
        public static Int32 ToInt32(this string input)
        {
            return input.ToInt32(0);
        }
        /// <summary>
        /// 字符串转换成int类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成int类型</returns>
        public static Int32 ToInt32(this string input, Int32 defaultValue)
        {
            Int32 iReturn;
            if (Int32.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 字符串转换成Int64类型（转换失败返回0）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成Int64类型</returns>
        public static Int64 ToInt64(this string input)
        {
            return input.ToInt64(0);
        }
        /// <summary>
        /// 字符串转换成Int64类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Int64类型</returns>
        public static Int64 ToInt64(this string input, Int64 defaultValue)
        {
            Int64 iReturn;
            if (Int64.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 字符串转换成Decimal类型（转换失败返回0m）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Decimal类型</returns>
        public static Decimal ToDecimal(this string input)
        {
            return input.ToDecimal(0m);
        }
        /// <summary>
        /// 字符串转换成Decimal类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Decimal类型</returns>
        public static Decimal ToDecimal(this string input, Decimal defaultValue)
        {
            Decimal iReturn;
            if (Decimal.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 字符串转换成Single类型（转换失败返回0f）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成Single类型</returns>
        public static Single ToSingle(this string input)
        {
            return input.ToSingle(0f);
        }
        /// <summary>
        /// 字符串转换成Single类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Single类型</returns>
        public static Single ToSingle(this string input, Single defaultValue)
        {
            Single iReturn;
            if (Single.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成Double类型（转换失败返回0d）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成Double类型</returns>
        public static Double ToDouble(this string input)
        {
            return input.ToDouble(0d);
        }
        /// <summary>
        /// 字符串转换成Double类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Double类型</returns>
        public static Double ToDouble(this string input, Double defaultValue)
        {
            Double iReturn;
            if (Double.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成Boolean类型（转换失败返回false）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>字符串转换成Boolean类型</returns>
        public static Boolean ToBoolean(this string input)
        {
            return input.ToBoolean(false);
        }
        /// <summary>
        /// 字符串转换成Boolean类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成Boolean类型</returns>
        public static Boolean ToBoolean(this string input, Boolean defaultValue)
        {
            Boolean iReturn;
            if (Boolean.TryParse(input, out iReturn))
                return iReturn;
            return false;
        }

        /// <summary>
        /// 字符串转换成DateTime类型（转换失败返回Now）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成DateTime类型</returns>
        public static DateTime ToDateTime(this string input)
        {
            return input.ToDateTime(DateTime.Now);
        }
        /// <summary>
        /// 字符串转换成DateTime类型（转换失败返回默认值）
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="defaultValue">转换失败时默认值</param>
        /// <returns>字符串转换成DateTime类型</returns>
        public static DateTime ToDateTime(this string input, DateTime defaultValue)
        {
            DateTime iReturn;
            if (DateTime.TryParse(input, out iReturn))
                return iReturn;
            return defaultValue;
        }

        /// <summary>
        /// 把可空时间类型转换为字符
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dt)
        {
            if (dt == null)
            {
                return string.Empty;
            }
            else
            {
                return dt.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 把字符串数组转化为整形数组
        /// </summary>
        /// <param name="arrstr"></param>
        /// <returns></returns>
        public static int[] StrArrayConvertIntArray(string[] arrstr)
        {
            if (arrstr == null || arrstr.Length == 0)
            {
                return new int[0];
            }
            int[] ia = new int[arrstr.Length];
            for (int i = 0; i < arrstr.Length; i++)
            {
                ia[i] = int.Parse(arrstr[i]);
            }
            return ia;
        }
        #endregion
        /// <summary>
        /// 转化object值类型为对应值类型
        /// </summary>
        /// <returns></returns>
        public static object ConvertToType(object value, Type t)
        {
            string val = value.ToString().Trim();
            if (t != typeof(string))
            {
                if (t == typeof(byte) || t == typeof(byte?))
                {
                    return val.ToByte();
                }
                if (t == typeof(Int16) || t == typeof(Int16?))
                {
                    return val.ToInt16();
                }
                if (t == typeof(Int32) || t == typeof(Int32?))
                {
                    return val.ToInt32();
                }
                if (t == typeof(Int64) || t == typeof(Int64?))
                {
                    return val.ToInt64();
                }
                if (t == typeof(Decimal) || t == typeof(Decimal?))
                {
                    return val.ToDecimal();
                }
                if (t == typeof(Single) || t == typeof(Single?))
                {
                    return val.ToSingle();
                }
                if (t == typeof(Double) || t == typeof(Double?))
                {
                    return val.ToDouble();
                }
                if (t == typeof(Boolean) || t == typeof(Boolean?))
                {
                    return val.ToBoolean();
                }
                if (t == typeof(DateTime) || t == typeof(DateTime?))
                {
                    return val.ToDateTime();
                }
            }
            return val;
        }
        /// <summary>
        /// 获取属性key value 对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IDictionary<String, Object> GetPropertiesValueDict<T>(T t)
        {
            IDictionary<String, Object> dict = new Dictionary<String, Object>();
            if (t == null)
            {
                return dict;
            }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0)
            {
                return dict;
            }
            foreach (PropertyInfo item in properties)
            {
                dict.Add(item.Name, item.GetValue(t, null));
            }
            return dict;
        }
        /// <summary>
        /// 获取表单数据转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        public static T ToModel<T>(HttpContextBase context, params string[] notcontainerfields) where T : new()
        {
            T model = new T();
            Type type = typeof(T);
            PropertyInfo[] ps = type.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                object value = context.Request[p.Name];
                if (value != null && !p.Name.EqualsIgnoreCase(notcontainerfields))
                {
                    //type.GetProperty(p.Name).SetValue(model, Convert.ChangeType(form[p.Name], p.PropertyType), null);
                    //if (p.PropertyType == typeof(string))
                    //    p.SetValue(model, System.Web.HttpUtility.HtmlEncode(form[p.Name].ToString()), null);
                    //else
                    p.SetValue(model, ConvertToType(value, p.PropertyType), null);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取表单数据转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        public static T ToModel<T>(this System.Collections.Specialized.NameValueCollection form, params string[] notcontainerfields) where T : new()
        {
            T model = new T();
            Type type = typeof(T);
            PropertyInfo[] ps = type.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (form[p.Name] != null && !p.Name.EqualsIgnoreCase(notcontainerfields))
                {
                    //type.GetProperty(p.Name).SetValue(model, Convert.ChangeType(form[p.Name], p.PropertyType), null);
                    //if (p.PropertyType == typeof(string))
                    //    p.SetValue(model, System.Web.HttpUtility.HtmlEncode(form[p.Name].ToString()), null);
                    //else
                    p.SetValue(model, ConvertToType(form[p.Name], p.PropertyType), null);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取表单数据更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        public static T UpdateModel<T>(this System.Collections.Specialized.NameValueCollection form, T entity, params string[] notcontainerfields) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] ps = type.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (form[p.Name] != null && !p.Name.EqualsIgnoreCase(notcontainerfields))
                {
                    //type.GetProperty(p.Name).SetValue(entity, Convert.ChangeType(form[p.Name], p.PropertyType), null);
                    //if (p.PropertyType == typeof(string))
                    //    p.SetValue(entity, System.Web.HttpUtility.HtmlEncode(form[p.Name].ToString()), null);
                    //else
                    p.SetValue(entity, ConvertToType(form[p.Name], p.PropertyType), null);
                }
            }
            return entity;
        }
        /// <summary>
        /// 判断b数组中是否包含a字符串(不区分大小写)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string a, params string[] b)
        {
            if (b == null || b.Length == 0)
            {
                return false;
            }
            foreach (string s in b)
            {
                if (string.Equals(a, s, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<T> ToList<T>(this DataTable dt) where T : new()
        {
            var list = new List<T>();
            if (dt == null) return list;
            var len = dt.Rows.Count;

            for (var i = 0; i < len; i++)
            {
                var info = new T();
                foreach (DataColumn dc in dt.Rows[i].Table.Columns)
                {
                    var field = dc.ColumnName;
                    var value = dt.Rows[i][field].ToString();
                    if (string.IsNullOrEmpty(value)) continue;
                    if (IsDate(value))
                    {
                        value = DateTime.Parse(value).ToString();
                    }

                    var p = info.GetType().GetProperty(field);

                    try
                    {
                        if (p.PropertyType == typeof(string))
                        {
                            p.SetValue(info, value, null);
                        }
                        else if (p.PropertyType == typeof(int) || p.PropertyType==typeof(int?))
                        {
                            p.SetValue(info, int.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(bool))
                        {
                            p.SetValue(info, bool.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(DateTime))
                        {
                            p.SetValue(info, DateTime.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(float))
                        {
                            p.SetValue(info, float.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(double))
                        {
                            p.SetValue(info, double.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(decimal))
                        {
                            p.SetValue(info, decimal.Parse(value), null);
                        }
                        else if (p.PropertyType == typeof(Guid))
                        {
                            p.SetValue(info, Guid.Parse(value), null);
                        }
                        else
                        {
                            p.SetValue(info, value, null);
                        }
                    }
                    catch (Exception)
                    {
                        //p.SetValue(info, ex.Message, null);
                    }
                }
                list.Add(info);
            }
            dt.Dispose(); dt = null;
            return list;
        }
        /// <summary>
        /// 按照属性顺序的列名集合
        /// </summary>
        public static IList<string> GetColumnNames(this DataTable dt)
        {
            DataColumnCollection dcc = dt.Columns;
            //由于集合中的元素是确定的，所以可以指定元素的个数，系统就不会分配多余的空间，效率会高点
            IList<string> list = new List<string>(dcc.Count);
            foreach (DataColumn dc in dcc)
            {
                list.Add(dc.ColumnName);
            }
            return list;
        }
        private static bool IsDate(string d)
        {
            DateTime d1;
            double d2;
            return !double.TryParse(d, out d2) && DateTime.TryParse(d, out d1);
        }
    }
}
