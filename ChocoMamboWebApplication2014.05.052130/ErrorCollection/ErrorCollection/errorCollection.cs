using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCollection
{
    public class errorCollection
    {
        #region CLASS INSTANCE VARIABLES

        String _strFileName;
        FileWriter _fileWritter;
        DateTime _dtNow = DateTime.Now;
        #endregion

        #region CONSTRUCTORS

        public errorCollection()
        {            
            _strFileName = "ErrorLog";
            _fileWritter = new FileWriter(_strFileName, "");
        }
        #endregion

        #region ACCESSORS
        public void openErrorLog()
        {
            System.Diagnostics.Process.Start(_strFileName);
        }
        #endregion

        #region MUTATORS

        public void createFile()
        {
            _fileWritter.CreateFile();
        }

        public void writeErrorToFile(String pStrErrorMessage)
        {
            if (!_fileWritter.FileExist())
                createFile();

           _fileWritter.saveRecord(BuildErrorMessage(pStrErrorMessage));
        }

        private string BuildErrorMessage(String pStrErrorMessage)
        {
            return "<--Error-->"+_dtNow.ToString() + " " + pStrErrorMessage;
        }
        #endregion
    }
}
