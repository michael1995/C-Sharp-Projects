using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo
{
    class Permission
    {
        #region instance variables

        long _lngPKID = 0;
        string _strTableName = "tblEmployeeForms";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructor

        public Permission()
        {
            loadDataSet();
            addNewRecord();
        }

        public Permission(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }
        #endregion

        #region Properties 

        public long EmployeeID { get; set; }
        public long FormID { get; set; }
        public string AccessLevelCode { get; set; }
        public string AccessType { get; set; }

        #endregion

        #region Accessors 

        public void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE EmployeeFormID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }

        private void assignFields()
        {
            EmployeeID = long.Parse(_dst.Tables[_strTableName].Rows[0]["EmployeeID"].ToString());
            FormID = long.Parse(_dst.Tables[_strTableName].Rows[0]["FormID"].ToString());
            AccessLevelCode = _dst.Tables[_strTableName].Rows[0]["AccessLevelCode"].ToString();
            AccessType = _dst.Tables[_strTableName].Rows[0]["AccessType"].ToString();
        }

        public DataTable getEmployees()
        {
            return _dbConn.GetDataTable("qryEmployeeActive");
        }

        public DataTable getForms()
        {
            return _dbConn.GetDataTable("tblForms");
        }

        public DataTable getAccessTypes()
        {
            return _dbConn.GetDataTable("tblEmployeeForms");
        }
        
        #endregion 

        #region Mutators

        public void saveData()
        {
            if (_lngPKID == 0)
                addNewRecord();
            else
                updateRecord();

            _dbConn.SaveData(_dst, _strTableName);
        }

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

        #endregion 
    }
}
