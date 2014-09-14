using DBConnection;
using ErrorCollection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


namespace ChocoMamboWebApplication.AppObjects
{
    public class SaleLine
    {
        #region Class Variables
        long _lngFKID = 0, _lngPKID = 0;
        string _strTableName = "tbl_SaleLines";
        dbConnection _dbConnection = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        errorCollection _errorCollection = new errorCollection();
        DataSet _dataset;
        DataRow _drwRecord = null;
        #endregion

        #region Constructor
        public SaleLine(DataSet pDataSet, long pLongID)
        {
            _dataset = pDataSet;
            _lngFKID = pLongID;
            loadDataSet();
            assignFields();
        }
        #endregion

        #region Properties
        public long SaleNumber { get; set; }
        public long ProductNumber { get; set; }
        public string productCode { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public long SaleLineQty { get; set; }
        public Decimal SaleLineSubTotal { get; set; }
        public long PKID
        {
            get { return _lngPKID; }
            set { _lngPKID = value; }
        }

        #endregion

        #region Control Events
        #endregion

        #region Accessors
        /// <summary>
        ///Pre-Condition:An instance of a dataset, a string tableName and long ID.
        ///Post-Condition: Dataset is loaded with data relevant to the query.
        ///Description: Loads a dataset with data relevant  to the query.
        /// </summary>
        private void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;
            if (_lngFKID != 0)
                strSQL += " WHERE SaleNumber = " + _lngFKID;

            _dbConnection.fillDataSet(_dataset, strSQL, _strTableName);
        }
        /// <summary>
        ///Pre-Condition:Dataset column names match the column names described
        ///Post-Condition: Properties in this class will be set to the values defined each specified column
        ///Description: assigns properties to dataset cell values.
        /// </summary>
        private void assignFields()
        {
            try
            {
                SaleNumber = long.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleNumber"].ToString());
                ProductNumber = long.Parse(_dataset.Tables[_strTableName].Rows[0]["ProductNumber"].ToString());
                productCode = _dataset.Tables[_strTableName].Rows[0]["ProductCode"].ToString();
                ProductName = _dataset.Tables[_strTableName].Rows[0]["ProductName"].ToString();
                ProductPrice = decimal.Parse(_dataset.Tables[_strTableName].Rows[0]["ProductPrice"].ToString());
                SaleLineQty = long.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleLineQty"].ToString());
            }
            catch (IndexOutOfRangeException ex)
            {
             //   _errorCollection.writeErrorToFile(ex.Message);
            }
        }
        #endregion

        #region Mutators
        public void saveData()
        {
            _dbConnection.SaveData(_dataset, _strTableName);
        }

        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:a new record is added to the table associated with the class 
        ///Description:Adds a new record to the table associated with the class
        /// </summary>
        public void addNewRecord()
        {
            _drwRecord = _dataset.Tables[_strTableName].NewRow();
            _drwRecord.BeginEdit();
            _drwRecord["SaleNumber"] = SaleNumber;
            _drwRecord["ProductNumber"] = ProductNumber;
            _drwRecord["ProductCode"] = productCode;
            _drwRecord["ProductName"] = ProductName;
            _drwRecord["ProductPrice"] = ProductPrice;
            _drwRecord["SaleLineQty"] = SaleLineQty;
            _drwRecord["SaleLineTotal"] = SaleLineSubTotal;
            _drwRecord.EndEdit();
            _dataset.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["ID"].ToString());
        }
        /// <summary>
        ///Pre-Condition: All properties have an assigned value
        ///Post-Condition:The current record is updated 
        ///Description:Updates the current record to the table associated with the class
        /// </summary>
        public void updateRecord()
        {
            try
            {
                _drwRecord = _dataset.Tables[_strTableName].Rows.Find(_lngPKID);
                _drwRecord.BeginEdit();
                _drwRecord["SaleNumber"] = SaleNumber;
                _drwRecord["ProductNumber"] = ProductNumber;
                _drwRecord["ProductCode"] = productCode;
                _drwRecord["ProductName"] = ProductName;
                _drwRecord["ProductPrice"] = ProductPrice;
                _drwRecord["SaleLineQty"] = SaleLineQty;
                _drwRecord["SaleLineTotal"] = SaleLineSubTotal;
                _drwRecord.EndEdit();
            }
            catch (System.NullReferenceException ex)
            {
         //       _errorCollection.writeErrorToFile(ex.Message);

            }
        }
        /// <summary>
        ///Description: Sets the private dataset to one passed.
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deleteSaleLine(long pLongPKID)
        {
            _dataset.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
        }
        #endregion
    }
}