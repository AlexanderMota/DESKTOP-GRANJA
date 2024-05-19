using CommunityToolkit.Mvvm.ComponentModel;
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
        public string Id
        {
            get => this._id;
            set => SetProperty(ref this._id, value);
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
            set => SetProperty(ref this.nombre, value);
        }
        private string apellidos = "";
        public string Apellidos
        {
            get => this.apellidos;
            set => SetProperty(ref this.apellidos, value);
        }
        private string telefono = "";
        public string Telefono
        {
            get => this.telefono;
            set => SetProperty(ref this.telefono, value);
        }
        private string email = "";
        public string Email
        {
            get => this.email;
            set => SetProperty(ref this.email, value);
        }
        private string rol = "";
        public string Rol
        {
            get => this.rol;
            set => SetProperty(ref this.rol, value);
        }
        public Empleado()
        {
        }
        public Empleado(string id/*, int idEmpleado*/, string nombre, string apellidos, string telefono, string email)
        {
            Id = id;
            //IdEmpleado = idEmpleado;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
        }
    }
}
