using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using DESKTOP_GRANJA.vista_modelo;
using DESKTOP_GRANJA.vistas.ventanas_emergentes;
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
            DataContext = vm;
            UIMostrandoDetalles();
        }

        private void Button_Click_Comentar( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.posComentario();
        }

        private void ListBox_Selected( object sender, System.Windows.RoutedEventArgs e )
        {
            // Obtiene el botón que disparó el evento
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Obtiene el DataContext del botón, que es la subtarea
                Tarea? selectedSubtarea = clickedButton.DataContext as Tarea;
                if (selectedSubtarea != null)
                {
                    vm.GuardaTareaPadre();
                    WeakReferenceMessenger.Default.Send(new DetalleTareaMessage(selectedSubtarea));
                }

            }
        }
        public void Button_Click_Editar( object sender, System.Windows.RoutedEventArgs e )
        {
            UIGuardandoDetalles();
            vm.EditaTarea = true;
        }
        public void Button_Click_GuardaTarea( object sender, System.Windows.RoutedEventArgs e )
        {
            if (vm.TareaActual.Id == "")
            {
                vm.GuardaNuevaSubtarea(); 
            }
            else
            {
                vm.GuardaCambiosTarea();
            }
            vm.EditaTarea = false;
            UIMostrandoDetalles();
        }
        private void Button_Click_NuevaSubtarea( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.Click_NuevaSubtarea();
            UIGuardandoDetalles();
        }
        public void Button_Click_Cancela( object sender, System.Windows.RoutedEventArgs e )
        {
            if(vm.TareaActual.Id == "")
            {
                vm.Click_CancelaNuevaSubtarea();

            }
            UIMostrandoDetalles();
        }
        private void UIMostrandoDetalles()
        {
            textoDepartamento.Visibility = System.Windows.Visibility.Visible;
            textoImportancia.Visibility = System.Windows.Visibility.Visible;
            textoTituloTarea.Visibility = System.Windows.Visibility.Visible;
            botonSolicitarTarea.Visibility = System.Windows.Visibility.Visible;
            txtBlDesc.Visibility = System.Windows.Visibility.Visible;
            botonNuevaSubtarea.Visibility = System.Windows.Visibility.Visible;
            botonEliminaTarea.Visibility = System.Windows.Visibility.Visible;
            botonEditaTarea.Visibility = System.Windows.Visibility.Visible;
            seccionEmpleadosTarea.Visibility = System.Windows.Visibility.Visible;

            botonEditaPlantilla.Visibility = System.Windows.Visibility.Collapsed;
            combBDepartamento.Visibility = System.Windows.Visibility.Collapsed;
            combBImportancia.Visibility = System.Windows.Visibility.Collapsed;
            inputTituloTarea.Visibility = System.Windows.Visibility.Collapsed;
            dateFechaFin.Visibility = System.Windows.Visibility.Collapsed;
            txtBoDesc.Visibility = System.Windows.Visibility.Collapsed;
            botonCancelaEditaTarea.Visibility = System.Windows.Visibility.Collapsed;
            botonGuardaEditaTarea.Visibility = System.Windows.Visibility.Collapsed; 
            seccionPlantillaTarea.Visibility= System.Windows.Visibility.Collapsed;

            seccionTopPlantilla.Width = new System.Windows.GridLength(85);

            dateFechaInicio.IsEnabled = false;
            dateFechaFin.IsEnabled = false;
        }
        private void UIGuardandoDetalles()
        {
            textoDepartamento.Visibility = System.Windows.Visibility.Collapsed;
            textoImportancia.Visibility = System.Windows.Visibility.Collapsed;
            textoTituloTarea.Visibility = System.Windows.Visibility.Collapsed;
            botonSolicitarTarea.Visibility = System.Windows.Visibility.Collapsed;
            txtBlDesc.Visibility = System.Windows.Visibility.Collapsed;
            botonNuevaSubtarea.Visibility = System.Windows.Visibility.Collapsed;
            botonEliminaTarea.Visibility = System.Windows.Visibility.Collapsed;
            botonEditaTarea.Visibility = System.Windows.Visibility.Collapsed;
            seccionEmpleadosTarea.Visibility = System.Windows.Visibility.Collapsed;

            botonEditaPlantilla.Visibility = System.Windows.Visibility.Visible;
            combBDepartamento.Visibility = System.Windows.Visibility.Visible;
            combBImportancia.Visibility = System.Windows.Visibility.Visible;
            inputTituloTarea.Visibility = System.Windows.Visibility.Visible;
            dateFechaFin.Visibility = System.Windows.Visibility.Visible;
            txtBoDesc.Visibility = System.Windows.Visibility.Visible;
            botonCancelaEditaTarea.Visibility = System.Windows.Visibility.Visible;
            botonGuardaEditaTarea.Visibility = System.Windows.Visibility.Visible;
            seccionPlantillaTarea.Visibility = System.Windows.Visibility.Visible;

            seccionTopPlantilla.Width = new System.Windows.GridLength(160);

            dateFechaInicio.IsEnabled = true;
            dateFechaFin.IsEnabled = true;
        }

        private void Button_Click_AgregaRol( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.TareaActual.Plantilla.Add(new RolCantidad());
        }

        private void Button_Click_QuitaPlantilla( object sender, System.Windows.RoutedEventArgs e )
        {
            var button = sender as Button;

            // Get the item bound to the button
            var item = button?.CommandParameter as RolCantidad;

            Trace.WriteLine($"Item >>> {button}");
            Trace.WriteLine($"Item >>> {item}");
            // Remove the item from the collection
            if (item != null)
            {
                vm.TareaActual.Plantilla.Remove(item);
            }
        }

        private void Button_Click_VuelveTareaPadre( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.VuelveTareaPadre();
        }
    }
}