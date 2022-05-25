using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using System.Diagnostics;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class VerSolicitudVM : ObservableObject
    {
        private Solicitud solicitud = new Solicitud(new Tarea(), new Empleado(),"prueba");
        public Solicitud Solicitud_
        {
            get => solicitud;
            set => SetProperty(ref solicitud, value);
        }

        public VerSolicitudVM()
        {
            WeakReferenceMessenger.Default.Register<VerSolicitudMessage>(this, (r, m) =>
            {
                Trace.WriteLine("VerSolicitudVM m =====> " + m.Value.ToString());
                this.Solicitud_ = m.Value;
                Trace.WriteLine("VerSolicitudVM this.s =====> " + this.Solicitud_.TareaSol.Nombre);
            });
            //Trace.WriteLine("VerSolicitudVM =====> " + Solicitud_.FechaSolicitud);
        }
    }
}
