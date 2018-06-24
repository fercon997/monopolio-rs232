using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_RS232
{
    class Instruccion
    {

        public static string INICIAR_PARTIDA = "0000";

        public static byte[] FormarTrama(byte primerOcteto, byte segundoOctecto)
        {
            byte[] toReturn = { 0x7E, primerOcteto, segundoOctecto, 0x7E };

            foreach (var b in toReturn)
            {
                Console.Write(Convert.ToString(b, 2) + " -");
            }
            return toReturn;
        }

        public static byte FormarPrimerByte(string origen, string destino, string instruccion)
        {
            string v = String.Format("{0}{1}{2}", origen, destino, instruccion);
            return Convert.ToByte(v, 2);
        }

        /*
            El parametro instruccion es de 3 bits y tarjeta es de 5 bits
         */
        public static byte FormarSegundoByte(string instruccion, string propiedad)
        {
            string v = String.Format("{0}{1}", instruccion, propiedad);
            return Convert.ToByte(v, 2);
        }
    }
}
