using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaSolicitudesVM : ObservableObject
    {
        private ObservableCollection<Solicitud> listaSolicitudes;
        public ObservableCollection<Solicitud> ListaSolicitudes
        {
            get => listaSolicitudes;
            set => SetProperty(ref this.listaSolicitudes, value);
        }

        public ListaSolicitudesVM()
        {
            GetAllSolicitudes();
        }
        private async void GetAllSolicitudes()
        {
            this.ListaSolicitudes =
                await new DBApi().GetAllSolicitudes(Properties.Settings.Default.Token);
        }
    }
}
