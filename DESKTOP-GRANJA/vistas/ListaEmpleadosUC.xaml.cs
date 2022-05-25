using DESKTOP_GRANJA.vista_modelo;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaEmpleadosUC.xaml
    /// </summary>
    public partial class ListaEmpleadosUC : UserControl
    {
        public ListaEmpleadosUC()
        {
            InitializeComponent();
            this.DataContext = new ListaEmpleadosVM();
        }
    }
}
