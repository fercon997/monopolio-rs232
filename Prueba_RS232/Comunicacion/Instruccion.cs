using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_RS232.Comunicacion
{
    public static class Instruccion
    {
        public static class PrimerByte
        {
            public static string INICIAR_PARTIDA = "0000";
            public static string TIRAR_DADOS = "0001";
            public static string SUBASTA = "0010";
            public static string RESPUESTA_SUBASTA = "0011";
            public static string PROPIEDADES = "0100";
            public static string TOMAR_TARJETA = "0101";
            public static string RETIRARSE_DEL_JUEGO = "0110";
            public static string VICTORIA = "0111";
        }

        public static class SegundoByte
        {
            public static string CONFIGURAR_PARTIDA = "10000";
            public static string CONTAR = "0";
            public static string ANUNCIAR = "1";
        }

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

        public static String ByteToString(byte b)
        {
            string bStr = Convert.ToString(b, 2);
            return bStr.PadLeft(8, '0');
        }
    }
}
