using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaTareasVM : ObservableObject
    {
        private ObservableCollection<Tarea> listaTareas;
        public ObservableCollection<Tarea> ListaTareas
        {
            get => listaTareas;
            set => SetProperty(ref this.listaTareas, value);
        }

        public ListaTareasVM()
        {
            GetAllTareasApi();
        }
        private async void GetAllTareasApi()
        {

            this.ListaTareas =
                await new DBApi().GetAllTareas(Properties.Settings.Default.Token);

            Trace.WriteLine("===================> cargando lista: ");
            foreach (Tarea tarea in this.ListaTareas)
            {
                Trace.WriteLine(tarea.Nombre);
            }
        }
    }
}
