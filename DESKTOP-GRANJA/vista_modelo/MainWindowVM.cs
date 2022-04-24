using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
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
        private Navegacion nav;
        private UserControl userControl = new LoginUC();
        public UserControl UserControl
        {
            get => userControl;
            set => SetProperty(ref userControl, value);
        }

        public MainWindowVM()
        {
            this.nav = new Navegacion();
        }
        private void CargaLoginUC()
        {
            this.UserControl = nav.CargaLoginUC();
        }
    }
}
