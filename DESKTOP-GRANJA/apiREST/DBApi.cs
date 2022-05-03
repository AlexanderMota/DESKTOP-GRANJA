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
        public async void GetTarea(int id,string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl + "tareas/" + id}");
            request.AddHeader("Authorization", token);

            var restResponse = await client.ExecuteAsync(request);

            Trace.WriteLine(restResponse.Content);
        }
        public async Task<ObservableCollection<Tarea>> GetAllTareas( string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl+"tareas/"}");
            request.AddHeader("Authorization", token);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {

                ObservableCollection<Tarea> ap = JsonConvert.DeserializeObject<ObservableCollection<Tarea>>(restResponse.Content);
                foreach (Tarea t in ap)
                {
                    Trace.WriteLine(t.Nombre);
                }
                return ap;
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Tarea>();
            }
        }
        public async Task<ObservableCollection<Empleado>> GetAllEmpleados(string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl + "empleados/"}");
            request.AddHeader("Authorization", token);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {

                ObservableCollection<Empleado> ap = JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content);
                foreach (Empleado t in ap)
                {
                    Trace.WriteLine(t.Nombre);
                }
                return ap;
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
        }
        public async Task<ObservableCollection<Solicitud>> GetAllSolicitudes(string token)
        {
            var client = new RestClient();
            var request = new RestRequest($"{BaseUrl + "tareas/solicitudes/todas"}");
            request.AddHeader("Authorization", token);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {

                ObservableCollection<Solicitud> ap = JsonConvert.DeserializeObject<ObservableCollection<Solicitud>>(restResponse.Content);
                foreach (Solicitud t in ap)
                {
                    Trace.WriteLine(t.FechaSolicitud);
                }
                return ap;
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Solicitud>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Solicitud>();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<Solicitud>();
            }
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
