using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;


namespace Prueba_RS232
{
    /*
        En esta ventana deberiamos poner nada mas el select del puerto,
        la configuracion de velocidad, paridad, etc se hace directo en
        el codigo. 

        Aqui deberiamos poner el boton de crear partida o unirse
    */
    public partial class Form1 : Form
    {
        private SerialPort comPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);

        delegate void SetNumeroMaquinaCallback(string numero);

        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;

        delegate void SetTextCallback(string text);

        string nMaquina = "sin asignar";

        string InputData = String.Empty;
        SerialDataReceivedEventHandler dataReceivedSubscription; 

        public Form1()
        {
            InitializeComponent();
            dataReceivedSubscription = new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            comPort.DataReceived += dataReceivedSubscription;
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
            cboBaudRate.Items.Add(300);
            cboBaudRate.Items.Add(600);
            cboBaudRate.Items.Add(1200);
            cboBaudRate.Items.Add(2400);
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
            cboDataBits.Items.Add(7);
            cboDataBits.Items.Add(8);
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
            byte[] receivedBytes = new byte[4];
            comPort.Read(receivedBytes, 0, 4);
            string control = Convert.ToString(receivedBytes[1], 2);
            control = control.PadLeft(9 - control.Length, '0');
            string inst = Convert.ToString(receivedBytes[2], 2);
            inst = inst.PadLeft(9 - inst.Length, '0');

            Console.WriteLine("Control: " + control);
            string origen = control.Substring(0, 2);
            string destino = control.Substring(2, 2);

            if (control.Substring(4,4) == "0000")
            {
                if (inst.Substring(0,5) == "10000")
                {
                    if (nMaquina != destino)
                    {
                        Console.WriteLine("Uniendose a partida");
                        var nJugador = Convert.ToInt32(inst.Substring(6, 2) + 1);
                        var strNumeroJugador = Convert.ToString(nJugador, 2);
                        strNumeroJugador = strNumeroJugador.PadLeft(3 - strNumeroJugador.Length, '0');
                        this.BeginInvoke(new SetNumeroMaquinaCallback(SetMaquina), new object[] { strNumeroJugador });

                        Console.WriteLine(strNumeroJugador);
                        comPort.Write(Instruccion.FormarTrama(
                            Instruccion.FormarPrimerByte("00", "00", "0000"),
                            Instruccion.FormarSegundoByte("100000", strNumeroJugador)),
                            0, 4);
                    }              
                }
            } else
            {
                Console.WriteLine("Fuckit");
            }

            InputData = BitConverter.ToString(receivedBytes);
            System.Diagnostics.Debug.WriteLine(InputData);
            Console.WriteLine(InputData);
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });

            }
        }

        private void SetText(string text)
        {
            this.rtbIncoming.Text += text;
        }      

        private void btnPortState_Click(object sender, EventArgs e)
        {
            if (btnPortState.Text == "Closed")
            {
                btnPortState.Text = "Open";
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
            else if (btnPortState.Text == "Open")
            {
                btnPortState.Text = "Closed";
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
            var nextWindow = new Principal();
            nextWindow.SetComPort(this.comPort);
            // Importante cancelar la subscripcion, asi permitimos a la nueva ventana
            // manejar los datos del puerto
            comPort.DataReceived -= dataReceivedSubscription;
            nextWindow.ShowDialog();
            this.Hide();
        }


        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            // btnUnirseAPartida.Enabled = false;
            // Enviar trama de inicio de partida
            this.SetMaquina("00");
            comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte(this.nMaquina, "00", "0000"),
                Instruccion.FormarSegundoByte("100", "00000")),
                0, 4);
        }

        private void btnUnirseAPartida_Click(object sender, EventArgs e)
        {
            /*
                Esperar a que recibamos una instruccion de inicio de partida           
            */
        }

        private void SetMaquina(string numero)
        {
            this.nMaquina = numero;
            this.nMaquinaLabel.Text = this.nMaquina;
        }
    }
}
