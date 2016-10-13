namespace BANK
{
    partial class NewPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbx_debitorDetails = new System.Windows.Forms.GroupBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.ltbx_creditBalance = new System.Windows.Forms.ListBox();
            this.ltbx_creditAmount = new System.Windows.Forms.ListBox();
            this.ltbx_creditID = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_messageCreditAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_paymentPassDate = new System.Windows.Forms.DateTimePicker();
            this.ltbx_debitorName = new System.Windows.Forms.ListBox();
            this.ltbx_debitorID = new System.Windows.Forms.ListBox();
            this.btn_saveNewPayment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbx_paymentAmount = new System.Windows.Forms.TextBox();
            this.txbx_paymentID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grbx_debitorDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbx_debitorDetails
            // 
            this.grbx_debitorDetails.Controls.Add(this.label8);
            this.grbx_debitorDetails.Controls.Add(this.label7);
            this.grbx_debitorDetails.Controls.Add(this.label4);
            this.grbx_debitorDetails.Controls.Add(this.btn_refresh);
            this.grbx_debitorDetails.Controls.Add(this.lbl_message);
            this.grbx_debitorDetails.Controls.Add(this.ltbx_creditBalance);
            this.grbx_debitorDetails.Controls.Add(this.ltbx_creditAmount);
            this.grbx_debitorDetails.Controls.Add(this.ltbx_creditID);
            this.grbx_debitorDetails.Controls.Add(this.label6);
            this.grbx_debitorDetails.Controls.Add(this.lbl_messageCreditAmount);
            this.grbx_debitorDetails.Controls.Add(this.label5);
            this.grbx_debitorDetails.Controls.Add(this.dtp_paymentPassDate);
            this.grbx_debitorDetails.Controls.Add(this.ltbx_debitorName);
            this.grbx_debitorDetails.Controls.Add(this.ltbx_debitorID);
            this.grbx_debitorDetails.Controls.Add(this.btn_saveNewPayment);
            this.grbx_debitorDetails.Controls.Add(this.label3);
            this.grbx_debitorDetails.Controls.Add(this.label2);
            this.grbx_debitorDetails.Controls.Add(this.label1);
            this.grbx_debitorDetails.Controls.Add(this.txbx_paymentAmount);
            this.grbx_debitorDetails.Controls.Add(this.txbx_paymentID);
            this.grbx_debitorDetails.Location = new System.Drawing.Point(16, 17);
            this.grbx_debitorDetails.Name = "grbx_debitorDetails";
            this.grbx_debitorDetails.Size = new System.Drawing.Size(630, 374);
            this.grbx_debitorDetails.TabIndex = 4;
            this.grbx_debitorDetails.TabStop = false;
            this.grbx_debitorDetails.Text = "Информация";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(335, 264);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(118, 23);
            this.btn_refresh.TabIndex = 21;
            this.btn_refresh.Text = "Очистить";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(467, 269);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(130, 13);
            this.lbl_message.TabIndex = 20;
            this.lbl_message.Text = "Введите сумму платежа";
            // 
            // ltbx_creditBalance
            // 
            this.ltbx_creditBalance.DisplayMember = "Balance";
            this.ltbx_creditBalance.FormattingEnabled = true;
            this.ltbx_creditBalance.Location = new System.Drawing.Point(463, 163);
            this.ltbx_creditBalance.Name = "ltbx_creditBalance";
            this.ltbx_creditBalance.Size = new System.Drawing.Size(161, 95);
            this.ltbx_creditBalance.TabIndex = 19;
            this.ltbx_creditBalance.ValueMember = "Balance";
            // 
            // ltbx_creditAmount
            // 
            this.ltbx_creditAmount.DisplayMember = "Amount";
            this.ltbx_creditAmount.FormattingEnabled = true;
            this.ltbx_creditAmount.Location = new System.Drawing.Point(285, 163);
            this.ltbx_creditAmount.Name = "ltbx_creditAmount";
            this.ltbx_creditAmount.Size = new System.Drawing.Size(172, 95);
            this.ltbx_creditAmount.TabIndex = 18;
            this.ltbx_creditAmount.ValueMember = "ID";
            // 
            // ltbx_creditID
            // 
            this.ltbx_creditID.DisplayMember = "ID";
            this.ltbx_creditID.FormattingEnabled = true;
            this.ltbx_creditID.Location = new System.Drawing.Point(120, 163);
            this.ltbx_creditID.Name = "ltbx_creditID";
            this.ltbx_creditID.Size = new System.Drawing.Size(159, 95);
            this.ltbx_creditID.TabIndex = 17;
            this.ltbx_creditID.ValueMember = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Кредит";
            // 
            // lbl_messageCreditAmount
            // 
            this.lbl_messageCreditAmount.AutoSize = true;
            this.lbl_messageCreditAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_messageCreditAmount.Location = new System.Drawing.Point(335, 138);
            this.lbl_messageCreditAmount.Name = "lbl_messageCreditAmount";
            this.lbl_messageCreditAmount.Size = new System.Drawing.Size(0, 13);
            this.lbl_messageCreditAmount.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата";
            // 
            // dtp_paymentPassDate
            // 
            this.dtp_paymentPassDate.Location = new System.Drawing.Point(120, 290);
            this.dtp_paymentPassDate.Name = "dtp_paymentPassDate";
            this.dtp_paymentPassDate.Size = new System.Drawing.Size(209, 20);
            this.dtp_paymentPassDate.TabIndex = 11;
            // 
            // ltbx_debitorName
            // 
            this.ltbx_debitorName.DisplayMember = "Name";
            this.ltbx_debitorName.FormattingEnabled = true;
            this.ltbx_debitorName.Location = new System.Drawing.Point(285, 47);
            this.ltbx_debitorName.Name = "ltbx_debitorName";
            this.ltbx_debitorName.Size = new System.Drawing.Size(339, 95);
            this.ltbx_debitorName.TabIndex = 10;
            this.ltbx_debitorName.ValueMember = "ID";
            this.ltbx_debitorName.SelectedIndexChanged += new System.EventHandler(this.ltbx_debitor_SelectedIndexChanged);
            // 
            // ltbx_debitorID
            // 
            this.ltbx_debitorID.DisplayMember = "ID";
            this.ltbx_debitorID.FormattingEnabled = true;
            this.ltbx_debitorID.Location = new System.Drawing.Point(120, 47);
            this.ltbx_debitorID.Name = "ltbx_debitorID";
            this.ltbx_debitorID.Size = new System.Drawing.Size(159, 95);
            this.ltbx_debitorID.TabIndex = 9;
            this.ltbx_debitorID.ValueMember = "ID";
            this.ltbx_debitorID.SelectedIndexChanged += new System.EventHandler(this.ltbx_debitor_SelectedIndexChanged);
            // 
            // btn_saveNewPayment
            // 
            this.btn_saveNewPayment.Location = new System.Drawing.Point(506, 336);
            this.btn_saveNewPayment.Name = "btn_saveNewPayment";
            this.btn_saveNewPayment.Size = new System.Drawing.Size(118, 23);
            this.btn_saveNewPayment.TabIndex = 8;
            this.btn_saveNewPayment.Text = "Добавить";
            this.btn_saveNewPayment.UseVisualStyleBackColor = true;
            this.btn_saveNewPayment.Click += new System.EventHandler(this.btn_saveNewPayment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сумма платежа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Клиент";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Идентификатор";
            // 
            // txbx_paymentAmount
            // 
            this.txbx_paymentAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_paymentAmount.Location = new System.Drawing.Point(120, 264);
            this.txbx_paymentAmount.MaxLength = 12;
            this.txbx_paymentAmount.Name = "txbx_paymentAmount";
            this.txbx_paymentAmount.Size = new System.Drawing.Size(209, 20);
            this.txbx_paymentAmount.TabIndex = 2;
            this.txbx_paymentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbx_paymentAmount_KeyPress);
            this.txbx_paymentAmount.Leave += new System.EventHandler(this.txbx_paymentAmount_Leave);
            // 
            // txbx_paymentID
            // 
            this.txbx_paymentID.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_paymentID.Location = new System.Drawing.Point(120, 21);
            this.txbx_paymentID.Name = "txbx_paymentID";
            this.txbx_paymentID.ReadOnly = true;
            this.txbx_paymentID.Size = new System.Drawing.Size(504, 20);
            this.txbx_paymentID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Идентификатор";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Сумма кредита";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Баланс";
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 403);
            this.Controls.Add(this.grbx_debitorDetails);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "NewPayment";
            this.Text = "Новый платеж";
            this.grbx_debitorDetails.ResumeLayout(false);
            this.grbx_debitorDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbx_debitorDetails;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.ListBox ltbx_creditBalance;
        private System.Windows.Forms.ListBox ltbx_creditAmount;
        private System.Windows.Forms.ListBox ltbx_creditID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_messageCreditAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_paymentPassDate;
        private System.Windows.Forms.ListBox ltbx_debitorName;
        private System.Windows.Forms.ListBox ltbx_debitorID;
        private System.Windows.Forms.Button btn_saveNewPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbx_paymentAmount;
        private System.Windows.Forms.TextBox txbx_paymentID;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}