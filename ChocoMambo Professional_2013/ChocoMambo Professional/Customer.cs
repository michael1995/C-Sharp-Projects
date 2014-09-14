using DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChocoMambo_Professional
{
    public class Customer
    {
        #region instance variables

        long _lngPKID = 0;
        string _strTableName = "tblCustomer"; // The Table Name
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // Database Name 
        DataSet _dst = new DataSet(); // Create new instances of the dataset
        DataRow _drwRecord = null;

        #endregion 

        #region Constructor
        /// <summary>
        /// Constructor for the new customer
        /// </summary>
        public Customer()
        {
            loadDataSet();
            addNewRecord();
        }
        /// <summary>
        /// Constructor for the existing customer
        /// </summary>
        /// <param name="pLongID"></param>
        public Customer(long pLongID)
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
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public Boolean Active { get; set; }

        #endregion

        #region Accessors 
        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblCustomer loaded.
        /// Description:    This method will load the dataset with records from the Customers table.
        /// </summary>
        public void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE CustomerID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            EmployeeID = long.Parse(_dst.Tables[_strTableName].Rows[0]["EmployeeID"].ToString());
            CustomerName = _dst.Tables[_strTableName].Rows[0]["CustomerName"].ToString();
            Phone = _dst.Tables[_strTableName].Rows[0]["Phone"].ToString();
            Address = _dst.Tables[_strTableName].Rows[0]["Address"].ToString();
            Suburb = _dst.Tables[_strTableName].Rows[0]["Suburb"].ToString();
            Postcode = _dst.Tables[_strTableName].Rows[0]["Postcode"].ToString();
            State = _dst.Tables[_strTableName].Rows[0]["State"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the qryEmployeeActive
        /// Description:    This method will return the qryEmployeeActive to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable qryEmployeeActive</returns>
        public DataTable getEmployees()
        {
            return _dbConn.GetDataTable("qryEmployeeActive");
        }
        #endregion 

        #region Mutators
        /// <summary>
        ///  Pre-condition:  true
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
            _drwRecord["EmployeeID"] = EmployeeID;
            _drwRecord["CustomerName"] = CustomerName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["State"] = State;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["CustomerID"].ToString());
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
            _drwRecord["CustomerName"] = CustomerName;
            _drwRecord["Phone"] = Phone;
            _drwRecord["Address"] = Address;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["State"] = State;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
