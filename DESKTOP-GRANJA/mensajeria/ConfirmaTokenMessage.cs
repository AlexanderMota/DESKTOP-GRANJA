using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_GRANJA.mensajeria
{
    internal class ConfirmaTokenMessage : ValueChangedMessage<bool>
    {
        public ConfirmaTokenMessage(bool value) : base(value)
        { }
    }
}
