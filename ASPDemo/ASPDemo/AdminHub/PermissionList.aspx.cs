using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.AdminHub
{
    public partial class PermissionList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control uc = LoadControl("PermissionList.ascx");
            PlaceHolder1.Controls.Add(uc);
        }
    }
}