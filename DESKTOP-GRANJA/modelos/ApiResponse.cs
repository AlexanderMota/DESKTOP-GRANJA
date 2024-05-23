using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class ApiResponse : ObservableObject
    {
        private Int32 status = 0;
        public Int32 Status
        {
            get => this.status;
            set => SetProperty(ref this.status, value);
        }
        private string message = "";
        public string Message
        {
            get => this.message;
            set => SetProperty(ref this.message, value);
        }
        public ApiResponse(int status, String message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
