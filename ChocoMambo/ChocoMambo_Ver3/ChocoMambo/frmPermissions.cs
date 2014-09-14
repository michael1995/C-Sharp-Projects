using DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChocoMambo
{
    public partial class frmPermissions : Form
    {

        #region Global Declaration

        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        DataSet _dst;

        #endregion 

        #region Constructor

        public frmPermissions()
        {
            InitializeComponent();
        }

        #endregion 

        #region Control Events
        private void FrmPermissions_Load(object sender, EventArgs e)
        {
            _dst = new DataSet();
            _dbConn.fillDataSet(_dst, "SELECT * FROM tblEmployeeForms", "tblEmployeeForms");

            dgvPermission.DataSource = _dst.Tables["tblEmployeeForms"];

            // set staf combo
            colEmployee.DisplayMember = "FirstName";
            colEmployee.ValueMember = "EmployeeID";
            colEmployee.DataSource = _dbConn.GetDataTable("qryEmployeeCombo");
            colEmployee.DataPropertyName = "EmployeeID";
            // set form combo
            colForm.DisplayMember = "FormName";
            colForm.ValueMember = "FormID";
            colForm.DataSource = _dbConn.GetDataTable("tblForms");
            colForm.DataPropertyName = "FormID";
            // set access combo
            colRights.DataPropertyName = "AccessType";
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            _dbConn.SaveData(_dst, "tblEmployeeForms");
            this.Close();
        }


        #endregion 
    }
}
