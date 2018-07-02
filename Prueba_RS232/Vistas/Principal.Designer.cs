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
            this.tabPropiedades = new System.Windows.Forms.TabPage();
            this.lbxHistoria = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
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
            this.lbPuerto.Location = new System.Drawing.Point(1810, 1040);
            this.lbPuerto.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(99, 32);
            this.lbPuerto.TabIndex = 1;
            this.lbPuerto.Text = "Puerto";
            // 
            // btnRollDices
            // 
            this.btnRollDices.Location = new System.Drawing.Point(1365, 236);
            this.btnRollDices.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRollDices.Name = "btnRollDices";
            this.btnRollDices.Size = new System.Drawing.Size(328, 55);
            this.btnRollDices.TabIndex = 21;
            this.btnRollDices.Text = "Lanzar dados";
            this.btnRollDices.UseVisualStyleBackColor = true;
            this.btnRollDices.Click += new System.EventHandler(this.btnRollDices_Click);
            // 
            // dice2
            // 
            this.dice2.Image = ((System.Drawing.Image)(resources.GetObject("dice2.Image")));
            this.dice2.Location = new System.Drawing.Point(1575, 62);
            this.dice2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dice2.Name = "dice2";
            this.dice2.Size = new System.Drawing.Size(161, 141);
            this.dice2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice2.TabIndex = 4;
            this.dice2.TabStop = false;
            // 
            // dice1
            // 
            this.dice1.Image = ((System.Drawing.Image)(resources.GetObject("dice1.Image")));
            this.dice1.Location = new System.Drawing.Point(1305, 62);
            this.dice1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dice1.Name = "dice1";
            this.dice1.Size = new System.Drawing.Size(161, 141);
            this.dice1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice1.TabIndex = 3;
            this.dice1.TabStop = false;
            // 
            // tablero
            // 
            this.tablero.Image = global::Monopolio_RS232.Properties.Resources.tablero;
            this.tablero.Location = new System.Drawing.Point(67, 62);
            this.tablero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(1067, 955);
            this.tablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tablero.TabIndex = 22;
            this.tablero.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHistoria);
            this.tabControl.Controls.Add(this.tabPropiedades);
            this.tabControl.Location = new System.Drawing.Point(1217, 334);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(666, 683);
            this.tabControl.TabIndex = 24;
            // 
            // tabHistoria
            // 
            this.tabHistoria.Controls.Add(this.lbxHistoria);
            this.tabHistoria.Location = new System.Drawing.Point(10, 48);
            this.tabHistoria.Name = "tabHistoria";
            this.tabHistoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistoria.Size = new System.Drawing.Size(646, 625);
            this.tabHistoria.TabIndex = 0;
            this.tabHistoria.Text = "Historia";
            this.tabHistoria.UseVisualStyleBackColor = true;
            // 
            // tabPropiedades
            // 
            this.tabPropiedades.Controls.Add(this.listBox2);
            this.tabPropiedades.Location = new System.Drawing.Point(10, 48);
            this.tabPropiedades.Name = "tabPropiedades";
            this.tabPropiedades.Padding = new System.Windows.Forms.Padding(3);
            this.tabPropiedades.Size = new System.Drawing.Size(646, 625);
            this.tabPropiedades.TabIndex = 1;
            this.tabPropiedades.Text = "Propiedades";
            this.tabPropiedades.UseVisualStyleBackColor = true;
            // 
            // lbxHistoria
            // 
            this.lbxHistoria.FormattingEnabled = true;
            this.lbxHistoria.ItemHeight = 31;
            this.lbxHistoria.Location = new System.Drawing.Point(3, 0);
            this.lbxHistoria.Name = "lbxHistoria";
            this.lbxHistoria.Size = new System.Drawing.Size(643, 624);
            this.lbxHistoria.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 31;
            this.listBox2.Items.AddRange(new object[] {
            "Propiedades"});
            this.listBox2.Location = new System.Drawing.Point(3, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(643, 624);
            this.listBox2.TabIndex = 25;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1959, 1090);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tablero);
            this.Controls.Add(this.btnRollDices);
            this.Controls.Add(this.dice2);
            this.Controls.Add(this.dice1);
            this.Controls.Add(this.lbPuerto);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
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
        private System.Windows.Forms.ListBox listBox2;
    }
}