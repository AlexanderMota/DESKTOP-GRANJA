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
        private readonly string _baseUrl;
        private readonly string _urlTareasByIdTarea;
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }*/
        public EmpleadoService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal+ "empleados/";
            _urlTareasByIdTarea = _baseUrl + "tarea/";
        }
        public async Task<Empleado?> GetEmpleadoByIdAsync( string userToken, string idEmpleado )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _baseUrl + idEmpleado}");
            request.AddHeader("Authorization", userToken);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<Empleado>(restResponse.Content!);
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
        public async Task<ObservableCollection<Empleado>?> GetAllEmpleadosAsync( string userToken/*string token*/ )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _baseUrl }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content!);
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
        public async Task<ObservableCollection<Empleado>?> GetEmpleadosByTareaAsync( string userToken, string idTarea )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ _urlTareasByIdTarea + idTarea }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content!);
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
