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
    internal class LoginVM : ObservableObject
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
        internal async void Aceptar()
        {
            ApiResponse ar = await new DBApi().Post("auth/signin", new Usuario(Nombre, Password));
            if(ar.Status == 201)
            {
                Properties.Settings.Default.Token = ar.Message;
                Trace.WriteLine(Properties.Settings.Default.Token);

                WeakReferenceMessenger.Default.Send(new ConfirmaTokenMessage(true));
            }
        }
    }
}
