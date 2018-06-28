using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_RS232.Comunicacion
{
    /* TODO:
             Esta clase es la que se debe encargar de manejar el SerialPort, es decir,
             aqui se deben implementar el listener de DataReceived y tambien debemos 
             tener los metodos que permitan enviar mensajes.

             Deberia tener sus propios delegates o algo por el estilo que implementen
             los Forms que quieran manejar los eventos de recibir datos etc.
    */
    class ServicioTransmicion
    {
        private SerialPort comPort;

        public ServicioTransmicion(SerialPort serialPort)
        {
            this.comPort = serialPort;
        }

        public void AnunciarJugadores(string origen, string destino, string numeroFaltante)
        {
            byte[] toSend = Instruccion.FormarTrama(
                                Instruccion.FormarPrimerByte(origen, destino, Instruccion.PrimerByte.INICIAR_PARTIDA),
                                Instruccion.FormarSegundoByte(
                                    Instruccion.SegundoByte.CONFIGURAR_PARTIDA + Instruccion.SegundoByte.ANUNCIAR,
                                    numeroFaltante));
            foreach (byte b in toSend)
            {
                Trace.WriteLine(Instruccion.ByteToString(b));
            }
            comPort.Write(toSend, 0, 4);
        }
    }
}
