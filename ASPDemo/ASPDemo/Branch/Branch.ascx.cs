using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Branch
{
    public partial class Branch1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        BranchClass _branch = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// Display the current Record
        /// </summary>
        private void displayRecord()
        {
            txtBranchOffice.Text = _branch.BranchOffice; // get the database values of this property to be displayed in this text box
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _branch.BranchOffice = txtBranchOffice.Text;
        }
        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchPKID"].ToString() != "" && long.TryParse(Session["BranchPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["BranchPKID"].ToString());
                _branch = new BranchClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();
                }
            }
            else
            {
                _branch = new BranchClass();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _branch.saveData();
            Session["BranchPKID"] = "";
            Response.Redirect("/Branch/BranchList.aspx");
        }
        #endregion 
    }
}