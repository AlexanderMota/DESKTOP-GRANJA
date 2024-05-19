using DESKTOP_GRANJA.modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.apiREST
{
    internal class AuthService
    {
        private string loginUrl = "auth/signin";
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }*/
        public AuthService()
        {
            //this.BaseUrl = Properties.Settings.Default.BaseURLApiLocal;
        }
        public async Task<ApiResponse> LogIn( Object json )
        {
            var client = new RestClient();

            var request = new RestRequest($"{Properties.Settings.Default.BaseURLApiLocal + loginUrl}", Method.Post);
            request.AddJsonBody(json);

            var restResponse = await client.ExecutePostAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
            //Trace.WriteLine(ap.Message);
        }
    }
}
