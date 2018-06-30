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
            this.tbDataReceived = new System.Windows.Forms.TextBox();
            this.lbPuerto = new System.Windows.Forms.Label();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.btnRollDices = new System.Windows.Forms.Button();
            this.dice2 = new System.Windows.Forms.PictureBox();
            this.dice1 = new System.Windows.Forms.PictureBox();
            this.pbTablero = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTablero)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDataReceived
            // 
            this.tbDataReceived.Location = new System.Drawing.Point(967, 453);
            this.tbDataReceived.Margin = new System.Windows.Forms.Padding(6);
            this.tbDataReceived.Multiline = true;
            this.tbDataReceived.Name = "tbDataReceived";
            this.tbDataReceived.Size = new System.Drawing.Size(416, 206);
            this.tbDataReceived.TabIndex = 0;
            this.tbDataReceived.TextChanged += new System.EventHandler(this.tbDataReceived_TextChanged);
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(974, 403);
            this.lbPuerto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(75, 25);
            this.lbPuerto.TabIndex = 1;
            this.lbPuerto.Text = "Puerto";
            // 
            // btnRollDices
            // 
            this.btnRollDices.Location = new System.Drawing.Point(1023, 258);
            this.btnRollDices.Margin = new System.Windows.Forms.Padding(6);
            this.btnRollDices.Name = "btnRollDices";
            this.btnRollDices.Size = new System.Drawing.Size(246, 44);
            this.btnRollDices.TabIndex = 21;
            this.btnRollDices.Text = "Lanzar dados";
            this.btnRollDices.UseVisualStyleBackColor = true;
            // 
            // dice2
            // 
            this.dice2.Image = ((System.Drawing.Image)(resources.GetObject("dice2.Image")));
            this.dice2.Location = new System.Drawing.Point(1181, 50);
            this.dice2.Margin = new System.Windows.Forms.Padding(2);
            this.dice2.Name = "dice2";
            this.dice2.Size = new System.Drawing.Size(121, 114);
            this.dice2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice2.TabIndex = 4;
            this.dice2.TabStop = false;
            // 
            // dice1
            // 
            this.dice1.Image = ((System.Drawing.Image)(resources.GetObject("dice1.Image")));
            this.dice1.Location = new System.Drawing.Point(979, 50);
            this.dice1.Margin = new System.Windows.Forms.Padding(2);
            this.dice1.Name = "dice1";
            this.dice1.Size = new System.Drawing.Size(121, 114);
            this.dice1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice1.TabIndex = 3;
            this.dice1.TabStop = false;
            // 
            // pbTablero
            // 
            this.pbTablero.Image = ((System.Drawing.Image)(resources.GetObject("pbTablero.Image")));
            this.pbTablero.Location = new System.Drawing.Point(71, 50);
            this.pbTablero.Margin = new System.Windows.Forms.Padding(2);
            this.pbTablero.Name = "pbTablero";
            this.pbTablero.Size = new System.Drawing.Size(675, 726);
            this.pbTablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTablero.TabIndex = 2;
            this.pbTablero.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 846);
            this.Controls.Add(this.btnRollDices);
            this.Controls.Add(this.dice2);
            this.Controls.Add(this.dice1);
            this.Controls.Add(this.pbTablero);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.tbDataReceived);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Principal";
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDataReceived;
        private System.Windows.Forms.Label lbPuerto;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.PictureBox pbTablero;
        private System.Windows.Forms.PictureBox dice1;
        private System.Windows.Forms.PictureBox dice2;
        private System.Windows.Forms.Button btnRollDices;
    }
}