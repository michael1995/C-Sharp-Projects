using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo_Professional
{
    public class Product
    {
        #region class variables 

        long _lngPKID = 0;
        string _strTableName = "Product"; // The Table Name
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // Database Name 
        DataSet _dst = new DataSet(); // Create new instances of the dataset
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors 
        /// <summary>
        /// Constructor for new Product
        /// </summary>
        public Product()
        {
            loadDataSet();
        }
        /// <summary>
        /// Constructor for existing product
        /// </summary>
        /// <param name="pLongID"></param>
        public Product(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties 
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string QuantityInStock { get; set; }
        public string Price { get; set; }
        public string Comments { get; set; }
        public Boolean Active { get; set; }
        #endregion 

        #region Accessors
        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the products loaded.
        /// Description:    This method will load the dataset with records from the products table.
        /// </summary>
        public void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE ProductID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            ProductName = _dst.Tables[_strTableName].Rows[0]["ProductName"].ToString();
            ProductCode = _dst.Tables[_strTableName].Rows[0]["ProductCode"].ToString();
            QuantityInStock = _dst.Tables[_strTableName].Rows[0]["QuantityInStock"].ToString();
            Price = _dst.Tables[_strTableName].Rows[0]["Price"].ToString();
            Comments = _dst.Tables[_strTableName].Rows[0]["Comments"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
        }

        #endregion 

        #region Mutator 
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
            _drwRecord["ProductName"] = ProductName;
            _drwRecord["ProductCode"] = ProductCode;
            _drwRecord["QuantityInStock"] = QuantityInStock;
            _drwRecord["Price"] = Price;
            _drwRecord["Comments"] = Comments;
            _drwRecord["Active"] = Active;
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
            _drwRecord["ProductName"] = ProductName;
            _drwRecord["ProductCode"] = ProductCode;
            _drwRecord["QuantityInStock"] = QuantityInStock;
            _drwRecord["Price"] = Price;
            _drwRecord["Comments"] = Comments;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
