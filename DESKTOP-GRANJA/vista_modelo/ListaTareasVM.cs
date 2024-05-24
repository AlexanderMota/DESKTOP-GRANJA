using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaTareasVM : ObservableObject
    {
        private TareaService tarServ = new TareaService();

        private Tarea tareaActual;
        public Tarea TareaActual
        {
            get => tareaActual;
            set => SetProperty(ref this.tareaActual, value);
        }
        private ObservableCollection<Tarea> listaTareas = new ObservableCollection<Tarea>();
        public ObservableCollection<Tarea>? ListaTareas
        {
            get => listaTareas;
            set => SetProperty(ref this.listaTareas!, value);
        }
        private int pageSize = 10;
        public int PageSize
        {
            get => pageSize;
            set => SetProperty(ref pageSize, value);
        }
        private int pageNum = 1;
        public int PageNum { get => pageNum; }
        public void PageNumMas() {  
            SetProperty(ref pageNum, pageNum+1);
            GetSubtareasAsync(Properties.Settings.Default.MiCentro);
        }
        public void PageNumMenos()
        {
            if (pageNum > 1)
            {
                SetProperty(ref pageNum, pageNum-1);
                GetSubtareasAsync(Properties.Settings.Default.MiCentro);
            }
        }

        public ListaTareasVM()
        {
            WeakReferenceMessenger.Default.Register<CambiaCentroMessage>(this, async ( r, m ) =>
            {
                if(m.Value.Length > 0)
                {
                    Properties.Settings.Default.MiCentro = m.Value;
                    GetSubtareasAsync(Properties.Settings.Default.MiCentro);
                }
            });
            GetSubtareasAsync(Properties.Settings.Default.MiCentro);
        }
        private async void GetSubtareasAsync( string centro)
        {
            var resultado = await tarServ.GetSubtareasAsync(Properties.Settings.Default.Token, centro, PageSize, PageNum);
            if (resultado is ObservableCollection<Tarea> departs) ListaTareas = departs;
            else if (resultado is ApiResponse apiResponse)
                Trace.WriteLine($"DetalleTareaVM.GetDepartamentos(): ===========> {apiResponse.Message}");
        }
        public void SfDataGrid_MouseDoubleClick() =>
            WeakReferenceMessenger.Default.Send(new DetalleTareaMessage(TareaActual));
    }
}
