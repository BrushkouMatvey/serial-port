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
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace serialPort
{
    public partial class Form1 : Form
    {
        ////////////////lab1///////////////

        private SerialPort serialPort;
        Package package;
        private String inputTextBoxStrToPackage;

        bool isSourceAddressSet = false, isDestinationAddressSet = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputTextBoxStrToPackage = string.Empty;
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

            textBoxDestinationAddress.Enabled = false;
            textBoxSourceAddress.Enabled = false;

            setSourceButton.Enabled = false;
            setDestinationButton.Enabled = false;

            textBoxSourceAddress.Enabled = false;
            textBoxDestinationAddress.Enabled = false;
            package = new Package();

        } 

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (serialPortConnect())
            {
                errorProvider.SetError(cBoxSelectedComPort, null);
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                cBoxSelectedComPort.Enabled = false;
                outputTextBox.Enabled = true;
                textBoxDestinationAddress.Enabled = true;
                textBoxSourceAddress.Enabled = true;
                textBoxSourceAddress.Enabled = true;
                textBoxDestinationAddress.Enabled = true;
                setDestinationButton.Enabled = true;
                setSourceButton.Enabled = true;
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            cBoxSelectedComPort.Enabled = true;
            outputTextBox.Enabled = true;
            inputTextBox.Enabled = false;
            textBoxDestinationAddress.Enabled = false;
            textBoxSourceAddress.Enabled = false;
            setSourceButton.Enabled = false;
            setDestinationButton.Enabled = false;
            package.DestinationAddress = 0;
            package.SourceAddress = 0;
            package.Fcs = 0;
            checkBoxErrorSimulation.Checked = false;

            clearTextBoxes();
            setDefaultSerialPortValues();
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort = null;
            }
        } 

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
        
        private void ErrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialError.Frame:
                    outputTextBox.AppendText(">>The hardware detected a framing error.\n");
                    break;
                case SerialError.Overrun:
                    outputTextBox.AppendText(">>A character - buffer overrun has occurred.The next character is lost.\n");
                    break;
                case SerialError.RXOver:
                    outputTextBox.AppendText(">>An input buffer overflow has occurred.\n");
                    break;
                case SerialError.RXParity:
                    outputTextBox.AppendText(">>The hardware detected a parity error.\n");
                    break;
                case SerialError.TXFull:
                    outputTextBox.AppendText(">>The application tried to transmit a character, but the output buffer was full.\n");
                    break;
            }
        }

        private void InputTextBox_GotFocus(object sender, EventArgs e) => OldText = new StringBuilder(inputTextBox.Text);
        
        private void InputTextBox_Click(object sender, EventArgs e)
        {
            if (inputTextBox.SelectionStart != inputTextBox.Text.Length)
            {
                inputTextBox.SelectionStart = inputTextBox.Text.Length;
            }
        }
        
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
        
        private void showInfoDebug()
        {
            tBoxDebugPortInfo.Text = "Name: " + serialPort.PortName + "\n";
            tBoxDebugPortInfo.AppendText("BaudRate: " + serialPort.BaudRate + "\n");
            tBoxDebugPortInfo.AppendText("BiteSize: " + serialPort.DataBits + "\n");
            tBoxDebugPortInfo.AppendText("StopBits: " + serialPort.StopBits + "\n");
            tBoxDebugPortInfo.AppendText("Parity: " + serialPort.Parity + "\n");
        }

        private void clearTextBoxes()
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            tBoxDebugPortInfo.Text = "";
            tBoxDebug.Text = "";
            textBoxDestinationAddress.Text = "";
            textBoxSourceAddress.Text = "";
            textBoxSourceAddress.Text = "";
            textBoxDestinationAddress.Text = "";
        }

        private StringBuilder OldText = new StringBuilder();
        
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

        ////////////////lab2///////////////
            
        private void TextBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "[0-9\b.]"))
                e.Handled = false;
            else e.Handled = true;
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "[A-Za-z0-9]"))
                e.Handled = false;
            else e.Handled = true;
        }
        
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!portIsOpen())
            {
                tBoxDebug.Text = "";
                tBoxDebug.AppendText(">>Serial port is not open\n");
            }

            byte[] data;
            if (OldText.Length <= inputTextBox.Text.Length)
            {
                if (inputTextBox.Text.Substring(OldText.Length)[0] < 'А' || inputTextBox.Text.Substring(OldText.Length)[0] > 'я')
                {
                    inputTextBoxStrToPackage += inputTextBox.Text.Substring(OldText.Length);
                    if (inputTextBoxStrToPackage.Length == 7)
                    {
                        data = Encoding.UTF8.GetBytes(inputTextBoxStrToPackage);
                        fillPackage(data);
                        byte[] sendMsg = bitStuffing(package);
                        if (package.Fcs == 0)
                        {
                            sendPackage(sendMsg);
                        }
                        string hex = ByteArrayToString(sendMsg);
                        tBoxDebug.AppendText(">>" + hex + "\n");
                        inputTextBoxStrToPackage = string.Empty;
                    }
                }
                else
                {
                    inputTextBox.Text = inputTextBox.Text.Substring(0, inputTextBox.Text.Length - 1);
                }
            }

            OldText.Length = inputTextBox.Text.Length;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", " ");
        }
        
        public void sendPackage(byte[] allPackageInfo)
        {
            serialPort.Write(allPackageInfo, 0, allPackageInfo.Length);
            tBoxDebug.AppendText(">>" + "Sending data..." + "\n");
        }

        private void fillPackage(byte[] data)
        {
            if (checkBoxErrorSimulation.Checked)
                package.Fcs = 1;
            else
                package.Fcs = 0;

            package.Data = data;
            showInfoDebug();
        }
        
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] data = new byte[sp.BytesToRead + 1];
            sp.Read(data, 0, data.Length);
            byte[] infoAfterBitStuffing = deBitStuffing(data);

            Package package = ByteArrayToObject(infoAfterBitStuffing);
            if (package.DestinationAddress != Convert.ToByte(textBoxSourceAddress.Text))
                return;
            string s = Encoding.GetEncoding("UTF-8").GetString(package.Data);
            tBoxDebug.AppendText(">>" + "Receiving data..." + "\n");
            outputTextBox.AppendText(s);
        }

        public byte[] bitStuffing(Package package)
        {
            byte[] allPackageInfo = ObjectToByteArray(package);

            String stringPackageInfo = string.Join("", allPackageInfo.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))).Substring(8);
            string resultStr = stringPackageInfo.Replace("0000111", "00001111");

            var numOfBytes = (int)Math.Ceiling(resultStr.Length / 8m);
            byte[] resultWithoutFlag = new byte[numOfBytes];
            string temp;
            for (int i = 0; i<numOfBytes;i++)
            {
                if(resultStr.Substring(8).Length < 8)
                {
                    resultWithoutFlag[i] = Convert.ToByte(resultStr.Substring(0, 8), 2);
                    resultWithoutFlag[i+1] = Convert.ToByte(resultStr.Substring(8), 2);
                    break;
                }
                else
                {
                    resultWithoutFlag[i] = Convert.ToByte(resultStr.Substring(0, 8), 2);
                    resultStr = resultStr.Substring(8);
                }
            }

            String flagStr = "00001110";
            byte[] flag = Enumerable.Range(0, flagStr.Length / 8).
                Select(pos => Convert.ToByte(flagStr.Substring(pos * 8, 8), 2)).ToArray();

            byte[] result = new byte[flag.Length + resultWithoutFlag.Length];

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = i < flag.Length ? flag[i] : resultWithoutFlag[i - flag.Length];
            }
            return result;
        }

        public byte[] deBitStuffing(byte[] package)
        {
            String stringPackageInfo = string.Join("", package.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))).Substring(8);
            string resultStr = stringPackageInfo.Replace("00001111", "0000111");
            byte[] resultWithoutFlag = Enumerable.Range(0, resultStr.Length / 8).
                       Select(pos => Convert.ToByte(resultStr.Substring(pos * 8, 8), 2)).ToArray();

            String flagStr = "00001110";
            byte[] flag = Enumerable.Range(0, flagStr.Length / 8).
                Select(pos => Convert.ToByte(flagStr.Substring(pos * 8, 8), 2)).ToArray();

            byte[] result = new byte[flag.Length + resultWithoutFlag.Length];

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = i < flag.Length ? flag[i] : resultWithoutFlag[i - flag.Length];
            }

            return result;
        }

        public byte[] ObjectToByteArray(Package package)
        {
            byte[] result = new byte[11];
            result[0] = package.Flag;
            result[1] = package.DestinationAddress; 
            result[2] = package.SourceAddress;
            for (int i = 3; i < 10; i++)
            {
                result[i] = package.Data[i - 3];
            }
            result[10] = package.Fcs;
            return result;
        }

        public Package ByteArrayToObject(byte[] data)
        {
            return new Package(data[1], data[2], getPackageData(data), data[10]);
        }

        public byte[] getPackageData(byte[] packageInfo)
        {
            byte[] packageData = new byte[7];
            for (int i = 3; i < 10; i++)
            {
                packageData[i - 3] = packageInfo[i];
            }
            return packageData;
        }

        private void SetSourceButton_Click(object sender, EventArgs e)
        {
            if (textBoxSourceAddress.Text.Length == 0)
            {
                tBoxDebug.AppendText(">>Source address is not filled\n");
                return;
            }
            if (Convert.ToInt32(textBoxSourceAddress.Text) < 0 ||
                Convert.ToInt32(textBoxSourceAddress.Text) > 255)
            {
                tBoxDebug.AppendText(">>Source address is not in the range from 0 to 255\n");
                return;
            }

            if (textBoxDestinationAddress.Text == textBoxSourceAddress.Text && isDestinationAddressSet)
            {
                tBoxDebug.AppendText(">>Source address must be different from Distination address\n");
                return;
            }
            package.SourceAddress = Convert.ToByte(textBoxSourceAddress.Text);
            tBoxDebug.AppendText(">>Source address is set\n");
            showInfoDebug();
            isSourceAddressSet = true;
            isAddressesSetted();
        }

        private void SetDestinationButton_Click(object sender, EventArgs e)
        {
            if (textBoxDestinationAddress.Text.Length == 0)
            {
                tBoxDebug.AppendText(">>Distination address is not filled\n");
                return;
            }
            if (Convert.ToInt32(textBoxDestinationAddress.Text) < 0 ||
                Convert.ToInt32(textBoxDestinationAddress.Text) > 255)
            {
                tBoxDebug.AppendText(">>Distination address is not in the range from 0 to 255\n");
                return;
            }
            if (textBoxDestinationAddress.Text == textBoxSourceAddress.Text && isSourceAddressSet)
            {
                tBoxDebug.AppendText(">>Distination address must be different from Source address\n");
                return;
            }
            package.DestinationAddress = Convert.ToByte(textBoxDestinationAddress.Text);
            tBoxDebug.AppendText(">>Distination address is set\n");
            showInfoDebug();
            isDestinationAddressSet = true;
            isAddressesSetted();
        }

        private void isAddressesSetted()
        {
            if (isSourceAddressSet && isDestinationAddressSet)
                inputTextBox.Enabled = true;
        }
    }

    public class Package
    {
        public byte Flag { get; set; } = 0x0E;
        public byte SourceAddress { get; set; }
        public byte DestinationAddress { get; set; }
        public byte[] Data { get; set; }
        public byte Fcs { get; set; }

        public Package() { }
        public Package(byte[] data, byte fcs)
        {
            this.Data = data;
            this.Fcs = fcs;
        }
        public Package(byte destinationAddress, byte sourceAddress, byte[] data, byte fcs)
        {
            this.SourceAddress = sourceAddress;
            this.DestinationAddress = destinationAddress;
            this.Data = data;
            this.Fcs = fcs;
        }
    }
}