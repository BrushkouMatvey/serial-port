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
            this.Adresses = new System.Windows.Forms.GroupBox();
            this.checkBoxErrorSimulation = new System.Windows.Forms.CheckBox();
            this.textBoxSourceAddress = new System.Windows.Forms.TextBox();
            this.setDestinationButton = new System.Windows.Forms.Button();
            this.textBoxDestinationAddress = new System.Windows.Forms.TextBox();
            this.setSourceButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxSpeed = new System.Windows.Forms.ComboBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.labelDatabits = new System.Windows.Forms.Label();
            this.cBoxParity = new System.Windows.Forms.ComboBox();
            this.labelStopbits = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxSelectedComPort = new System.Windows.Forms.ComboBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxDebugPortInfo = new System.Windows.Forms.TextBox();
            this.tBoxDebug = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.GroupBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Adresses.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(17, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 86);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTextBox.Location = new System.Drawing.Point(12, 21);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(442, 54);
            this.outputTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Adresses);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(17, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 561);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control and debug";
            // 
            // Adresses
            // 
            this.Adresses.Controls.Add(this.checkBoxErrorSimulation);
            this.Adresses.Controls.Add(this.textBoxSourceAddress);
            this.Adresses.Controls.Add(this.setDestinationButton);
            this.Adresses.Controls.Add(this.textBoxDestinationAddress);
            this.Adresses.Controls.Add(this.setSourceButton);
            this.Adresses.Controls.Add(this.label3);
            this.Adresses.Controls.Add(this.label2);
            this.Adresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Adresses.Location = new System.Drawing.Point(6, 304);
            this.Adresses.Name = "Adresses";
            this.Adresses.Size = new System.Drawing.Size(454, 122);
            this.Adresses.TabIndex = 20;
            this.Adresses.TabStop = false;
            this.Adresses.Text = "Packet transmission control";
            // 
            // checkBoxErrorSimulation
            // 
            this.checkBoxErrorSimulation.AutoSize = true;
            this.checkBoxErrorSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxErrorSimulation.Location = new System.Drawing.Point(16, 92);
            this.checkBoxErrorSimulation.Name = "checkBoxErrorSimulation";
            this.checkBoxErrorSimulation.Size = new System.Drawing.Size(150, 24);
            this.checkBoxErrorSimulation.TabIndex = 27;
            this.checkBoxErrorSimulation.Text = "Error simulation";
            this.checkBoxErrorSimulation.UseVisualStyleBackColor = true;
            // 
            // textBoxSourceAddress
            // 
            this.textBoxSourceAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSourceAddress.Location = new System.Drawing.Point(111, 26);
            this.textBoxSourceAddress.MinimumSize = new System.Drawing.Size(0, 26);
            this.textBoxSourceAddress.Name = "textBoxSourceAddress";
            this.textBoxSourceAddress.Size = new System.Drawing.Size(138, 28);
            this.textBoxSourceAddress.TabIndex = 26;
            this.textBoxSourceAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAddress_KeyPress);
            // 
            // setDestinationButton
            // 
            this.setDestinationButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.setDestinationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setDestinationButton.Location = new System.Drawing.Point(255, 57);
            this.setDestinationButton.Name = "setDestinationButton";
            this.setDestinationButton.Size = new System.Drawing.Size(193, 28);
            this.setDestinationButton.TabIndex = 25;
            this.setDestinationButton.Text = "Set dest.";
            this.setDestinationButton.UseVisualStyleBackColor = true;
            this.setDestinationButton.Click += new System.EventHandler(this.SetDestinationButton_Click);
            // 
            // textBoxDestinationAddress
            // 
            this.textBoxDestinationAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDestinationAddress.Location = new System.Drawing.Point(111, 58);
            this.textBoxDestinationAddress.MinimumSize = new System.Drawing.Size(0, 26);
            this.textBoxDestinationAddress.Name = "textBoxDestinationAddress";
            this.textBoxDestinationAddress.Size = new System.Drawing.Size(138, 28);
            this.textBoxDestinationAddress.TabIndex = 24;
            this.textBoxDestinationAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAddress_KeyPress);
            // 
            // setSourceButton
            // 
            this.setSourceButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.setSourceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setSourceButton.Location = new System.Drawing.Point(255, 25);
            this.setSourceButton.Name = "setSourceButton";
            this.setSourceButton.Size = new System.Drawing.Size(193, 28);
            this.setSourceButton.TabIndex = 20;
            this.setSourceButton.Text = "Set source";
            this.setSourceButton.UseVisualStyleBackColor = true;
            this.setSourceButton.Click += new System.EventHandler(this.SetSourceButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Destination addr.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Source addr.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBoxSpeed);
            this.groupBox4.Controls.Add(this.labelSpeed);
            this.groupBox4.Controls.Add(this.cBoxDataBits);
            this.groupBox4.Controls.Add(this.applyButton);
            this.groupBox4.Controls.Add(this.labelDatabits);
            this.groupBox4.Controls.Add(this.cBoxParity);
            this.groupBox4.Controls.Add(this.labelStopbits);
            this.groupBox4.Controls.Add(this.labelParity);
            this.groupBox4.Controls.Add(this.cBoxStopBits);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(6, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(454, 179);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Properties";
            // 
            // cBoxSpeed
            // 
            this.cBoxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cBoxSpeed.Location = new System.Drawing.Point(97, 21);
            this.cBoxSpeed.Name = "cBoxSpeed";
            this.cBoxSpeed.Size = new System.Drawing.Size(351, 26);
            this.cBoxSpeed.TabIndex = 1;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeed.Location = new System.Drawing.Point(16, 25);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(91, 18);
            this.labelSpeed.TabIndex = 8;
            this.labelSpeed.Text = "Speed (bit/s)";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(97, 81);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(351, 26);
            this.cBoxDataBits.TabIndex = 3;
            // 
            // applyButton
            // 
            this.applyButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyButton.Location = new System.Drawing.Point(189, 140);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(259, 34);
            this.applyButton.TabIndex = 19;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // labelDatabits
            // 
            this.labelDatabits.AutoSize = true;
            this.labelDatabits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDatabits.Location = new System.Drawing.Point(16, 85);
            this.labelDatabits.Name = "labelDatabits";
            this.labelDatabits.Size = new System.Drawing.Size(64, 18);
            this.labelDatabits.TabIndex = 9;
            this.labelDatabits.Text = "DataBits";
            // 
            // cBoxParity
            // 
            this.cBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxParity.FormattingEnabled = true;
            this.cBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParity.Location = new System.Drawing.Point(97, 51);
            this.cBoxParity.Name = "cBoxParity";
            this.cBoxParity.Size = new System.Drawing.Size(351, 26);
            this.cBoxParity.TabIndex = 4;
            // 
            // labelStopbits
            // 
            this.labelStopbits.AutoSize = true;
            this.labelStopbits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStopbits.Location = new System.Drawing.Point(16, 114);
            this.labelStopbits.Name = "labelStopbits";
            this.labelStopbits.Size = new System.Drawing.Size(64, 18);
            this.labelStopbits.TabIndex = 11;
            this.labelStopbits.Text = "StopBits";
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParity.Location = new System.Drawing.Point(16, 55);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(70, 18);
            this.labelParity.TabIndex = 10;
            this.labelParity.Text = "ParityBits";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(97, 110);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(351, 26);
            this.cBoxStopBits.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxSelectedComPort);
            this.groupBox2.Controls.Add(this.disconnectButton);
            this.groupBox2.Controls.Add(this.connectButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 99);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            // 
            // cBoxSelectedComPort
            // 
            this.cBoxSelectedComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSelectedComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSelectedComPort.FormattingEnabled = true;
            this.cBoxSelectedComPort.Location = new System.Drawing.Point(12, 26);
            this.cBoxSelectedComPort.Name = "cBoxSelectedComPort";
            this.cBoxSelectedComPort.Size = new System.Drawing.Size(436, 26);
            this.cBoxSelectedComPort.TabIndex = 9;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disconnectButton.Location = new System.Drawing.Point(244, 55);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(204, 31);
            this.disconnectButton.TabIndex = 18;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectButton.Location = new System.Drawing.Point(12, 55);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(226, 31);
            this.connectButton.TabIndex = 11;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.82898F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.17102F));
            this.tableLayoutPanel1.Controls.Add(this.tBoxDebugPortInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxDebug, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 432);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 123);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tBoxDebugPortInfo
            // 
            this.tBoxDebugPortInfo.Location = new System.Drawing.Point(3, 3);
            this.tBoxDebugPortInfo.Multiline = true;
            this.tBoxDebugPortInfo.Name = "tBoxDebugPortInfo";
            this.tBoxDebugPortInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxDebugPortInfo.Size = new System.Drawing.Size(128, 117);
            this.tBoxDebugPortInfo.TabIndex = 16;
            // 
            // tBoxDebug
            // 
            this.tBoxDebug.Location = new System.Drawing.Point(147, 3);
            this.tBoxDebug.Multiline = true;
            this.tBoxDebug.Name = "tBoxDebug";
            this.tBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxDebug.Size = new System.Drawing.Size(304, 117);
            this.tBoxDebug.TabIndex = 17;
            // 
            // input
            // 
            this.input.Controls.Add(this.inputTextBox);
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input.Location = new System.Drawing.Point(17, 8);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(466, 86);
            this.input.TabIndex = 12;
            this.input.TabStop = false;
            this.input.Text = "Input";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(12, 21);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(442, 54);
            this.inputTextBox.TabIndex = 7;
            this.inputTextBox.Click += new System.EventHandler(this.InputTextBox_Click);
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            this.inputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTextBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(495, 760);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.input);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serial Port App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Adresses.ResumeLayout(false);
            this.Adresses.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Adresses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button setSourceButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button setDestinationButton;
        private System.Windows.Forms.TextBox textBoxDestinationAddress;
        private System.Windows.Forms.TextBox textBoxSourceAddress;
        private System.Windows.Forms.CheckBox checkBoxErrorSimulation;
    }
}

