using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorCollection;

namespace DBConnection
{
    public class dbConnection
    {
        #region Class Variables

        OleDbConnection _dbConn;
        string _strDBFile = null;
        string strConnection = null;
        errorCollection _errorCollection = new errorCollection();
        #endregion

        #region Constructor

        /// <summary>
        /// Pre-Condition:  The database file specified in the parameter exists.
        /// Post-Condition: The connection to the database will be established.
        /// Description:    The class constructor that will establish the
        ///                 connection to the database specified by the parameter.
        /// </summary>
        /// <param name="pStrDBFile">The database file that will be use by this connection.</param>
        public dbConnection(string pStrConnectionString)
        {
            if (strConnection == pStrConnectionString) return;
            strConnection = pStrConnectionString;

            _dbConn = new OleDbConnection(strConnection);
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Pre-Condition:  The string parameters will be in the order of the SQL query,
        ///                 and the table name.
        /// Post-Condition: The records specified in the SQL query will be loaded in the 
        ///                 table.
        /// Description:    This method will return a data table loaded with records
        ///                 specified in the SQL query for display purposes.
        /// </summary>
        /// <param name="pStrQuery">The SQL query that will select the 
        ///                         records to be loaded.</param>
        /// <param name="pStrTableName">The table name used by the query.</param>
        /// <returns></returns>
        public DataTable GetDataTable(string pStrQuery, string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the DataTable with the table name specified by the parameter
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdapter object to fill the DataTable or DataSet
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // create an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter Fill method
                dbDA.Fill(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  _errorCollection.writeErrorToFile(ex.Message);
            }
            finally
            {
                // close the connection after the Fill
                _dbConn.Close();
            }

            return dtb;
        }

        /// <summary>
        /// Pre-Condition:  The string parameters will be the table name.
        /// Post-Condition: The records specified in the table will be loaded in the 
        ///                 table.
        /// Description:    This method will return a data table loaded with records
        ///                 from the table.
        /// </summary>
        /// <param name="pStrTableName">The table name used by the query.</param>
        /// <returns></returns>
        public DataTable GetDataTable(string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the DataTable with the table name specified by the parameter
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdapter object to fill the DataTable or DataSet
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // create an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = "SELECT * FROM " + pStrTableName;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter Fill method
                dbDA.Fill(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //_errorCollection.writeErrorToFile(ex.Message);
            }
            finally
            {
                // close the connection after the Fill
                _dbConn.Close();
            }

            return dtb;
        }

        public void fillDataSet(DataSet pDataSet, string pStrQuery, string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the DataTable with the table name specified by the parameter
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdapter object to fill the DataTable or DataSet
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // create an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter Fill method
                dbDA.Fill(dtb);

                // close the connection after the fill
                _dbConn.Close();

                // add the table to the dataset
                pDataSet.Tables.Add(dtb);

                // set the primary key constraints of the table
                pDataSet.Tables[pStrTableName].PrimaryKey = new DataColumn[] { pDataSet.Tables[pStrTableName].Columns[0] };
                // set the primary key to autoincrement
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrement = true;
                // set the starting value of the primary key auto-increments
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementSeed = -1;
                // set the increment step
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementStep = -10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //_errorCollection.writeErrorToFile(ex.Message);
            }
            finally
            {
                _dbConn.Close();
            }
        }

        #endregion

        #region Mutators

        /// <summary>
        /// Pre-Condition:  The parameters will be in the order of passing the dataset,
        ///                 and the string table name.
        /// Post-Condition: The update dataset will be persisted in the database.
        /// Description:    This method will update the database based on the updated
        ///                 records in the dataset for a given table.
        /// </summary>
        /// <param name="pDataSet">The dataset that contains the updated records.</param>
        /// <param name="pStrTableName">The table name that will be updated in the
        ///                             database.</param>
        public void SaveData(DataSet pDataSet, string pStrTableName)
        {
            string strQuery = "SELECT * FROM " + pStrTableName;

            OleDbDataAdapter dbDA = new OleDbDataAdapter(strQuery, _dbConn);

            try
            {
                // setup Command Builders
                OleDbCommandBuilder dbBLD = new OleDbCommandBuilder(dbDA);
                dbDA.InsertCommand = dbBLD.GetInsertCommand();
                dbDA.UpdateCommand = dbBLD.GetUpdateCommand();
                dbDA.DeleteCommand = dbBLD.GetDeleteCommand();

                // subscribe to the OleDbRowUpdateEventHandler
                dbDA.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);

                _dbConn.Open();
                dbDA.Update(pDataSet, pStrTableName);
                pDataSet.Tables[pStrTableName].AcceptChanges();
                _dbConn.Close();
                pStrTableName = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //_errorCollection.writeErrorToFile(ex.Message);
            }
            finally
            {
                _dbConn.Close();
            }
        }

        /// <summary>
        /// Pre-Condition:  The first column in the query is an AutoNumber field.
        /// Post-Condition: Child records will be persisted in the database
        ///                 consistent with the primary key of the parent record.
        /// Description:    This method will synchronize the primary and foreign
        ///                 key together.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
        {
            int intNewID = 0;

            if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

            OleDbCommand dbCmd = new OleDbCommand("SELECT @@IDENTITY", _dbConn);

            if (args.StatementType == StatementType.Insert)
            {
                intNewID = (int)dbCmd.ExecuteScalar();
                args.Row[0] = intNewID;
            }
        }

        #endregion
    }
}
