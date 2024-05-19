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
        private ObservableCollection<Tarea> subtareas;
        public ObservableCollection<Tarea> Subtareas
        {
            get => subtareas;
            set => SetProperty(ref subtareas, value);
        }
        private ObservableCollection<Empleado> empleados;
        public ObservableCollection<Empleado> Empleados
        {
            get => empleados;
            set => SetProperty(ref empleados, value);
        }
        private ObservableCollection<Comentario> comentarios;
        public ObservableCollection<Comentario> Comentarios
        {
            get => comentarios;
            set => SetProperty(ref comentarios, value);
        }
        public DetalleTareaVM() =>
            WeakReferenceMessenger.Default.Register<DetalleTareaMessage>(this, async ( r, m ) => { 
                TareaActual = m.Value;
                NumPlant = "Plantilla: 0 / " + TareaActual.Plantilla.Count.ToString();
                Empleados = await empServ.GetAllEmpleados();
                Subtareas = await tarServ.GetAllTareasAsync();
                Trace.WriteLine("TareaActual.Id: ===================> " + TareaActual.Id);
                Comentarios = await comServ.GetComentariosByIdTareaAsync(TareaActual.Id);
            });
    }
}
