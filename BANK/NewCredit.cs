using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace BANK
{
    public partial class NewCredit : Form
    {
        ArrayList allDebitors;
        DAL dal = new DAL();

        public NewCredit()
        {
            InitializeComponent();
            txbx_creditID.Text = Guid.NewGuid().ToString();

            allDebitors = dal.GetAllDebitors();

            if (allDebitors == null || allDebitors.Count == 0)
                txbx_creditBalance.Enabled =
                    txbx_creditAmount.Enabled =
                    btn_saveNewCredit.Enabled = false;

            ltbx_debitorID.DataSource = allDebitors;
            ltbx_debitorName.DataSource = allDebitors;
        }

        private void txbx_creditAmount_TextChanged(object sender, EventArgs e)
        {
            txbx_creditBalance.Text = txbx_creditAmount.Text;
        }

        private void btn_saveNewCredit_Click(object sender, EventArgs e)
        {
            if (dal.SaveNewCredit(new Guid(txbx_creditID.Text), new Guid(ltbx_debitorID.SelectedValue.ToString()), Int32.Parse(txbx_creditAmount.Text), Int32.Parse(txbx_creditBalance.Text), dtp_creditOpenDate.Value))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;
        }

        private void txbx_creditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//выбрали все символа - цифры
                e.Handled = true;
        }

        private void txbx_creditAmount_Leave(object sender, EventArgs e)
        {
            if (txbx_creditAmount.Text == string.Empty || 
                Int64.Parse(txbx_creditAmount.Text.Trim()) < 100 ||
                Int64.Parse(txbx_creditAmount.Text.Trim()) > 100000000)
            {
                lbl_messageCreditAmount.ForeColor = Color.Red;
                lbl_messageCreditAmount.Text = "Недопустимая сумма!";
                btn_saveNewCredit.Enabled = false;
            }
            else
            { 
                lbl_messageCreditAmount.ForeColor = Color.Green;
                lbl_messageCreditAmount.Text = "Сумма разрешена";
                btn_saveNewCredit.Enabled = true;
            }
        }
    }
}
