using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ErrorHandling
{
    public class HandleErrors
    {

        static DateTime DateT = DateTime.Now;

        static string Error;
        string fileName = "Documents:\\Error.txt";
        static string Message = DateT + "" + Error;

        public void writeMessage(Exception ex)
        {
            Error = ex.Message;
            CheckFileExist(fileName);

            StreamWriter sw = new StreamWriter(fileName, true);
            for (int i = 0; i < 2; i++)
            {
                sw.WriteLine(string.Empty[i]);
            }
            sw.WriteLine(Message);
            sw.Close();
        }

        private void CheckFileExist(string pStrFilePath)
        {
            if (!File.Exists(pStrFilePath))
            {
                File.Create(pStrFilePath);
            }
        }

        public void displayMessage(Exception ex)
        {
            Console.WriteLine(DateT + "\n" + ex.Message);
        }
        public void openText()
        {
            //open a note pad error text file
            System.Diagnostics.Process.Start("notepad.exe", "G:\\poop.txt");
        }
    }
}
