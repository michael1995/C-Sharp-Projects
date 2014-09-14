using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class Permissions : System.Web.UI.Page
    {
        dbConnection _dbconnection = new dbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        DataSet _dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                _dataSet = new DataSet();
                _dbconnection.fillDataSet(_dataSet, "SELECT * FROM tbl_UserForms", "tbl_UserForms");
                gv_permissions.DataSource = _dataSet.Tables["tbl_UserForms"];
                gv_permissions.DataBind();
            

            
            
        }

      

        protected void btn_update_Click(object sender, EventArgs e)
        {
            _dbconnection.SaveData(_dataSet, "tbl_UserForms");
        }

        protected void gv_permissions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             if(e.Row.RowType  == DataControlRowType.DataRow)
             {
                
                 //Cast the row item as DatarowView
                 DataRowView drv = e.Row.DataItem as DataRowView;

                 //Set Employee dropdown

                 //Get the Value Employee for the Current Row
                 String strTemp = drv["EmployeeNumber"].ToString();
                 //Find the DropDownList inside the Rows
                 DropDownList dd_temp = (DropDownList)e.Row.FindControl("dd_employee");
                 //Bind the Temporory Table we have Created
                 dd_temp.DataSource = _dbconnection.GetDataTable("qry_EmployeeList"); 
                 //Set the Display value
                 dd_temp.DataTextField = "EmployeeName";
                //Set the Value 
                 dd_temp.DataValueField = "ID";
                 //Bind the values to DropDownList
                 dd_temp.DataBind();
                 //Find the Current Employee and set that as Selected
                 dd_temp.Items.FindByValue(strTemp).Selected = true;

                 //Set Form dropdown
                
                 //Get the Value Form for the Current Row
                 strTemp = drv["FormID"].ToString();
                 //Find the DropDownList inside the Rows
                 dd_temp = (DropDownList)e.Row.FindControl("dd_form");
                 //Bind the Temporory Table we have Created
                 dd_temp.DataSource = _dbconnection.GetDataTable("tbl_Forms");
                 //Set the Display value
                 dd_temp.DataTextField = "FormName";
                 //Set the Value
                 dd_temp.DataValueField = "ID";
                 //Bind the values to DropDownList
                 dd_temp.DataBind();
                 //Find the Current City and set that as Selected
                 dd_temp.Items.FindByValue(strTemp).Selected = true;


                 //Set Access Type dropdown

                 //Get the Value Access type for the Current Row
                 strTemp = drv["AccessType"].ToString();
                 //Find the DropDownList inside the Rows
                 dd_temp = (DropDownList)e.Row.FindControl("dd_AccessRight");
                 //Bind the Temporory Table we have Created
                 dd_temp.DataSource = _dbconnection.GetDataTable("tbl_AccessType");
                 //Set the Display value
                 dd_temp.DataTextField = "Type";
                 //Bind the values to DropDownList
                 dd_temp.DataBind();
                 //Find the Current Access type and set that as Selected
                 dd_temp.Items.FindByText(strTemp).Selected = true;
             }
        }
    }
}