using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.vista_modelo;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DESKTOP_GRANJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM(this.PanelNavegacion);
            this.DataContext = vm;
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.LisenciaSyncfusion);
        }
        private void MuestraCentros( object sender, RoutedEventArgs e )
        {
            Button? button = sender as Button;
            if (button != null)
            {
                ContextMenu? menu = FindResource("ProfileMenu") as ContextMenu;
                if (menu != null)
                {
                    menu.PlacementTarget = button;
                    menu.IsOpen = true;
                }
            }
        }

        private void MenuItem_Click( object sender, RoutedEventArgs e )
        {
            if (sender is MenuItem menuItem)
                if (menuItem.DataContext is Tarea tarea)
                    vm.SeleccionaCentro(tarea);
        }
    }
}
