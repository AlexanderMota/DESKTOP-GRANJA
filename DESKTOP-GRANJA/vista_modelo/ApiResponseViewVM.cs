using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ApiResponseViewVM : ObservableObject
    {
        private string mensaje = "";
        public string Mensaje
        {
            get => mensaje;
            set => SetProperty(ref mensaje, value);
        }
        public ApiResponseViewVM()
        {

        }
        public ApiResponseViewVM(string msg)
        {
            Mensaje = msg;
        }
    }
}
