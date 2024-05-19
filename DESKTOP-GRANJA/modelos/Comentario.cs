using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Comentario : ObservableObject
    {
        private string _id = "";
        public string Id
        {
            get => this._id;
            set => SetProperty(ref this._id, value);
        }
        private string idTarea = "";
        public string IdTarea
        {
            get => this.idTarea;
            set => SetProperty(ref this.idTarea, value);
        }
        private string idAutor = "";
        public string IdAutor
        {
            get => this.idAutor;
            set => SetProperty(ref this.idAutor, value);
        }
        private string nombre = "";
        public string Nombre
        {
            get => this.nombre;
            set => SetProperty(ref this.nombre, value);
        }
        private string descripcion = "";
        public string Descripcion
        {
            get => this.descripcion;
            set => SetProperty(ref this.descripcion, value);
        }
        private DateTime fechaRegistro = new DateTime();
        public DateTime FechaRegistro
        {
            get => this.fechaRegistro;
            set => SetProperty(ref this.fechaRegistro, value);
        }
        public Comentario( string id, string idTarea, string idAutor, string nombre, string descripcion, DateTime fechaRegistro )
        {
            Id = id;
            IdTarea = idTarea;
            IdAutor = idAutor;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaRegistro = fechaRegistro;
        }
    }
}
