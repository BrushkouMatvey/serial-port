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
            package.Crc = 0;
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
                tBoxDebug.AppendText(">>Serial port is not open");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            if (!setConfigParams())
            {
                return;
            }
            showInfoDebug();
            tBoxDebug.AppendText(">>Сonfiguration parameters changed");
            tBoxDebug.AppendText(Environment.NewLine);
        }

        private bool serialPortConnect()
        {
            if (serialPort != null)
                serialPort.Close();

            serialPort = new SerialPort(cBoxSelectedComPort.SelectedItem.ToString());
            try
            {
                serialPort.Open();
                tBoxDebug.AppendText(">>Connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.");
                tBoxDebug.AppendText(Environment.NewLine);
                setConfigParams();
                showInfoDebug();

            }
            catch
            {
                tBoxDebug.AppendText(">>Can't connect to " + cBoxSelectedComPort.SelectedItem.ToString() + " serial port.");
                tBoxDebug.AppendText(Environment.NewLine);
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
                tBoxDebug.AppendText(">>Invalid combination of DataBits and StopBits values");
                tBoxDebug.AppendText(Environment.NewLine);
                cBoxDataBits.SelectedIndex = cBoxDataBits.FindStringExact(Convert.ToString(5));
                showInfoDebug();
                return false;
            }
            else if (cBoxStopBitsValue == "Two" && cBoxDataBitsValue.ToString() == Convert.ToString(5))
            {
                tBoxDebug.AppendText(">>Invalid combination of DataBits and StopBits values");
                tBoxDebug.AppendText(Environment.NewLine);
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
            string hex;

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
                        package.Flag = 0x0E;
                        package.DestinationAddress = Convert.ToByte(textBoxDestinationAddress.Text);
                        package.SourceAddress = Convert.ToByte(textBoxSourceAddress.Text);
                        data = Encoding.UTF8.GetBytes(inputTextBoxStrToPackage);
                        fillPackage(data);

                        byte[] allPackageInfo = ObjectToByteArray(package);

                        String stringPackageInfo = string.Join("", allPackageInfo.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))).Substring(0, 8 * (allPackageInfo.Length - 1));
                        String CRCcode = createCRC(stringPackageInfo);
                        CRCcode = CRCcode.PadLeft(8, '0');

                        byte[] crc = Enumerable.Range(0, CRCcode.Length / 8).
                        Select(pos => Convert.ToByte(CRCcode.Substring(pos * 8, 8), 2)).ToArray();
                        package.Crc = crc[0];

                        tBoxDebug.AppendText(">>CRC code: " + package.Crc);
                        tBoxDebug.AppendText(Environment.NewLine);

                        byte[] allPackageInfoWithCRC = ObjectToByteArray(package);
                        String stringPackageInfoWithoutCRC = string.Join("", allPackageInfoWithCRC.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))).Substring(0, 8 * (allPackageInfoWithCRC.Length - 1));

                        byte[] sendMsg;
                        if (checkBoxErrorSimulation.Checked)
                        {
                            Random randomNumber = new Random();
                            int rnd = randomNumber.Next(0, stringPackageInfoWithoutCRC.Length - 1);


                            if (stringPackageInfoWithoutCRC[rnd] == '1')
                            {
                                stringPackageInfoWithoutCRC = stringPackageInfoWithoutCRC.Remove(rnd, 1);
                                stringPackageInfoWithoutCRC = stringPackageInfoWithoutCRC.Insert(rnd, "0");
                            }
                            else
                            {
                                stringPackageInfoWithoutCRC = stringPackageInfoWithoutCRC.Remove(rnd, 1);
                                stringPackageInfoWithoutCRC = stringPackageInfoWithoutCRC.Insert(rnd, "1");
                            }


                            sendMsg = Enumerable.Range(0, (stringPackageInfoWithoutCRC + CRCcode).Length / 8).Select(pos => Convert.ToByte((stringPackageInfoWithoutCRC + CRCcode).Substring(pos * 8, 8), 2)).ToArray();

                            package.Flag = sendMsg[0];
                            package.DestinationAddress = sendMsg[1];
                            package.SourceAddress = sendMsg[2];
                            package.Data = getPackageData(sendMsg);

                            hex = ByteArrayToString(sendMsg);
                            tBoxDebug.AppendText(">>Create error");
                            tBoxDebug.AppendText(Environment.NewLine);
                            tBoxDebug.AppendText(">>" + hex);
                            tBoxDebug.AppendText(Environment.NewLine);
                        }
                        sendMsg = bitStuffing(package);
                        String stringAfterBitStuffing = string.Join("", sendMsg.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                        

                        sendPackage(sendMsg);

                        hex = ByteArrayToString(sendMsg);
                        tBoxDebug.AppendText(">>" + hex);
                        tBoxDebug.AppendText(Environment.NewLine);
                        tBoxDebug.AppendText(Environment.NewLine);
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
        }

        private void fillPackage(byte[] data)
        {
            package.Data = data;
            showInfoDebug();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            String stringPackageInfo;
            byte[] infoAfterDeBitStuffing;
            byte[] data;
            if (sp.BytesToRead == 11)
            {
                data = new byte[sp.BytesToRead];
                sp.Read(data, 0, data.Length);
                infoAfterDeBitStuffing = deBitStuffing(data);
                stringPackageInfo = string.Join("", infoAfterDeBitStuffing.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            }
            else
            {
                data = new byte[sp.BytesToRead];
                sp.Read(data, 0, data.Length);
                infoAfterDeBitStuffing = deBitStuffing(data);
                stringPackageInfo = string.Join("", infoAfterDeBitStuffing.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            }
            string hex;
            
            String reminder = verificationData(stringPackageInfo);

            if (reminder.PadLeft(9, '0').CompareTo("000000000") != 0)
            {
                stringPackageInfo = dataErrorFix(stringPackageInfo, reminder);
                tBoxDebug.AppendText(">>" + "Fixing error...");
                tBoxDebug.AppendText(Environment.NewLine);
            }
            byte[] infoAfterFixError = Enumerable.Range(0, stringPackageInfo.Length / 8).
               Select(pos => Convert.ToByte(stringPackageInfo.Substring(pos * 8, 8), 2)).ToArray();


            hex = ByteArrayToString(infoAfterFixError);
            tBoxDebug.AppendText(">>" + hex);
            tBoxDebug.AppendText(Environment.NewLine);

            Package package = ByteArrayToObject(infoAfterFixError);
            if (package.DestinationAddress != Convert.ToByte(textBoxSourceAddress.Text))
            {
                tBoxDebug.AppendText(">>AddressError");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            string s = Encoding.GetEncoding("UTF-8").GetString(package.Data);
            tBoxDebug.AppendText(Environment.NewLine);
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
            for (int i = 0; i < numOfBytes; i++)
            {
                if (resultStr.Substring(8).Length < 8 && resultStr.Substring(8).Length != 0)
                {
                    string nullstr = "00000000";
                    resultWithoutFlag[i] = Convert.ToByte(resultStr.Substring(0, 8), 2);
                    resultStr = resultStr.Insert(resultStr.Substring(0).Length, nullstr.Substring(resultStr.Substring(8).Length));
                    resultWithoutFlag[i + 1] = Convert.ToByte(resultStr.Substring(8), 2);
                    break;
                }
                else
                {
                    resultWithoutFlag[i] = Convert.ToByte(resultStr.Substring(0, 8), 2);
                    resultStr = resultStr.Substring(8);
                }
            }

            String flagStr = Convert.ToString(package.Flag, 2).PadLeft(8, '0');
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
            result[10] = package.Crc;
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
                tBoxDebug.AppendText(">>Source address is not filled");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            if (Convert.ToInt32(textBoxSourceAddress.Text) < 0 ||
                Convert.ToInt32(textBoxSourceAddress.Text) > 255)
            {
                tBoxDebug.AppendText(">>Source address is not in the range from 0 to 255");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }

            if (textBoxDestinationAddress.Text == textBoxSourceAddress.Text && isDestinationAddressSet)
            {
                tBoxDebug.AppendText(">>Source address must be different from Distination address");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            package.SourceAddress = Convert.ToByte(textBoxSourceAddress.Text);
            tBoxDebug.AppendText(">>Source address is set");
            tBoxDebug.AppendText(Environment.NewLine);
            showInfoDebug();
            isSourceAddressSet = true;
            isAddressesSetted();
        }

        private void SetDestinationButton_Click(object sender, EventArgs e)
        {
            if (textBoxDestinationAddress.Text.Length == 0)
            {
                tBoxDebug.AppendText(">>Distination address is not filled");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            if (Convert.ToInt32(textBoxDestinationAddress.Text) < 0 ||
                Convert.ToInt32(textBoxDestinationAddress.Text) > 255)
            {
                tBoxDebug.AppendText(">>Distination address is not in the range from 0 to 255");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            if (textBoxDestinationAddress.Text == textBoxSourceAddress.Text && isSourceAddressSet)
            {
                tBoxDebug.AppendText(">>Distination address must be different from Source address");
                tBoxDebug.AppendText(Environment.NewLine);
                return;
            }
            package.DestinationAddress = Convert.ToByte(textBoxDestinationAddress.Text);
            tBoxDebug.AppendText(">>Distination address is set");
            tBoxDebug.AppendText(Environment.NewLine);
            showInfoDebug();
            isDestinationAddressSet = true;
            isAddressesSetted();
        }

        private void isAddressesSetted()
        {
            if (isSourceAddressSet && isDestinationAddressSet)
                inputTextBox.Enabled = true;
        }


        public String polinom = "100000111";

        private String createCRC(String data)
        {
            String dataWithoutZeros = removeFirstZeros(data);
            if (dataWithoutZeros.Length == polinom.Length)
                return dataWithoutZeros;
            dataWithoutZeros = dataWithoutZeros.PadRight(dataWithoutZeros.Length + polinom.Length - 1, '0');

            String reminder = "";
            int i = 0;
            while (true)
            {
                if (dataWithoutZeros.Length < polinom.Length - reminder.Length)
                {
                    reminder += dataWithoutZeros;
                    break;
                }
                String dataToNewXor = addFromData(dataWithoutZeros.Substring(0, polinom.Length - reminder.Length), reminder);
                if (dataToNewXor.Length < polinom.Length) break;
                dataWithoutZeros = dataWithoutZeros.Substring(polinom.Length - reminder.Length);
                reminder = removeFirstZeros(xorPolinom(dataToNewXor));
            }
            return reminder;
        }
        public String verificationData(String data)
        {
            String reminder = "";
            String dataWithoutZeros = removeFirstZeros(data);
            while (true)
            {
                if (dataWithoutZeros.Length < polinom.Length - reminder.Length)
                {
                    reminder += dataWithoutZeros;
                    break;
                }
                String dataToNewXor = addFromData(dataWithoutZeros.Substring(0, polinom.Length - reminder.Length), reminder);
                if (dataToNewXor.Length < polinom.Length) break;
                dataWithoutZeros = dataWithoutZeros.Substring(polinom.Length - reminder.Length);
                String reminderWithZeros = xorPolinom(dataToNewXor);
                if (reminderWithZeros.PadLeft(9, '0').CompareTo("000000000") == 0 &&
                    dataWithoutZeros.Length < polinom.Length - reminder.Length)
                    return reminderWithZeros;

                reminder = removeFirstZeros(xorPolinom(dataToNewXor));
            }
            return reminder;
        }
        public String addFromData(String data, String strNeed)
        {
            strNeed += data;
            return strNeed;
        }
        public String xorPolinom(String argument)
        {
            int i = 0;
            String result = "";
            foreach (var item in argument)
            {
                if (item == polinom[i])
                    result += '0';
                else result += '1';
                i++;
            }
            return result;
        }
        private String removeFirstZeros(String dataWithZeros)
        {
            int i = 0;
            int j = 0;
            int length = 0;
            while(i<dataWithZeros.Length && dataWithZeros[i] == '0' )
            {
                length++;
                i++;
            }
            while (j<length)
            {
                dataWithZeros = dataWithZeros.Substring(1);
                j++;
            }

            return dataWithZeros;
        }
        private int weightOfReminder(String reminder)
        {
            int weight = 0;
            foreach (var item in reminder)
                if (item == '1') weight++;
            return weight;
        }

        private String xorWithReminder(String data, String reminder)
        {
            String result = data.Substring(0, data.Length - reminder.Length);
            for (int i = reminder.Length; i > 0; i--)
            {
                if (reminder[reminder.Length - i] == data[data.Length - i])
                    result += '0';
                else
                    result += '1';
            }
            return result;
        }

        private String shiftLeft(String data)
        {
            String buf = data.Substring(0, 1);
            data = data.Substring(1);
            data += buf;
            return data;
        }

        private String shiftRight(String data)
        {
            String buf = data.Substring(data.Length - 1);
            data = data.Substring(0, data.Length - 1);
            buf += data;
            return buf;
        }

        private String dataErrorFix(String data, String reminder)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '1')
                {
                    data = data.Remove(i, 1);
                    data = data.Insert(i, "0");
                    reminder = verificationData(data);
                    if (reminder.PadLeft(9, '0').CompareTo("000000000") == 0)
                        break;
                    else
                    {
                        data = data.Remove(i, 1);
                        data = data.Insert(i, "1");
                    }
                }
                else
                {
                    data = data.Remove(i, 1);
                    data = data.Insert(i, "1");
                    reminder = verificationData(data);
                    if (reminder.PadLeft(9, '0').CompareTo("000000000") == 0)
                        break;
                    else
                    {
                        data = data.Remove(i, 1);
                        data = data.Insert(i, "0");
                    }
                }

            }
            return data;


            //int counterLeftShift = 0;
            //while (weightOfReminder(reminder) > 1)
            //{
            //    data = shiftLeft(data);
            //    counterLeftShift++;
            //    reminder = verificationData(data);
            //}
            //if (counterLeftShift != 0)
            //{
            //    data = xorWithReminder(data, reminder);

            //    for (int i = 0; i < counterLeftShift; i++)
            //        shiftRight(data);
            //}
            //else data = xorWithReminder(data, reminder);
            //return data;
        }

    


        public class Package
        {
            public byte Flag { get; set; } = 0x0E;
            public byte SourceAddress { get; set; }
            public byte DestinationAddress { get; set; }
            public byte[] Data { get; set; }
            public byte Crc { get; set; }

            public Package() { }
            public Package(byte[] data, byte crc)
            {
                this.Data = data;
                this.Crc = crc;
            }
            public Package(byte destinationAddress, byte sourceAddress, byte[] data, byte crc)
            {
                this.SourceAddress = sourceAddress;
                this.DestinationAddress = destinationAddress;
                this.Data = data;
                this.Crc = crc;
            }
        }
    }
}