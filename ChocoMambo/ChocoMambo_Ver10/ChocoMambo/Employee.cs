using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo
{
    public class Employee
    {

        #region Class Variables

        long _lngPKID = 0;
        string _strTableName = "tblEmployees";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors

        /// <summary>
        /// Constructor for the new customer 
        /// </summary>
        public Employee()
        {
            loadDataSet();
        }

        /// <summary>
        /// Constructor for the exisiting customer
        /// </summary>
        public Employee(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();

        }

        #endregion 

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Boolean Active { get; set; }
        #endregion 

        #region Accessors
        private void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE EmployeeID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }


        private void assignFields()
        {
            FirstName = _dst.Tables[_strTableName].Rows[0]["FirstName"].ToString();
            LastName = _dst.Tables[_strTableName].Rows[0]["LastName"].ToString();
            Phone = _dst.Tables[_strTableName].Rows[0]["Phone"].ToString();
            AddressLine1 = _dst.Tables[_strTableName].Rows[0]["AddressLine1"].ToString();
            Postcode = _dst.Tables[_strTableName].Rows[0]["Postcode"].ToString();
            Suburb = _dst.Tables[_strTableName].Rows[0]["Suburb"].ToString();
            State = _dst.Tables[_strTableName].Rows[0]["State"].ToString();
            Department = _dst.Tables[_strTableName].Rows[0]["Department"].ToString();
            Salary = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["Salary"].ToString());
            UserName = _dst.Tables[_strTableName].Rows[0]["UserName"].ToString();
            UserPassword = _dst.Tables[_strTableName].Rows[0]["UserPassword"].ToString();
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
            _drwRecord["FirstName"] = FirstName;
            _drwRecord["LastName"] = LastName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["AddressLine1"] = AddressLine1;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Department"] = Department;
            _drwRecord["Salary"] = Salary;
            _drwRecord["UserName"] = UserName;
            _drwRecord["UserPassword"] = UserPassword;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
        }

        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["FirstName"] = FirstName;
            _drwRecord["LastName"] = LastName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["AddressLine1"] = AddressLine1;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Department"] = Department;
            _drwRecord["Salary"] = Salary;
            _drwRecord["UserName"] = UserName;
            _drwRecord["UserPassword"] = UserPassword;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
