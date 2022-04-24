using DESKTOP_GRANJA.modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.apiREST
{
    class DBApi
    {
        public static async Task<ApiResponse> Post(string url, Object json, string auth = "")
        {
            var client = new RestClient();
            
            var request = new RestRequest($"http://localhost:4300/api/{url}", Method.Post);
            request.AddJsonBody(json);

            var restResponse = await client.ExecutePostAsync(request);

            ApiResponse ap = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
            Trace.WriteLine(ap.Message);
            return ap;
        }
        public static async void Get()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:4300/api/home");

            var restResponse =
                await client.ExecuteAsync(request);

            Trace.WriteLine(restResponse.Content);
        }
    }
}
