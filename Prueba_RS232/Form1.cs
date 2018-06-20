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
    public partial class Form1 : Form
    {
        private SerialPort comPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);

        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;

        delegate void SetTextCallback(string text);

        string InputData = String.Empty;

        public Form1()
        {
            InitializeComponent();
            SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            comPort.DataReceived +=
              new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);

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
            InputData = comPort.ReadExisting();
            System.Diagnostics.Debug.WriteLine(InputData);
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }

        private void SetText(string text)
        {
            this.rtbIncoming.Text += text;
        }

       /* private void btnTest_Click(object sender, EventArgs e)
        {
            SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            comPort.PinChanged += SerialPinChangedEventHandler1;
            try
            {
                comPort.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            comPort.RtsEnable = true;
            comPort.DtrEnable = true;
            btnTest.Enabled = false;
        }*/

        internal void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange SerialPinChange1 = 0;
            bool signalState = false;
            SerialPinChange1 = e.EventType;
            lblCTSStatus.BackColor = Color.Green;
            lblDSRStatus.BackColor = Color.Green;
            lblRIStatus.BackColor = Color.Green;
            lblBreakStatus.BackColor = Color.Green;

            switch (SerialPinChange1)
            {
                case SerialPinChange.Break:
                    lblBreakStatus.BackColor = Color.Red;
                    //MessageBox.Show("Break is Set");
                    break;
                case SerialPinChange.CDChanged:
                    signalState = comPort.CtsHolding;
                    //  MessageBox.Show("CD = " + signalState.ToString());
                    break;
                case SerialPinChange.CtsChanged:
                    signalState = comPort.CDHolding;
                    lblCTSStatus.BackColor = Color.Red;
                    //MessageBox.Show("CTS = " + signalState.ToString());
                    break;
                case SerialPinChange.DsrChanged:
                    signalState = comPort.DsrHolding;
                    lblDSRStatus.BackColor = Color.Red;
                    // MessageBox.Show("DSR = " + signalState.ToString());
                    break;
                case SerialPinChange.Ring:
                    lblRIStatus.BackColor = Color.Red;
                    //MessageBox.Show("Ring Detected");
                    break;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Command1 = txtCommand.Text;
            string CommandSent;
            int Length, j = 0;

            Length = Command1.Length;
            for (int i = 0; i < Length; i++)
            {
                CommandSent = Command1.Substring(j, 1);
                comPort.Write(CommandSent);
                j++;
            }
        }
    }
}
