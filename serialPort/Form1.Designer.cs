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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.cBoxSelectedComPort = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxDebugPortInfo = new System.Windows.Forms.TextBox();
            this.tBoxDebug = new System.Windows.Forms.TextBox();
            this.labelStopbits = new System.Windows.Forms.Label();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.labelParity = new System.Windows.Forms.Label();
            this.cBoxParity = new System.Windows.Forms.ComboBox();
            this.labelDatabits = new System.Windows.Forms.Label();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.cBoxSpeed = new System.Windows.Forms.ComboBox();
            this.input = new System.Windows.Forms.GroupBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.input.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outputTextBox);
            this.groupBox3.Location = new System.Drawing.Point(17, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 86);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "output";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(12, 21);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(307, 54);
            this.outputTextBox.TabIndex = 8;
            this.outputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disconnectButton);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.cBoxSelectedComPort);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.labelStopbits);
            this.groupBox1.Controls.Add(this.cBoxStopBits);
            this.groupBox1.Controls.Add(this.labelParity);
            this.groupBox1.Controls.Add(this.cBoxParity);
            this.groupBox1.Controls.Add(this.labelDatabits);
            this.groupBox1.Controls.Add(this.cBoxDataBits);
            this.groupBox1.Controls.Add(this.labelSpeed);
            this.groupBox1.Controls.Add(this.cBoxSpeed);
            this.groupBox1.Location = new System.Drawing.Point(17, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 384);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control and debug";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(170, 60);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(152, 31);
            this.disconnectButton.TabIndex = 18;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 60);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(152, 31);
            this.connectButton.TabIndex = 11;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // cBoxSelectedComPort
            // 
            this.cBoxSelectedComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSelectedComPort.FormattingEnabled = true;
            this.cBoxSelectedComPort.Location = new System.Drawing.Point(12, 30);
            this.cBoxSelectedComPort.Name = "cBoxSelectedComPort";
            this.cBoxSelectedComPort.Size = new System.Drawing.Size(310, 24);
            this.cBoxSelectedComPort.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tBoxDebugPortInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxDebug, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 224);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 100);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tBoxDebugPortInfo
            // 
            this.tBoxDebugPortInfo.Location = new System.Drawing.Point(3, 3);
            this.tBoxDebugPortInfo.Multiline = true;
            this.tBoxDebugPortInfo.Name = "tBoxDebugPortInfo";
            this.tBoxDebugPortInfo.Size = new System.Drawing.Size(149, 92);
            this.tBoxDebugPortInfo.TabIndex = 16;
            // 
            // tBoxDebug
            // 
            this.tBoxDebug.Location = new System.Drawing.Point(158, 3);
            this.tBoxDebug.Multiline = true;
            this.tBoxDebug.Name = "tBoxDebug";
            this.tBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxDebug.Size = new System.Drawing.Size(149, 92);
            this.tBoxDebug.TabIndex = 17;
            // 
            // labelStopbits
            // 
            this.labelStopbits.AutoSize = true;
            this.labelStopbits.Location = new System.Drawing.Point(10, 199);
            this.labelStopbits.Name = "labelStopbits";
            this.labelStopbits.Size = new System.Drawing.Size(60, 17);
            this.labelStopbits.TabIndex = 11;
            this.labelStopbits.Text = "StopBits";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(120, 195);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(199, 24);
            this.cBoxStopBits.TabIndex = 5;
            this.cBoxStopBits.Text = "One";
            this.cBoxStopBits.SelectedIndexChanged += new System.EventHandler(this.CBoxStopBits_SelectedIndexChanged);
            this.cBoxStopBits.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxStopBits_Validating);
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(10, 140);
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
            this.cBoxParity.Location = new System.Drawing.Point(120, 136);
            this.cBoxParity.Name = "cBoxParity";
            this.cBoxParity.Size = new System.Drawing.Size(199, 24);
            this.cBoxParity.TabIndex = 4;
            this.cBoxParity.Text = "None";
            this.cBoxParity.SelectedIndexChanged += new System.EventHandler(this.CBoxParity_SelectedIndexChanged);
            this.cBoxParity.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxParity_Validating);
            // 
            // labelDatabits
            // 
            this.labelDatabits.AutoSize = true;
            this.labelDatabits.Location = new System.Drawing.Point(10, 170);
            this.labelDatabits.Name = "labelDatabits";
            this.labelDatabits.Size = new System.Drawing.Size(61, 17);
            this.labelDatabits.TabIndex = 9;
            this.labelDatabits.Text = "DataBits";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(120, 166);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(199, 24);
            this.cBoxDataBits.TabIndex = 3;
            this.cBoxDataBits.Text = "8";
            this.cBoxDataBits.SelectedIndexChanged += new System.EventHandler(this.CBoxDataBits_SelectedIndexChanged);
            this.cBoxDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxDataBits_Validating);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(10, 110);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(89, 17);
            this.labelSpeed.TabIndex = 8;
            this.labelSpeed.Text = "Speed (bit/s)";
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
            this.cBoxSpeed.Location = new System.Drawing.Point(120, 106);
            this.cBoxSpeed.Name = "cBoxSpeed";
            this.cBoxSpeed.Size = new System.Drawing.Size(199, 24);
            this.cBoxSpeed.TabIndex = 1;
            this.cBoxSpeed.Text = "9600";
            this.cBoxSpeed.SelectedIndexChanged += new System.EventHandler(this.CBoxSpeed_SelectedIndexChanged);
            this.cBoxSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.CBoxSpeed_Validating);
            // 
            // input
            // 
            this.input.Controls.Add(this.inputTextBox);
            this.input.Location = new System.Drawing.Point(17, 8);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(348, 86);
            this.input.TabIndex = 12;
            this.input.TabStop = false;
            this.input.Text = "input";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 21);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(307, 54);
            this.inputTextBox.TabIndex = 7;
            this.inputTextBox.Click += new System.EventHandler(this.InputTextBox_Click);
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputTextBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(374, 622);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.input);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serial Port App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.input.ResumeLayout(false);
            this.input.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cBoxSelectedComPort;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox input;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelStopbits;
        private System.Windows.Forms.ComboBox cBoxStopBits;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.ComboBox cBoxParity;
        private System.Windows.Forms.Label labelDatabits;
        private System.Windows.Forms.ComboBox cBoxDataBits;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.ComboBox cBoxSpeed;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBoxDebugPortInfo;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tBoxDebug;
        private System.Windows.Forms.Button disconnectButton;
    }
}

