using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;

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

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        SerialDataReceivedEventHandler dataReceivedSubscription;

        public Principal(Form inicial)
        {
            InitializeComponent();
            this.inicial = inicial;
            this.lbPuerto.Text = this.comPort.PortName;

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
        }

        private void btnRollDices_Click(object sender, EventArgs e)
        {
            Random dado1rand = new Random();
            this.dice1.Image = Image.FromFile("../../Resources/" + dados[dado1rand.Next(6)] + ".png");
            this.dice2.Image = Image.FromFile("../../Resources/" + dados[dado1rand.Next(6)] + ".png");
        }
    }
}
