using DESKTOP_GRANJA.modelos;
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
    internal class EmpleadoService
    {
        private RestClient client = new RestClient();
        private readonly string _baseUrl;
        private readonly string _urlTareasByIdTarea;
        private readonly string _urlDepartamentos;
        private readonly string _urlRoles;
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }*/
        public EmpleadoService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal + "empleados/";
            _urlTareasByIdTarea = _baseUrl + "tarea/";
            _urlDepartamentos = _baseUrl + "departamentos/";
            _urlRoles = _baseUrl + "roles/";
        }
        public async Task<object?> GetRolesAsync( string userToken )
        {
            var request = new RestRequest(_urlRoles); // Assuming 'departamentos' is the endpoint

            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<string[]>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
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
                return new ApiResponse(406, "Network error");
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ApiResponse(406, "HTTP request error");
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ApiResponse(406, "Null argument error");
            }
        }
        public async Task<object?> GetDepartamentosAsync( string userToken )
        {
            var request = new RestRequest(_urlDepartamentos); // Assuming 'departamentos' is the endpoint

            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<string[]>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    return new ApiResponse( 406, "Error parsing response" );
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ApiResponse(406, "Network error" );
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ApiResponse(406, "HTTP request error" );
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ApiResponse(406, "Null argument error" );
            }
        }
        public async Task<object?> GetEmpleadoByIdAsync( string userToken, string idEmpleado )
        {
            var request = new RestRequest($"{ _baseUrl + idEmpleado}");
            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<Empleado>(restResponse.Content!);
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
                    Trace.WriteLine(ex.Message);
                    return new ApiResponse(406, "Error parsing response");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Empleado();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Empleado();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new Empleado();
            }
        }
        public async Task<object?> GetAllEmpleadosAsync( string userToken, int pageSize = 10, int pageNum = 1 )
        {
            var request = new RestRequest($"{ _baseUrl }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content!);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content!);
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
                return new ObservableCollection<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
        }
        public async Task<object?> GetEmpleadosByTareaAsync( string userToken, string idTarea )
        {
            var request = new RestRequest($"{ _urlTareasByIdTarea + idTarea }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content!);
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
                    Trace.WriteLine(ex.Message);
                    return new ApiResponse(406, "Error parsing response");
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
        }
    }
}
