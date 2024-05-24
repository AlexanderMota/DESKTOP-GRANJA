using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Comentario : ObservableObject
    {
        private EmpleadoService empServ = new EmpleadoService();
        private string _id = "";
        [JsonProperty("_id")]
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
        private string nombreAutor = "";
        public string NombreAutor
        {
            get => this.nombreAutor;
            set => SetProperty(ref this.nombreAutor, value);
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

        public Comentario()
        {
        }
        public async void GetNombreAutor()
        {
            Empleado? autor = new Empleado();
            var res3 = await empServ.GetEmpleadoByIdAsync(Properties.Settings.Default.Token, IdAutor);
            if (res3 is Empleado emp) autor = emp;
            else if (res3 is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");


            NombreAutor = (autor == null) ? "" : autor.Nombre + " " + autor.Apellidos;

        }

        public override string ToString()
            => $"> | {this.Id} | {this.Nombre} | {this.Descripcion} | {this.IdAutor} | {this.IdTarea} |";

    }
}
