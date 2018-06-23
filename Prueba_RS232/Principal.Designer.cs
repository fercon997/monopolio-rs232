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
            this.tbDataReceived = new System.Windows.Forms.TextBox();
            this.lbPuerto = new System.Windows.Forms.Label();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // tbDataReceived
            // 
            this.tbDataReceived.Location = new System.Drawing.Point(226, 87);
            this.tbDataReceived.Multiline = true;
            this.tbDataReceived.Name = "tbDataReceived";
            this.tbDataReceived.Size = new System.Drawing.Size(210, 158);
            this.tbDataReceived.TabIndex = 0;
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(223, 39);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(43, 15);
            this.lbPuerto.TabIndex = 1;
            this.lbPuerto.Text = "Puerto";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 345);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.tbDataReceived);
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDataReceived;
        private System.Windows.Forms.Label lbPuerto;
        private System.IO.Ports.SerialPort comPort;
    }
}