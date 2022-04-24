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
        private string base_url = "";
        private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }
        public DBApi()
        {
            this.BaseUrl = Properties.Settings.Default.BaseURLApiLocal;
        }
        public async void Get(string url,int id,string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl + url + id}");
            request.AddHeader("Authorization", token);

            var restResponse = await client.ExecuteAsync(request);

            Trace.WriteLine(restResponse.Content);
        }
        public async Task<ObservableCollection<Tarea>> GetAll(string url, string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl+url}");
            request.AddHeader("Authorization", token);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            ObservableCollection<Tarea> ap = JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content);
            foreach(Tarea t in ap)
            {
                Trace.WriteLine(t.Nombre);
            }
            return ap;
        }
        public async Task<ApiResponse> Post(string url, Object json, string auth = "")
        {
            var client = new RestClient();
            
            var request = new RestRequest($"{BaseUrl + url}", Method.Post);
            request.AddJsonBody(json);

            var restResponse = await client.ExecutePostAsync(request);

            ApiResponse ap = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
            //Trace.WriteLine(ap.Message);
            return ap;
        }
    }
}
