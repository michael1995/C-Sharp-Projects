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
    public partial class frmRawIngredients : Form
    {

        #region Variable Declarations
        RawIngredients _rawIngredients = null;
        #endregion 

        #region Constructor
        public frmRawIngredients()
        {
            InitializeComponent();
            _rawIngredients = new RawIngredients();
        }

        public frmRawIngredients(long pLongID)
        {
            InitializeComponent();
            _rawIngredients = new RawIngredients(pLongID);
            mnuSave.Enabled = true; mnuDelete.Enabled = true; mnuWindow.Enabled = true;
            displayRecord();
        }

        #endregion 

        #region Accessor
        private void displayRecord()
        {
            txtIngredientName.Text = _rawIngredients.IngredientName;
            txtIngCode.Text = _rawIngredients.IngCode;
            txtPrice.Text = _rawIngredients.Price.ToString("c2");
            cbActive.Checked = _rawIngredients.Active;
        }

        #endregion

        #region Mutators

        private void assignData()
        {
            _rawIngredients.IngredientName = txtIngredientName.Text;
            _rawIngredients.IngCode = txtIngCode.Text;
            _rawIngredients.Price = decimal.Parse(txtPrice.Text.Substring
                                              (txtPrice.Text.IndexOf('$') + 1));
            _rawIngredients.Active = cbActive.Checked;
        }

        public void CheckFields(TextBox[] pTxtArray)
        {
            for (int i = 0; i < pTxtArray.Length; i++)
            {
                if (isClear(pTxtArray[i]))
                {
                    mnuSave.Enabled = false;
                }
                else
                {
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

        #endregion 

        #region Control Events

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTitleHorizontal_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTitleVertical_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _rawIngredients.saveData();
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
                    _rawIngredients.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("This Item cannot be Deleted, becuase it has already been Deleted!");
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            TextBox[] txtArray = new TextBox[3] { txtIngredientName, txtPrice, txtIngCode };
            CheckFields(txtArray);
        }
        #endregion
    }
}
