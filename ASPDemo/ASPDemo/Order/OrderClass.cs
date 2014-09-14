using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ASPDemo.Order
{
    public class OrderClass
    {
        #region Instance Variables

        long _lngPKID = 0;
        string _strTableName = "tblOrders";
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;
        // create an instance of the OrderLine class so we can create the relationship between the tables tblOrders and tblOrderLines
        OrderLineClass _orderLine = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for new Order
        /// </summary>
        public OrderClass()
        {
            loadDataSet();
            addNewRecord();
            _orderLine = new OrderLineClass(_dst, _lngPKID);
            createRelationship();
        }

        /// <summary>
        /// Constructor for existing Order
        /// </summary>
        /// <param name="pLongID">The record ID of the order that will be used in this class</param>
        public OrderClass(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            _orderLine = new OrderLineClass(_dst, _lngPKID);
            createRelationship();
            assignFields();
        }

        #endregion

        #region Properties

        public string OrderName { get; set; }
        public string OrderDate { get; set; }
        public string OrderShippingDate { get; set; }
        public string OrderShippingAddress { get; set; }
        public long CustomerID { get; set; }
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Property to return the Order primary key ID to be used to create new order lines.
        /// </summary>
        public long PKID
        {
            get { return _lngPKID; }
        }

        /// <summary>
        /// Property to return the OrderLine class to be able to call its' properties and methods.
        /// </summary>
        public OrderLineClass OrderLineClass
        {
            get
            {
                return _orderLine;
            }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblOrders loaded.
        /// Description:    This method will load the dataset with records from the Orders table.
        /// </summary>
        private void loadDataSet()
        {
            string strSQL = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strSQL += " WHERE OrderNumber = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strSQL, _strTableName);
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will create the relationship between Orders and OrderLines tables.
        /// Description:    This method will create the relationship in the dataset between tblOrders and tblOrderLines.
        /// </summary>
        private void createRelationship()
        {
            if (_dst.Relations.Contains("orderRelationship") == false)
            {
                _dst.Relations.Add("orderRelationship", _dst.Tables["tblOrders"].Columns["OrderNumber"],
                                                       _dst.Tables["tblOrderLines"].Columns["OrderNumber"]);
            }
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            OrderName = _dst.Tables[_strTableName].Rows[0]["OrderName"].ToString();
            OrderDate = _dst.Tables[_strTableName].Rows[0]["OrderDate"].ToString();
            OrderShippingDate = _dst.Tables[_strTableName].Rows[0]["OrderShippingDate"].ToString();
            OrderShippingAddress = _dst.Tables[_strTableName].Rows[0]["OrderShippingAddress"].ToString();
            CustomerID = long.Parse(_dst.Tables[_strTableName].Rows[0]["CustomerID"].ToString());
            OrderTotal = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["OrderTotal"].ToString());
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblCustomers
        /// Description:    This method will return the tblCustomers to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable tblCustomers</returns>
        public DataTable getCustomers()
        {
            return _dbConn.GetDataTable("qryCustomer");
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblProducts
        /// Description:    This method will return the tblProducts to be used as a data source for a combo box.
        /// </summary>
        /// <returns>DataTable tblProducts</returns>
        public DataTable getProduct()
        {
            return _dbConn.GetDataTable("qryProduct");
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will return the tblOrderLines
        /// Description:    This method will return the tblOrderLines to be used as a data source for a combo box.
        /// </summary>
        /// <returns></returns>
        public DataTable getOrderLinesTable()
        {
            return _dst.Tables["tblOrderLines"];
        }

        public DataTable getOrderLines()
        {
            return _dst.Tables["qryOrderLineList"];
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
            _drwRecord["OrderName"] = OrderName;
            _drwRecord["OrderDate"] = OrderDate;
            _drwRecord["OrderShippingDate"] = OrderShippingDate;
            _drwRecord["OrderShippingAddress"] = OrderShippingAddress;
            _drwRecord["CustomerID"] = CustomerID;
            _drwRecord["OrderTotal"] = OrderTotal;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["OrderNumber"].ToString());
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
            _drwRecord["OrderName"] = OrderName;
            _drwRecord["OrderDate"] = OrderDate;
            _drwRecord["OrderShippingDate"] = OrderShippingDate;
            _drwRecord["OrderShippingAddress"] = OrderShippingAddress;
            _drwRecord["CustomerID"] = CustomerID;
            _drwRecord["OrderTotal"] = OrderTotal;
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