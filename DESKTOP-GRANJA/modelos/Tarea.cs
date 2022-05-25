using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Tarea : ObservableObject
    {
        public enum GradoImportancia
        {
            Critica,
            Alta,
            Media,
            Baja
        }
        private string _id = "";
        public string Id
        {
            get => this._id; 
            set => SetProperty(ref this._id, value); 
        }
        private int idTarea = 0;
        public int IdTarea
        {
            get => this.idTarea;
            set => SetProperty(ref this.idTarea, value);
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
        private GradoImportancia importancia;
        public GradoImportancia Importancia
        {
            get => this.importancia;
            set => SetProperty(ref this.importancia, value);
        }
        private DateTime fechainicio = new DateTime();
        public DateTime Fechainicio
        {
            get => this.fechainicio;
            set => SetProperty(ref this.fechainicio, value);
        }
        private DateTime fechafin = new DateTime();
        public DateTime Fechafin
        {
            get => this.fechafin;
            set => SetProperty(ref this.fechafin, value);
        }
        private bool terminada = false;
        public bool Terminada
        {
            get => this.terminada;
            set => SetProperty(ref this.terminada, value);
        }
        private int numeroTrabajadores = 0;
        public int NumeroTrabajadores
        {
            get => this.numeroTrabajadores;
            set => SetProperty(ref this.numeroTrabajadores, value);
        }
        public Tarea(string _id, int idTarea, string nombre, string descripcion, GradoImportancia importancia, DateTime fechainicio, DateTime fechafin, bool terminada, int numeroTrabajadores)
        {
            Id = _id;
            IdTarea = idTarea;
            Nombre = nombre;
            Descripcion = descripcion;
            Importancia = importancia;
            Fechainicio = fechainicio;
            Fechafin = fechafin;
            Terminada = terminada;
            NumeroTrabajadores = numeroTrabajadores;
        }
        public Tarea() { }
        public override string ToString()
            => $"> | {this.IdTarea} | {this.Nombre} | {this.Fechainicio} | {this.Terminada} | {this.NumeroTrabajadores} |";
        

        /*
        public Tarea(
            string _id, 
            int idTarea, 
            string nombre, 
            string descripcion, 
            string importancia, 
            string fechainicio, 
            string fechafin, 
            bool terminada, 
            int numeroTrabajadores)
        {
            _id = _id;
            this.idTarea = idTarea;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.importancia = importancia;
            this.fechainicio = fechainicio;
            this.fechafin = fechafin;
            this.terminada = terminada;
            this.numeroTrabajadores = numeroTrabajadores;
        }*/
    }
}
