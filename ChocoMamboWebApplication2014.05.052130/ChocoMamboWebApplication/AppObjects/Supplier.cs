using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class Supplier:BusinessContact
    {
        #region Class Variables
        long _lngPKID = 0;
        string _strTableName = "tbl_BusinessContact";
        string _strPKName = "ID";
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        DataSet _dataset = new DataSet();
        DataRow _drwRecord = null;
        #endregion

        #region Constructor
        public Supplier()
        {
            loadDataSet();
           
        }
        public Supplier(long pLongID)
        {
            _lngPKID = pLongID;
            loadDataSet();
            assignFields();
        }
        #endregion

        #region Properties
        public Boolean IsASupplier { get; set; }
       
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
            string strQuery = "SELECT * FROM " + _strTableName;

            if (_lngPKID > 0)
                strQuery += " WHERE " + _strPKName + " = " + _lngPKID;
            else
                strQuery += " WHERE IsASupplier  = True ";

            _dbConn.fillDataSet(_dataset, strQuery, _strTableName);
        }
        /// <summary>
        ///Pre-Condition:Dataset column names match the column names described
        ///Post-Condition: Properties in this class will be set to the values defined each specified column
        ///Description: assigns properties to dataset cell values.
        /// </summary>
        private void assignFields()
        {
            Name = _dataset.Tables[_strTableName].Rows[0]["ContactName"].ToString();
            PhoneNumber = _dataset.Tables[_strTableName].Rows[0]["PhoneNumber"].ToString();
            BuildingNumber = _dataset.Tables[_strTableName].Rows[0]["BuildingNumber"].ToString();
            StreetName = _dataset.Tables[_strTableName].Rows[0]["StreetName"].ToString();
            Suburb = _dataset.Tables[_strTableName].Rows[0]["Suburb"].ToString();
            State = _dataset.Tables[_strTableName].Rows[0]["State"].ToString();
            Postcode = _dataset.Tables[_strTableName].Rows[0]["Postcode"].ToString();
            IsASupplier = Boolean.Parse(_dataset.Tables[_strTableName].Rows[0]["IsASupplier"].ToString());
            ContactPerson = _dataset.Tables[_strTableName].Rows[0]["ContactPerson"].ToString();
        }
        public DataSet GetDataSet()
        {
            return _dataset;
        }
        #endregion

        #region Mutators
        public void saveData()
        {
            if (_lngPKID == 0)
                addNewRecord();
            else
                updateRecord();

            _dbConn.SaveData(_dataset, _strTableName);
        }
        /// <summary>
        ///Pre-Condition: Supplier selected
        ///Post-Condition: selected Supplier deleted
        ///Description: deletes selected Supplier
        /// </summary>
        /// <param name="pLongPKID"></param>
        public void deleteSupplier(long pLongPKID)
        {
            if (_lngPKID != 0)
            {
                _dataset.Tables[_strTableName].Rows.Find(pLongPKID).Delete();
                _dbConn.SaveData(_dataset, _strTableName);
            }

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
            _drwRecord["ContactName"] = Name;
            _drwRecord["PhoneNumber"] = PhoneNumber;
            _drwRecord["BuildingNumber"] = BuildingNumber;
            _drwRecord["StreetName"] = StreetName;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["IsASupplier"] = IsASupplier;
            _drwRecord["ContactPerson"] = ContactPerson;
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
            _drwRecord["ContactName"] = Name;
            _drwRecord["PhoneNumber"] = PhoneNumber;
            _drwRecord["BuildingNumber"] = BuildingNumber;
            _drwRecord["StreetName"] = StreetName;
            _drwRecord["Suburb"] = Suburb;
            _drwRecord["State"] = State;
            _drwRecord["Postcode"] = Postcode;
            _drwRecord["IsASupplier"] = IsASupplier;
            _drwRecord["ContactPerson"] = ContactPerson;
            _drwRecord.EndEdit();
        }

        #endregion

    }
}