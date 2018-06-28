using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prueba_RS232.Logica;

namespace Prueba_RS232
{
    /*
        Esta seria la ventana principal donde estaria el tablero. 
    */
    public partial class Principal : Form
    {
        private Form inicial;
        string InputData = string.Empty;

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        SerialDataReceivedEventHandler dataReceivedSubscription;

        public Principal(Form inicial)
        {
            InitializeComponent();
            this.inicial = inicial;
            this.lbPuerto.Text = this.comPort.PortName;
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
    }
}
