using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.nav;
using DESKTOP_GRANJA.vistas.ventanas_emergentes;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaSolicitudesVM : ObservableObject
    {
        private SolicitudService solServ = new SolicitudService();
        private TareaService tarServ = new TareaService();
        private EmpleadoService empServ = new EmpleadoService();

        private Navegacion navegacion;
        private SolicitudCompleta solicitudActual;
        public SolicitudCompleta SolicitudActual
        {
            get => solicitudActual;
            set => SetProperty(ref solicitudActual, value);
        }
        private ObservableCollection<Solicitud>? listaSolicitudes;
        private ObservableCollection<Solicitud>? ListaSolicitudes
        {
            get => listaSolicitudes;
            set => SetProperty(ref this.listaSolicitudes, value);
        }
        private ObservableCollection<SolicitudCompleta>? listaSolicitudesComp = new ObservableCollection<SolicitudCompleta>();
        public ObservableCollection<SolicitudCompleta>? ListaSolicitudesComp
        {
            get => listaSolicitudesComp;
            set => SetProperty(ref this.listaSolicitudesComp, value);
        }
        public ListaSolicitudesVM()
        {
            GetAllSolicitudes();
            this.navegacion = new Navegacion();
        }
        private async void GetAllSolicitudes()
        {
            var res = await solServ.GetAllSolicitudes(Properties.Settings.Default.Token);
            if (res is ObservableCollection<Solicitud> solis) ListaSolicitudes = solis;
            else if (res is ApiResponse apiResponse)
                Trace.WriteLine($"ListaSolicitudesVM.GetAllSolicitudes(): ===========> {apiResponse.Message}");


            if (ListaSolicitudes != null)
            {
                ListaSolicitudesComp = new ObservableCollection<SolicitudCompleta>();
                foreach (var sol in ListaSolicitudes)
                {
                    Tarea? tar = new Tarea();
                    var resT = await tarServ.GetTareaByIdAsync(Properties.Settings.Default.Token, sol.IdTarea);
                    if (resT is Tarea tare) tar = tare;
                    else if (res is ApiResponse apiResponse)
                        Trace.WriteLine($"ListaSolicitudesVM.GetAllSolicitudes(): ===========> {apiResponse.Message}");

                    Empleado? emp = new Empleado();
                    var resE = await empServ.GetEmpleadoByIdAsync(Properties.Settings.Default.Token, sol.IdEmpleado);
                    if (resE is Empleado empl) emp = empl;
                    else if (res is ApiResponse apiResponse)
                        Trace.WriteLine($"ListaSolicitudesVM.GetAllSolicitudes(): ===========> {apiResponse.Message}");


                    Trace.WriteLine("ListaSolicitudesComp: ==============> " + tar.Id);
                    if(tar.Id.Length < 1)
                    {
                        tar = new Tarea();
                        tar.Nombre = sol.IdTarea;
                    }
                    if (emp.Id.Length < 1)
                    {
                        emp = new Empleado();
                        emp.Nombre = sol.IdEmpleado;
                    }
                    ListaSolicitudesComp.Add(new SolicitudCompleta(sol.Id,tar , emp, sol.Aprobada, sol.FechaSolicitud));
                }
            }
        }
        internal void SfDataGrid_MouseDoubleClick() => ShowPopup();
        private async void ShowPopup()
        {
            ApiResponseView popup = new ApiResponseView($"¿Desea aprobar la solicitud de {SolicitudActual.empleado!.Nombre} {SolicitudActual.empleado!.Apellidos} para la tarea '{SolicitudActual.tarea!.Nombre}'?");
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                ApiResponse? res = await tarServ.PostAsignaEmpleadoTarea(Properties.Settings.Default.Token, 
                    SolicitudActual.tarea.Id, 
                    SolicitudActual.empleado.Id,
                    SolicitudActual.IdSolicitud!);
                if (res != null)
                {
                    Trace.WriteLine(res.Message);
                    if(res.Status < 220) GetAllSolicitudes();
                }
            }
        }
    }
    internal class SolicitudCompleta : ObservableObject
    {
        private string? idSolicitud = "";
        public string? IdSolicitud
        {
            get => idSolicitud;
            set => SetProperty(ref idSolicitud, value);
        }
        private Tarea? _tarea;
        public Tarea? tarea
        {
            get => _tarea;
            set => SetProperty(ref _tarea, value);
        }
        private Empleado? _empleado;
        public Empleado? empleado
        {
            get => _empleado;
            set => SetProperty(ref _empleado, value);
        }
        private bool? aprobada = false;
        public bool? Aprobada
        {
            get => aprobada;
            set => SetProperty(ref aprobada, value);
        }
        private DateTime? fechaRegistro = new DateTime();
        public DateTime? FechaSolicitud
        {
            get => fechaRegistro;
            set => SetProperty(ref fechaRegistro, value);
        }
        public SolicitudCompleta(string idSol, Tarea tar, Empleado emp, bool ap, DateTime? date)
        {
            IdSolicitud = idSol;
            tarea = tar;
            empleado = emp;
            Aprobada = ap;
            FechaSolicitud = date;
        }
    }
}