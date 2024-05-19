﻿using CommunityToolkit.Mvvm.ComponentModel;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.modelos;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class ListaTareasVM : ObservableObject
    {
        private TareaService tarServ = new TareaService();
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
           // Trace.WriteLine("===================> cargando lista: GetAllTareasApi()");

            this.ListaTareas = await tarServ.GetAllTareasAsync();

            //Trace.WriteLine("===================> cargando lista: ");
            foreach (Tarea tarea in this.ListaTareas)
            {
                Trace.WriteLine(tarea.Nombre);
            }
        }
    }
}
