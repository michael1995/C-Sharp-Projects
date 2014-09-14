using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo
{
    public class Supplier
    {
        #region Class Variables

        long _lngPKID = 0;
        string _strTableName = "tblSuppliers";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors

        /// <summary>
        /// Constructor for the new customer 
        /// </summary>
        public Supplier()
        {
            loadDataSet();
        }

        /// <summary>
        /// Constructor for the exisiting customer
        /// </summary>
        public Supplier(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();

        }

        #endregion 

        #region Properties

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public Boolean Active { get; set; }
        #endregion 

        #region Accessors
        private void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE SupplierID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }

        private void assignFields()
        {
            SupplierName = _dst.Tables[_strTableName].Rows[0]["SupplierName"].ToString();
            Address = _dst.Tables[_strTableName].Rows[0]["Address"].ToString();
            Suburb = _dst.Tables[_strTableName].Rows[0]["Suburb"].ToString();
            State = _dst.Tables[_strTableName].Rows[0]["State"].ToString();
            Postcode = _dst.Tables[_strTableName].Rows[0]["Postcode"].ToString();
            Phone = _dst.Tables[_strTableName].Rows[0]["Phone"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());

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
            _drwRecord["SupplierName"] = SupplierName;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
        }

        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord["SupplierName"] = SupplierName;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
