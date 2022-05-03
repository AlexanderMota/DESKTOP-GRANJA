using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.nav;
using DESKTOP_GRANJA.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class MainWindowVM : ObservableObject
    {
        bool tokenRecibido = false;
        private bool TokenRecibido
        {
            get => this.tokenRecibido;
            set => this.SetProperty(ref this.tokenRecibido, value);
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

        public MainWindowVM(StackPanel panelNavegacion)
        {
            this.nav = new Navegacion();
            WeakReferenceMessenger.Default.Register<ConfirmaTokenMessage>(this, (r, m) =>
            {
                TokenRecibido = m.Value;
                if (TokenRecibido)
                {
                    CargaListaTareasUC();
                    panelNavegacion.Visibility = System.Windows.Visibility.Visible;
                }
            });
            this.ListaTareasCommand = new RelayCommand(CargaListaTareasUC);
            this.ListaEmpleadosCommand = new RelayCommand(CargaListaEmpleadosUC);
            this.ListaSolicitudesCommand = new RelayCommand(CargaListaSolicitudesUC);
        }

        private void CargaListaSolicitudesUC()
        {
            this.UserControl = nav.CargaListaSolicitudesUC();
        }

        private void CargaLoginUC()
        {
            this.UserControl = nav.CargaLoginUC();
        }
        private void CargaListaTareasUC()
        {
            this.UserControl = nav.CargaListaTareasUC();
        }
        private void CargaListaEmpleadosUC()
        {
            this.UserControl = nav.CargaListaEmpleadosUC();
        }
    }
}
