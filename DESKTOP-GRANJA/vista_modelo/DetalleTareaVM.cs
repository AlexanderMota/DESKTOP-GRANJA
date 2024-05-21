using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class DetalleTareaVM : ObservableObject
    {
        private EmpleadoService empServ = new EmpleadoService();
        private TareaService tarServ = new TareaService();

        private ComentarioService comServ = new ComentarioService();
        private string numPlant = "";

        private Tarea tareaActual = new Tarea();
        public Tarea TareaActual
        {
            get => tareaActual;
            set => SetProperty(ref tareaActual, value);
        }
        public string NumPlant
        {
            get => numPlant;
            set => SetProperty(ref numPlant, value);
        }
        private ObservableCollection<Tarea>? subtareas;
        public ObservableCollection<Tarea>? Subtareas
        {
            get => subtareas;
            set => SetProperty(ref subtareas, value);
        }
        private Empleado empleadoActual = new Empleado();
        public Empleado EmpleadoActual
        {
            get => empleadoActual;
            set => SetProperty(ref empleadoActual, value);
        }
        private ObservableCollection<Empleado>? empleados;
        public ObservableCollection<Empleado>? Empleados
        {
            get => empleados;
            set => SetProperty(ref empleados, value);
        }
        private Comentario comentarioNuevo = new Comentario();
        public Comentario ComentarioNuevo
        {
            get => comentarioNuevo;
            set => SetProperty(ref comentarioNuevo, value);
        }
        private ObservableCollection<Comentario>? comentarios;
        public ObservableCollection<Comentario>? Comentarios
        {
            get => comentarios;
            set => SetProperty(ref comentarios, value);
        }
        public DetalleTareaVM() =>
            WeakReferenceMessenger.Default.Register<DetalleTareaMessage>(this, async ( r, m ) => { 
                TareaActual = m.Value;
                int n = 0;
                foreach (var p in TareaActual.Plantilla)
                {
                    Trace.WriteLine("Plantilla: ===========> Rol: " + p.Rol + " - " + p.Cantidad);
                    n += p.Cantidad;
                }
                Empleados = await empServ.GetEmpleadosByTareaAsync(Properties.Settings.Default.Token, TareaActual.Id);
                Subtareas = await tarServ.GetSubtareasAsync(Properties.Settings.Default.Token, TareaActual.Id);
                Comentarios = await comServ.GetComentariosByIdTareaAsync(Properties.Settings.Default.Token, TareaActual.Id);
                if(Comentarios != null && Comentarios.Count > 0)
                {
                    for(int i = 0; i < Comentarios.Count; i++)
                    {
                        Comentarios[i].GetNombreAutor();
                    }
                }
                NumPlant = "Plantilla: " +  ((Empleados == null) ? "0" :$"{ Empleados.Count }")+" / " + $"{ n }";
            });

        internal void posComentario()
        {
            Trace.WriteLine("posComentario(): ===================> " + ComentarioNuevo.Nombre);
        }
    }
}
