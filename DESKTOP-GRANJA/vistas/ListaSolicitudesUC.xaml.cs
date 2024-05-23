using DESKTOP_GRANJA.vista_modelo;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaSolicitudesUC.xaml
    /// </summary>
    public partial class ListaSolicitudesUC : UserControl
    {
        private ListaSolicitudesVM vm = new ListaSolicitudesVM();
        public ListaSolicitudesUC()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void SfDataGrid_MouseDoubleClick( object sender, System.Windows.Input.MouseButtonEventArgs e ) =>
            vm.SfDataGrid_MouseDoubleClick();
    }
}
