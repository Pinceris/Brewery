using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BeerManagment.Controllers
{
    public class ApiClient
    {
        static readonly HttpClient Client = new HttpClient();

        static ApiClient()
        {
            Client.BaseAddress = new Uri("http://localhost:8001/api/");
        }

        //Post
        public static async Task PostAsync<T>(T payload, string url)
        {
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(url, content);
        }

        //Get single
        public static async Task<T> GetSingleAsync<T>(string url, string id)
        {

            string response = await Client.GetStringAsync(url + id);
            T obj = JsonConvert.DeserializeObject<T>(response);

            return obj;
        }

        //GET all
        public static async Task<List<T>> GetAllAsync<T>(string url)
        {
            string response = await Client.GetStringAsync(url);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(response);

            return list;
        }

        public static async Task PutObjectAsync<T>(T obj, string url, string id)
        {
            var content = SerializeToContent<T>(obj);
            content.Headers.ContentType = new MediaTypeHeaderValue("Application/json");

            await Client.PutAsync(url+id, content);
        }

        public static StringContent SerializeToContent<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        public static async Task DeleteByIdAsync(string url, string id)
        {
            await Client.DeleteAsync(url + id);
        }
    }
}
