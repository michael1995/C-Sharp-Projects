using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo
{
    public class Product
    {
        #region class variables 

        long _lngPKID = 0;
        string _strTableName = "Product";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors 

        public Product()
        {
            loadDataSet();
        }

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
        public decimal Price { get; set; }
        public string Comments { get; set; }
        public Boolean Active { get; set; }
        #endregion 

        #region Accessors

        public void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE ProductID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }

        private void assignFields()
        {
            ProductName = _dst.Tables[_strTableName].Rows[0]["ProductName"].ToString();
            ProductCode = _dst.Tables[_strTableName].Rows[0]["ProductCode"].ToString();
            QuantityInStock = _dst.Tables[_strTableName].Rows[0]["QuantityInStock"].ToString();
            Price = decimal.Parse(_dst.Tables[_strTableName].Rows[0]["Price"].ToString());
            Comments = _dst.Tables[_strTableName].Rows[0]["Comments"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
        }

        #endregion 

        #region Mutator 

        public void saveData()
        {
            if (_lngPKID == 0)
                addNewRecord();
            else
                updateRecord();

            _dbConn.SaveData(_dst, _strTableName);
        }

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
