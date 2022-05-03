using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaTareasVM : ObservableObject
    {
        private ObservableCollection<Tarea> listaTareas;
        public ObservableCollection<Tarea> ListaTareas
        {/*
            {
                List<Tarea> listaMostrar = new List<Tarea>();
                foreach (Tarea tarea in this.listaTareas)
                {
                    tarea.
                    listaMostrar.Add(tarea);
                }
                listaTareas;
            }*/
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
