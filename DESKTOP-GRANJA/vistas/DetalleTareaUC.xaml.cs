using DESKTOP_GRANJA.vista_modelo;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.vistas
{
    /// <summary>
    /// Lógica de interacción para DetalleTareaUC.xaml
    /// </summary>
    public partial class DetalleTareaUC : UserControl
    {
        public DetalleTareaUC()
        {
            InitializeComponent();
            this.DataContext = new DetalleTareaVM();
        }
    }
}
