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


        private Tarea tarAux = new Tarea();
        private ObservableCollection<Tarea> tareaPadre = new ObservableCollection<Tarea>();
        private ObservableCollection<Tarea> TareaPadre
        {
            get => tareaPadre;
            set => SetProperty(ref tareaPadre, value);
        }
        private Tarea tareaActual = new Tarea();
        public Tarea TareaActual
        {
            get => tareaActual;
            set => SetProperty(ref tareaActual, value);
        }
        private string numPlant = "";
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

        internal void ShowPopup( string v )
        {
            throw new NotImplementedException();
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
        private bool editaTarea = false;
        public bool EditaTarea
        {
            get => editaTarea;
            set => SetProperty(ref editaTarea, value);
        }
        private string[] importancias = new string[] { "Crítica", "Alta", "Media", "Baja"};
        public string[] Importancias
        {
            get => importancias;
            set => SetProperty(ref importancias, value);
        }
        private string[] departamentos = new string[0];
        public string[] Departamentos
        {
            get => departamentos;
            set => SetProperty(ref departamentos, value);
        }
        private string[] roles = new string[0];
        public string[] Roles
        {
            get => roles;
            set => SetProperty(ref roles, value);
        }






        public DetalleTareaVM()
        {
            GetRoles();
            GetDepartamentos();
            WeakReferenceMessenger.Default.Register<DetalleTareaMessage>(this, async ( r, m ) =>
            {
                TareaPadre.Add(TareaActual);
                TareaActual = m.Value;
                int n = 0;
                foreach (var p in TareaActual.Plantilla)
                {
                    Trace.WriteLine("Plantilla: ===========> Rol: " + p.Rol + " - " + p.Cantidad);
                    n += p.Cantidad;
                }
                var res1 = await empServ.GetEmpleadosByTareaAsync(Properties.Settings.Default.Token, TareaActual.Id); 
                if (res1 is ObservableCollection<Empleado> emps) Empleados = emps;
                else if (res1 is ApiResponse apiResponse)
                    Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");

                var res2 = await tarServ.GetSubtareasAsync(Properties.Settings.Default.Token, TareaActual.Id);
                if (res2 is ObservableCollection<Tarea> tareas) Subtareas = tareas;
                else if (res2 is ApiResponse apiResponse)
                    Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");

                var res3 = await comServ.GetComentariosByIdTareaAsync(Properties.Settings.Default.Token, TareaActual.Id);
                if (res3 is ObservableCollection<Comentario> comm) Comentarios = comm;
                else if (res3 is ApiResponse apiResponse)
                    Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");


                if (Comentarios != null && Comentarios.Count > 0)
                {
                    for (int i = 0; i < Comentarios.Count; i++)
                    {
                        Comentarios[i].GetNombreAutor();
                    }
                }
                NumPlant = "Plantilla: " + ((Empleados == null) ? "0" : $"{ Empleados.Count }") + " / " + $"{ n }";
            });
        }
        internal void posComentario()
        {
            Trace.WriteLine("posComentario(): ===================> " + ComentarioNuevo.Nombre);
        }
        internal async void GuardaCambiosTarea()
        {
            ApiResponse? res = await tarServ.PatchTareaAsync(Properties.Settings.Default.Token, TareaActual);
            if (res != null)
                Trace.WriteLine($"DetalleTareaVM.GuardaCambiosTarea(): ===================================> {res.Message}");
            
        }

        internal async void GuardaNuevaSubtarea()
        {
            Trace.WriteLine("DetalleTareaVM.GuardaNuevaSubtarea(): ===============> " + TareaActual.Nombre);
            Trace.WriteLine("DetalleTareaVM.GuardaNuevaSubtarea(): ===============> " + tarAux.Id);

            ApiResponse? res = await tarServ.PostTareaAsync(Properties.Settings.Default.Token, TareaActual, tarAux.Id);
            if(res != null)
            {
                if(res.Status < 220)
                {
                    Trace.WriteLine("DetalleTareaVM.GuardaNuevaSubtarea(): ===============> " + res.Message);
                    Click_CancelaNuevaSubtarea();
                }
                else
                {
                    Trace.WriteLine("ERROR >>> DetalleTareaVM.GuardaNuevaSubtarea(): ===============> " + res.Message);
                }
            }

        }
        internal void ShowPopup()
        {
            Trace.WriteLine("DetalleTareaVM.ShowPopup(): ===================> " + ComentarioNuevo.Nombre);
        }
        internal void VuelveTareaPadre()
        {

            if (TareaPadre.Count > 0 && TareaPadre[TareaPadre.Count - 1].Id != "")
            {
                Tarea destino = TareaPadre[TareaPadre.Count - 1];
                TareaPadre.Remove(TareaPadre[TareaPadre.Count - 1]);
                WeakReferenceMessenger.Default.Send(new DetalleTareaMessage(destino));
            }
        }
        private async void GetDepartamentos()
        {
            var resultado = await empServ.GetDepartamentosAsync(Properties.Settings.Default.Token);
            if (resultado is string[] departs)  Departamentos = departs; 
            else if (resultado is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM.GetDepartamentos(): ===========> {apiResponse.Message}");
        }


        private async void GetRoles()
        {
            var resultado = await empServ.GetRolesAsync(Properties.Settings.Default.Token);
            if (resultado is string[] ro) Roles = ro;
            else if (resultado is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM.GetRolesAsync(): ===========> {apiResponse.Message}");
        }
        internal void Click_NuevaSubtarea()
        {
            tarAux = TareaActual;
            TareaActual = new Tarea();
            TareaActual.Fechainicio = DateTime.Now;
            TareaActual.Fechafin = DateTime.Now;
        }
        internal void Click_CancelaNuevaSubtarea()
        {
            TareaActual = tarAux;
            tarAux = new Tarea();
        }
    }
}
