using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Solicitud : ObservableObject
    {

        private string _id = "";
        [JsonProperty("_id")]
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string idTarea = ""/* = new Tarea()*/;
        public string IdTarea
        {
            get => idTarea;
            set => SetProperty(ref idTarea, value);
        }
        private string idEmpleado = ""/* = new Empleado()*/;
        public string IdEmpleado
        {
            get => idEmpleado;
            set => SetProperty(ref idEmpleado, value);
        }
        private bool aprobada = false/* = new Empleado()*/;
        public bool Aprobada
        {
            get => aprobada;
            set => SetProperty(ref aprobada, value);
        }
        private DateTime? fechaRegistro;
        [JsonProperty("fechaRegistro")]
        public DateTime? FechaSolicitud 
        { 
            get => fechaRegistro; 
            set => SetProperty(ref fechaRegistro, value); 
        }
        public Solicitud( string idTarea, string idEmpleado, string fechaRegistro )
        {
            IdTarea = idTarea;
            IdEmpleado = idEmpleado;
            try
            {

                Trace.WriteLine(fechaRegistro); 
                FechaSolicitud = DateTime.Parse(fechaRegistro);

            }catch(FormatException ex)
            {
                Trace.WriteLine("============>"+ex.Message);
            }
        }
        /*public Solicitud()
        {
        }*/
    }
}
