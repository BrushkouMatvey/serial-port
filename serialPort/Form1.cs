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
using System.Text.RegularExpressions;

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
            string[] ports = SerialPort.GetPortNames();
            cBoxSelectedComPort.Items.AddRange(ports);

            cBoxSpeed.Text = "9600";
            cBoxStopBits.Text = "One";
            cBoxParity.Text = "None";
            cBoxDataBits.Text = "8";


            if (ports.Length != 0)
                cBoxSelectedComPort.Text = ports[0].ToString();
            disconnectButton.Enabled = false;

            inputTextBox.Enabled = false;
            outputTextBox.ReadOnly = true;
            outputTextBox.Enabled = false;

            tBoxDebug.ReadOnly = true;
            tBoxDebugPortInfo.ReadOnly = true;

        }

        //обработка события нажати на кнопку Connect
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (serialPortConnect())
            {
                errorProvider.SetError(cBoxSelectedComPort, null);
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                cBoxSelectedComPort.Enabled = false;
                inputTextBox.Enabled = true;
                outputTextBox.Enabled = true;
            }
        }

        //обработка события нажати на кнопку Disconnect
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            cBoxSelectedComPort.Enabled = true;
            outputTextBox.Enabled = true;
            inputTextBox.Enabled = false;

            clearTextBoxes();
            setDefaultSerialPortValues();
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort = null;
            }
        }

        //установка конфигурационных параметров
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                tBoxDebug.AppendText(">>Serial port is not open" + "\n");
                return;
            }
            if (!setConfigParams())
            {
                return;
            }
            showInfoDebug();
            tBoxDebug.AppendText(">>Сonfiguration parameters changed" + "\n");
        }

        //open serial port        
        private bool serialPortConnect()
        {
            if (serialPort != null)
                serialPort.Close();

            serialPort = new SerialPort(cBoxSelectedComPort.SelectedItem.ToString());
            try
            {
                serialPort.Open();
                tBoxDebug.AppendText(">>Connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.\n");
                setConfigParams();
                showInfoDebug();

            }
            catch
            {
                tBoxDebug.AppendText(">>Can't connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.\n");
                serialPort.Close();
                serialPort = null;
                return false;
            }
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorHandler);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            return true;

        }

        //установка параметров по умолчанию в текстовые поля
        private void setDefaultSerialPortValues()
        {
            cBoxStopBits.Text = "One";
            cBoxParity.Text = "None";
            cBoxDataBits.Text = "8";
            cBoxSpeed.Text = "9600";
        }

        //проверка переменной serialPort
        private bool portIsOpen()
        {
            if (serialPort != null)
                return true;
            else return false;
        }

        //отправка данных в порт
        public void sendData(string data)
        {
            serialPort.Write(data);
            tBoxDebug.AppendText(">>Sending data...\n");
        }

        //Обработка последней нажатой клавиши. Считывается код и передается в другой порт через функцию SendData
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!portIsOpen())
            {
                tBoxDebug.AppendText(">>Serial port is not open\n");
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
        //Событие DataReceived возникает во вторичном потоке при получении данных от объекта SerialPort.
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
                    tBoxDebug.AppendText(">>Receiving data...\n");
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
                    outputTextBox.AppendText(">>The hardware detected a framing error.\n");
                    break;
                case SerialError.Overrun:
                    //Произошло переполнение буфера символов.
                    outputTextBox.AppendText(">>A character - buffer overrun has occurred.The next character is lost.\n");
                    break;
                case SerialError.RXOver:
                    //Произошло переполнение входного буфера.
                    outputTextBox.AppendText(">>An input buffer overflow has occurred.\n");
                    break;
                case SerialError.RXParity:
                    //ошибка четности.
                    outputTextBox.AppendText(">>The hardware detected a parity error.\n");
                    break;
                case SerialError.TXFull:
                    //Приложение попыталось передать символ, но буфер вывода был заполнен.
                    outputTextBox.AppendText(">>The application tried to transmit a character, but the output buffer was full.\n");
                    break;
            }
        }

        private void InputTextBox_GotFocus(object sender, EventArgs e) => OldText = new StringBuilder(inputTextBox.Text);

        //измения в текстовом поле input
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            if (!portIsOpen())
            {
                tBoxDebug.Text = "";
                outputTextBox.AppendText(">>Serial port is not open\n");
            }

            byte[] data;
            if (OldText.Length <= inputTextBox.Text.Length)
            {
                str = inputTextBox.Text.Substring(OldText.Length);
                data = Encoding.UTF8.GetBytes(str);
                tBoxDebug.AppendText(">>Sending data...\n");
                serialPort.RtsEnable = true;
                serialPort.Write(data, 0, data.Length);
                serialPort.RtsEnable = false;
            }
            OldText.Length = inputTextBox.Text.Length;
        }

        //перемещение курсора в конец текстового поля
        private void InputTextBox_Click(object sender, EventArgs e)
        {
            if (inputTextBox.SelectionStart != inputTextBox.Text.Length)
            {
                inputTextBox.SelectionStart = inputTextBox.Text.Length;
            }
        }

        //проверка зависимости StopBits от DataBits
        private bool checkCombinations(string cBoxStopBitsValue, int cBoxDataBitsValue)
        {
            if (cBoxStopBitsValue == "OnePointFive" &&
                    (cBoxDataBitsValue.ToString() == Convert.ToString(6) ||
                    cBoxDataBitsValue.ToString() == Convert.ToString(7) ||
                    cBoxDataBitsValue.ToString() == Convert.ToString(8)))
            {
                tBoxDebug.AppendText(">>Invalid combination of DataBits and StopBits values\n");
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(5));
                showInfoDebug();
                return false;
            }
            else if (cBoxStopBitsValue == "Two" && cBoxDataBitsValue.ToString() == Convert.ToString(5))
            {
                tBoxDebug.AppendText(">>Invalid combination of DataBits and StopBits values\n");
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(8));
                showInfoDebug();
                return false;
            }
            else
            {
                serialPort.DataBits = int.Parse(cBoxDataBits.SelectedItem.ToString());
                return true;
            }
        }

        //отображение информации о порте
        private void showInfoDebug()
        {
            tBoxDebugPortInfo.Text = "Name: " + serialPort.PortName + "\n";
            tBoxDebugPortInfo.AppendText("BaudRate: " + serialPort.BaudRate + "\n");
            tBoxDebugPortInfo.AppendText("BiteSize: " + serialPort.DataBits + "\n");
            tBoxDebugPortInfo.AppendText("StopBits: " + serialPort.StopBits + "\n");
            tBoxDebugPortInfo.AppendText("Parity: " + serialPort.Parity + "\n");
        }

        //очистка текстовых полей
        private void clearTextBoxes()
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            tBoxDebugPortInfo.Text = "";
            tBoxDebug.Text = "";
        }

        private StringBuilder OldText = new StringBuilder();

        //установка параметров порта
        private bool setConfigParams()
        {
            serialPort.BaudRate = int.Parse(cBoxSpeed.SelectedItem.ToString());

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

            cBoxStopBitsValue = cBoxStopBits.SelectedItem.ToString();
            cBoxDataBitsValue = Convert.ToInt32(cBoxDataBits.SelectedItem.ToString());
            if (!checkCombinations(cBoxStopBitsValue, cBoxDataBitsValue))
                return false;
            else return true;

        }

        private void TextBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "[0-9\b.]"))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
