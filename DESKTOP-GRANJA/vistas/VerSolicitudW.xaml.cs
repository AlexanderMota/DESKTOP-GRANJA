using DESKTOP_GRANJA.vista_modelo;
using System.Windows;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para VerSolicitudW.xaml
    /// </summary>
    public partial class VerSolicitudW : Window
    {
        public VerSolicitudW()
        {
            InitializeComponent();
            this.DataContext = new VerSolicitudVM();
        }
    }
}
