using DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChocoMambo
{
    public class Customer
    {
        #region instance variables

        long _lngPKID = 0;
        string _strTableName = "tblCustomer";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructor

        public Customer()
        {
            loadDataSet();
            addNewRecord();
        }

        public Customer(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }
        #endregion

        #region Properties 

        public long EmployeeID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public decimal CreditLimit { get; set; }
        public Boolean Active { get; set; }

        #endregion

        #region Accessors 

        public void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE CustomerID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }

        private void assignFields()
        {
            EmployeeID = long.Parse(_dst.Tables[_strTableName].Rows[0]["EmployeeID"].ToString());
            CustomerName = _dst.Tables[_strTableName].Rows[0]["CustomerName"].ToString();
            Phone = _dst.Tables[_strTableName].Rows[0]["Phone"].ToString();
            Address = _dst.Tables[_strTableName].Rows[0]["Address"].ToString();
            Suburb = _dst.Tables[_strTableName].Rows[0]["Suburb"].ToString();
            Postcode = _dst.Tables[_strTableName].Rows[0]["Postcode"].ToString();
            State = _dst.Tables[_strTableName].Rows[0]["State"].ToString();
            CreditLimit = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["CreditLimit"].ToString());
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
        }

        public DataTable getEmployees()
        {
            return _dbConn.GetDataTable("qryEmployeeActive");
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
            _drwRecord["CustomerName"] = CustomerName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["State"] = State;
            _drwRecord["CreditLimit"] = CreditLimit;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["CustomerID"].ToString());
        }

        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["EmployeeID"] = EmployeeID;
            _drwRecord["CustomerName"] = CustomerName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["State"] = State;
            _drwRecord["CreditLimit"] = CreditLimit;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
