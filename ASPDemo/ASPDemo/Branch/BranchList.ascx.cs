using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Branch
{
    public partial class BranchList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        BranchClass _branch;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryBranch"));
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
            Session["BranchPKID"] = "";
            Response.Redirect("/Branch/Branch.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["BranchPKID"].ToString() != "")
            {
                Response.Redirect("/Branch/Branch.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["BranchPKID"].ToString() != "" && long.TryParse(Session["BranchPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["BranchPKID"].ToString());
                _branch = new BranchClass(_PKID);
                _branch.deleteRecord(_PKID);
                Session["BranchPKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["BranchPKID"] = row.Cells[1].Text;
        }
        #endregion 
    }
}