using Microsoft.AspNetCore.Http;
using System;

namespace ContentMgmtCore.Controllers
{

    public class CommonHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="SetValue"></param>
        public static int SetValueFromFormInt(HttpRequest request, string key)
        {
            int SetValue = int.MinValue;

            if (request.Form.ContainsKey(key))
            {
                string _KeyValue = request.Form[key];
                int keyValue = int.MinValue;
                if (!String.IsNullOrEmpty(_KeyValue))
                {
                    if (!Int32.TryParse(_KeyValue, out keyValue))
                    {
                        keyValue = int.MinValue;
                    }
                } 
                
                SetValue = keyValue;
            }
            return SetValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="SetValue"></param>
        public static double SetValueFromFormDouble(HttpRequest request, string key)
        {
            double SetValue = 0;
            if (request.Form.ContainsKey(key))
            {
                string _KeyValue = request.Form[key];
                double keyValue = double.MinValue;
                double.TryParse(_KeyValue, out keyValue);
                SetValue = keyValue;
            }
            return SetValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="SetValue"></param>
        public static string SetValueFromFormString(HttpRequest request, string key)
        {
            string SetValue = String.Empty;
            if (request.Form.ContainsKey(key))
            {
                string _KeyValue = request.Form[key];
                SetValue = _KeyValue;
            }
            return SetValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="SetValue"></param>
        public static DateTime SetValueFromFormDatetime(HttpRequest request, string key)
        {
            DateTime SetValue = DateTime.MinValue;
            if (request.Form.ContainsKey(key))
            {
                string _ValueKey = request.Form[key];
                DateTime valueKey = DateTime.MinValue;
                DateTime.TryParse(_ValueKey, out valueKey);
                SetValue = valueKey;
            }
            return SetValue;
        }
    }
}
