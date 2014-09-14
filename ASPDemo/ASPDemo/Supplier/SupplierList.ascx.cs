﻿using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Supplier
{
    public partial class SupplierList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        SupplierClass _supplier;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qrySupplier"));
            gvData.DataSource = _dtb.DefaultView;
            gvData.DataBind();
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGridView();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session["SuplierPKID"] = "";
            Response.Redirect("/Supplier/Supplier.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["SuplierPKID"].ToString() != "")
            {
                Response.Redirect("/Supplier/Supplier.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["SuplierPKID"].ToString() != "" && long.TryParse(Session["SuplierPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["SuplierPKID"].ToString());
                _supplier = new SupplierClass(_PKID);
                _supplier.deleteRecord(_PKID);
                Session["SuplierPKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["SuplierPKID"] = row.Cells[1].Text;
        }
        #endregion 
    }
}