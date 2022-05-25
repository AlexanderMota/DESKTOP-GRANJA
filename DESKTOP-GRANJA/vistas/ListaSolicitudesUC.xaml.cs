using DESKTOP_GRANJA.vista_modelo;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaSolicitudesUC.xaml
    /// </summary>
    public partial class ListaSolicitudesUC : UserControl
    {
        public ListaSolicitudesUC()
        {
            InitializeComponent();
            this.DataContext = new ListaSolicitudesVM();
        }
    }
}
