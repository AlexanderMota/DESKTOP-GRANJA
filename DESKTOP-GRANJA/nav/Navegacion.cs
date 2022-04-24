using DESKTOP_GRANJA.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DESKTOP_GRANJA.nav
{
    internal class Navegacion
    {
        internal UserControl CargaLoginUC() => new LoginUC();
    }
}
