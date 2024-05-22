using DESKTOP_GRANJA.vista_modelo;
using System.Windows;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaEmpleadosUC.xaml
    /// </summary>
    public partial class ListaEmpleadosUC : UserControl
    {
        private ListaEmpleadosVM vm = new ListaEmpleadosVM();
        public ListaEmpleadosUC()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
        public void ListBox_Selected( object sender, RoutedEventArgs e )
        {

        }

        private void SfDataGrid_MouseDoubleClick( object sender, System.Windows.Input.MouseButtonEventArgs e ) =>
            vm.SfDataGrid_MouseDoubleClick();
    }
}
