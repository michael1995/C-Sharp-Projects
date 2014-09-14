using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoMambo
{
    public class SearchDataTables
    {
        #region Accessors

       
        public DataTable loadCustomerData()
        {
            // create a dbConnection and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a data table to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qryCustomerActive");
            return dtb;
        }

        public DataTable loadBranchData()
        {
            // create a dbConnection and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a data table to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qryBranchActive");
            return dtb;
        }

        public DataTable loadProductData()
        {
            // create a dbConnection and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a data table to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qryProductActive");
            return dtb;
        }

        public DataTable loadRawIngredientData()
        {
            // create a dbConnection and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a data table to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qryRawIngredientsActive");
            return dtb;
        }

        public DataTable loadOrderData()
        {
            // create a dbConnection object and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a DataTable to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qryOrdersActive");
            return dtb;
        }

        public DataTable loadSupplierData()
        {
            // create a dbConnection object and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a DataTable to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qrySupplierActive");
            return dtb;
        }

        public DataTable loadSupplierPurchaseData()
        {
            // create a dbConnection object and pass the database name
            dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
            // create a DataTable to store the table tblCustomers
            DataTable dtb = dbConn.GetDataTable("qrySupplierPurchaseActive");
            return dtb;
        }

        #endregion
    }
}
