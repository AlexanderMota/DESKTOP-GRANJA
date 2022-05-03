using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Solicitud : ObservableObject
    {
        private string _id = "";
        public string Id
        {
            get => this._id;
            set => SetProperty(ref this._id, value);
        }
        private int idSolicitud = 0;
        public int IdSolicitud
        {
            get => this.idSolicitud;
            set => SetProperty(ref this.idSolicitud, value);
        }
        private string idEmpleado = "";
        public string IdEmpleado
        {
            get => this.idEmpleado;
            set => SetProperty(ref this.idEmpleado, value);
        }
        private string idTarea = "";
        public string IdTarea
        {
            get => this.idTarea;
            set => SetProperty(ref this.idTarea, value);
        }
        private string fechaSolicitud = "";
        public string FechaSolicitud
        {
            get => this.fechaSolicitud;
            set => SetProperty(ref this.fechaSolicitud, value);
        }
        private bool aprovada = false;
        public bool Aprovada
        {
            get => this.aprovada;
            set => SetProperty(ref this.aprovada, value);
        }

        public Solicitud(string _id, int idSolicitud, string idEmpleado, string idTarea, string fechaSolicitud, bool aprovada)
        {
            Id = _id;
            IdSolicitud = idSolicitud;
            IdEmpleado = idEmpleado;
            IdTarea = idTarea;
            FechaSolicitud = fechaSolicitud;
            Aprovada = aprovada;
        }
    }
}
