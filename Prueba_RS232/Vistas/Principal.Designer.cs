namespace Monopolio_RS232
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.lbPuerto = new System.Windows.Forms.Label();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.btnRollDices = new System.Windows.Forms.Button();
            this.dice2 = new System.Windows.Forms.PictureBox();
            this.dice1 = new System.Windows.Forms.PictureBox();
            this.tablero = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHistoria = new System.Windows.Forms.TabPage();
            this.lbxHistoria = new System.Windows.Forms.ListBox();
            this.tabPropiedades = new System.Windows.Forms.TabPage();
            this.lbxPropiedades = new System.Windows.Forms.ListBox();
            this.btnFinalizarTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDineroDisponible = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabHistoria.SuspendLayout();
            this.tabPropiedades.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(1382, 19);
            this.lbPuerto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(75, 25);
            this.lbPuerto.TabIndex = 1;
            this.lbPuerto.Text = "Puerto";
            // 
            // btnRollDices
            // 
            this.btnRollDices.Location = new System.Drawing.Point(1014, 192);
            this.btnRollDices.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRollDices.Name = "btnRollDices";
            this.btnRollDices.Size = new System.Drawing.Size(310, 44);
            this.btnRollDices.TabIndex = 21;
            this.btnRollDices.Text = "Lanzar dados";
            this.btnRollDices.UseVisualStyleBackColor = true;
            this.btnRollDices.Click += new System.EventHandler(this.btnRollDices_Click);
            // 
            // dice2
            // 
            this.dice2.Image = ((System.Drawing.Image)(resources.GetObject("dice2.Image")));
            this.dice2.Location = new System.Drawing.Point(1204, 50);
            this.dice2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dice2.Name = "dice2";
            this.dice2.Size = new System.Drawing.Size(121, 114);
            this.dice2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice2.TabIndex = 4;
            this.dice2.TabStop = false;
            // 
            // dice1
            // 
            this.dice1.Image = ((System.Drawing.Image)(resources.GetObject("dice1.Image")));
            this.dice1.Location = new System.Drawing.Point(1014, 50);
            this.dice1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dice1.Name = "dice1";
            this.dice1.Size = new System.Drawing.Size(121, 114);
            this.dice1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice1.TabIndex = 3;
            this.dice1.TabStop = false;
            // 
            // tablero
            // 
            this.tablero.Image = global::Monopolio_RS232.Properties.Resources.tablero;
            this.tablero.Location = new System.Drawing.Point(50, 50);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(800, 770);
            this.tablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tablero.TabIndex = 22;
            this.tablero.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHistoria);
            this.tabControl.Controls.Add(this.tabPropiedades);
            this.tabControl.Location = new System.Drawing.Point(913, 269);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 551);
            this.tabControl.TabIndex = 24;
            // 
            // tabHistoria
            // 
            this.tabHistoria.Controls.Add(this.lbxHistoria);
            this.tabHistoria.Location = new System.Drawing.Point(8, 39);
            this.tabHistoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHistoria.Name = "tabHistoria";
            this.tabHistoria.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHistoria.Size = new System.Drawing.Size(484, 504);
            this.tabHistoria.TabIndex = 0;
            this.tabHistoria.Text = "Historia";
            this.tabHistoria.UseVisualStyleBackColor = true;
            // 
            // lbxHistoria
            // 
            this.lbxHistoria.FormattingEnabled = true;
            this.lbxHistoria.ItemHeight = 25;
            this.lbxHistoria.Location = new System.Drawing.Point(2, 0);
            this.lbxHistoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxHistoria.Name = "lbxHistoria";
            this.lbxHistoria.Size = new System.Drawing.Size(483, 504);
            this.lbxHistoria.TabIndex = 0;
            // 
            // tabPropiedades
            // 
            this.tabPropiedades.Controls.Add(this.lbxPropiedades);
            this.tabPropiedades.Location = new System.Drawing.Point(8, 39);
            this.tabPropiedades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPropiedades.Name = "tabPropiedades";
            this.tabPropiedades.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPropiedades.Size = new System.Drawing.Size(484, 504);
            this.tabPropiedades.TabIndex = 1;
            this.tabPropiedades.Text = "Propiedades";
            this.tabPropiedades.UseVisualStyleBackColor = true;
            // 
            // lbxPropiedades
            // 
            this.lbxPropiedades.FormattingEnabled = true;
            this.lbxPropiedades.ItemHeight = 25;
            this.lbxPropiedades.Items.AddRange(new object[] {
            "Propiedades"});
            this.lbxPropiedades.Location = new System.Drawing.Point(2, 5);
            this.lbxPropiedades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxPropiedades.Name = "lbxPropiedades";
            this.lbxPropiedades.Size = new System.Drawing.Size(483, 504);
            this.lbxPropiedades.TabIndex = 25;
            // 
            // btnFinalizarTurno
            // 
            this.btnFinalizarTurno.Enabled = false;
            this.btnFinalizarTurno.Location = new System.Drawing.Point(1212, 836);
            this.btnFinalizarTurno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinalizarTurno.Name = "btnFinalizarTurno";
            this.btnFinalizarTurno.Size = new System.Drawing.Size(200, 44);
            this.btnFinalizarTurno.TabIndex = 26;
            this.btnFinalizarTurno.Text = "Finalizar turno";
            this.btnFinalizarTurno.UseVisualStyleBackColor = true;
            this.btnFinalizarTurno.Click += new System.EventHandler(this.btnFinalizarTurno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 846);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Dinero disponible:";
            // 
            // lbDineroDisponible
            // 
            this.lbDineroDisponible.AutoSize = true;
            this.lbDineroDisponible.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbDineroDisponible.Location = new System.Drawing.Point(241, 846);
            this.lbDineroDisponible.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDineroDisponible.Name = "lbDineroDisponible";
            this.lbDineroDisponible.Size = new System.Drawing.Size(24, 25);
            this.lbDineroDisponible.TabIndex = 28;
            this.lbDineroDisponible.Text = "0";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 914);
            this.Controls.Add(this.lbDineroDisponible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFinalizarTurno);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tablero);
            this.Controls.Add(this.btnRollDices);
            this.Controls.Add(this.dice2);
            this.Controls.Add(this.dice1);
            this.Controls.Add(this.lbPuerto);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Principal";
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabHistoria.ResumeLayout(false);
            this.tabPropiedades.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPuerto;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.PictureBox dice1;
        private System.Windows.Forms.PictureBox dice2;
        private System.Windows.Forms.Button btnRollDices;
        private System.Windows.Forms.PictureBox tablero;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHistoria;
        private System.Windows.Forms.ListBox lbxHistoria;
        private System.Windows.Forms.TabPage tabPropiedades;
        private System.Windows.Forms.ListBox lbxPropiedades;
        private System.Windows.Forms.Button btnFinalizarTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDineroDisponible;
    }
}