using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
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
        internal void Aceptar()
        {
            //DBApi.Post("auth/signin",new Usuario(Nombre,Password));
            Task<System.Collections.ObjectModel.ObservableCollection<modelos.Tarea>> tar = 
                new DBApi().GetAll("tareas/", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbXBsZWFkbyI6eyJpZEVtcGxlYWRvIjo2LCJub21icmUiOiJMaXNhIn0sImlhdCI6MTY1MDgzMDM2NiwiZXhwIjoxNjUwODMzOTY2fQ.EK_GI5-48Yejg4N_clUmNFibak2luysqSLaOtkBYHaY");
            /*
            List<Tarea> lista = tar.Result.ToList();
            foreach (modelos.Tarea tarea in lista)
            {
                Trace.WriteLine(tarea.Nombre);
            }*/
        }
    }
}
