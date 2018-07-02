using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using Monopolio_RS232.Logica;
using System.Diagnostics;
using System.Drawing;
using Monopolio_RS232.Comunicacion;

namespace Monopolio_RS232
{
    /*
        En esta ventana deberiamos poner nada mas el select del puerto,
        la configuracion de velocidad, paridad, etc se hace directo en
        el codigo. 

        Aqui deberiamos poner el boton de crear partida o unirse
    */
    public partial class ConfigurarPartidaForm : Form
    {
        private SerialPort comPort = new SerialPort();
        Player jugadorLocal;
        private Board BOARD = new Board();
        private ServicioTransmision servicioTransmision;
        private bool JOIN_MATCH = false;

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);

        delegate void SetJugadorCallback(Player jugador);

        delegate void SetTextCallback(string text);

        string InputData = String.Empty;
        SerialDataReceivedEventHandler dataReceivedSubscription; 

        public ConfigurarPartidaForm()
        {
            InitializeComponent();
            servicioTransmision = new ServicioTransmision(comPort);
            dataReceivedSubscription = new SerialDataReceivedEventHandler(port_DataReceived_1);
            comPort.DataReceived += dataReceivedSubscription;

            btnContinue.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetSerialPorts_Click(object sender, EventArgs e)
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            //Com Ports
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                cboPorts.Items.Add(ArrayComPortsNames[index]);
            } while (!((ArrayComPortsNames[index] == ComPortName) ||
              (index == ArrayComPortsNames.GetUpperBound(0))));
            Array.Sort(ArrayComPortsNames);

            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }

            //get first item print in text
            cboPorts.Text = ArrayComPortsNames[0];

            //Baud Rate
            cboBaudRate.Items.Add(2400);
            cboBaudRate.Items.Add(300);
            cboBaudRate.Items.Add(600);
            cboBaudRate.Items.Add(1200);
            cboBaudRate.Items.Add(9600);
            cboBaudRate.Items.Add(14400);
            cboBaudRate.Items.Add(19200);
            cboBaudRate.Items.Add(38400);
            cboBaudRate.Items.Add(57600);
            cboBaudRate.Items.Add(115200);
            cboBaudRate.Items.ToString();

            //get first item print in text
            cboBaudRate.Text = cboBaudRate.Items[0].ToString();
            //Data Bits
            cboDataBits.Items.Add(8);
            cboDataBits.Items.Add(7);
            //get the first item print it in the text 
            cboDataBits.Text = cboDataBits.Items[0].ToString();

            //Stop Bits
            cboStopBits.Items.Add("One");
            cboStopBits.Items.Add("OnePointFive");
            cboStopBits.Items.Add("Two");
            //get the first item print in the text
            cboStopBits.Text = cboStopBits.Items[0].ToString();

            //Parity 
            cboParity.Items.Add("None");
            cboParity.Items.Add("Even");
            cboParity.Items.Add("Mark");
            cboParity.Items.Add("Odd");
            cboParity.Items.Add("Space");

            //get the first item print in the text

            cboParity.Text = cboParity.Items[0].ToString();

            //Handshake
            cboHandShaking.Items.Add("None");
            cboHandShaking.Items.Add("XOnXOff");
            cboHandShaking.Items.Add("RequestToSend");
            cboHandShaking.Items.Add("RequestToSendXOnXOff");

            //get the first item print it in the text 
            cboHandShaking.Text = cboHandShaking.Items[0].ToString();
        }

        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            if (comPort.BytesToRead < 4)
            {
                return;
            }
            Trace.WriteLine("Recibiendo");
            byte[] receivedBytes = new byte[4];
            comPort.Read(receivedBytes, 0, 4);
            string primerByte = Instruccion.ByteToString(receivedBytes[1]);
            string segundoByte = Instruccion.ByteToString(receivedBytes[2]);
            Trace.WriteLine("Primer byte: " + primerByte);
            Trace.WriteLine("Segundo byte: " + segundoByte);

            string origen = primerByte.Substring(0, 2);
            string destino = primerByte.Substring(2, 2);
            string currentPlayer = "Sin asignar";
            if (jugadorLocal != null)
                currentPlayer = jugadorLocal.GetIdAsString(); 

            if (primerByte.Substring(4,4) == Instruccion.PrimerByte.INICIAR_PARTIDA)
            {
                if (segundoByte.Substring(0,5) == Instruccion.SegundoByte.CONFIGURAR_PARTIDA)
                {
                    Trace.WriteLine("Anunciar o crear: " + segundoByte.Substring(5, 1));
                    if (segundoByte.Substring(5, 1) == Instruccion.SegundoByte.ANUNCIAR)
                    {
                        // Obtenemos los dos ultimos bits del segundo byte que representan el numero de
                        // jugadores y lo convertimos a una variable de tipo int para poder sumarle
                        var binaryJugadoresPorAgregar = segundoByte.Substring(6, 2);
                        var jugadoresPorAgregar = Convert.ToInt32(segundoByte.Substring(6, 2), 2);
                        Trace.WriteLine("Numero de jugadores que debemos crear localmente: " + jugadoresPorAgregar);
                        // Como solo son dos bits, el maximo valor que se puede representar es 3, 
                        // pero el 11 representa 4 jugadores.
                        var jugadoresTotales = jugadoresPorAgregar + 1;
                        var listaJugadores = new List<Player>();
                        listaJugadores.Add(jugadorLocal);
                        Trace.WriteLine("Local id: " + jugadorLocal.getID());
                        //Creamos los jugadores faltantes
                        for (int i = 0; i <= jugadoresPorAgregar; i++)
                        {
                            if (i != jugadorLocal.getID())
                            {
                                listaJugadores.Add(new Player(i, i.ToString()));
                            }
                        }
                        BOARD.SetPlayers(listaJugadores.ToArray());
                        // Boleteo temporal para cambiarle el texto al label desde otro thread
                        this.lbNumeroJugadores.BeginInvoke((MethodInvoker)delegate () {
                            this.lbNumeroJugadores.Text = "Numero de jugadores: " + BOARD.getPlayers().Length; ;
                        });

                        if (jugadorLocal.GetIdAsString() != destino)
                            AnunciarJugadores(origen, destino, binaryJugadoresPorAgregar);
                        else
                            // Ya terminamos de configurar la partida, ahora se deberia 
                            // mostrar el tablero con las opciones para continuar el juego
                            Trace.WriteLine("Ya todas las maquinas recibieron y manejaron el anuncio de jugadores");
                    } else
                    {
                        // Como estamos configurando una partida, esto pasara en las maquinas que 
                        // todavia no han recibido la trama de creacion de partida
                        if (jugadorLocal == null)
                        {
                            Trace.WriteLine("Uniendose a partida");
                            var nJugador = Convert.ToInt32(segundoByte.Substring(6, 2), 2);
                            Trace.WriteLine("Numero de jugador recibido: " + nJugador);
                            nJugador = nJugador + 1;
                            var strNumeroJugador = Convert.ToString(nJugador, 2).PadLeft(2, '0');
                            Trace.WriteLine("Nuevo numero de jugador: " + strNumeroJugador);
                            Player newPlayer = new Player(nJugador, strNumeroJugador);
                            this.BeginInvoke(new SetJugadorCallback(SetJugador), new object[] { newPlayer });

                            Trace.WriteLine("Emitiendo mensaje de crear partida");
                            comPort.Write(Instruccion.FormarTrama(
                                Instruccion.FormarPrimerByte(origen, destino, Instruccion.PrimerByte.INICIAR_PARTIDA),
                                Instruccion.FormarSegundoByte(
                                    Instruccion.SegundoByte.CONFIGURAR_PARTIDA + Instruccion.SegundoByte.CONTAR,
                                    newPlayer.GetIdAsString())),
                                    0, 4);
                        }
                        else
                        {
                            Trace.WriteLine("Mensaje llego al destino");
                            var binaryJugadoresPorAgregar = segundoByte.Substring(6, 2);
                            // Anunciamos la cantidad de jugadores, y cuando el mensaje vuelva a llegar
                            // a la maquina creadora, esta actualiza su lista de jugadores
                            AnunciarJugadores(origen, destino, binaryJugadoresPorAgregar);
                        }
                    }
                    this.btnContinue.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.btnContinue.Enabled = true;
                    });
                }
            } else
            {
                Trace.WriteLine("Fuckit");
            }

            InputData = BitConverter.ToString(receivedBytes);
            Trace.WriteLine(InputData);
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });

            }
        }

        private void AnunciarJugadores(string origen, string destino, string numeroFaltante)
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

        private void SetText(string text)
        {
            this.rtbIncoming.Text += text;
        }      

        private void btnPortState_Click(object sender, EventArgs e)
        {
            if (btnPortState.Text == "Open")
            {
                btnPortState.Text = "Close";
                comPort.PortName = Convert.ToString(cboPorts.Text);
                comPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                comPort.DataBits = Convert.ToInt16(cboDataBits.Text);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                try
                {
                    comPort.Open();
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btnPortState.Text == "Close")
            {
                btnPortState.Text = "Open";
                comPort.Close();
            }
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            try
            {
                comPort.Write("Hello World!");
            } catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rtbOutgoing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // enter key  
            {
                try
                {
                    comPort.Write("\r\n");
                } catch(InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                rtbOutgoing.Text = "";
            }
            else if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                e.Handled = true; // ignores anything else outside printable ASCII range  
            }
            else
            {
                try
                {
                    comPort.Write(e.KeyChar.ToString());
                } catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            var nextWindow = new Principal(this, BOARD);
            nextWindow.SetComPort(this.comPort);
            // Importante cancelar la subscripcion, asi permitimos a la nueva ventana
            // manejar los datos del puerto
            comPort.DataReceived -= dataReceivedSubscription;
            nextWindow.Show();
            this.Hide();
        }


        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            btnUnirseAPartida.Enabled = false;
            this.JOIN_MATCH = true;
            // Enviar trama de inicio de partida
            this.jugadorLocal = new Player(0, "Creador de partida");
            this.SetJugador(jugadorLocal);
            Trace.WriteLine("Creando partida");
            try
            {
                comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), jugadorLocal.GetIdAsString(), Instruccion.PrimerByte.INICIAR_PARTIDA),
                Instruccion.FormarSegundoByte(
                    Instruccion.SegundoByte.CONFIGURAR_PARTIDA + Instruccion.SegundoByte.CONTAR,
                    jugadorLocal.GetIdAsString())),
                0, 4);
            } catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnirseAPartida_Click(object sender, EventArgs e)
        {
            /*
                Esperar a que recibamos una instruccion de inicio de partida           
            */
            
            this.JOIN_MATCH = true;
        }

        private void SetJugador(Player jugador)
        {
            this.jugadorLocal = jugador;
            this.nMaquinaLabel.Text = String.Format("({0}) {1}", jugador.GetIdAsString(), jugador.getName()) ;
        }
    }
}
