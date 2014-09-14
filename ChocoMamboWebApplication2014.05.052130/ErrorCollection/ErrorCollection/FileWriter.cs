using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCollection
{
    class FileWriter
    {
         
        #region CLASS INSTANCE VARIABLES
                string _strFileName = null, _strFileType = null;   
        #endregion

        #region CONSTRUCTORS
        //A constructor is a special method invoked by the new operator, 
       //to initialise a new instance of the class.

        public FileWriter(string pStrFileName, string pStrFileType)
        {
            _strFileType = pStrFileType;
            _strFileName = pStrFileName;
        }

        #endregion

        #region ACCESSORS
        //are used to let application  see the values of instance variables


        //so we can read from a txt file and binary file
        public string[] readFile()
        {
            string[] arrStrRecords;
            if (_strFileType.Equals("Text"))
                arrStrRecords = readFromTextFile();
            else
                arrStrRecords = readFromBinaryFile();

            return arrStrRecords;
        }

        private string[] readFromTextFile()
        {
            //declare an array to hold our records

            string[] arrStrRecords = new string[getNumberOfRecords()];
            //declare an index to hold the array
            int intIndex = 0;
            
            //streams to open and read the file
            FileStream fsFile = new FileStream(_strFileName, FileMode.Open, FileAccess.Read);
            StreamReader srFile = new StreamReader(fsFile);

            //loop through each file to get the values
            while (!srFile.EndOfStream)
            {
                arrStrRecords[intIndex] = srFile.ReadLine();
                intIndex++; //increment intvalue which will give us the num of records
            }
            //close the streams
            fsFile.Flush();
            srFile.Close();
            fsFile.Close();
            return arrStrRecords;
        }


        public Boolean FileExist()
        {
            Boolean boolTemp = false;
            if (File.Exists(_strFileName))
                boolTemp = true;
            return boolTemp;
        }

        private string[] readFromBinaryFile()
        {
          //declare an array to hold our records. doesnt need an array cos its one line. but to comply with our generic method it we declare it with one record  
            string[] arrStrRecords = new string[1];
            //streams to open and read the Binary file
            FileStream fsFile = new FileStream(_strFileName, FileMode.Open, FileAccess.Read);
            BinaryReader brFile = new BinaryReader(fsFile);
            //read from binary file
            arrStrRecords[0] = brFile.ReadString();
            //close the streams
            fsFile.Flush();
            brFile.Close();
            fsFile.Close();

            return arrStrRecords;
        }

        private int getNumberOfRecords()
        {
            int intValue = 0; //the int value which will be returned
            FileStream fsFile = new FileStream(_strFileName, FileMode.Open, FileAccess.Read);
            StreamReader srFile = new StreamReader(fsFile);

            while (!srFile.EndOfStream)
            {
                srFile.ReadLine();
                intValue++; //increment intvalue which will give us the num of records
            }

            fsFile.Flush();
            srFile.Close();
            fsFile.Close();

            return intValue;
        }
       

        #endregion

        #region MUTATORS
        //lets application update the value of an instance variable in a controlled manner

        //give the user a method to create the file
        public void CreateFile()
        {
            FileStream outFile = new FileStream(_strFileName, FileMode.Append, FileAccess.Write);
            
            if (_strFileType.Equals("Text"))
            {
                StreamWriter writer = new StreamWriter(outFile);
            }
            else
            {
                BinaryWriter writer = new BinaryWriter(outFile);
            }
            outFile.Close();
        }

        public void saveRecord(string pStringRecord)
        {
            if (_strFileType.Equals("Text"))
            writeToTextFile(pStringRecord);
            else
            {
                writeToBinaryFile(pStringRecord);
            }
        }

        private void writeToTextFile(string pStringRecord)
        {
            StreamWriter swFile = new StreamWriter(_strFileName, true);
            swFile.WriteLine(pStringRecord);
            swFile.Close();
        }

        private void writeToBinaryFile(string pStringRecord)
        {
            FileStream fsFile = new FileStream(_strFileName, FileMode.Append, FileAccess.Write);
            BinaryWriter bwFile = new BinaryWriter(fsFile);
            bwFile.Write(pStringRecord);
            fsFile.Flush();
            bwFile.Close();
            fsFile.Close();
        }
        #endregion
    }
}
