using CommunityToolkit.Mvvm.Messaging.Messages;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.mensajeria
{
    internal class DetalleTareaMessage : ValueChangedMessage<Tarea>
    {
        public DetalleTareaMessage( Tarea t ) : base(t)
        { }
    }
}
