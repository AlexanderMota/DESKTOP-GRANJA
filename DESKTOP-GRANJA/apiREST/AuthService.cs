using DESKTOP_GRANJA.modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.apiREST
{
    internal class AuthService
    {
        private readonly string _userToken;
        private readonly string _baseUrl;
        private readonly string _urlLogin;
        private readonly string _urlMyUser;
        //private RestClient client = new RestClient();
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }*/
        public AuthService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal + "auth/";
            _urlLogin = _baseUrl + "signin/";
            _urlMyUser = _baseUrl + "myuser/";
            //this.BaseUrl = Properties.Settings.Default.BaseURLApiLocal;
        }
        public async Task<ApiResponse> LogIn( Usuario user )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _urlLogin }", Method.Post);
            request.AddJsonBody(user);

            var restResponse = await client.ExecutePostAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
            //Trace.WriteLine(ap.Message);
        }
            
        public async Task<Empleado?> GetMyUser( string userToken, string email/*, string token*/ )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _urlMyUser + email }");
            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<Empleado>(restResponse.Content);
        }
    }
}
