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
        private int numeroDado1 = 0;
        private int numeroDado2 = 0;

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        delegate void AddToHistoryCallback(string text);

        SerialDataReceivedEventHandler dataReceivedSubscription;

        public Principal(Form inicial, Board board)
        {
            InitializeComponent();
            this.inicial = inicial;
            //this.lbPuerto.Text = this.comPort.PortName;
            this.jugadorLocal = board.getPlayers()[0];
            Trace.WriteLine("JUGADOR LOCAL: " + this.jugadorLocal.getID());
            this.board = board;           
            this.btnRollDices.Enabled = false;
            if (jugadorLocal.GetIdAsString() == "00")
            {
                this.btnRollDices.Enabled = true;
            }
            Closing += this.OnWindowClosing;
            tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.Principal_Paint);
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
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                lbxHistoria.Items.Add("Trama recibida: " + primerByte);
            });
            string segundoByte = Instruccion.ByteToString(receivedBytes[2]);
            Trace.WriteLine("Primer byte: " + primerByte);
            Trace.WriteLine("Segundo byte: " + segundoByte);
            string origen = primerByte.Substring(0, 2);
            string destino = primerByte.Substring(2, 2);
            Trace.WriteLine(String.Format("Origen: {0}\nDestino: {1}", origen, destino));

            if (primerByte.Substring(4,4) == Instruccion.PrimerByte.TIRAR_DADOS)
            {
                leerTramaTirarDados(origen, destino, segundoByte);
            }
            else if (primerByte.Substring(4, 4) == Instruccion.PrimerByte.PROPIEDADES)
            {
                leerTramaPropiedades(origen, destino, segundoByte);
            }

            InputData = comPort.ReadExisting();
            Console.WriteLine();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }

        private void leerTramaTirarDados(String origen, String destino, String segundoByte)
        {
            string dado1Str = segundoByte.Substring(2, 3);
            string dado2Str = segundoByte.Substring(5, 3);

            int dado1 = Convert.ToInt32(dado1Str, 2);
            Trace.WriteLine("Dado 1: " + dado1);
            int dado2 = Convert.ToInt32(dado2Str, 2);
            Trace.WriteLine("Dado 2: " + dado2);

            if (jugadorLocal.GetIdAsString() != destino)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.btnRollDices.Enabled = false;
                    this.btnFinalizarTurno.Enabled = false;
                    lbxHistoria.Items.Add("Jugador que le toca: " + origen);
                });
                dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + dado1);
                dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + dado2);
                // Actualizamos la posicion del jugador que se esta moviendo
                var jugadorMoviendose = board.getPlayer(Convert.ToInt32(origen, 2));
                Trace.WriteLine("Actualizando posicion del jugador que se movio. Id: " + jugadorMoviendose.getID());
                int newPosition = Board.normalizePosition(jugadorMoviendose.getCurrentPosition() + dado1 + dado2);
                jugadorMoviendose.setPosition(newPosition);
                Square pos = board.GetSquares()[newPosition];
                jugadorMoviendose.SetPoisitionX(pos.GetPositionX());
                jugadorMoviendose.SetPoisitionY(pos.GetPositionY());
                tablero.Invalidate();
                Trace.WriteLine(String.Format("Posicion del jugador {0}: {1}, {2} (Casilla: {3})",
                    jugadorMoviendose.getID(),
                    jugadorMoviendose.GetPositionX(),
                    jugadorMoviendose.GetPositionY(),
                    newPosition));

                this.comPort.Write(Instruccion.FormarTrama(
                    Instruccion.FormarPrimerByte(origen, destino, Instruccion.PrimerByte.TIRAR_DADOS),
                    Instruccion.FormarSegundoByteDados(dado1Str, dado2Str)
                    ), 0, 4);
            }
            else if (jugadorLocal.GetIdAsString() == origen)
            {
                if (dado1 != dado2)
                {
                    // Aqui deberiamos hacer las acciones que si de comprar, etc
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.btnFinalizarTurno.Enabled = true;
                    });
                }

                else if (dado1 == dado2)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.btnRollDices.Enabled = true;
                        this.btnFinalizarTurno.Enabled = false;
                        lbxHistoria.Items.Add("Dobles");
                    });
                }
            }
            else if (jugadorLocal.GetIdAsString() == destino)
            {
                Trace.WriteLine(String.Format("Jugador local: {0}  Destino: {1}", jugadorLocal.GetIdAsString(), destino));
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.btnRollDices.Enabled = true;
                    lbxHistoria.Items.Add("SOY YO: " + jugadorLocal.GetIdAsString());
                });
            }
            else // Creo que nunca llegara hasta aqui
            {
                Trace.WriteLine("No creo que pase");
            }
        }

        private void leerTramaPropiedades(String origen, String destino, String segundoByte)
        {
            string propiedadComprada = segundoByte.Substring(3, 5);
            int posicionPropiedad = board.GetHousePositionFromBits(propiedadComprada);

            if (jugadorLocal.GetIdAsString() != destino)
            {
                byte origenByte = Convert.ToByte(origen);
                int origenNumber = Convert.ToInt32(origenByte);

                // board.GetSquares()[posicionPropiedad].SetOwner(origenNumber);
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbxHistoria.Items.Add("Jugador " + origen + " compró la propiedad " + board.GetSquares()[posicionPropiedad].getName());
                });

                this.comPort.Write(Instruccion.FormarTrama(
                    Instruccion.FormarPrimerByte(origen, destino, Instruccion.PrimerByte.PROPIEDADES),
                    Convert.ToByte("000" + propiedadComprada, 2)
                    ), 0, 4);
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbxPropiedades.Items.Add(posicionPropiedad + " " + board.GetSquares()[posicionPropiedad].getName());
                    lbxHistoria.Items.Add("Compré la propiedad " + board.GetSquares()[posicionPropiedad].getName());
                });
            }
        }

        public static void SetText(string text)
        {
            
        }

        public void SetComPort(SerialPort port)
        {
            this.comPort = port;
            dataReceivedSubscription = new System.IO.Ports.SerialDataReceivedEventHandler(OnDatosRecebidos);
            comPort.DataReceived += dataReceivedSubscription;
            this.lbPuerto.Text = this.comPort.PortName;
        }

        private void Principal_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //if (rolledDices)
            //{
                //Square currentSquare = board.movePlayer(jugadorLocal, numeroDado1 + numeroDado2);
                //Trace.WriteLine("Current Position: " + jugadorLocal.getCurrentPosition());

                //jugadorLocal.SetPoisitionX(currentSquare.GetPositionX());
                //jugadorLocal.SetPoisitionY(currentSquare.GetPositionY());
                
                foreach(var j in board.getPlayers())
                {
                    var imagen = (Image)Properties.Resources.ResourceManager.GetObject("player" + (j.getID() + 1));
                    e.Graphics.DrawImage(imagen, j.GetPositionX(), j.GetPositionY(), 30, 30);
                }
            actualizarDatosJugadorLocal();

                
                //e.Graphics.DrawImage(jugadorLocal.GetImage(), jugadorLocal.GetPositionX(), jugadorLocal.GetPositionY(), 30, 30);
                //this.rolledDices = false;
                
            //}
        }

        private void btnRollDices_Click(object sender, EventArgs e)
        {
            this.btnRollDices.Enabled = false;
            Random randDado = new Random();
            numeroDado1 = randDado.Next(1, 7);
            numeroDado2 = randDado.Next(1, 7);
            dice1.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + numeroDado1);
            dice2.Image = (Image)Properties.Resources.ResourceManager.GetObject("dado" + numeroDado2);

            string numeroDado1Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado1));
            string numeroDado1Str = numeroDado1Byte.Substring(5);
            string numeroDado2Byte = Instruccion.ByteToString(Convert.ToByte(numeroDado2));
            string numeroDado2Str = numeroDado2Byte.Substring(5);

            this.btnFinalizarTurno.Enabled = true;
            lbxHistoria.Items.Add("Lanzar dados: " + Instruccion.ByteToString(Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), jugadorLocal.GetIdAsString(), Instruccion.PrimerByte.TIRAR_DADOS)));
            this.comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), jugadorLocal.GetIdAsString(), Instruccion.PrimerByte.TIRAR_DADOS),
                Instruccion.FormarSegundoByteDados(numeroDado1Str, numeroDado2Str)
                ), 0, 4);

            Square currentSquare = board.movePlayer(jugadorLocal, numeroDado1 + numeroDado2);
            Trace.WriteLine("Current Position: " + jugadorLocal.getCurrentPosition());

            jugadorLocal.SetPoisitionX(currentSquare.GetPositionX());
            jugadorLocal.SetPoisitionY(currentSquare.GetPositionY());
            tablero.Invalidate();

            int resultado = currentSquare.doAction(jugadorLocal, board);
            Trace.WriteLine("New player money: " + jugadorLocal.getMoney().getMoney());
            // Esto estaba así en el board, no se si haga falta porque tal vez podamos validarlo dentro del doAction
            if (jugadorLocal.getMoney().isBrokeOut())
            {
                Trace.WriteLine(jugadorLocal, jugadorLocal.getName() + " has been broke out!");
                jugadorLocal.setBrokeOut(true);
            }
            actualizarDatosJugadorLocal();

            // Aquí empieza lo bueno
            if (resultado == 1)
            {
                Trace.WriteLine("Debería enviar el mensaje");
                this.comPort.Write(Instruccion.FormarTrama(
                Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), jugadorLocal.GetIdAsString(), Instruccion.PrimerByte.PROPIEDADES),
                Convert.ToByte("000" + board.GetHouseBits(jugadorLocal.getCurrentPosition()), 2)
                ), 0, 4);
            }
        }

        private void btnFinalizarTurno_Click(object sender, EventArgs e)
        {
            int nextPlayer = jugadorLocal.getID() + 1;
            if (jugadorLocal.getID() == board.getPlayers().Length - 1)
                nextPlayer = 0;

            byte nextJugadorLocalId = Convert.ToByte(nextPlayer);
            string nextJugadorLocalIdStrByte = Instruccion.ByteToString(nextJugadorLocalId);
            string nextJugadorLocalIdStr = nextJugadorLocalIdStrByte.Substring(6, 2);
            Trace.WriteLine("Siguiente jugador: " + nextJugadorLocalIdStr);

            this.btnRollDices.Enabled = false;
            this.btnFinalizarTurno.Enabled = false;
            lbxHistoria.Items.Add("Siguiente jugador: " + nextJugadorLocalIdStr);
            lbxHistoria.Items.Add("     Trama: " + Instruccion.ByteToString(Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), nextJugadorLocalIdStr, Instruccion.PrimerByte.TIRAR_DADOS)));
            // Mandamos 01 y 01 en los dados pero realmente este valor no afecta, solo importa que sea != 0
            this.comPort.Write(Instruccion.FormarTrama(
            Instruccion.FormarPrimerByte(jugadorLocal.GetIdAsString(), nextJugadorLocalIdStr, Instruccion.PrimerByte.TIRAR_DADOS),
            Instruccion.FormarSegundoByteDados("01", "01")
            ), 0, 4);
        }

        private void actualizarDatosJugadorLocal()
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                lbDineroDisponible.Text = this.jugadorLocal.getMoney().getMoney().ToString();
            });
        }
    }
}
