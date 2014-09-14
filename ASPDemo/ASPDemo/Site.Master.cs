using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLoggedIn() == false)
            {
                NavigationMenu.Enabled = false;
            }
            else
            {
                NavigationMenu.Enabled = true;
                HeadLoginView.Visible = true;
            }
        }

        private Boolean isLoggedIn()
        {
            String path = HttpContext.Current.Request.Url.AbsolutePath;

            if (path == "/Login/UserLogin.aspx")
                return false;
            else
                return true;
        }
    }
}
