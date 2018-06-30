using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

using Monopolio_RS232.Comunicacion;
using Monopolio_RS232.Logica;

namespace Monopolio_RS232
{
    /*
        Esta seria la ventana principal donde estaria el tablero. 
    */
    public partial class Principal : Form
    {
        private Form inicial;
        string InputData = string.Empty;
        private Player jugadorLocal;
        private Board board;

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        SerialDataReceivedEventHandler dataReceivedSubscription;

        public Principal(Form inicial, Board board)
        {
            InitializeComponent();
            this.inicial = inicial;
            //this.lbPuerto.Text = this.comPort.PortName;
            this.jugadorLocal = board.getPlayer(0);
            this.board = board;           
            this.btnRollDices.Enabled = false;
            if (jugadorLocal.GetIdAsString() == "00")
            {
                this.btnRollDices.Enabled = true;
            }

            this.btnRollDices.Click += new EventHandler(this.btnRollDices_Click);
            Closing += this.OnWindowClosing;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {          
            DialogResult dialogResult = MessageBox.Show("De verdad quieres salir?", "Saliendo de la partida", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                inicial.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /*
            Aqui deberiamos procesar los datos recibidos y realizar las acciones 
            necesarias sobre nuestros objetos locales.
        */
        private void OnDatosRecebidos(object sender, SerialDataReceivedEventArgs e)
        {
            if (comPort.BytesToRead < 4)
            {
                return;
            }

            byte[] receivedBytes = new byte[4];
            comPort.Read(receivedBytes, 0, 4);
            string primerByte = Instruccion.ByteToString(receivedBytes[1]);
            string segundoByte = Instruccion.ByteToString(receivedBytes[2]);
            Trace.WriteLine("Primer byte: " + primerByte);
            Trace.WriteLine("Segundo byte: " + segundoByte);
            string origen = primerByte.Substring(0, 2);
            string destino = primerByte.Substring(2, 2);

            if (primerByte.Substring(4,4) == Instruccion.PrimerByte.TIRAR_DADOS)
            {
                string dado1Str = segundoByte.Substring(2, 3);
                string dado2Str = segundoByte.Substring(5, 3);

                int dado1 = Convert.ToInt32(dado1Str, 2);
                Trace.WriteLine(dado1);
                int dado2 = Convert.ToInt32(dado2Str, 2);
                Trace.WriteLine(dado2);

                if (jugadorLocal.GetIdAsString() != destino) {
                    dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + dado1);
                    dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + dado2);

                    this.comPort.Write(Instruccion.FormarTrama(
                        Instruccion.FormarPrimerByte(origen, destino, Instruccion.PrimerByte.TIRAR_DADOS),
                        Instruccion.FormarSegundoByteDados(dado1Str, dado2Str)
                        ), 0, 4);
                }
                else if (jugadorLocal.GetIdAsString() == origen)
                {
                    
                    if (dado1 != dado2)
                    {
                        byte nextJugadorLocalId = Convert.ToByte(jugadorLocal.getID() + 1);
                        string nextJugadorLocalIdStrByte = Instruccion.ByteToString(nextJugadorLocalId);
                        string nextJugadorLocalIdStr = nextJugadorLocalIdStrByte.Substring(6, 2);
                        Trace.WriteLine("Siguiente jugador: " + nextJugadorLocalIdStr);
                        this.comPort.Write(Instruccion.FormarTrama(
                        Instruccion.FormarPrimerByte(origen, nextJugadorLocalIdStr, Instruccion.PrimerByte.TIRAR_DADOS),
                        Instruccion.FormarSegundoByteDados(dado1Str, dado2Str)
                        ), 0, 4);
                    }
                    else if (dado1 == dado2)
                    {
                        this.btnRollDices.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.btnRollDices.Enabled = true;
                        });
                    }
                } else
                {
                    this.btnRollDices.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.btnRollDices.Enabled = true;
                    });
                }
            }


            InputData = comPort.ReadExisting();
            Console.WriteLine();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }

        private void SetText(string text)
        {
            this.tbDataReceived.Text += text;
            
        }

        public void SetComPort(SerialPort port)
        {
            this.comPort = port;
            dataReceivedSubscription = new System.IO.Ports.SerialDataReceivedEventHandler(OnDatosRecebidos);
            comPort.DataReceived += dataReceivedSubscription;
            this.lbPuerto.Text = this.comPort.PortName;
        }

        private void btnRollDices_Click(object sender, EventArgs e)
        {
            this.btnRollDices.Enabled = false;
            Random randDado = new Random();
            int numeroDado1 = randDado.Next(1, 7);
            int numeroDado2 = randDado.Next(1, 7);
            dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + numeroDado1);
            dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + numeroDado2);

            string numeroDado1Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado1));
            string numeroDado1Str = numeroDado1Byte.Substring(5);
            string numeroDado2Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado2));
            string numeroDado2Str = numeroDado2Byte.Substring(5);

            this.comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), jugadorLocal.GetIdAsString(), Instruccion.PrimerByte.TIRAR_DADOS),
                Instruccion.FormarSegundoByteDados(numeroDado1Str, numeroDado2Str)
                ), 0, 4);


        }

        private void tbDataReceived_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
