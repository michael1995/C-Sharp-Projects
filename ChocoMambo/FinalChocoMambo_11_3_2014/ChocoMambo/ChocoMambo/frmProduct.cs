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
    public partial class frmProduct : Form
    {

        #region Variable Declarations
        Product _product = null;
        Boolean _blnReadOnly;
        #endregion 

        #region Constructor
        public frmProduct()
        {
            InitializeComponent();
            _product = new Product();
            _blnReadOnly = false;
        }

        public frmProduct(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _product = new Product(pLongID);
            _blnReadOnly = pBlnReadOnly;
            displayRecord();
            OrganizeMenuButtons();
        }

        #endregion 

        #region Accessor

        private void displayRecord()
        {
            txtProductName.Text = _product.ProductName;
            txtProductCode.Text = _product.ProductCode;
            txtQuantityInStock.Text = _product.QuantityInStock;
            txtPrice.Text = _product.Price.ToString("c2");
            txtComment.Text = _product.Comments;
            cbActive.Checked = _product.Active;
        }

        #endregion

        #region Mutators

        private void assignData()
        {
            _product.ProductName = txtProductName.Text;
            _product.ProductCode = txtProductCode.Text;
            _product.QuantityInStock = txtQuantityInStock.Text;
            _product.Price = decimal.Parse(txtPrice.Text.Substring
                                                          (txtPrice.Text.IndexOf('$') + 1));
            _product.Comments = txtComment.Text;
            _product.Active = cbActive.Checked;
        }

        public void CheckFields(TextBox[] pTxtArray)
        {
            for (int i = 0; i < pTxtArray.Length; i++)
            {
                if (isClear(pTxtArray[i]))
                {
                    ErrorProvider.SetError(this, "Fields Cannot Be Empty");
                    mnuSave.Enabled = false;
                }
                else
                {
                    ErrorProvider.Dispose();
                    mnuSave.Enabled = true;
                }
            }
        }

        private bool isClear(TextBox ptxtFields)
        {
            bool temp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                temp = true;
            return temp;
        }
        public void OrganizeMenuButtons()
        {
            if (_blnReadOnly.Equals(true))
            {
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events
        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _product.saveData();
            this.Close();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (cbActive.Checked.Equals(true))
            {
                if (MessageBox.Show("Are you sure you want to delete the selected record?",
                              "ChocoMambo", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cbActive.Checked = false;
                    assignData();
                    _product.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot Delete. Please try again.", "ChocoMambo",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            TextBox[] txtArray = new TextBox[5] { txtProductName, txtProductCode, txtQuantityInStock, txtPrice, txtComment };
            if (_blnReadOnly.Equals(false))
            {
                CheckFields(txtArray);
            }
        }

        #endregion
    }
}
