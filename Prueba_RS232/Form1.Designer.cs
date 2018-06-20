namespace Prueba_RS232
{
    partial class Form1
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
            this.lblBreakStatus = new System.Windows.Forms.Label();
            this.lblCTSStatus = new System.Windows.Forms.Label();
            this.lblDSRStatus = new System.Windows.Forms.Label();
            this.lblRIStatus = new System.Windows.Forms.Label();
            this.btnPortState = new System.Windows.Forms.Button();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.btnHello = new System.Windows.Forms.Button();
            this.rtbIncoming = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnGetSerialPorts
            // 
            this.btnGetSerialPorts.Location = new System.Drawing.Point(38, 95);
            this.btnGetSerialPorts.Name = "btnGetSerialPorts";
            this.btnGetSerialPorts.Size = new System.Drawing.Size(125, 33);
            this.btnGetSerialPorts.TabIndex = 0;
            this.btnGetSerialPorts.Text = "Ports";
            this.btnGetSerialPorts.UseVisualStyleBackColor = true;
            this.btnGetSerialPorts.Click += new System.EventHandler(this.btnGetSerialPorts_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(192, 95);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(121, 21);
            this.cboPorts.TabIndex = 2;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(192, 122);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cboBaudRate.TabIndex = 3;
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(192, 153);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 21);
            this.cboStopBits.TabIndex = 4;
            // 
            // cboHandShaking
            // 
            this.cboHandShaking.FormattingEnabled = true;
            this.cboHandShaking.Location = new System.Drawing.Point(192, 180);
            this.cboHandShaking.Name = "cboHandShaking";
            this.cboHandShaking.Size = new System.Drawing.Size(121, 21);
            this.cboHandShaking.TabIndex = 5;
            // 
            // lblBreakStatus
            // 
            this.lblBreakStatus.AutoSize = true;
            this.lblBreakStatus.Location = new System.Drawing.Point(36, 309);
            this.lblBreakStatus.Name = "lblBreakStatus";
            this.lblBreakStatus.Size = new System.Drawing.Size(35, 13);
            this.lblBreakStatus.TabIndex = 6;
            this.lblBreakStatus.Text = "Break";
            // 
            // lblCTSStatus
            // 
            this.lblCTSStatus.AutoSize = true;
            this.lblCTSStatus.Location = new System.Drawing.Point(97, 309);
            this.lblCTSStatus.Name = "lblCTSStatus";
            this.lblCTSStatus.Size = new System.Drawing.Size(28, 13);
            this.lblCTSStatus.TabIndex = 7;
            this.lblCTSStatus.Text = "CTS";
            // 
            // lblDSRStatus
            // 
            this.lblDSRStatus.AutoSize = true;
            this.lblDSRStatus.Location = new System.Drawing.Point(158, 309);
            this.lblDSRStatus.Name = "lblDSRStatus";
            this.lblDSRStatus.Size = new System.Drawing.Size(30, 13);
            this.lblDSRStatus.TabIndex = 8;
            this.lblDSRStatus.Text = "DSR";
            // 
            // lblRIStatus
            // 
            this.lblRIStatus.AutoSize = true;
            this.lblRIStatus.Location = new System.Drawing.Point(219, 309);
            this.lblRIStatus.Name = "lblRIStatus";
            this.lblRIStatus.Size = new System.Drawing.Size(18, 13);
            this.lblRIStatus.TabIndex = 9;
            this.lblRIStatus.Text = "RI";
            // 
            // btnPortState
            // 
            this.btnPortState.Location = new System.Drawing.Point(38, 134);
            this.btnPortState.Name = "btnPortState";
            this.btnPortState.Size = new System.Drawing.Size(125, 30);
            this.btnPortState.TabIndex = 11;
            this.btnPortState.Text = "Closed";
            this.btnPortState.UseVisualStyleBackColor = true;
            this.btnPortState.Click += new System.EventHandler(this.btnPortState_Click);
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(192, 234);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 12;
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(192, 207);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 21);
            this.cboDataBits.TabIndex = 13;
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(38, 170);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(125, 30);
            this.btnHello.TabIndex = 14;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // rtbIncoming
            // 
            this.rtbIncoming.Location = new System.Drawing.Point(371, 122);
            this.rtbIncoming.Name = "rtbIncoming";
            this.rtbIncoming.Size = new System.Drawing.Size(197, 131);
            this.rtbIncoming.TabIndex = 15;
            this.rtbIncoming.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 352);
            this.Controls.Add(this.rtbIncoming);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.btnPortState);
            this.Controls.Add(this.lblRIStatus);
            this.Controls.Add(this.lblDSRStatus);
            this.Controls.Add(this.lblCTSStatus);
            this.Controls.Add(this.lblBreakStatus);
            this.Controls.Add(this.cboHandShaking);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.btnGetSerialPorts);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label lblBreakStatus;
        private System.Windows.Forms.Label lblCTSStatus;
        private System.Windows.Forms.Label lblDSRStatus;
        private System.Windows.Forms.Label lblRIStatus;
        private System.Windows.Forms.Button btnPortState;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.RichTextBox rtbIncoming;
    }
}

