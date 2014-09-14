using DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChocoMambo
{
    public class Branch
    {
        #region class variables 

        long _lngPKID = 0;
        string _strTableName = "tblBranch";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors 

        public Branch()
        {
            loadDataSet();
        }

        public Branch(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties 

        public string BranchOffice { get; set; }
        public Boolean Active { get; set; }

        #endregion 

        #region Accessors

        public void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE BranchID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }

        private void assignFields()
        {
            BranchOffice = _dst.Tables[_strTableName].Rows[0]["BranchOffice"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
        }

        #endregion 

        #region Mutator 

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
            _drwRecord["BranchOffice"] = BranchOffice;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
        }

        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["BranchOffice"] = BranchOffice;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 

    }
}
