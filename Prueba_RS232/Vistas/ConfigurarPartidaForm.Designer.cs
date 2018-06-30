namespace Monopolio_RS232
{
    partial class ConfigurarPartidaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetSerialPorts = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboHandShaking = new System.Windows.Forms.ComboBox();
            this.btnPortState = new System.Windows.Forms.Button();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.btnHello = new System.Windows.Forms.Button();
            this.rtbIncoming = new System.Windows.Forms.RichTextBox();
            this.rtbOutgoing = new System.Windows.Forms.RichTextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnUnirseAPartida = new System.Windows.Forms.Button();
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.nMaquinaLabel = new System.Windows.Forms.Label();
            this.lbNumeroJugadores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetSerialPorts
            // 
            this.btnGetSerialPorts.Location = new System.Drawing.Point(76, 108);
            this.btnGetSerialPorts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGetSerialPorts.Name = "btnGetSerialPorts";
            this.btnGetSerialPorts.Size = new System.Drawing.Size(250, 64);
            this.btnGetSerialPorts.TabIndex = 0;
            this.btnGetSerialPorts.Text = "Ports";
            this.btnGetSerialPorts.UseVisualStyleBackColor = true;
            this.btnGetSerialPorts.Click += new System.EventHandler(this.btnGetSerialPorts_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(384, 108);
            this.cboPorts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(238, 33);
            this.cboPorts.TabIndex = 2;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(384, 160);
            this.cboBaudRate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(238, 33);
            this.cboBaudRate.TabIndex = 3;
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(384, 219);
            this.cboStopBits.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(238, 33);
            this.cboStopBits.TabIndex = 4;
            // 
            // cboHandShaking
            // 
            this.cboHandShaking.FormattingEnabled = true;
            this.cboHandShaking.Location = new System.Drawing.Point(384, 271);
            this.cboHandShaking.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboHandShaking.Name = "cboHandShaking";
            this.cboHandShaking.Size = new System.Drawing.Size(238, 33);
            this.cboHandShaking.TabIndex = 5;
            // 
            // btnPortState
            // 
            this.btnPortState.Location = new System.Drawing.Point(76, 183);
            this.btnPortState.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPortState.Name = "btnPortState";
            this.btnPortState.Size = new System.Drawing.Size(250, 58);
            this.btnPortState.TabIndex = 11;
            this.btnPortState.Text = "Open";
            this.btnPortState.UseVisualStyleBackColor = true;
            this.btnPortState.Click += new System.EventHandler(this.btnPortState_Click);
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(384, 375);
            this.cboParity.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(238, 33);
            this.cboParity.TabIndex = 12;
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(384, 323);
            this.cboDataBits.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(238, 33);
            this.cboDataBits.TabIndex = 13;
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(76, 252);
            this.btnHello.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(250, 58);
            this.btnHello.TabIndex = 14;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // rtbIncoming
            // 
            this.rtbIncoming.Location = new System.Drawing.Point(738, 164);
            this.rtbIncoming.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtbIncoming.Name = "rtbIncoming";
            this.rtbIncoming.Size = new System.Drawing.Size(390, 248);
            this.rtbIncoming.TabIndex = 15;
            this.rtbIncoming.Text = "";
            // 
            // rtbOutgoing
            // 
            this.rtbOutgoing.Location = new System.Drawing.Point(738, 111);
            this.rtbOutgoing.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtbOutgoing.Name = "rtbOutgoing";
            this.rtbOutgoing.Size = new System.Drawing.Size(390, 37);
            this.rtbOutgoing.TabIndex = 16;
            this.rtbOutgoing.Text = "";
            this.rtbOutgoing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbOutgoing_KeyPress);
            // 
            // btnContinue
            // 

            //this.btnContinue.Location = new System.Drawing.Point(1303, 608);
            //this.btnContinue.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnContinue.Location = new System.Drawing.Point(870, 490);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(150, 44);
            this.btnContinue.TabIndex = 20;
            this.btnContinue.Text = "Continuar";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnUnirseAPartida
            // 
            this.btnUnirseAPartida.Location = new System.Drawing.Point(76, 542);
            this.btnUnirseAPartida.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnUnirseAPartida.Name = "btnUnirseAPartida";
            this.btnUnirseAPartida.Size = new System.Drawing.Size(276, 44);
            this.btnUnirseAPartida.TabIndex = 21;
            this.btnUnirseAPartida.Text = "Unirse a partida";
            this.btnUnirseAPartida.UseVisualStyleBackColor = true;
            this.btnUnirseAPartida.Click += new System.EventHandler(this.btnUnirseAPartida_Click);
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.Location = new System.Drawing.Point(76, 490);
            this.btnCrearPartida.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(276, 44);
            this.btnCrearPartida.TabIndex = 22;
            this.btnCrearPartida.Text = "Crear partida";
            this.btnCrearPartida.UseVisualStyleBackColor = true;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // nMaquinaLabel
            // 
            this.nMaquinaLabel.AutoSize = true;
            this.nMaquinaLabel.Location = new System.Drawing.Point(852, 25);
            this.nMaquinaLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nMaquinaLabel.Name = "nMaquinaLabel";
            this.nMaquinaLabel.Size = new System.Drawing.Size(95, 25);
            this.nMaquinaLabel.TabIndex = 23;
            this.nMaquinaLabel.Text = "Maquina";
            // 
            // lbNumeroJugadores
            // 
            this.lbNumeroJugadores.AutoSize = true;
            this.lbNumeroJugadores.Location = new System.Drawing.Point(112, 31);
            this.lbNumeroJugadores.Name = "lbNumeroJugadores";
            this.lbNumeroJugadores.Size = new System.Drawing.Size(295, 32);
            this.lbNumeroJugadores.TabIndex = 24;
            this.lbNumeroJugadores.Text = "Numero de jugadores:";
            // 
            // ConfigurarPartidaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(1616, 756);
            this.Controls.Add(this.lbNumeroJugadores);
            this.ClientSize = new System.Drawing.Size(1212, 610);
            this.Controls.Add(this.nMaquinaLabel);
            this.Controls.Add(this.btnCrearPartida);
            this.Controls.Add(this.btnUnirseAPartida);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.rtbOutgoing);
            this.Controls.Add(this.rtbIncoming);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.btnPortState);
            this.Controls.Add(this.cboHandShaking);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.btnGetSerialPorts);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ConfigurarPartidaForm";
            this.Text = "Monopolio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetSerialPorts;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboHandShaking;
        private System.Windows.Forms.Button btnPortState;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.RichTextBox rtbIncoming;
        private System.Windows.Forms.RichTextBox rtbOutgoing;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnUnirseAPartida;
        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Label nMaquinaLabel;
        private System.Windows.Forms.Label lbNumeroJugadores;
    }
}

