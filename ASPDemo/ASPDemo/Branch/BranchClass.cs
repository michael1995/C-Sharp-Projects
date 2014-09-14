using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.Branch
{
    public class BranchClass
    {
        #region class variables 

        long _lngPKID = 0; // set the long to 0
        string _strTableName = "tblBranch"; // table name
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); 
        DataSet _dst = new DataSet(); // set up a new instance of the dataset 
        DataRow _drwRecord = null; // make the instance null

        #endregion 

        #region Constructors 

        /// <summary>
        /// Constructor for the new branch
        /// </summary>
        public BranchClass()
        {
            loadDataSet();
        }

        /// <summary>
        /// Constructor for the existing branch
        /// </summary>
        /// <param name="pLongID"></param>
        public BranchClass(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties 
        /// <summary>
        /// Creating Properties to be used manipulate data to the database
        /// </summary>
        public string BranchOffice { get; set; }

        #endregion 

        #region Accessors
        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblBranch loaded.
        /// Description:    This method will load the dataset with records from the branch table. 
        /// </summary>
        public void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE BranchID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            BranchOffice = _dst.Tables[_strTableName].Rows[0]["BranchOffice"].ToString();
        }

        #endregion 

        #region Mutator 
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will save the data to the database.
        /// Description:    This method will save the data to the database whether its' new or updated record.
        /// </summary>
        public void saveData()
        {
            if (_lngPKID == 0)
                addNewRecord();
            else
                updateRecord();

            _dbConn.SaveData(_dst, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will add a new record in the dataset.
        /// Description:    This method will add a new record in the dataset.
        /// </summary>
        private void addNewRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].NewRow();
            _drwRecord.BeginEdit();
            _drwRecord["BranchOffice"] = BranchOffice;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will update the selected record in the dataset.
        /// Description:    This method will update the selected record in the dataset.
        /// </summary>
        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["BranchOffice"] = BranchOffice;
            _drwRecord.EndEdit();
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will delete the selected record in the data set.
        /// Description:    This method will delete the selected record in the dataset.
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deleteRecord(long pLongPKID)
        {
            if (_lngPKID != 0)
            {
                _dst.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
                _dbConn.SaveData(_dst, _strTableName);
            }
        }

        #endregion 
    }
}