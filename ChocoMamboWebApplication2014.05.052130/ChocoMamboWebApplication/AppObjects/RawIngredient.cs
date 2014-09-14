using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class RawIngredient: Stock
    {
        #region Class Variables
        long _lngPKID = 0;
        string _strTableName = "tbl_RawIngredients";
        string _strPKName = "ID";
        dbConnection _dbConnection = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        DataSet _dataset = new DataSet();
        DataRow _drwRecord = null;
        #endregion

        #region Constructor
        public RawIngredient()
        {
            loadDataSet();
           
        }
        public RawIngredient(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }
        public RawIngredient(String pstrSearch)
        {
            loadDataSet();
           
        }
        #endregion

        #region Properties

        public long SupplierNumber { get; set; }

        public DataSet GetDataSet()
        {
            return _dataset;
        }

        #endregion

        #region Accessors
        /// <summary>
        ///Pre-Condition:An instance of a dataset, a string tableName and long ID.
        ///Post-Condition: Dataset is loaded with data relevant to the query.
        ///Description: Loads a dataset with data relevant  to the query.
        /// </summary>
        private void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;


            if (_lngPKID > 0)
                strQuery += " WHERE " + _strPKName + " = " + _lngPKID;

            _dbConnection.fillDataSet(_dataset, strQuery, _strTableName);
        }
        /// <summary>
        ///Pre-Condition:Dataset column names match the column names described
        ///Post-Condition: Properties in this class will be set to the values defined each specified column
        ///Description: assigns properties to dataset cell values.
        /// </summary>
        private void assignFields()
        {
            Name = _dataset.Tables[_strTableName].Rows[0]["IngName"].ToString();
            Code = _dataset.Tables[_strTableName].Rows[0]["IngCode"].ToString();
            Price = Decimal.Parse(_dataset.Tables[_strTableName].Rows[0]["IngPrice"].ToString());
            QtyOnHand = long.Parse(_dataset.Tables[_strTableName].Rows[0]["IngQtyOnHand"].ToString());
            QtyOnOrder = long.Parse(_dataset.Tables[_strTableName].Rows[0]["IngQtyOnOrder"].ToString());
            SupplierNumber = long.Parse(_dataset.Tables[_strTableName].Rows[0]["SupplierNumber"].ToString());

        }
        public DataTable getSuppliers()
        {
            return _dbConnection.GetDataTable("qry_SupplierList");
        }
        #endregion

        #region Mutators

        public void saveData()
        {
            if (_lngPKID == 0)
                addNewRecord();
            else
                updateRecord();

            _dbConnection.SaveData(_dataset, _strTableName);
        }
        /// <summary>
        ///Pre-Condition: Product selected
        ///Post-Condition: selected Product deleted
        ///Description: deletes Product Supplier
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deleteRawIngredient(long pLongPKID)
        {
            if (_lngPKID != 0)
            {
                _dataset.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
                _dbConnection.SaveData(_dataset, _strTableName);
            }

        }
        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:a new record is added to the table associated with the class 
        ///Description:Adds a new record to the table associated with the class
        /// </summary>
        /// 
        private void addNewRecord()
        {
            _drwRecord = _dataset.Tables[_strTableName].NewRow();
            _drwRecord.BeginEdit();
            _drwRecord["IngName"] = Name;
            _drwRecord["IngCode"] = Code;
            _drwRecord["IngPrice"] = Price;
            _drwRecord["IngQtyOnHand"] = QtyOnHand;
            _drwRecord["IngQtyOnOrder"] = QtyOnOrder;
            _drwRecord["SupplierNumber"] = SupplierNumber;
            _drwRecord.EndEdit();
            _dataset.Tables[_strTableName].Rows.Add(_drwRecord);
        }
        /// <summary>
        ///Pre-Condition: All properties have an assigned value
        ///Post-Condition:The current record is updated 
        ///Description:Updates the current record to the table associated with the class
        /// </summary>
        private void updateRecord()
        {
            _drwRecord = _dataset.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["IngName"] = Name;
            _drwRecord["IngCode"] = Code;
            _drwRecord["IngPrice"] = Price;
            _drwRecord["IngQtyOnHand"] = QtyOnHand;
            _drwRecord["IngQtyOnOrder"] = QtyOnOrder;
            _drwRecord["SupplierNumber"] = SupplierNumber;
            _drwRecord.EndEdit();
        }

        /// <summary>
        /// Description: fills a datatable with supplier information
        /// </summary>
        /// <returns></returns>

        #endregion
    }
}