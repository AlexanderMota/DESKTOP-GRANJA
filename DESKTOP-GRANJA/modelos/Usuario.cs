using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.modelos
{
    internal class Usuario
    {
        private string _nombre;
        private string _password;
        public string nombre { get => this._nombre; set => this._nombre = value; }
        public string password { get => this._password; set => this._password = value; }
        public Usuario()
        {
            this._nombre = string.Empty;
            this._password = string.Empty;
        }
        public Usuario(string nombre, string password)
        {
            this._nombre = nombre;
            this._password = password;
        }
    }
}
