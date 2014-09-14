using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPDemo.Employee
{
    public class EmployeeClass
    {

        #region Class Variables

        long _lngPKID = 0;
        string _strTableName = "tblEmployees"; // table name
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst = new DataSet(); // Creating new instance of dataset
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors

        /// <summary>
        /// Constructor for the new Employee 
        /// </summary>
        public EmployeeClass()
        {
            loadDataSet();
        }

        /// <summary>
        /// Constructor for the exisiting Employee
        /// </summary>
        public EmployeeClass(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();

        }

        #endregion 

        #region Properties
        /// <summary>
        /// Creating properties to manipulate the database 
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        #endregion 

        #region Accessors
        /// <summary>
        ///  Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblEmployees loaded.
        /// Description:    This method will load the dataset with records from the Employee table. 
        /// </summary>
        private void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE EmployeeID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
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
            Salary = _dst.Tables[_strTableName].Rows[0]["Salary"].ToString();
            UserName = _dst.Tables[_strTableName].Rows[0]["UserName"].ToString();
            UserPassword = _dst.Tables[_strTableName].Rows[0]["UserPassword"].ToString();
        }

        public DataSet GetDataSet()
        {
            return _dst;
        }

        #endregion 

        #region Mutators
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
