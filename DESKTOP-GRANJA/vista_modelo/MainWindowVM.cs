using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class MainWindowVM : ObservableObject
    {
        private string nombre = "";
        public string Nombre
        {
            get { return this.nombre; }
            set { SetProperty(ref this.nombre, value); }
        }
        private string password = "";
        public string Password
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }

        public MainWindowVM()
        {

        }
        internal void Aceptar()
        {
            DBApi.Post("/auth/signin",new Usuario(Nombre,Password));
        }
    }

}
