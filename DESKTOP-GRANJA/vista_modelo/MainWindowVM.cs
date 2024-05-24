using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.nav;
using DESKTOP_GRANJA.vistas;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class MainWindowVM : ObservableObject
    {
        private TareaService tarServ = new TareaService();
        private bool tokenRecibido = false;
        private bool TokenRecibido
        {
            get => this.tokenRecibido;
            set => this.SetProperty(ref tokenRecibido, value);
        }
        /*private Tarea? centro;
        public Tarea? Centro
        {
            get => centro;
            set => SetProperty(ref centro, value);
        }*/
        private ObservableCollection<Tarea> superTareas = new ObservableCollection<Tarea>();
        public ObservableCollection<Tarea>? SuperTareas
        {
            get
            {
                ObservableCollection<Tarea> supers = new ObservableCollection<Tarea>();
                foreach (Tarea tarea in superTareas)
                {
                    Tarea tar = new Tarea();
                    tar.Nombre = tarea.Nombre;
                    tar.Id = tarea.Id;
                    supers.Add(tar);
                }
                return supers;
            }
            set => SetProperty(ref superTareas!, value);
        }
        private Navegacion nav;
        private UserControl userControl = new LoginUC();
        public UserControl UserControl
        {
            get => userControl;
            set => SetProperty(ref userControl, value);
        }

        public RelayCommand ListaTareasCommand { get; }
        public RelayCommand ListaEmpleadosCommand { get; }
        public RelayCommand ListaSolicitudesCommand { get; }

        public MainWindowVM(Grid panelNavegacion)
        {
            nav = new Navegacion();
            WeakReferenceMessenger.Default.Register<ConfirmaTokenMessage>(this, async (r, m) =>
            {
                TokenRecibido = m.Value;
                if (TokenRecibido)
                {
                    var res = await tarServ.GetSuperTareasAsync(Properties.Settings.Default.Token);
                    if (res is ObservableCollection<Tarea> tars) SuperTareas = tars;
                    else if (res is ApiResponse apiResponse)
                        Trace.WriteLine($"MainWindowVM(): ==================> {apiResponse.Message}");
                    //Trace.WriteLine("MainWindowVM.MainWindowVM(): ============> SuperTareas!.Count("+ SuperTareas!.Count + ")");
                    CargaListaTareasUC();
                    panelNavegacion.Visibility = System.Windows.Visibility.Visible;
                }
            });

            ListaTareasCommand = new RelayCommand(CargaListaTareasUC);
            ListaEmpleadosCommand = new RelayCommand(CargaListaEmpleadosUC);
            ListaSolicitudesCommand = new RelayCommand(CargaListaSolicitudesUC);
        }

        private void CargaListaSolicitudesUC() =>
            this.UserControl = nav.CargaListaSolicitudesUC();
        private void CargaListaTareasUC() =>
            this.UserControl = nav.CargaListaTareasUC();
        private void CargaListaEmpleadosUC()=>
            this.UserControl = nav.CargaListaEmpleadosUC();
        public void SeleccionaCentro( Tarea centro ) =>
            WeakReferenceMessenger.Default.Send(
                new CambiaCentroMessage((centro == null) ? "" : centro.Id));
    }
}
