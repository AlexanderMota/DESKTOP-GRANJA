﻿using DESKTOP_GRANJA.modelos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.apiREST
{
    internal class TareaService
    {
        private RestClient client = new RestClient();
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }
        public TareaService()
        {
            this.BaseUrl = Properties.Settings.Default.BaseURLApiLocal;
        }*/

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _urlTareasByIdTarea;
        private readonly string _urlSubtareas;
        private readonly string _urlSuperTareas;
        private readonly string _urlTareasByIdEmpleado;
        private readonly string _urlAgregaEmpleadoATarea;
        private readonly string _urlAgregaSubtarea;

        public TareaService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal + "tareas/";
            _urlTareasByIdTarea = _baseUrl + "byid/";
            _urlSubtareas = _baseUrl + "subtareas/";
            _urlSuperTareas = _baseUrl + "supertareas/";
            _urlTareasByIdEmpleado = _baseUrl + "empleado/";
            _urlAgregaEmpleadoATarea = _baseUrl + "addempleado/";
            _urlAgregaSubtarea = _baseUrl + "addsubtarea/";
        }
        public async Task<object?> GetTareaByIdAsync( string userToken, string id/*, string token*/ )
        {
            //var client = new RestClient();
            var request = new RestRequest($"{ _urlTareasByIdTarea + id }");
            request.AddHeader("Authorization", userToken );

            var restResponse = await client.ExecuteAsync(request);

            //Trace.WriteLine(restResponse.Content);
            try
            {
                return JsonConvert.DeserializeObject<Tarea>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
                }
                catch (Exception ex)
                {
                    return new ApiResponse(406, $"Error parsing response: {ex}");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Tarea();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Tarea();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Tarea();
            }
        }
        public async Task<object?> GetAllTareasAsync( string userToken, int pageSize = 10, int pageNum = 1 )
        {
            //var client = new RestClient();
            var request = new RestRequest($"{ _baseUrl }");
            request.AddHeader("Authorization", userToken );
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    return new ApiResponse(406, $"Error parsing response: {ex}");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
        }
        /*
        public async Task<ObservableCollection<Tarea>?> GetTareaAsync( string id )
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Trace.WriteLine(content);
            return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(content);
        }*/
        /*
        public async Task<ObservableCollection<Tarea>> GetAllTareas( int pageSize = 20, int pageNum = 1 )
        {
            var requestUrl = $"{_baseUrl}?pageSize={pageSize}&pageNum={pageNum}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(content);
        }*/
        /*
        public async Task<Tarea?> GetTareaByIdAsync( int id )
        {
            var response = await _httpClient.GetAsync($"{_urlTareasByIdTarea}{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tarea>(content);
        }*/

        public async Task<object?> GetTareaByIdEmpleadoAsync( string userToken, string idEmpleado, int pageSize = 10, int pageNum = 1 )
        {
            //var response = await _httpClient.GetAsync($"{_urlTareasByIdEmpleado}{idEmpleado}");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(content);
            //var client = new RestClient();
            var request = new RestRequest($"{ _urlTareasByIdEmpleado}{idEmpleado }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);


            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    return new ApiResponse(406, $"Error parsing response: {ex}");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
        }
        public async Task<object?> GetSuperTareasAsync( string userToken, int pageSize = 10, int pageNum = 1 )
        {
            //var client = new RestClient();
            var request = new RestRequest($"{ _urlSuperTareas}");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    return new ApiResponse(406, $"Error parsing response: {ex}");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
        }
        public async Task<object?> GetSubtareasAsync( string userToken, string idTarea, int pageSize = 20, int pageNum = 1 )
        {
            var request = new RestRequest($"{ _urlSubtareas}{idTarea}");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!); ;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    return new ApiResponse(406, "Error parsing response");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
        }
        public async Task<ApiResponse?> PostTareaAsync( string userToken, Tarea tarea, string idSuper = "0b" )
        {
            var request = new RestRequest($"{ _baseUrl }?idSuper={ idSuper }", Method.Post);
            request.AddHeader("Authorization", userToken);
            request.AddJsonBody(tarea);
            //request.AddParameter("idSuper", idSuper);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400,"ERRROR >>> Error inesperado: =================> "+ex.Message);
            }
        }
        public async Task<ApiResponse?> PostAsignaEmpleadoTarea( string userToken, string idTarea, string idEmpleado, string idSol = "" )
        {
            var request = new RestRequest($"{ _urlAgregaEmpleadoATarea }", Method.Post);
            request.AddHeader("Authorization", userToken);
            request.AddJsonBody(new
            {
                idTarea = idTarea,
                idEmpleado = idEmpleado,
                idSolicitud = idSol
            });

            var restResponse = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
        }
        public async Task<ApiResponse?> PatchTareaAsync( string userToken, Tarea tarea )
        {
            var request = new RestRequest($"{ _baseUrl}{tarea.Id}", Method.Patch);
            request.AddHeader("Authorization", userToken);
            request.AddJsonBody(tarea);

            var restResponse = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
        }

        /// <summary>
        /// /////////////////////por adaptar
        /// </summary>
        /// <returns></returns>



        public async Task<ApiResponse> PostEmpleadoATareaAsync( string idTarea, string idEmpleado, string idSolicitud )
        {
            var json = JsonConvert.SerializeObject(new { idTarea, idEmpleado, idSolicitud });
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_urlAgregaEmpleadoATarea, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
        }


        public async Task<ApiResponse> DeleteTareaAsync( string idTar, int conservaSubs )
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{idTar}_{conservaSubs}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResponse> DeleteEmpleadoTareaAsync( string idTar, string idEmp )
        {
            var response = await _httpClient.DeleteAsync($"{_urlTareasByIdEmpleado}{idTar}_{idEmp}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
