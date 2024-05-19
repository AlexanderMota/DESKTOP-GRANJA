using DESKTOP_GRANJA.vista_modelo;
using System.Windows;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        private LoginVM vm = new LoginVM();
        public LoginUC()
        {
            InitializeComponent();
            this.DataContext = vm;

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.LisenciaSyncfusion);
        }
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            vm.Aceptar(feedbackLogin);
        }
    }
}
