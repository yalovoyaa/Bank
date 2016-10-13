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
    public partial class NewPayment : Form
    {
        DAL dal = new DAL();
        ArrayList allDebitors;
        ArrayList allCredits;

        public NewPayment()
        {
            InitializeComponent();
            txbx_paymentID.Text = Guid.NewGuid().ToString();

            allDebitors = dal.GetAllDebitors();

            if (allDebitors == null || allDebitors.Count == 0)
            {
                btn_saveNewPayment.Enabled = false;
                txbx_paymentAmount.Enabled = false;
            }
            else
            {
                btn_saveNewPayment.Enabled = true;
                txbx_paymentAmount.Enabled = true;
            }
                

            ltbx_debitorID.DataSource = allDebitors;
            ltbx_debitorName.DataSource = allDebitors;
        }

        private void ltbx_debitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            allCredits = dal.GetAllCreditsForDebitor(ltbx_debitorID.SelectedValue.ToString());
            ltbx_creditID.DataSource = allCredits;

            if (allCredits == null || allCredits.Count == 0)
            {
                btn_saveNewPayment.Enabled = false;
                txbx_paymentAmount.Enabled = false;
            }
            else
            {
                btn_saveNewPayment.Enabled = true;
                txbx_paymentAmount.Enabled = true;
            }

            ltbx_creditAmount.DataSource = allCredits;
            ltbx_creditBalance.DataSource = allCredits;

            ltbx_creditID.DisplayMember = "ID";
            ltbx_creditID.ValueMember = "ID";
            ltbx_creditAmount.DisplayMember = "Amount";
            ltbx_creditAmount.ValueMember = "ID";
            ltbx_creditBalance.DisplayMember = "Balance";
            ltbx_creditBalance.ValueMember = "Balance";
        }

        private void txbx_paymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                if (txbx_paymentAmount.Text.Trim().Contains(',') ||
                    txbx_paymentAmount.Text == String.Empty)
                {
                    e.Handled = true;
                    return;
                }
                    
                else
                {
                    e.Handled = false;
                    return;
                }

            short res;
            if (Int16.TryParse(e.KeyChar.ToString(), out res))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txbx_paymentAmount_Leave(object sender, EventArgs e)
        {
            if (txbx_paymentAmount.Text.Trim() == string.Empty)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "Недопустимая сумма!";
                btn_saveNewPayment.Enabled = false;
                return;
            }
            else
            {
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = "Сумма разрешена";
                btn_saveNewPayment.Enabled = true;
            }

            decimal payValue = decimal.Parse(txbx_paymentAmount.Text.Trim());

            if (payValue < 100 || payValue > decimal.Parse(ltbx_creditBalance.SelectedValue.ToString()))
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "Недопустимая сумма!";
                btn_saveNewPayment.Enabled = false;
            }
            else
            {
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = "Сумма разрешена";
                btn_saveNewPayment.Enabled = true;
            }


        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txbx_paymentAmount.Text = "";
        }

        private void btn_saveNewPayment_Click(object sender, EventArgs e)
        {
            decimal paymentAmount;
            if (!decimal.TryParse(txbx_paymentAmount.Text.Trim(), out paymentAmount))
            {
                MessageBox.Show("Неверная сумма платежа");
                return;
            }

            if (dal.SaveNewPayment(new Guid(txbx_paymentID.Text.Trim()),
                new Guid(ltbx_creditID.SelectedValue.ToString()),
                paymentAmount, dtp_paymentPassDate.Value))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;
        }

    }
}
