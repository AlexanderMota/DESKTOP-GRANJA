namespace DESKTOP_GRANJA.modelos
{
    internal class Usuario
    {
        private string _email = "";
        private string _password = "";
        public string email { get => _email; set => _email = value; }
        public string password { get => _password; set => _password = value; }
        public Usuario()
        { }
        public Usuario(string nombre, string password)
        {
            this.email = nombre;
            this.password = password;
        }
    }
}
