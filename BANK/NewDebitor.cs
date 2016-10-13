using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class NewDebitor : Form
    {
        DAL dal = new DAL();

        public NewDebitor()
        {
            InitializeComponent();

            txbx_debitorID.Text = Convert.ToString(Guid.NewGuid());

        }

        private void btn_saveNewDebitor_Click(object sender, EventArgs e)
        {
            if (dal.SaveNewDebitor(txbx_debitorID.Text.Trim(), 
                               txbx_debitorName.Text.Trim(), 
                               txbx_debitorPostNumber.Text.Trim(), 
                               txbx_phoneNumber.Text.Trim()))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;

 
        }
    }
}
