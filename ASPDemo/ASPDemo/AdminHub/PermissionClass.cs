using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.AdminHub
{
    public class PermissionClass
    {
        #region instance variables

        long _lngPKID = 0; // set the long to 0
        string _strTableName = "tblEmployeeForms"; // table name
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst = new DataSet(); // set up a new instance of the dataset 
        DataRow _drwRecord = null; // make the instance null

        #endregion 

        #region Constructor
        /// <summary>
        /// Constructor for the new Permissions
        /// </summary>
        public PermissionClass()
        {
            loadDataSet();
            addNewRecord();
        }
        /// <summary>
        /// Constructor for the existing Permissions
        /// </summary>
        /// <param name="pLongID"></param>
        public PermissionClass(long pLongID)
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
        public string Employee { get; set; }
        public long PageID { get; set; }
        public string Page { get; set; }
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
            Employee = _dst.Tables[_strTableName].Rows[0]["Employee"].ToString();
            PageID = long.Parse(_dst.Tables[_strTableName].Rows[0]["PageID"].ToString());
            Page = _dst.Tables[_strTableName].Rows[0]["Page"].ToString();
            AccessType = _dst.Tables[_strTableName].Rows[0]["AccessType"].ToString();
        }
        /// <summary>
        /// get all the data from the query
        /// </summary>
        /// <returns></returns>
        public DataTable getEmployees()
        {
            return _dbConn.GetDataTable("qryEmployee");
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
            _drwRecord["Employee"] = Employee;
            _drwRecord["PageID"] = PageID;
            _drwRecord["Page"] = Page;
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
            _drwRecord["Employee"] = Employee;
            _drwRecord["PageID"] = PageID;
            _drwRecord["Page"] = Page;
            _drwRecord["AccessType"] = AccessType;
            _drwRecord.EndEdit();
        }

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