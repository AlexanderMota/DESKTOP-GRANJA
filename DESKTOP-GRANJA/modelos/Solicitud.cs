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
        private string idTarea = ""/* = new Tarea()*/;
        public string IdTarea
        {
            get => this.idTarea;
            set => SetProperty(ref this.idTarea, value);
        }
        private string idEmpleado = ""/* = new Empleado()*/;
        public string IdEmpleadoSol
        {
            get => this.idEmpleado;
            set => SetProperty(ref this.idEmpleado, value);
        }
        private DateTime? fechaRegistro;
        public DateTime? FechaSolicitud 
        { 
            get => this.fechaRegistro; 
            set => SetProperty(ref this.fechaRegistro, value); 
        }
        public Solicitud( string idTarea, string idEmpleado, string fechaRegistro )
        {
            this.IdTarea = idTarea;
            this.idEmpleado = idEmpleado;
            try
            {

                Trace.WriteLine(fechaRegistro); 
                this.FechaSolicitud = DateTime.Parse(fechaRegistro);

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
