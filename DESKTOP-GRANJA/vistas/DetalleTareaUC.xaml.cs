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
            this.DataContext = vm;
        }

        private void Button_Click_Comentar( object sender, System.Windows.RoutedEventArgs e )
        {
            vm.posComentario();
        }
        private void VerSubtarea( object sender, System.Windows.Input.MouseButtonEventArgs e )
        {
            Trace.WriteLine("VerSubtarea: " + sender.ToString());
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
                    // Aquí puedes realizar las acciones necesarias con la subtarea seleccionada
                    Trace.WriteLine($"Nombre: {selectedSubtarea.Id}\nDescripción: {selectedSubtarea.Descripcion}");
                    WeakReferenceMessenger.Default.Send(new DetalleTareaMessage(selectedSubtarea));
                }
            }
        }
        private void ShowPopup()
        {
            ApiResponseView popup = new ApiResponseView();
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                // Acción si el usuario aceptó
            }
            else
            {
                // Acción si el usuario canceló
            }
        }
        public void Button_Click_Editar( object sender, System.Windows.RoutedEventArgs e )
        {
            //vm.EditarTarea(true);
            if(vm.EditaTarea == false)
            {
                textoDepartamento.Visibility = System.Windows.Visibility.Collapsed;
                textoImportancia.Visibility = System.Windows.Visibility.Collapsed;
                textoTituloTarea.Visibility = System.Windows.Visibility.Collapsed;
                botonSolicitarTarea.Visibility = System.Windows.Visibility.Collapsed;

                botonEditaPlantilla.Visibility = System.Windows.Visibility.Visible;
                combBDepartamento.Visibility = System.Windows.Visibility.Visible;
                combBImportancia.Visibility = System.Windows.Visibility.Visible;
                inputTituloTarea.Visibility = System.Windows.Visibility.Visible;
                dateFechaFin.Visibility = System.Windows.Visibility.Visible;

                seccionTopPlantilla.Width = new System.Windows.GridLength(160);

                dateFechaInicio.IsEnabled = true;

                botonEditaTarea.Content = "Guardar";

                vm.EditaTarea = true;
            }
            else
            {
                textoDepartamento.Visibility = System.Windows.Visibility.Visible;
                textoImportancia.Visibility = System.Windows.Visibility.Visible;
                textoTituloTarea.Visibility = System.Windows.Visibility.Visible;
                botonSolicitarTarea.Visibility=System.Windows.Visibility.Visible;   

                botonEditaPlantilla.Visibility = System.Windows.Visibility.Collapsed;
                combBDepartamento.Visibility = System.Windows.Visibility.Collapsed;
                combBImportancia.Visibility = System.Windows.Visibility.Collapsed;
                inputTituloTarea.Visibility = System.Windows.Visibility.Collapsed;
                dateFechaFin.Visibility = System.Windows.Visibility.Collapsed;

                seccionTopPlantilla.Width = new System.Windows.GridLength(85);

                dateFechaInicio.IsEnabled = false;

                botonEditaTarea.Content = "Editar";

                vm.EditaTarea = false;
            }
        }
    }
}
