using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.nav;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaSolicitudesVM : ObservableObject
    {
        private Navegacion navegacion;
        private Solicitud solicitudActual;
        public Solicitud SolicitudActual
        {
            get => solicitudActual;
            set => SetProperty(ref solicitudActual, value);
        }
        private ObservableCollection<Solicitud> listaSolicitudes;
        public ObservableCollection<Solicitud> ListaSolicitudes
        {
            get => listaSolicitudes;
            set => SetProperty(ref this.listaSolicitudes, value);
        }
        //private RelayCommand verSolicitudCommand;
        public RelayCommand VerSolicitudCommand { get;}
        public ListaSolicitudesVM()
        {
            //GetAllSolicitudes(); esto da error
            this.navegacion = new Navegacion();
        }
        private async void GetAllSolicitudes()
        {
            this.ListaSolicitudes =
                await new DBApi().GetAllSolicitudes(Properties.Settings.Default.Token);
        }
    }
}
