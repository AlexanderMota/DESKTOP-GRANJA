using CommunityToolkit.Mvvm.ComponentModel;
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
        private Tarea tarea/* = new Tarea()*/;
        public Tarea TareaSol
        {
            get => this.tarea;
            set => SetProperty(ref this.tarea, value);
        }
        private Empleado empleado/* = new Empleado()*/;
        public Empleado EmpleadoSol
        {
            get => this.empleado;
            set => SetProperty(ref this.empleado, value);
        }
        private DateTime fecha;
        public DateTime FechaSolicitud 
        { 
            get => this.fecha; 
            set => SetProperty(ref this.fecha, value); 
        }
        public Solicitud(Tarea tarea, Empleado empleado, string fechaSolicitud)
        {
            this.TareaSol = tarea;
            this.EmpleadoSol = empleado;
            try
            {

                Trace.WriteLine(fechaSolicitud);
                this.FechaSolicitud = DateTime.Parse(fechaSolicitud);

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
