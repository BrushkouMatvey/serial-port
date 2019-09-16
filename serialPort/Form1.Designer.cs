namespace serialPort
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
            this.components = new System.ComponentModel.Container();
            this.cBoxSpeed = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStopbits = new System.Windows.Forms.Label();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.labelParity = new System.Windows.Forms.Label();
            this.cBoxParity = new System.Windows.Forms.ComboBox();
            this.labelDatabits = new System.Windows.Forms.Label();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.labelSelectedComPort = new System.Windows.Forms.Label();
            this.cBoxSelectedComPort = new System.Windows.Forms.ComboBox();
            this.openButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxSpeed
            // 
            this.cBoxSpeed.FormattingEnabled = true;
            this.cBoxSpeed.Items.AddRange(new object[] {
            "75",
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cBoxSpeed.Location = new System.Drawing.Point(131, 31);
            this.cBoxSpeed.Name = "cBoxSpeed";
            this.cBoxSpeed.Size = new System.Drawing.Size(160, 24);
            this.cBoxSpeed.TabIndex = 1;
            this.cBoxSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxSpeed_Validating);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 184);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(314, 52);
            this.textBox4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStopbits);
            this.groupBox1.Controls.Add(this.cBoxStopBits);
            this.groupBox1.Controls.Add(this.labelParity);
            this.groupBox1.Controls.Add(this.cBoxParity);
            this.groupBox1.Controls.Add(this.labelDatabits);
            this.groupBox1.Controls.Add(this.cBoxDataBits);
            this.groupBox1.Controls.Add(this.labelSpeed);
            this.groupBox1.Controls.Add(this.cBoxSpeed);
            this.groupBox1.Location = new System.Drawing.Point(15, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM port control";
            // 
            // labelStopbits
            // 
            this.labelStopbits.AutoSize = true;
            this.labelStopbits.Location = new System.Drawing.Point(21, 124);
            this.labelStopbits.Name = "labelStopbits";
            this.labelStopbits.Size = new System.Drawing.Size(60, 17);
            this.labelStopbits.TabIndex = 11;
            this.labelStopbits.Text = "StopBits";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(131, 120);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(160, 24);
            this.cBoxStopBits.TabIndex = 5;
            this.cBoxStopBits.Text = "One";
            this.cBoxStopBits.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxStopBits_Validating);
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(21, 65);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(67, 17);
            this.labelParity.TabIndex = 10;
            this.labelParity.Text = "ParityBits";
            // 
            // cBoxParity
            // 
            this.cBoxParity.FormattingEnabled = true;
            this.cBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParity.Location = new System.Drawing.Point(131, 61);
            this.cBoxParity.Name = "cBoxParity";
            this.cBoxParity.Size = new System.Drawing.Size(160, 24);
            this.cBoxParity.TabIndex = 4;
            this.cBoxParity.Text = "None";
            this.cBoxParity.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxParity_Validating);
            // 
            // labelDatabits
            // 
            this.labelDatabits.AutoSize = true;
            this.labelDatabits.Location = new System.Drawing.Point(21, 95);
            this.labelDatabits.Name = "labelDatabits";
            this.labelDatabits.Size = new System.Drawing.Size(60, 17);
            this.labelDatabits.TabIndex = 9;
            this.labelDatabits.Text = "Databits";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(131, 91);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(160, 24);
            this.cBoxDataBits.TabIndex = 3;
            this.cBoxDataBits.Text = "8";
            this.cBoxDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxDataBits_Validating);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(21, 35);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(89, 17);
            this.labelSpeed.TabIndex = 8;
            this.labelSpeed.Text = "Speed (bit/s)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 109);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(314, 52);
            this.textBox5.TabIndex = 7;
            // 
            // labelSelectedComPort
            // 
            this.labelSelectedComPort.AutoSize = true;
            this.labelSelectedComPort.Location = new System.Drawing.Point(14, 37);
            this.labelSelectedComPort.Name = "labelSelectedComPort";
            this.labelSelectedComPort.Size = new System.Drawing.Size(125, 17);
            this.labelSelectedComPort.TabIndex = 10;
            this.labelSelectedComPort.Text = "Selected Com Port";
            // 
            // cBoxSelectedComPort
            // 
            this.cBoxSelectedComPort.FormattingEnabled = true;
            this.cBoxSelectedComPort.Location = new System.Drawing.Point(134, 33);
            this.cBoxSelectedComPort.Name = "cBoxSelectedComPort";
            this.cBoxSelectedComPort.Size = new System.Drawing.Size(192, 24);
            this.cBoxSelectedComPort.TabIndex = 9;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(216, 63);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(110, 35);
            this.openButton.TabIndex = 11;
            this.openButton.Text = "open port";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(39, 450);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 12;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(339, 521);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.labelSelectedComPort);
            this.Controls.Add(this.cBoxSelectedComPort);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxSpeed;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelStopbits;
        private System.Windows.Forms.ComboBox cBoxStopBits;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.ComboBox cBoxParity;
        private System.Windows.Forms.Label labelDatabits;
        private System.Windows.Forms.ComboBox cBoxDataBits;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox textBox5;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label labelSelectedComPort;
        private System.Windows.Forms.ComboBox cBoxSelectedComPort;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

