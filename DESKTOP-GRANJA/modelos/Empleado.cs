using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Empleado : ObservableObject
    {
        private string _id = "";
        [JsonProperty("_id")]
        public string Id
        {
            get => this._id;
            set => SetProperty(ref _id, value);
        }
        /*private int idEmpleado = 0;
        public int IdEmpleado
        {
            get => this.idEmpleado;
            set => SetProperty(ref this.idEmpleado, value);
        }*/
        private string nombre = "";
        public string Nombre
        {
            get => this.nombre;
            set => SetProperty(ref nombre, value);
        }
        private string apellidos = "";
        public string Apellidos
        {
            get => this.apellidos;
            set => SetProperty(ref apellidos, value);
        }
        private string telefono = "";
        public string Telefono
        {
            get => this.telefono;
            set => SetProperty(ref telefono, value);
        }
        private string email = "";
        public string Email
        {
            get => this.email;
            set => SetProperty(ref email, value);
        }
        private string rol = "";
        public string Rol
        {
            get => this.rol;
            set => SetProperty(ref rol, value);
        }
        private string centroTrabajo = "";
        public string CentroTrabajo
        {
            get => this.centroTrabajo;
            set => SetProperty(ref centroTrabajo, value);
        }
        public Empleado()
        {
        }
        public Empleado(string _id/*, int idEmpleado*/, string nombre, string apellidos, string telefono, string email, string rol, string centroTrabajo )
        {
            Id = _id;
            //IdEmpleado = idEmpleado;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            Rol = rol;
            CentroTrabajo = centroTrabajo;
        }
    }
}
