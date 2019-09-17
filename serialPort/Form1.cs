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
        }

        private void serialPortConnect()
        {
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



        private bool portIsOpen()
        {
            if (serialPort != null)
                return true;
            else return false;
        }
        public void sendData(string data)
        {
            serialPort.Write(data);
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(char.IsLetterOrDigit((char)e.KeyCode))
                sendData(Convert.ToChar(e.KeyCode).ToString());
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            outputTextBox.AppendText(Convert.ToChar(sp.ReadChar()).ToString());
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
                errorProvider.SetError(openButton, "Open Serial port, please");
                return;
            }
            serialPort.BaudRate = int.Parse(cBoxSpeed.SelectedItem.ToString());
            showInfoDebug();
        }

        private void CBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(openButton, "Open Serial port, please");
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
                errorProvider.SetError(openButton, "Open Serial port, please");
                return;
            }
            string strParity = cBoxStopBits.SelectedItem.ToString();
            switch (strParity)
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
            showInfoDebug();
        }

        private void CBoxDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                errorProvider.SetError(openButton, "Open Serial port, please");
                return;
            }
            int cBoxDataBitsValue = int.Parse(cBoxDataBits.SelectedItem.ToString());

            if (cBoxDataBitsValue == 6 || cBoxDataBitsValue == 7 || cBoxDataBitsValue == 8)
                cBoxStopBits.SelectedIndex = cBoxStopBits.FindStringExact("One");
            else
                cBoxStopBits.SelectedIndex = cBoxStopBits.FindStringExact("OnePointFive");
            serialPort.DataBits = cBoxDataBitsValue;

            showInfoDebug();
        }

        private void showInfoDebug()
        {
            tBoxDebugPortInfo.Text = "Name:" + serialPort.PortName + "\n";
            tBoxDebugPortInfo.AppendText("BaudRate:" + serialPort.BaudRate + "\n");
            tBoxDebugPortInfo.AppendText("BiteSize:" + serialPort.DataBits + "\n");
            tBoxDebugPortInfo.AppendText("StopBits:" + serialPort.StopBits + "\n");
            tBoxDebugPortInfo.AppendText("Parity:" + serialPort.Parity + "\n");
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                inputTextBox.Text = "";
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sendData(inputTextBox.Text.Last().ToString());
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
        }

        private void clearTextBoxes()
        {
            tBoxDebugPortInfo.Text = "";
            tBoxDebug.Text = "";
        }

        
    }
}
