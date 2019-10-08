using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialPort
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            /*if (args.Length == 0)
            {
                Process process = new Process();
                process.StartInfo.FileName = "D:\\Documents\\Learning\\Unik\\5sem\\ТОКС\\serialPort\\serialPort\\bin\\Debug\\serialPort.exe";
                process.StartInfo.Arguments = "app2";
                process.Start();
            }*/
            Application.Run(new Form1());


        }
    }
}
