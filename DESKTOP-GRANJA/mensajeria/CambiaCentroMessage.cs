using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.mensajeria
{
    internal class CambiaCentroMessage : ValueChangedMessage<string>
    {
        public CambiaCentroMessage( string value ) : base(value)
        { }
    }
}
