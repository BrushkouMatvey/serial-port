using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialPort
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxSelectedComPort.Items.AddRange(ports);
            cBoxSelectedComPort.Text = ports[0].ToString();
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {

            serialPortConnect();
            errorProvider.SetError(cBoxSelectedComPort, null);
        }
        private void serialPortConnect()
        {
            if (serialPort != null)
                serialPort.Close();

            serialPort = new SerialPort(cBoxSelectedComPort.SelectedItem.ToString());
            try
            {
                serialPort.Open();
                tBoxDebug.Text = "Serial port " + cBoxSelectedComPort.SelectedItem.ToString() + " is open.\n";
                showInfoDebug();
            }
            catch
            {
                tBoxDebug.Text = "Serial port " + cBoxSelectedComPort.SelectedItem.ToString() + " can't open.\n";
            }
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        }
        private void setDefaultSerialPortValues()
        {
            cBoxStopBits.Text = "One";
            cBoxParity.Text = "None";
            cBoxDataBits.Text = "8";
            cBoxSpeed.Text = "9600";
        }
        private bool portIsOpen()
        {
            if (serialPort != null)
                return true;
            else return false;
        }
        public void sendData(string data)
        {
            serialPort.Write(data);
            tBoxDebug.AppendText("Sending data...\n");
        }
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e) { 
            if (!portIsOpen())
            {
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inputTextBox.Text = "";
                return;
            }
            byte[] data = { Convert.ToByte(e.KeyCode) };
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter)
                serialPort.Write(data, 0, data.Length);
            else sendData(Convert.ToChar(e.KeyCode).ToString().ToLower());
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            Keys keyCode = (Keys)sp.ReadChar();
            switch (keyCode)
            {
                case Keys.Back:
                    if (outputTextBox.Text.Length == 0) break;
                    outputTextBox.Text = outputTextBox.Text.Substring(0, outputTextBox.Text.Length - 1);
                    break;
                case Keys.Enter:
                    outputTextBox.AppendText("\n");
                    break;
                default:
                    outputTextBox.AppendText(Convert.ToChar(keyCode).ToString());
                    break;
            }
            tBoxDebug.AppendText("Receiving data...\n");
        }
        private void validData(ComboBox comboBox, CancelEventArgs e)
        {
            bool validValue = false;
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Text == comboBox.Items[i].ToString())
                    validValue = true;
            }
            if (!validValue)
            {
                e.Cancel = true;
                errorProvider.SetError(comboBox, "Ivalid value");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(comboBox, null);
            }
        }

        private void CBoxDataBits_Validating(object sender, CancelEventArgs e)
        {
            validData(cBoxDataBits, e);
        }
        private void CBoxStopBits_Validating(object sender, CancelEventArgs e)
        {
            validData(cBoxStopBits, e);
        }
        private void CBoxParity_Validating(object sender, CancelEventArgs e)
        {
            validData(cBoxParity, e);
        }
        private void CBoxSpeed_Validating(object sender, CancelEventArgs e)
        {
            validData(cBoxSpeed, e);
        }

        private void CBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(cBoxSelectedComPort, "Open Serial port, please");
                return;
            }
            
            serialPort.BaudRate = int.Parse(cBoxSpeed.SelectedItem.ToString());
            showInfoDebug();
        }
        private void CBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(cBoxSelectedComPort, "Open Serial port, please");
                return;
            }
            string strParity = cBoxParity.SelectedItem.ToString();
            switch (strParity)
            {
                case "None":
                    serialPort.Parity = Parity.None;
                    break;
                case "Odd":
                    serialPort.Parity = Parity.Odd;
                    break;
                case "Even":
                    serialPort.Parity = Parity.Even;
                    break;
                default:
                    break;
            }
            showInfoDebug();
        }
        private void CBoxStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(cBoxSelectedComPort, "Open Serial port, please");
                return;
            }
            string cBoxStopBitsValue = cBoxStopBits.SelectedItem.ToString();
            int cBoxDataBitsValue = Convert.ToInt32(cBoxDataBits.SelectedItem.ToString());
            switch (cBoxStopBitsValue)
            {
                case "None":
                    serialPort.StopBits = StopBits.None;
                    break;
                case "One":
                    serialPort.StopBits = StopBits.One;
                    break;
                case "OnePointFive":
                    serialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "Two":
                    serialPort.StopBits = StopBits.Two;
                    break;
                default:
                    break;
            }           
            
            checkCombinations(cBoxStopBitsValue, cBoxDataBitsValue);
            showInfoDebug();
        }
        private void CBoxDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(cBoxSelectedComPort, "Open Serial port, please");
                return;
            }
    
            string cBoxStopBitsValue = cBoxStopBits.SelectedItem.ToString();
            int cBoxDataBitsValue = Convert.ToInt32(cBoxDataBits.SelectedItem.ToString());
            checkCombinations(cBoxStopBitsValue, cBoxDataBitsValue);

            serialPort.DataBits = cBoxDataBitsValue;

            showInfoDebug();
        }

        private void checkCombinations(string cBoxStopBitsValue, int cBoxDataBitsValue)
        {
            if (cBoxStopBitsValue == "OnePointFive" &&
                    (cBoxDataBitsValue.ToString() == Convert.ToString(6) ||
                    cBoxDataBitsValue.ToString() == Convert.ToString(7) ||
                    cBoxDataBitsValue.ToString() == Convert.ToString(8)))
            {
                MessageBox.Show("Invalid combination of DataBits and StopBits values", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(5));
                showInfoDebug();
                return;
            }

            if (cBoxStopBitsValue == "Two" && cBoxDataBitsValue.ToString() == Convert.ToString(5))
            {
                MessageBox.Show("Invalid combination of DataBits and StopBits values", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(8));
                showInfoDebug();
                return;
            }
        }
        private void showInfoDebug()
        {
            tBoxDebugPortInfo.Text = "Name:" + serialPort.PortName + "\n";
            tBoxDebugPortInfo.AppendText("BaudRate:" + serialPort.BaudRate + "\n");
            tBoxDebugPortInfo.AppendText("BiteSize:" + serialPort.DataBits + "\n");
            tBoxDebugPortInfo.AppendText("StopBits:" + serialPort.StopBits + "\n");
            tBoxDebugPortInfo.AppendText("Parity:" + serialPort.Parity + "\n");
        }
        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                inputTextBox.Text = "";
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CBoxSelectedComPort_SelectedValueChanged(object sender, EventArgs e)
        {
            clearTextBoxes();
            setDefaultSerialPortValues();
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort = null;
            }
        }
        private void clearTextBoxes()
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            tBoxDebugPortInfo.Text = "";
            tBoxDebug.Text = "";
        }
    }
}
