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
using System.Data.SqlClient;

namespace BANK
{
    public partial class MainForm : Form
    {
        DAL dal = new DAL();
        ArrayList allDebitors;

        SqlDataAdapter adapter;
        DataSet ds;
        int pageSize = 10;
        int pageNumber; 

        public MainForm()
        {
            InitializeComponent();
            allDebitors = dal.GetAllDebitors();

            GetDebitorsFromAdapter();

            dgv_debitors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_debitors.AllowUserToAddRows = false;
            txbx_kolvoStrok.Text = "10";

            SettingsDVG();
        }

        void SettingsDVG()
        {
            try
            {
                dgv_debitors.Columns["ID"].Visible = false;
                dgv_debitors.Columns["PostNumber"].Visible = false;
                dgv_debitors.Columns["PhoneNumber"].Visible = false;
                dgv_debitors.TopLeftHeaderCell.Value = "№";
                dgv_debitors.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

                dgv_credits.TopLeftHeaderCell.Value = "№";
                dgv_credits.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

                dgv_payments.TopLeftHeaderCell.Value = "№";
                dgv_payments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            }
            catch
            { 
            
            }
        }

        public void GetDebitorsFromAdapter()
        {
            using (SqlConnection connection = new SqlConnection(dal.connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds = new DataSet();
                adapter.Fill(ds, "Debitors");
                dgv_debitors.DataSource = ds.Tables[0];
                dgv_debitors.Columns["ID"].ReadOnly = true;
            }
        }

        private void dgv_debitors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txbx_debitorID.Text = dgv_debitors.Rows[e.RowIndex].Cells[0].Value.ToString();
            txbx_debitorName.Text = dgv_debitors.Rows[e.RowIndex].Cells[1].Value.ToString();
            txbx_debitorPostNumber.Text = dgv_debitors.Rows[e.RowIndex].Cells[2].Value.ToString();

            string phone = dgv_debitors.Rows[e.RowIndex].Cells[3].Value.ToString();
            txbx_phoneNumber.Text = (phone == String.Empty) ? "Нет данных" : phone;

            dgv_credits.DataSource = dal.GetAllCreditsForDebitor(dgv_debitors.CurrentRow.Cells["ID"].Value.ToString());

            //02092016 - очистка dgv_payments при отсутствии кредитов у клиента
            if (dgv_credits.CurrentRow == null)
                dgv_payments.DataSource = null;
        }

        private void dgv_credits_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string creditorID = dgv_credits.CurrentRow.Cells[0].Value.ToString();
            dgv_payments.DataSource = dal.GetAllPaymentsForCredit(creditorID);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgv_debitors.CellEnter += new DataGridViewCellEventHandler(dgv_debitors_CellEnter);
            dgv_credits.CellEnter += new DataGridViewCellEventHandler(dgv_credits_CellEnter);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Кредиты", MessageBoxButtons.OKCancel) == DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close(); //закрывает только текущую форму(если в приложении одна форма то можно использовать)
            Application.Exit(); //закрывает ВСЁ приложение
        }

        private void addNewDebitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDebitor newDebitor = new NewDebitor();
            if (newDebitor.ShowDialog() == DialogResult.OK)
            {
                allDebitors.Clear();
                
                allDebitors = dal.GetAllDebitors();
                dgv_debitors.DataSource = allDebitors;

                MessageBox.Show("Новый дебетор успешно добавлен", "КЛАССИКБАНК", MessageBoxButtons.OK);
            }
                
            else
                MessageBox.Show("Ошибка! Новый дебитор не создан", "КЛАССИКБАНК", MessageBoxButtons.OK);

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Программа для выдачи и погашения кредитов
                        ПАО 'КЛАССИКБАНК'

