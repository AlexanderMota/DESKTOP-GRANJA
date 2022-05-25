using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System.Collections.ObjectModel;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaEmpleadosVM : ObservableObject
    {
        private ObservableCollection<Empleado> listaEmpleados;
        public ObservableCollection<Empleado> ListaEmpleados
        {
            get => listaEmpleados;
            set => SetProperty(ref this.listaEmpleados, value);
        }

        public ListaEmpleadosVM()
        {
            GetAllEmpleadosApi();
        }
        private async void GetAllEmpleadosApi()
        {

            this.ListaEmpleados =
                await new DBApi().GetAllEmpleados(Properties.Settings.Default.Token);

        }
    }
}
