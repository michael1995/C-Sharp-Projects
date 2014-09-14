using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class Order
    {
        #region Class Variables
        long _lngPKID = 0;
        string _strTableName = "tbl_Order";
        Boolean _delete = false;

        dbConnection _dbConnection = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        DataSet _dataset = new DataSet();
        DataRow _drwRecord = null;
        OrderLines _OrderLine = null;

        #endregion

        #region Constructor
        public Order()
        {
            loadDataSet();
            addNewRecord();
            _OrderLine = new OrderLines(_dataset, _lngPKID);
            createRelationship();
            OrderDataset = _dataset;
        }
        public Order(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            OrderDataset = _dataset;
            _OrderLine = new OrderLines(_dataset, _lngPKID);
            createRelationship();
            assignFields();
        }
        public Order(String pstrSearch)
        {
            loadDataSet();
            _OrderLine = new OrderLines(_dataset, _lngPKID);
            createRelationship();
            OrderDataset = _dataset;
        }


        #endregion

        #region Properties
        public DataSet OrderDataset { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderExpectedDeliveryDate { get; set; }
        public long SupplierNumber { get; set; }
        public decimal OrderTotal { get; set; }
        public long Branch { get; set; }
        public long PKID
        {
            get { return _lngPKID; }
        }

        public OrderLines OrderLineClass
        {
            get { return _OrderLine; }
        }
        public DataSet GetDataSet()
        {
            return _dataset;
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
            if (_dataset.Relations.Contains("OrderRelationship") == false)
            {
                _dataset.Relations.Add("OrderRelationship", _dataset.Tables["tbl_Order"].Columns["ID"],
                                                       _dataset.Tables["tbl_OrderLines"].Columns["OrderNumber"]);
            }
        }
        /// <summary>
        ///Pre-Condition: Supplier selected
        ///Post-Condition: DataTable filled with Raw Ingredients related to the selected supplier
        ///Description: Fills a datatable with Raw Ingredients related to the selected supplier
        /// </summary>
        /// <param name="pLongSupplierID"></param>
        /// <param name="pstrTableName"></param>
        /// <returns></returns>
        public DataTable getRawIngredients(long pLongSupplierID, String pstrTableName)
        {
            string strSQL = "SELECT * FROM " + pstrTableName;

            if (pLongSupplierID > 0)
                strSQL += " WHERE SupplierNumber = " + pLongSupplierID;

            return _dbConnection.GetDataTable(strSQL, pstrTableName);
        }
        /// <summary>
        ///Description: Fills a datatable with Suppliers
        /// </summary>
        /// <returns></returns>
        public DataTable getSuppliers()
        {
            return _dbConnection.GetDataTable("qry_SupplierList");
        }
        /// <summary>
        ///Description: Fills a datatable with Branch details
        /// </summary>
        /// <returns></returns>
        public DataTable getBranch()
        {
            return _dbConnection.GetDataTable("tbl_Branch");
        }
        /// <summary>
        ///Description: Fills a datatable with OrderLines related to the currentOrder
        /// </summary>
        /// <returns></returns>
        public DataTable getOrderLinesTable()
        {
            return _dataset.Tables["tbl_OrderLines"];
        }

        #endregion

        #region Mutators
        public void deleteOrder(long plongPKID)
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
            OrderDate = DateTime.Parse(_dataset.Tables[_strTableName].Rows[0]["OrderDate"].ToString());
            OrderExpectedDeliveryDate = DateTime.Parse(_dataset.Tables[_strTableName].Rows[0]["OrderExpectedDeliveryDate"].ToString());
            SupplierNumber = long.Parse(_dataset.Tables[_strTableName].Rows[0]["SupplierNumber"].ToString());
            OrderTotal = Decimal.Parse(_dataset.Tables[_strTableName].Rows[0]["OrderTotal"].ToString());
            Branch = long.Parse(_dataset.Tables[_strTableName].Rows[0]["Branch"].ToString());
        }
        public void saveData()
        {
            if (_lngPKID == 0)
            {
                addNewRecord();
            }
            else
                if(!_delete)
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
            _drwRecord["OrderDate"] = OrderDate;
            _drwRecord["OrderExpectedDeliveryDate"] = OrderExpectedDeliveryDate;
            _drwRecord["SupplierNumber"] = SupplierNumber;
            _drwRecord["OrderTotal"] = OrderTotal;
            _drwRecord["Branch"] = Branch;
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
            _drwRecord["OrderDate"] = OrderDate;
            _drwRecord["OrderExpectedDeliveryDate"] = OrderExpectedDeliveryDate;
            _drwRecord["SupplierNumber"] = SupplierNumber;
            _drwRecord["OrderTotal"] = OrderTotal;
            _drwRecord["Branch"] = Branch;
            _drwRecord.EndEdit();
        }
        #endregion
    }
}