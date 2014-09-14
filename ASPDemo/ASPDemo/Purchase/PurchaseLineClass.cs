using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.Purchase
{
    public class PurchaseLineClass
    {
        #region Instance Variables

        long _lngFKID = 0, _lngPKID = 0;
        string _strTableName = "tblSupplierPurchaseLines";
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst;
        DataRow _drwRecord = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for SupplierPurchaseLine
        /// </summary>
        /// <param name="pDataSet">The dataset that will store this child class tables.</param>
        /// <param name="pLongID">The foreign key ID that will be used in this child class.</param>
        public PurchaseLineClass(DataSet pDataSet, long pLongID)
        {
            _dst = pDataSet;
            _lngFKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties

        public long RawIngredientsID { get; set; }
        public decimal Price { get; set; }
        public long SupplierLineQty { get; set; }
        public long PurchaseID { get; set; }
        public decimal SupplierLineSubTotal { get; set; }
        public string IngredientName { get; set; }

        /// <summary>
        /// Property to return the SupplierPurchaseLine primary key ID to be used to update existing SupplierPurchaseLines.
        /// </summary>
        public long PKID
        {
            get { return _lngPKID; }
            set { _lngPKID = value; }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the qrySupplierLineList loaded.
        /// Description:    This method will load the dataset with records from the qrySupplierLineList query using the foreign key
        ///                 OrderID as the filter criteria.
        ///                 qrySupplierLineList is created in Access to retrieve selected fields 
        /// </summary>
        private void loadDataSet()
        {
            string strSQL = "SELECT * FROM qrySupplierLineList";
            strSQL += " WHERE PurchaseID = " + _lngFKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties.
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            try
            {
                RawIngredientsID = long.Parse(_dst.Tables[_strTableName].Rows[0]["RawIngredientsID"].ToString());
                Price = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["Price"].ToString());
                SupplierLineQty = long.Parse(_dst.Tables[_strTableName].Rows[0]["SupplierLineQty"].ToString());
                PurchaseID = long.Parse(_dst.Tables[_strTableName].Rows[0]["PurchaseID"].ToString());
                IngredientName = _dst.Tables[_strTableName].Rows[0]["IngredientName"].ToString();
                SupplierLineSubTotal = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["SupplierLineSubTotal"].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                //this exception occurs when order line row is empty which we can safely ignore.
            }
        }

        #endregion

        #region Mutators

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will save the data to the database.
        /// Description:    This method will save the data to the database.
        /// </summary>
        public void saveData()
        {
            _dbConn.SaveData(_dst, _strTableName);
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will add a new record in the dataset.
        /// Description:    This method will add a new record in the dataset.
        /// </summary>
        public void addNewRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].NewRow();
            _drwRecord.BeginEdit();
            _drwRecord["RawIngredientsID"] = RawIngredientsID;
            _drwRecord["Price"] = Price;
            _drwRecord["SupplierLineQty"] = SupplierLineQty;
            _drwRecord["PurchaseID"] = PurchaseID;
            _drwRecord["SupplierLineSubTotal"] = SupplierLineSubTotal;
            _drwRecord["IngredientName"] = IngredientName;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["PurchaseLineID"].ToString());
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will update the selected record in the dataset.
        /// Description:    This method will update the selected record in the dataset.
        /// </summary>
        public void updateRecord()
        {
            try
            {
                _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
                _drwRecord["RawIngredientsID"] = RawIngredientsID;
                _drwRecord["Price"] = Price;
                _drwRecord["SupplierLineQty"] = SupplierLineQty;
                _drwRecord["PurchaseID"] = PurchaseID;
                _drwRecord["SupplierLineSubTotal"] = SupplierLineSubTotal;
                _drwRecord["IngredientName"] = IngredientName;
                _drwRecord.EndEdit();
            }
            catch (System.NullReferenceException)
            { }
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will delete the selected record in the databaset.
        /// Description:    This method will delete the selected record in the dataset.
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deletePurchaseLine(long pLongPKID)
        {
            _dst.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
        }

        #endregion
    }
}