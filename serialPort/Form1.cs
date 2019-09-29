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


        //загрузка названий сэмулированных последовательных портов в массив строк
        private void Form1_Load(object sender, EventArgs e)
        {
            outputTextBox.ReadOnly = true;
            string[] ports = SerialPort.GetPortNames();
            cBoxSelectedComPort.Items.AddRange(ports);
            if (ports.Length != 0)
                cBoxSelectedComPort.Text = ports[0].ToString();
            disconnectButton.Enabled = false;
        }


        //событие нажатия на кнопку OpenPort
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if(serialPortConnect())
            {
                errorProvider.SetError(cBoxSelectedComPort, null);
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                cBoxSelectedComPort.Enabled = false;
            }
            
        }

        //open serial port
        //Событие DataReceived возникает во вторичном потоке при получении данных от объекта SerialPort.
        private bool serialPortConnect()
        {
            if (serialPort != null)
                serialPort.Close();

            serialPort = new SerialPort(cBoxSelectedComPort.SelectedItem.ToString());
            try
            {
                serialPort.Open();
                tBoxDebug.Text = "Connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.\n";
                showInfoDebug();
                
            }
            catch
            {
                tBoxDebug.Text = "Can't connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.\n";
                return false;
            }
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorHandler);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            return true;

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

        //отправка одного символа в порт
        public void sendData(string data)
        {
            serialPort.Write(data);
            tBoxDebug.AppendText("Sending data...\n");
        }

        //последняя нажатая клавиша. Считывается код и передается в другой порт через функцию SedndData
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!portIsOpen())
            {
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inputTextBox.Text = "";
                return;
            }

            e.KeyData.ToString();
            
            byte[] data = { Convert.ToByte(e.KeyCode) };
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter)
            {
                serialPort.Write(data, 0, 1);
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }            
        }

        //обработка отправленных данных в порт
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            byte[] data = new byte[sp.BytesToRead];
            sp.Read(data, 0, data.Length);

            Keys keyCode = (Keys)data[0];
            switch (keyCode)
            {
                case Keys.Back:
                    if (outputTextBox.Text.Length == 0) break;
                    outputTextBox.Text = outputTextBox.Text.Substring(0, outputTextBox.Text.Length - 1);
                    
                    break;
                default:
                    string s = Encoding.GetEncoding("UTF-8").GetString(data);
                    outputTextBox.AppendText(s);
                    tBoxDebug.AppendText("Receiving data...\n");
                    break;
            }          
        }

        //Определяет ошибки, возникающие в объекте SerialPort.
        private void ErrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            switch (e.EventType)
            {
                
                case SerialError.Frame:
                    //Аппаратное обеспечение обнаружило ошибку кадрирования.
                    MessageBox.Show("The hardware detected a framing error.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case SerialError.Overrun:
                    //Произошло переполнение буфера символов.
                    MessageBox.Show("A character-buffer overrun has occurred. The next character is lost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case SerialError.RXOver:
                    //Произошло переполнение входного буфера.
                    MessageBox.Show("An input buffer overflow has occurred.There is either no room in the input buffer, or a character was received after the end of file(EOF) character.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case SerialError.RXParity:
                    //ошибка четности.
                    MessageBox.Show("The hardware detected a parity error.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case SerialError.TXFull:
                    //Приложение попыталось передать символ, но буфер вывода был заполнен.
                    MessageBox.Show("The application tried to transmit a character, but the output buffer was full.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //проверка введенного значения со значениями из списка 
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

        //события обработки comboBoxes
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

        //События изменения comboBoxes. Если в списке выбран другой элемент, проверяем данные.
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
            showInfoDebug();
        }

        //проверка зависимости StopBits от DataBits
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
            else if (cBoxStopBitsValue == "Two" && cBoxDataBitsValue.ToString() == Convert.ToString(5))
            {
                MessageBox.Show("Invalid combination of DataBits and StopBits values", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(8));
                showInfoDebug();
                return;
            }
            else
            {
                serialPort.DataBits = int.Parse(cBoxDataBits.SelectedItem.ToString());
            }
        }

        //отображение информации о порте
        private void showInfoDebug()
        {
            tBoxDebugPortInfo.Text = "Name:" + serialPort.PortName + "\n";
            tBoxDebugPortInfo.AppendText("BaudRate:" + serialPort.BaudRate + "\n");
            tBoxDebugPortInfo.AppendText("BiteSize:" + serialPort.DataBits + "\n");
            tBoxDebugPortInfo.AppendText("StopBits:" + serialPort.StopBits + "\n");
            tBoxDebugPortInfo.AppendText("Parity:" + serialPort.Parity + "\n");
        }

        //проверка текста в модуле input (изменен до открытия порта). MessageBox с предупреждением
        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                inputTextBox.Text = "";
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void clearTextBoxes()
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            tBoxDebugPortInfo.Text = "";
            tBoxDebug.Text = "";
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            cBoxSelectedComPort.Enabled = true;

            clearTextBoxes();
            setDefaultSerialPortValues();
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort = null;
            }
        }

        private StringBuilder OldText = new StringBuilder();
        private void InputTextBox_GotFocus(object sender, EventArgs e)
        {
            OldText = new StringBuilder(inputTextBox.Text);
            
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            if (!portIsOpen())
            {
                inputTextBox.Text = "";
                MessageBox.Show("Serial port is not open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            byte[] data;
            if (OldText.Length <= inputTextBox.Text.Length)
            {
                str = inputTextBox.Text.Substring(OldText.Length);
                data = Encoding.UTF8.GetBytes(str);
                tBoxDebug.AppendText("Sending data...\n");
                serialPort.RtsEnable = true;
                serialPort.Write(data, 0, data.Length);
                serialPort.RtsEnable = false; 
            }
            OldText.Length = inputTextBox.Text.Length;
        }

        private void InputTextBox_Click(object sender, EventArgs e)
        {
            if (inputTextBox.SelectionStart != inputTextBox.Text.Length)
            {
                inputTextBox.SelectionStart = inputTextBox.Text.Length;
            }
        }
    }
}
