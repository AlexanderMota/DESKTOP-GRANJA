using DESKTOP_GRANJA.vista_modelo;
using System.Diagnostics;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para DetalleTareaUC.xaml
    /// </summary>
    public partial class DetalleTareaUC : UserControl
    {
        private DetalleTareaVM vm = new DetalleTareaVM();
        public DetalleTareaUC()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Button_Click_Comentar( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.posComentario();
        }
    }
}
