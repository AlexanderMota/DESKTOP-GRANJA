using DESKTOP_GRANJA.vista_modelo;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para ListaTareasUC.xaml
    /// </summary>
    public partial class ListaTareasUC : UserControl
    {
        private ListaTareasVM vm = new ListaTareasVM();
        public ListaTareasUC()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
        private void SfDataGrid_MouseDoubleClick( object sender, 
            System.Windows.Input.MouseButtonEventArgs e ) =>
            vm.SfDataGrid_MouseDoubleClick();

        private void Button_Click_PageNumMenos( object sender, RoutedEventArgs e ) =>
            vm.PageNumMenos();
        private void Button_Click_PageNumMas( object sender, RoutedEventArgs e ) =>
            vm.PageNumMas();
    }
}
