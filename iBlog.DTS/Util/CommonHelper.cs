using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Text;

namespace iBlog.DTS.Util
{
    public static class CommonHelper
    {
        #region HttpClient

        private static HttpClient _httpClient;

        public static HttpClient httpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.Timeout = new TimeSpan(0, 4, 0);
                }
                return _httpClient;
            }
            set { _httpClient = value; }
        }

        public static HtmlDocument GetHtmlDocument
        {
            get { return new HtmlDocument(); }
        }

        #endregion HttpClient

        #region get请求

        /// <summary>
        /// get请求返回的字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetRequestStr(string url)
        {
            try
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// get请求返回的二进制
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] GetRequestByteArr(string url)
        {
            try
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;
                return response.Content.ReadAsByteArrayAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion get请求

        #region post请求

        /// <summary>
        /// post请求返回的字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string PostRequestStr(string url)
        {
            try
            {
                string contentStr = "";
                StringContent sc = new StringContent(contentStr);
                sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");//todo
                var response = httpClient.PostAsync(new Uri(url), sc).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion post请求

        #region 过滤非法字符

        public static string AliasEncode(string url)
        {
            if (url == null)
                return "";
            StringBuilder result = new StringBuilder();
            if (url != null)
            {
                url = url.Trim();
                for (int pos = 0; pos < url.Length; pos++)
                {
                    switch (url[pos])
                    {
                        case '.': result.Append("dot"); break;
                        case '#': result.Append("sharp"); break;
                        case '?': result.Append("quet"); break;
                        case '&': result.Append("and"); break;
                        default: result.Append(url[pos]); break;
                    }
                }
            }
            return result.ToString();
        }

        #endregion
    }
}