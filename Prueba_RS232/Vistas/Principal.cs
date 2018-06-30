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
        private string[] dados = new string[] { "dado1", "dado2", "dado3", "dado4", "dado5", "dado6" };
        private Player jugadorLocal;

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        SerialDataReceivedEventHandler dataReceivedSubscription;

        public Principal(Form inicial)
        {
            InitializeComponent();
            this.inicial = inicial;
            //this.lbPuerto.Text = this.comPort.PortName;

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

            byte[] receivedBytes = new byte[4];
            comPort.Read(receivedBytes, 0, 4);
            string primerByte = Instruccion.ByteToString(receivedBytes[1]);
            string segundoByte = Instruccion.ByteToString(receivedBytes[2]);
            Trace.WriteLine("Primer byte: " + primerByte);
            Trace.WriteLine("Segundo byte: " + segundoByte);
            //this.tbDataReceived.Text = Convert.To primerByte + segundoByte;

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

        // public void SetJugadorLocal(Player jugadorLocal)
        //{
        //    this.jugadorLocal = jugadorLocal;
        //}

        private void btnRollDices_Click(object sender, EventArgs e)
        {
            Random randDado = new Random();
            int numeroDado1 = randDado.Next(6);
            int numeroDado2 = randDado.Next(6);
            this.dice1.Image = Image.FromFile("../../Resources/" + dados[numeroDado1] + ".png");
            this.dice2.Image = Image.FromFile("../../Resources/" + dados[numeroDado2] + ".png");

            string numeroDado1Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado1 + 1));
            string numeroDado1Str = numeroDado1Byte.Substring(5);
            string numeroDado2Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado2 + 1));
            string numeroDado2Str = numeroDado2Byte.Substring(5);

            this.comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte("00", "00", Instruccion.PrimerByte.TIRAR_DADOS),
                Instruccion.FormarSegundoByteDados(numeroDado1Str, numeroDado2Str)
                ), 0, 4);


        }

    }
}
