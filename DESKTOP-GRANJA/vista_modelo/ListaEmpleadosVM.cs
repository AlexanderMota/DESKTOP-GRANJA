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
        private int pageSize = 10;
        public int PageSize
        {
            get => pageSize;
            set => SetProperty(ref pageSize, value);
        }
        private int pageNum = 1;
        public int PageNum { get => pageNum; }
        public void PageNumMas()
        {
            SetProperty(ref pageNum, pageNum + 1);
            GetAllEmpleadosApi();
        }
        public void PageNumMenos()
        {
            if (pageNum > 1)
            {
                SetProperty(ref pageNum, pageNum - 1);
                GetAllEmpleadosApi();
            }
        }
        public ListaEmpleadosVM()
        {
            GetAllEmpleadosApi();
            //GetAllTareasApi();
        }
        private async void GetAllEmpleadosApi()
        {
            var res = await empServ.GetAllEmpleadosAsync(
                Properties.Settings.Default.Token, PageSize, PageNum);

            if (res is ObservableCollection<Empleado> emps) ListaEmpleados = emps;
            else if (res is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");
        }
        //private async void GetAllTareasApi() => TareasEmpleado = await tarServ.GetAllTareasAsync(Properties.Settings.Default.Token);
        public async void SfDataGrid_MouseDoubleClick()
        {
            var res = await tarServ.GetTareaByIdEmpleadoAsync(
                Properties.Settings.Default.Token, EmpleadoActual!.Id);

            if (res is ObservableCollection<Tarea> tars) TareasEmpleado = tars;
            else if (res is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM(): ===========> {apiResponse.Message}");
        }
    }
}
