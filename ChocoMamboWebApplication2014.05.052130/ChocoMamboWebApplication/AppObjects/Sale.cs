using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace ChocoMamboWebApplication.AppObjects
{
    class Sale
    {
        #region Class Variables
        long _lngPKID = 0;
        string _strTableName = "tbl_Sale";
        Boolean _delete = false;
        dbConnection _dbConnection = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        DataSet _dataset = new DataSet();
        DataRow _drwRecord = null;
        SaleLine _saleLine = null;
        #endregion

        #region Constructor
        public Sale()
        {
            loadDataSet();
            addNewRecord();
            _saleLine = new SaleLine(_dataset, _lngPKID);
            createRelationship();
           
        }
        public Sale(long pLongID, Boolean isDelete)
        {
            _lngPKID = pLongID;
            _delete = isDelete;
            loadDataSet();
           
            _saleLine = new SaleLine(_dataset, _lngPKID);
            createRelationship();
            if (!_delete)
                assignFields();
        }
        public Sale(String pstrSearch)
        {
            loadDataSet();
            _saleLine = new SaleLine(_dataset, _lngPKID);
            createRelationship();
           
        }
        #endregion


        #region Properties
        
        public DateTime SaleDate { get; set; }
        public DateTime SaleShippingDate { get; set; }
        public string SaleShippingAddress { get; set; }
        public long CustomerNumber { get; set; }
        public decimal SaleTotal { get; set; }
        public long SaleMananger { get; set; }
        

        public long PKID
        {
            get { return _lngPKID; }
        }
        public SaleLine SaleLineClass
        {
            get { return _saleLine; }
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

            if (_lngPKID > 0)
                strSQL += " WHERE ID = " + _lngPKID;

            _dbConnection.fillDataSet(_dataset, strSQL, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will create the relationship between Orders and OrderLines tables.
        /// Description:    This method will create the relationship in the dataset between tblOrders and tblOrderLines.
        /// </summary>
        private void createRelationship()
        {
            if (_dataset.Relations.Contains("SaleRelationship") == false)
            {
                _dataset.Relations.Add("SaleRelationship", _dataset.Tables["tbl_Sale"].Columns["ID"],
                                                       _dataset.Tables["tbl_SaleLines"].Columns["SaleNumber"]);
            }
        }
        public DataSet GetDataSet()
        {
            return _dataset;
        }
        public DataTable getCustomers()
        {
            return _dbConnection.GetDataTable("qry_CustomerList");
        }
        public DataTable getProducts()
        {
            return _dbConnection.GetDataTable("qry_ProductList");
        }
        public DataTable getSaleReps()
        {
            return _dbConnection.GetDataTable("qry_SalesRepList");
        }
        public DataTable getSaleLinesTable()
        {
            return _dataset.Tables["tbl_SaleLines"];
        }

        #endregion

        #region Mutators

        public void deleteSale(long plongPKID)
        {
            _delete = true;
            _dataset.Tables[_strTableName].Rows.Find(plongPKID).Delete();
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            SaleDate = DateTime.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleDate"].ToString());
            SaleShippingDate = DateTime.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleShippingDate"].ToString());
            SaleShippingAddress = _dataset.Tables[_strTableName].Rows[0]["SaleShippingAddress"].ToString();
            CustomerNumber = long.Parse(_dataset.Tables[_strTableName].Rows[0]["CustomerNumber"].ToString());
            SaleTotal = Decimal.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleTotal"].ToString());
            SaleMananger = long.Parse(_dataset.Tables[_strTableName].Rows[0]["SaleMananger"].ToString());
        }
        public void saveData()
        {
            if (_lngPKID == 0)
            {

                addNewRecord();
            }
            else
                if (!_delete)
                    updateRecord();

            _dbConnection.SaveData(_dataset, _strTableName);
        }
        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:a new record is added to the table associated with the class 
        ///Description:Adds a new record to the table associated with the class
        /// </summary>

        private void addNewRecord()
        {
            _drwRecord = _dataset.Tables[_strTableName].NewRow();
            _drwRecord.BeginEdit();
            _drwRecord["SaleDate"] = SaleDate;
            _drwRecord["SaleShippingDate"] = SaleShippingDate;
            _drwRecord["SaleShippingAddress"] = SaleShippingAddress;
            _drwRecord["CustomerNumber"] = CustomerNumber;
            _drwRecord["SaleTotal"] = SaleTotal;
            _drwRecord["SaleMananger"] = SaleMananger;
            _drwRecord.EndEdit();
            _dataset.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["ID"].ToString());
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will update the selected record in the dataset.
        /// Description:    This method will update the selected record in the dataset.
        /// </summary>
        private void updateRecord()
        {
            _drwRecord = _dataset.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["SaleDate"] = SaleDate;
            _drwRecord["SaleShippingDate"] = SaleShippingDate;
            _drwRecord["SaleShippingAddress"] = SaleShippingAddress;
            _drwRecord["CustomerNumber"] = CustomerNumber;
            _drwRecord["SaleTotal"] = SaleTotal;
            _drwRecord["SaleMananger"] = SaleMananger;
            _drwRecord.EndEdit();
        }

        #endregion
                    
    }
}
