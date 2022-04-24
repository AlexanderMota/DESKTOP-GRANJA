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
        private Int32 status;
        private String message;
        public Int32 Status { get { return status; } }
        public String Message { get { return message; } }
        public ApiResponse(int status, String message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
