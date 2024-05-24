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
    internal class SolicitudService
    {
        private RestClient client = new RestClient();
        private readonly string _baseUrl;
        private readonly string _urlSolicitudById;
        public SolicitudService()
        {
            _baseUrl = Properties.Settings.Default.BaseURLApiLocal + "solicitud/";
            _urlSolicitudById = _baseUrl + "byid/";
        }
        public async Task<object?> GetAllSolicitudes( string userToken, int pageSize = 10, int pageNum = 1 )
        {
            var request = new RestRequest($"{ _baseUrl }");
            request.AddHeader("Authorization", userToken);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNum", pageNum);

            var restResponse = await client.ExecuteAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Solicitud>>(restResponse.Content!);
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
                return new ObservableCollection<Solicitud>();
            }
            catch (HttpRequestException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Solicitud>();
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.Message);
                return new ObservableCollection<Solicitud>();
            }
        }
    }
}
