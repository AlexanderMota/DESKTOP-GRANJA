using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaEmpleadosVM : ObservableObject
    {
        private EmpleadoService empServ = new EmpleadoService();
        private TareaService tarServ = new TareaService();
        private Empleado? empleadoActual;
        public Empleado? EmpleadoActual
        {
            get => empleadoActual;
            set => SetProperty(ref empleadoActual, value);
        }
        private ObservableCollection<Empleado>? listaEmpleados;
        public ObservableCollection<Empleado>? ListaEmpleados
        {
            get => listaEmpleados;
            set => SetProperty(ref listaEmpleados, value);
        }
        private ObservableCollection<Tarea>? tareasEmpleado;
        public ObservableCollection<Tarea>? TareasEmpleado
        {
            get => tareasEmpleado;
            set => SetProperty(ref tareasEmpleado, value);
        }

        public ListaEmpleadosVM()
        {
            GetAllEmpleadosApi();
            //GetAllTareasApi();
        }
        private async void GetAllEmpleadosApi() => ListaEmpleados = await empServ.GetAllEmpleadosAsync(Properties.Settings.Default.Token);
        //private async void GetAllTareasApi() => TareasEmpleado = await tarServ.GetAllTareasAsync(Properties.Settings.Default.Token);
        public async void SfDataGrid_MouseDoubleClick() => TareasEmpleado = await tarServ.GetTareaByIdEmpleadoAsync(Properties.Settings.Default.Token, EmpleadoActual!.Id);
    }
}
