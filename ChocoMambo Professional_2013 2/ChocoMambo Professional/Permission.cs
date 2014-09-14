using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo_Professional
{
    class Permission
    {
        #region instance variables

        long _lngPKID = 0; // set the long to 0
        string _strTableName = "tblEmployeeForms"; // table name
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); //Database located in the debug folder of this project
        DataSet _dst = new DataSet(); // set up a new instance of the dataset 
        DataRow _drwRecord = null; // make the instance null

        #endregion 

        #region Constructor
        /// <summary>
        /// Constructor for the new Permissions
        /// </summary>
        public Permission()
        {
            loadDataSet();
            addNewRecord();
        }
        /// <summary>
        /// Constructor for the existing Permissions
        /// </summary>
        /// <param name="pLongID"></param>
        public Permission(long pLongID)
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
        public long EmployeeID { get; set; }
        public long FormID { get; set; }
        public string AccessLevelCode { get; set; }
        public string AccessType { get; set; }

        #endregion

        #region Accessors 
        /// <summary>
        /// load the dataset from selecting everything from the table and by grabbing the ID 
        /// </summary>
        public void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE EmployeeFormID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }
        /// <summary>
        /// Make the properties equal to the database objects
        /// </summary>
        private void assignFields()
        {
            EmployeeID = long.Parse(_dst.Tables[_strTableName].Rows[0]["EmployeeID"].ToString());
            FormID = long.Parse(_dst.Tables[_strTableName].Rows[0]["FormID"].ToString());
            AccessLevelCode = _dst.Tables[_strTableName].Rows[0]["AccessLevelCode"].ToString();
            AccessType = _dst.Tables[_strTableName].Rows[0]["AccessType"].ToString();
        }
        /// <summary>
        /// get all the data from the query
        /// </summary>
        /// <returns></returns>
        public DataTable getEmployees()
        {
            return _dbConn.GetDataTable("qryEmployeeActive");
        }
        /// <summary>
        /// get all the data from the query
        /// </summary>
        /// <returns></returns>
        public DataTable getForms()
        {
            return _dbConn.GetDataTable("tblForms");
        }
        /// <summary>
        /// get all the data from the query
        /// </summary>
        /// <returns></returns>
        public DataTable getAccessTypes()
        {
            return _dbConn.GetDataTable("tblEmployeeForms");
        }
        
        #endregion 

        #region Mutators
        /// <summary>
        /// Either add a new record or update and save the ID and its row from the table 
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
            _drwRecord["EmployeeID"] = EmployeeID;
            _drwRecord["FormID"] = FormID;
            _drwRecord["AccessLevelCode"] = AccessLevelCode;
            _drwRecord["AccessType"] = AccessType;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["EmployeeFormID"].ToString());
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
            _drwRecord["EmployeeID"] = EmployeeID;
            _drwRecord["FormID"] = FormID;
            _drwRecord["AccessLevelCode"] = AccessLevelCode;
            _drwRecord["AccessType"] = AccessType;
            _drwRecord.EndEdit();
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will delete the selected record in the data set.
        /// Description:    This method will delete the selected record in the dataset.
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void delete(long pLongPKID)
        {
            _dst.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
            _dbConn.SaveData(_dst, _strTableName);
        }

        #endregion 
    }
}