                                    версия 1.0", "КЛАССИКБАНК", MessageBoxButtons.OK);
        }

        private void openNewCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCredit newCredit = new NewCredit();
            if (newCredit.ShowDialog() == DialogResult.OK)
            {
                dgv_credits.DataSource = dal.GetAllCreditsForDebitor(dgv_debitors.CurrentRow.Cells["ID"].Value.ToString());
                MessageBox.Show("Новый кредит успешно выдан", "КЛАССИКБАНК", MessageBoxButtons.OK); 
            }
            else
                MessageBox.Show("Ошибка! Новый кредит не выдан", "КЛАССИКБАНК", MessageBoxButtons.OK);
        }

        private void passNewPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPayment newPayment = new NewPayment();
            if (newPayment.ShowDialog() == DialogResult.OK)
            {
                dgv_credits.DataSource = dal.GetAllCreditsForDebitor(dgv_debitors.CurrentRow.Cells["ID"].Value.ToString());
                MessageBox.Show("Платеж успешно принят", "КЛАССИКБАНК", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Ошибка! Платеж не принят", "КЛАССИКБАНК", MessageBoxButtons.OK);
        }

        private void saveDataToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dal.SaveDBToLocalFile())
                MessageBox.Show("Выгрузка данных прошла успешно", "КЛАССИКБАНК", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else
               MessageBox.Show("Ошибка! Данные не выгружены", "КЛАССИКБАНК", 
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value; //получили текущее значение ячейки куда хотим запихнуть порядкоый номер
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        List<DataGridViewRow> searchedRows;
        int currentRow;
        private void btn_search_Click(object sender, EventArgs e)
        {
            searchedRows = new List<DataGridViewRow>();
            string debName = txbx_searchedDebName.Text.Trim();
            string debPostNumber = txbx_searchedDebPostNumber.Text.Trim();
            string debPhoneNumber = txbx_searchedDebPhoneNumber.Text.Trim();

            if (!chbx_DB.Checked)
            {
                dgv_debitors.DataSource = allDebitors;
                foreach (DataGridViewRow row in dgv_debitors.Rows)
                {
                    if (
                        row.Cells["Name"].FormattedValue.ToString().Contains(debName) &&
                        row.Cells["PostNumber"].FormattedValue.ToString().Contains(debPostNumber) &&
                        row.Cells["PhoneNumber"].FormattedValue.ToString().Contains(debPhoneNumber)
                        )
                        searchedRows.Add(row);
                }

                if (searchedRows.Count == 0)
                { 
                    MessageBox.Show("Клиент не найден");
                    btn_nextRow.Enabled = false;
                    return;
                }

                MessageBox.Show("Найдено записей: " + searchedRows.Count);
                btn_nextRow.Enabled = true;
                currentRow = -1;
                btn_nextRow_Click(null, null);
            }

            else
            {
                btn_nextRow.Enabled = false;
                ArrayList searchedDebitors = dal.SearchDebitors(debName, debPostNumber, debPhoneNumber);
                if (searchedDebitors == null || searchedDebitors.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено");
                    return;
                }
                MessageBox.Show("Найдено записей: " + searchedDebitors.Count);
                dgv_debitors.DataSource = searchedDebitors;
            }
        }

        private void btn_nextRow_Click(object sender, EventArgs e)
        {
            if (searchedRows == null)
                return;

            if (currentRow == searchedRows.Count - 1)
                currentRow = 0;
            else
                currentRow++;

            dgv_debitors.CurrentCell = searchedRows[currentRow].Cells[1];
        }

        //кнопка Далее  - загрузки списка дебиторов частями из DataAdapter
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Debitors"].Rows.Count < pageSize) return;

            if (txbx_kolvoStrok.Text.Trim() != null)
                try
                {
                    pageSize = Int32.Parse(txbx_kolvoStrok.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

            pageNumber++;
            using (SqlConnection connection = new SqlConnection(dal.connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);
                ds.Tables["Debitors"].Rows.Clear();
                adapter.Fill(ds, "Debitors");
            }
        }

        //кнопка Назад  - загрузки списка дебиторов частями из DataAdapter
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            pageNumber--;

            if (txbx_kolvoStrok.Text.Trim() != null)
                try
                {
                    pageSize = Int32.Parse(txbx_kolvoStrok.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

            using (SqlConnection connection = new SqlConnection(dal.connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);
                ds.Tables["Debitors"].Rows.Clear();
                adapter.Fill(ds, "Debitors");
            }
        }

        private string GetSql()
        {
            return "SELECT * FROM Debitors ORDER BY Name OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }

    }
}
