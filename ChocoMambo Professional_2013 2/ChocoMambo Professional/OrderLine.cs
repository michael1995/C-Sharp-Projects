using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo_Professional
{
    public class OrderLine
    {

        #region Instance Variables

        long _lngFKID = 0, _lngPKID = 0;
        string _strTableName = "tblOrderLines";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst;
        DataRow _drwRecord = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for orderlines
        /// </summary>
        /// <param name="pDataSet">The dataset that will store this child class tables.</param>
        /// <param name="pLongID">The foreign key ID that will be used in this child class.</param>
        public OrderLine(DataSet pDataSet, long pLongID)
        {
            _dst = pDataSet;
            _lngFKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties

        public long ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public long OrderLineQty { get; set; }
        public long OrderNumber { get; set; }
        public decimal OrderLineSubTotal { get; set; }
        public string ProductName { get; set; }

        /// <summary>
        /// Property to return the OrderLine primary key ID to be used to update existing order lines.
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
        /// Post-Condition: The dataset will have the qryOrderLineList loaded.
        /// Description:    This method will load the dataset with records from the qryOrderLineList query using the foreign key
        ///                 OrderID as the filter criteria.
        ///                 qryOrderLineList is created in Access to retrieve selected fields including ProductName from the tblProducts
        ///                 to display descriptive details about the order line.
        ///                 Create a query in Access and use the following SQL:
        ///                 SELECT tblOrderLines.OrderLineID, tblProducts.ProductName, tblOrderLines.ProductPrice, tblOrderLines.OrderLineQty, tblOrderLines.OrderLineSubTotal, tblOrderLines.ProductID, tblOrderLines.OrderNumber
        ///                 FROM tblProducts INNER JOIN tblOrderLines ON tblProducts.ProductID = tblOrderLines.ProductID;
        /// </summary>
        private void loadDataSet()
        {
            string strSQL = "SELECT * FROM qryOrderLineList";
            strSQL += " WHERE OrderNumber = " + _lngFKID;

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
                ProductID = long.Parse(_dst.Tables[_strTableName].Rows[0]["ProductID"].ToString());
                ProductPrice = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["Price"].ToString());
                OrderLineQty = long.Parse(_dst.Tables[_strTableName].Rows[0]["OrderLineQty"].ToString());
                OrderNumber = long.Parse(_dst.Tables[_strTableName].Rows[0]["OrderNumber"].ToString());
                OrderLineSubTotal = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["OrderLineSubTotal"].ToString());
                ProductName = _dst.Tables[_strTableName].Rows[0]["ProductName"].ToString();
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
            _drwRecord["ProductID"] = ProductID;
            _drwRecord["Price"] = ProductPrice;
            _drwRecord["OrderLineQty"] = OrderLineQty;
            _drwRecord["OrderNumber"] = OrderNumber;
            _drwRecord["OrderLineSubTotal"] = OrderLineSubTotal;
            _drwRecord["ProductName"] = ProductName;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
            _lngPKID = long.Parse(_drwRecord["OrderLineID"].ToString());
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
                _drwRecord.BeginEdit();
                _drwRecord["ProductID"] = ProductID;
                _drwRecord["Price"] = ProductPrice;
                _drwRecord["OrderLineQty"] = OrderLineQty;
                _drwRecord["OrderNumber"] = OrderNumber;
                _drwRecord["OrderLineSubTotal"] = OrderLineSubTotal;
                _drwRecord["ProductName"] = ProductName;
                _drwRecord.EndEdit();
            }
            catch (System.NullReferenceException)
            { }
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will delete the selected record in the data set.
        /// Description:    This method will delete the selected record in the dataset.
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deleteOrderLine(long pLongPKID)
        {
            _dst.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
        }

        #endregion
    }
}
