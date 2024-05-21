using DESKTOP_GRANJA.modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.apiREST
{
    internal class ComentarioService
    {
        private readonly string _baseUrl;
        private readonly string _urlComentarios;
        private readonly string _urlAddComentario;
        public ComentarioService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal + "tareas/";
            _urlComentarios = _baseUrl + "comentarios/";
            _urlAddComentario = _baseUrl + "addcomentario/";
        }
        public async Task<ObservableCollection<Comentario>?> GetComentariosByIdTareaAsync( string userToken, string id/*, string token*/ )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _urlComentarios + id }");
            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Comentario>>(restResponse.Content);
        }
        public async Task<ApiResponse?> postComentarioByIdTarea( string userToken, string id, Comentario comment )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _urlAddComentario + id }", Method.Post);
            request.AddHeader("Authorization", userToken);
            request.AddJsonBody(comment);

            var restResponse = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
        }
    }
}
