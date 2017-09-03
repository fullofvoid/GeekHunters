using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GSRForms
{
    public class HttpClientHelper
    {

        public string WebApiUrl { get; private set; }

        public HttpClientHelper()
        {
            this.WebApiUrl = ConfigurationManager.AppSettings["APIURL"];
        }


        public T Get<T>(string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var task = client.GetStringAsync(WebApiUrl+path);
                task.Wait();
                string jsonStringResult = task.Result;
                return JsonConvert.DeserializeObject<T>(jsonStringResult);
            }
        }

        public void Post<T>(string path, T content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = JsonConvert.SerializeObject(content);
                var task = client.PostAsync(
                    WebApiUrl + path,new StringContent(stringContent, Encoding.UTF8, "application/json"));
                task.Wait();
            }
        }
        public void Put<T>(string path, T content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var task = client.PutAsync(
                    WebApiUrl + path,
                    new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));
                task.Wait();
            }
        }
        public void Delete(string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var task = client.DeleteAsync(WebApiUrl + path);
                task.Wait();
            }
        }
    }
}
