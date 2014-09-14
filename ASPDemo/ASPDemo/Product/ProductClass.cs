using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.Product
{
    public class ProductClass
    {
        #region class variables 

        long _lngPKID = 0;
        string _strTableName = "Product"; // The Table Name
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst = new DataSet(); // Create new instances of the dataset
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors 
        /// <summary>
        /// Constructor for new Product
        /// </summary>
        public ProductClass()
        {
            loadDataSet();
        }
        /// <summary>
        /// Constructor for existing product
        /// </summary>
        /// <param name="pLongID"></param>
        public ProductClass(long pLongID)
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