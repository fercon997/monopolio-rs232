namespace Prueba_RS232
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
            this.pbTablero = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTablero)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDataReceived
            // 
            this.tbDataReceived.Location = new System.Drawing.Point(1300, 170);
            this.tbDataReceived.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbDataReceived.Multiline = true;
            this.tbDataReceived.Name = "tbDataReceived";
            this.tbDataReceived.Size = new System.Drawing.Size(553, 254);
            this.tbDataReceived.TabIndex = 0;
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(1310, 108);
            this.lbPuerto.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(99, 32);
            this.lbPuerto.TabIndex = 1;
            this.lbPuerto.Text = "Puerto";
            // 
            // pbTablero
            // 
            this.pbTablero.Image = ((System.Drawing.Image)(resources.GetObject("pbTablero.Image")));
            this.pbTablero.Location = new System.Drawing.Point(95, 62);
            this.pbTablero.Name = "pbTablero";
            this.pbTablero.Size = new System.Drawing.Size(900, 900);
            this.pbTablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTablero.TabIndex = 2;
            this.pbTablero.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1959, 1049);
            this.Controls.Add(this.pbTablero);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.tbDataReceived);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Principal";
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pbTablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDataReceived;
        private System.Windows.Forms.Label lbPuerto;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.PictureBox pbTablero;
    }
}