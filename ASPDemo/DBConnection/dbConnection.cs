using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DBConnection
{
    public class dbConnection
    {
        #region Class Variables

        OleDbConnection _dbConn;
        string _strDBFile = null;

        #endregion 

        #region Constructor

        /// <summary>
        /// Pre - Condition: The database file specified in the paremeter exists
        /// Post - Condition: The connection to the database will be established
        /// Description: The class constructor that will be specified by the paremeter.
        /// </summary>
        /// <param name="pStrDBFile"> The database file will be used by this connection  </param> 
        public dbConnection(string pStrDBFile)
        {
            if (_strDBFile == pStrDBFile) return;

            _strDBFile = pStrDBFile;

            string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + pStrDBFile;

            _dbConn = new OleDbConnection(strConnection);
        }

        #endregion 

        #region Accessors

        /// <summary>
        /// Pre Condition: The string paremeters will be in the order of the SQL query, and the table name
        /// Post: Condition: The post condition specified in the SQL query will be loaded in the table.
        /// Description: This method will return a data table loaded with records specified in the SQL query for display purposes 
        /// </summary>
        /// <param name="pStrQuery"> The SQL query that will select the records to be loaded </param>
        /// <param name="pStrTableName"> The table name used by the query </param>
        /// <returns></returns>
        public DataTable GetDataTable(string pStrQuery, string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the data table with the table name specified by the paremeter 
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdpater object to fill the data data table or data set
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // creat an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();

                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdpater SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible 
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the data table with OleDBDataAdpater fill method
                dbDA.Fill(dtb);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                //close the connection after fill
                _dbConn.Close();
            }


            return dtb;
            
        }


        /// <summary>
        /// Pre Condition: The string paremeters will be the table name
        /// Post: Condition: The post condition specified in the table will be loaded in the table.
        /// Description: This method will return a data table loaded with records from the table
        /// </summary>
        /// <param name="pStrTableName"> The table name used by the query </param>
        /// <returns></returns>
        public DataTable GetDataTable(string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the data table with the table name specified by the paremeter 
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdpater object to fill the data data table or data set
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // creat an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();

                // set the command to the SQL string
                dbCmd.CommandText = "SELECT * FROM " + pStrTableName;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdpater SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible 
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the data table with OleDBDataAdpater fill method
                dbDA.Fill(dtb);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                //close the connection after fill
                _dbConn.Close();
            }


            return dtb;

        }

        public void fillDataSet(DataSet pDataSet, string pStrQuery, string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // name the data table with the table name specified by the paremeter 
                dtb.TableName = pStrTableName;

                // create an OleDBDataAdpater object to fill the data data table or data set
                OleDbDataAdapter dbDA = new OleDbDataAdapter();

                // creat an OleDBCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();

                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDBCommand connection
                dbCmd.Connection = _dbConn;

                // set the OleDBDataAdpater SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible 
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the data table with OleDBDataAdpater fill method
                dbDA.Fill(dtb);

                // close the connection after the fill
                _dbConn.Close();

                // add the table to the dataset
                pDataSet.Tables.Add(dtb);

                // set the primary key constaints of the table
                pDataSet.Tables[pStrTableName].PrimaryKey = new DataColumn[] { pDataSet.Tables[pStrTableName].Columns[0] };

                // set the primay key to autoincrement
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrement = true;

                //set the starting values of the primary key auto-increments 
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementSeed = -1;

                // set the increment step
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementStep = -10;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                _dbConn.Close();
            }
        }

        #endregion 

        #region Mutators

        /// <summary>
        /// Pre Condition: The paremeters will be in order of passing the dataset and the string table name
        /// Post Condition: The update dataset will be persisted in the data base
        /// Description: This method will update the database based on the update
        /// </summary>
        /// <param name="pDataSet"> The dataset that contains the updated records</param>
        /// <param name="pStrTableName"> The table name will be updated in the database </param>
        public void SaveData(DataSet pDataSet, string pStrTableName)
        {
            string strQuery = "SELECT * FROM " + pStrTableName;

            OleDbDataAdapter dbDA = new OleDbDataAdapter(strQuery, _dbConn);


            try
            {

                // setup the command builders
                OleDbCommandBuilder dbBLD = new OleDbCommandBuilder(dbDA);
                dbDA.InsertCommand = dbBLD.GetInsertCommand();
                dbDA.UpdateCommand = dbBLD.GetUpdateCommand();
                dbDA.DeleteCommand = dbBLD.GetDeleteCommand();

                // subsrcibe to the OleDBRowUpdateEventHandler
                dbDA.RowUpdated += new OleDbRowUpdatedEventHandler(onRowUpdated);
                _dbConn.Open();
                dbDA.Update(pDataSet, pStrTableName);
                pDataSet.Tables[pStrTableName].AcceptChanges();
                _dbConn.Close();
                pStrTableName = null;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                _dbConn.Close();
            }
        }

        /// <summary>
        /// pre-condition: The frist column in the query is the autonumber field
        /// post-condition: Child will be perssisted in the database consistent with the primary key of the parent record
        /// description:    this method will synchronize the primary and foriegn key togehter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void onRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
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
