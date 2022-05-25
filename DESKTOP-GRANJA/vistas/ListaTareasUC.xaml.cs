using DESKTOP_GRANJA.vista_modelo;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaTareasUC.xaml
    /// </summary>
    public partial class ListaTareasUC : UserControl
    {
        public ListaTareasUC()
        {
            InitializeComponent();
            this.DataContext = new ListaTareasVM();
        }
    }
}
