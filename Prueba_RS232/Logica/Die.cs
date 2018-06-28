using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_RS232.Logica
{
    class Die
    {
        public int getFace()
        {
            Random rand = new Random();
            int face = rand.Next(1,6);
            return face;
        }
    }
}
