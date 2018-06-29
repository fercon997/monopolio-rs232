using System;
using System.Collections.Generic;
using System.Text;

namespace Monopolio_RS232.Comunicacion
{
    public delegate void DatosRecibidosHandler(object source, DatosRecibidosEvent e);

    public class DatosRecibidosEvent: EventArgs
    {
        private string EventInfo;
        public DatosRecibidosEvent(string Text)
        {
            EventInfo = Text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }


}
