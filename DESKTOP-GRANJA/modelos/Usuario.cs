namespace DESKTOP_GRANJA.modelos
{
    internal class Usuario
    {
        private string _email = "";
        private string _password = "";
        public string email { get => this._email; set => this._email = value; }
        public string password { get => this._password; set => this._password = value; }
        public Usuario()
        {
            this.email = string.Empty;
            this.password = string.Empty;
        }
        public Usuario(string nombre, string password)
        {
            this.email = nombre;
            this.password = password;
        }
    }
}
