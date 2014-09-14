using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo_Professional
{
    public class RawIngredients
    {
        #region class variables 

        long _lngPKID = 0;
        string _strTableName = "tblRawIngredients";
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst = new DataSet();
        DataRow _drwRecord = null;

        #endregion 

        #region Constructors 
        /// <summary>
        /// Constructor for new raw ingredients 
        /// </summary>
        public RawIngredients()
        {
            loadDataSet();
        }

        /// <summary>
        /// Contructor for existing raw ingredients
        /// </summary>
        /// <param name="pLongID"></param>
        public RawIngredients(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }

        #endregion

        #region Properties 
        public string IngCode { get; set; }
        public string IngredientName { get; set; }
        public string Price { get; set; }
        public Boolean Active { get; set; }

        #endregion 

        #region Accessors
        /// <summary>
        /// Pre-Condition:  true
        /// Post-Condition: The dataset will have the tblRawIngredients loaded.
        /// Description:    This method will load the dataset with records from the RawIngredients table.
        /// </summary>
        public void loadDataSet()
        {
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE RawIngredientsID = " + _lngPKID;

            _dbConn.fillDataSet(_dst, strQuery, _strTableName);
        }
        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Will assign the field values to its' respective properties
        /// Description:    This method will assign the field values to its' respective properties.
        /// </summary>
        private void assignFields()
        {
            IngCode = _dst.Tables[_strTableName].Rows[0]["IngCode"].ToString();
            IngredientName = _dst.Tables[_strTableName].Rows[0]["IngredientName"].ToString();
            Price = _dst.Tables[_strTableName].Rows[0]["Price"].ToString();
            Active = Boolean.Parse(_dst.Tables[_strTableName].Rows[0]["Active"].ToString());
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
            _drwRecord["IngCode"] = IngCode;
            _drwRecord["IngredientName"] = IngredientName;
            _drwRecord["Price"] = Price;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
            _dst.Tables[_strTableName].Rows.Add(_drwRecord);
        }
        /// <summary>
        ///  Pre-condition:  true
        /// Post-condition: Will update the selected record in the dataset.
        /// Description:    This method will update the selected record in the dataset.
        /// </summary>
        private void updateRecord()
        {
            _drwRecord = _dst.Tables[_strTableName].Rows.Find(_lngPKID);
            _drwRecord.BeginEdit();
            _drwRecord["IngCode"] = IngCode;
            _drwRecord["IngredientName"] = IngredientName;
            _drwRecord["Price"] = Price;
            _drwRecord["Active"] = Active;
            _drwRecord.EndEdit();
        }

        #endregion 
    }
}
