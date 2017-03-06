using System;
using System.Net.Http;

namespace Calabash.AutoEf.Core.Helper
{
    public class HttpClientHelper
    {
        private static readonly HttpClient httpClient;
        //http://192.168.1.243:8086/

        private static readonly string ApiAddress = "https://api.udcredit.com";

        /// <summary>
        /// 为了后续的访问更快 其实并没有必要
        /// </summary>
        static HttpClientHelper()
        {
            try
            {
                httpClient = new HttpClient() { BaseAddress = new Uri(ApiAddress) };
                httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                //帮HttpClient热身
                httpClient.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("HEAD"),
                    RequestUri = new Uri(ApiAddress + "/")
                }).Result.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string PostAsync(string postUrl, string postJson)
        {
            var responseJson = "";
            try
            {
                HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
                responseJson = httpClient.PostAsync(postUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
            return responseJson;
        }

        public static string GetAsync(string getUrl)
        {
            var responseJson = "";
            try
            {
                responseJson = httpClient.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
            return responseJson;
        }
    }
}
