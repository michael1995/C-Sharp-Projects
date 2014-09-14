using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassErrorCollection
{
    public class ErrorCollection
    {
        #region Global Variables 

        String _strErrorMessage, _strFileName;
        FileWriter _fileWriter; // call the file writer class
        DateTime _dtDate = DateTime.Now; // set the date time to now
        #endregion 

        #region Constructor
        /// <summary>
        /// set the error message 
        /// </summary>
        /// <param name="pStrErrorMessage"></param>
        public ErrorCollection(String pStrErrorMessage)
        {
            _strErrorMessage = pStrErrorMessage; // the global now has the same value as the paremeter value passed
            _strFileName = "ErrorLog"; // give the file a name
            _fileWriter = new FileWriter(_strFileName, ""); // pass the name and nothing becuase it is a binary file that we want this file to be
        } 

        #endregion 

        #region Accessors
        /// <summary>
        /// open the error log 
        /// </summary>
        public void errorLog()
        {
            System.Diagnostics.Process.Start(_strFileName); // opens the file whever it is located
        }

        #endregion

        #region Properties


        #endregion

        #region Mutators
        /// <summary>
        /// write to the file using the file writer class
        /// </summary>
        public void writeToFile()
        {
            if (!_fileWriter.checkIfFileExists())
            {
                _fileWriter.CreateFile(); // only create the file if the file exists
            }
            _fileWriter.saveRecord(BuildErrorMessage()); // save the error message 
        }
        /// <summary>
        /// create the file using the file writer class
        /// </summary>
        public void createFile()
        {
            _fileWriter.CreateFile();
        }
        /// <summary>
        /// build the error message
        /// </summary>
        /// <returns>the strTemp so it can be used in the write message method</returns>
        private string BuildErrorMessage()
        {
            // put together a temp string with other values like the error message and the date with other characters 
            string strTemp = "<-- Error --> " + _dtDate.ToString() + ", " +_strErrorMessage + " <-- End Of line -->" + System.Environment.NewLine;

            return strTemp;
        }
        #endregion
    }
}
