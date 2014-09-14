using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.Purchase
{
    public class PurchaseClass
    {
        #region Instance Variables

        long _lngPKID = 0;
        string _strTableName = "tblSupplierPurchase";
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;
        // create an instance of the OrderLine class so we can create the relationship between the tables tblOrders and tblOrderLines
        PurchaseLineClass _PurchaseLine = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for new supplier purchase
        /// </summary>
        public PurchaseClass()
        {
            loadDataSet();
            addNewRecord();
            _PurchaseLine = new PurchaseLineClass(_dst, _lngPKID);
            createRelationship();
        }

        /// <summary>
        /// Constructor for existing supplier purchase
        /// </summary>
        /// <param name="pLongID">The record ID of the order that will be used in this class</param>
        public PurchaseClass(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            _PurchaseLine = new PurchaseLineClass(_dst, _lngPKID);
            createRelationship();
            assignFields();
        }

        #endregion

        #region Properties

        public string PurchaseCode { get; set; }
        public long BranchID { get; set; }
        public string DatePurchased { get; set; }
        public long SupplierID { get; set; }
        public decimal PurchaseTotal { get; set; }

        /// <summary>
        /// Property to return the Order primary key ID to be used to create new supplier purchase lines.
        /// </summary>
        public long PKID
        {
            get { return _lngPKID; }
        }

        /// <summary>
        /// Property to return the supplier purchase class to be able to call its' properties and methods.
        /// </summary>
        public PurchaseLineClass PurchaseLineClass
        {
            get
            {
                return _PurchaseLine;
            }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblSupplierPurchase loaded.
        /// Description:    This method will load the dataset with records from the SupplierPurchases table.
        /// </summary>
        private void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE PurchaseID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will create the relationship between SupplierPurchase and SupplierPurchaseLines tables.
        /// Description:    This method will create the relationship in the dataset between tblSupplierPurchase and tblSupplierPurchaseLines.
        /// </summary>
        private void createRelationship()
        {
            if (_dst.Relations.Contains("orderRelationship") == false)
            {
                _dst.Relations.Add("orderRelationship", _dst.Tables["tblSupplierPurchase"].Columns["PurchaseID"],
                                                       _dst.Tables["tblSupplierPurchaseLines"].Columns["PurchaseID"]);
            }
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            PurchaseCode = _dst.Tables[_strTableName].Rows[0]["PurchaseCode"].ToString();
            BranchID = long.Parse(_dst.Tables[_strTableName].Rows[0]["BranchID"].ToString());
            DatePurchased = _dst.Tables[_strTableName].Rows[0]["DatePurchased"].ToString();
            SupplierID = long.Parse(_dst.Tables[_strTableName].Rows[0]["SupplierID"].ToString());
            PurchaseTotal = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["PurchaseTotal"].ToString());
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblBranch
        /// Description:    This method will return the tblBranch to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable tblBranch</returns>
        public DataTable getBranch()
        {
            return _dbConn.GetDataTable("qryBranch");
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblSupplier
        /// Description:    This method will return the tblSupplier to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable tblSupplier</returns>
        public DataTable getSupplier()
        {
            return _dbConn.GetDataTable("qrySupplier");
        }
        /// <summary>
        ///  Pre-condition:  true
        /// Post-condition: Will return the tblRawIngredients
        /// Description:    This method will return the tblRawIngredients to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable tblRawIngredients</returns>
        public DataTable getRawIngredients()
        {
            return _dbConn.GetDataTable("qryRawIngredients");
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblSupplierLinesTable
        /// Description:    This method will return the tblSupplierLinesTable to be used as a data source for a combo box.
        /// </summary>
        /// <returns></returns>
        public DataTable getPurchaseLinesTable()
        {
            return _dst.Tables["tblSupplierPurchaseLines"];
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
            _drwRecord["PurchaseCode"] = PurchaseCode;
            _drwRecord["BranchID"] = BranchID;
            _drwRecord["DatePurchased"] = DatePurchased;
            _drwRecord["SupplierID"] = SupplierID;
            _drwRecord["PurchaseTotal"] = PurchaseTotal;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["PurchaseID"].ToString());
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
            _drwRecord["PurchaseCode"] = PurchaseCode;
            _drwRecord["BranchID"] = BranchID;
            _drwRecord["DatePurchased"] = DatePurchased;
            _drwRecord["SupplierID"] = SupplierID;
            _drwRecord["PurchaseTotal"] = PurchaseTotal;
            _drwRecord.EndEdit();
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will delete the selected record in the data set.
        /// Description:    This method will delete the selected record in the dataset.
        /// </summary>
        /// <param name="pLongPKID"></param>
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