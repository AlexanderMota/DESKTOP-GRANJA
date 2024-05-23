using DESKTOP_GRANJA.vista_modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DESKTOP_GRANJA.vistas.ventanas_emergentes
{
    /// <summary>
    /// Lógica de interacción para ApiResponseView.xaml
    /// </summary>
    public partial class ApiResponseView : Window
    {
        private ApiResponseViewVM vm = new ApiResponseViewVM();
        public ApiResponseView()
        {
            InitializeComponent();
            DataContext = vm;
        }
        public ApiResponseView(string msg)
        {
            InitializeComponent();
            vm.Mensaje = msg;
            DataContext = vm;
        }
        private void AcceptButton_Click( object sender, RoutedEventArgs e )
        {
            // Lógica para manejar la aceptación
            this.DialogResult = true; // Si usas ShowDialog() para abrir la ventana
            this.Close();
        }

        private void CancelButton_Click( object sender, RoutedEventArgs e )
        {
            // Lógica para manejar la cancelación
            this.DialogResult = false; // Si usas ShowDialog() para abrir la ventana
            this.Close();
        }
    }
}
