using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.vistas;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.nav
{
    internal class Navegacion
    {
        internal UserControl CargaLoginUC() => new LoginUC();
        internal UserControl CargaListaTareasUC() => new ListaTareasUC();
        internal UserControl CargaListaEmpleadosUC() => new ListaEmpleadosUC();
        internal UserControl CargaListaSolicitudesUC() => new ListaSolicitudesUC(); 
    }
}
