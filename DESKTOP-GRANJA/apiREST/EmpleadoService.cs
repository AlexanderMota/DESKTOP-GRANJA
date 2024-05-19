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
        private string empleadosUrl = "empleados/";
        /*private string BaseUrl
        {
            get => base_url;
            set => base_url = value;
        }
        public EmpleadoService()
        {
            this.BaseUrl = Properties.Settings.Default.BaseURLApiLocal;
        }*/
        public async Task<ObservableCollection<Empleado>> GetAllEmpleados( /*string token*/ )
        {
            var client = new RestClient();
            var request = new RestRequest($"{ Properties.Settings.Default.BaseURLApiLocal + empleadosUrl }");
            request.AddHeader("Authorization", Properties.Settings.Default.Token);
            request.AddParameter("pageSize", 10);

            var restResponse = await client.ExecuteAsync(request);
            try
            {
                /*ObservableCollection<Empleado> ap =*/
                return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(restResponse.Content);
                /*foreach (Empleado t in ap)
                {
                    Trace.WriteLine(t.Nombre);
                }
                return ap;*/
            }
            catch (SocketException ex)
            {
                //Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                //Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
            catch (ArgumentNullException ex)
            {
                //Trace.WriteLine(ex.Message);
                return new ObservableCollection<Empleado>();
            }
        }
    }
}
