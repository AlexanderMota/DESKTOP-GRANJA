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

        public ListaTareasVM()
        {
            WeakReferenceMessenger.Default.Register<CambiaCentroMessage>(this, async ( r, m ) =>
            {
                if(m.Value.Length > 0)
                {
                    Properties.Settings.Default.MiCentro = m.Value;
                    GetAllTareasApi(Properties.Settings.Default.MiCentro);
                }
            });
            GetAllTareasApi(Properties.Settings.Default.MiCentro);
        }
        private async void GetAllTareasApi(string centro)
        {
            this.ListaTareas = await tarServ.GetSubtareasAsync(Properties.Settings.Default.Token, centro);
        }
        public void SfDataGrid_MouseDoubleClick() =>
            WeakReferenceMessenger.Default.Send(new DetalleTareaMessage(TareaActual));
    }
}
