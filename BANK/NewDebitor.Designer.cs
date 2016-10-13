namespace BANK
{
    partial class NewDebitor
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
            this.btn_saveNewDebitor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbx_phoneNumber = new System.Windows.Forms.TextBox();
            this.txbx_debitorPostNumber = new System.Windows.Forms.TextBox();
            this.txbx_debitorName = new System.Windows.Forms.TextBox();
            this.txbx_debitorID = new System.Windows.Forms.TextBox();
            this.grbx_debitorDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbx_debitorDetails
            // 
            this.grbx_debitorDetails.Controls.Add(this.btn_saveNewDebitor);
            this.grbx_debitorDetails.Controls.Add(this.label4);
            this.grbx_debitorDetails.Controls.Add(this.label3);
            this.grbx_debitorDetails.Controls.Add(this.label2);
            this.grbx_debitorDetails.Controls.Add(this.label1);
            this.grbx_debitorDetails.Controls.Add(this.txbx_phoneNumber);
            this.grbx_debitorDetails.Controls.Add(this.txbx_debitorPostNumber);
            this.grbx_debitorDetails.Controls.Add(this.txbx_debitorName);
            this.grbx_debitorDetails.Controls.Add(this.txbx_debitorID);
            this.grbx_debitorDetails.Location = new System.Drawing.Point(12, 12);
            this.grbx_debitorDetails.Name = "grbx_debitorDetails";
            this.grbx_debitorDetails.Size = new System.Drawing.Size(543, 183);
            this.grbx_debitorDetails.TabIndex = 2;
            this.grbx_debitorDetails.TabStop = false;
            this.grbx_debitorDetails.Text = "Информация";
            // 
            // btn_saveNewDebitor
            // 
            this.btn_saveNewDebitor.Location = new System.Drawing.Point(419, 154);
            this.btn_saveNewDebitor.Name = "btn_saveNewDebitor";
            this.btn_saveNewDebitor.Size = new System.Drawing.Size(118, 23);
            this.btn_saveNewDebitor.TabIndex = 8;
            this.btn_saveNewDebitor.Text = "Добавить";
            this.btn_saveNewDebitor.UseVisualStyleBackColor = true;
            this.btn_saveNewDebitor.Click += new System.EventHandler(this.btn_saveNewDebitor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Телефонный номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Почтовый индекс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя  и Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Идентификатор";
            // 
            // txbx_phoneNumber
            // 
            this.txbx_phoneNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_phoneNumber.Location = new System.Drawing.Point(120, 96);
            this.txbx_phoneNumber.Name = "txbx_phoneNumber";
            this.txbx_phoneNumber.Size = new System.Drawing.Size(417, 20);
            this.txbx_phoneNumber.TabIndex = 3;
            // 
            // txbx_debitorPostNumber
            // 
            this.txbx_debitorPostNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_debitorPostNumber.Location = new System.Drawing.Point(120, 70);
            this.txbx_debitorPostNumber.Name = "txbx_debitorPostNumber";
            this.txbx_debitorPostNumber.Size = new System.Drawing.Size(417, 20);
            this.txbx_debitorPostNumber.TabIndex = 2;
            // 
            // txbx_debitorName
            // 
            this.txbx_debitorName.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_debitorName.Location = new System.Drawing.Point(120, 44);
            this.txbx_debitorName.Name = "txbx_debitorName";
            this.txbx_debitorName.Size = new System.Drawing.Size(417, 20);
            this.txbx_debitorName.TabIndex = 1;
            // 
            // txbx_debitorID
            // 
            this.txbx_debitorID.BackColor = System.Drawing.SystemColors.Info;
            this.txbx_debitorID.Location = new System.Drawing.Point(120, 17);
            this.txbx_debitorID.Name = "txbx_debitorID";
            this.txbx_debitorID.ReadOnly = true;
            this.txbx_debitorID.Size = new System.Drawing.Size(417, 20);
            this.txbx_debitorID.TabIndex = 0;
            // 
            // NewDebitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 273);
            this.Controls.Add(this.grbx_debitorDetails);
            this.Name = "NewDebitor";
            this.Text = "Новый клиент";
            this.grbx_debitorDetails.ResumeLayout(false);
            this.grbx_debitorDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbx_debitorDetails;
        private System.Windows.Forms.Button btn_saveNewDebitor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbx_phoneNumber;
        private System.Windows.Forms.TextBox txbx_debitorPostNumber;
        private System.Windows.Forms.TextBox txbx_debitorName;
        private System.Windows.Forms.TextBox txbx_debitorID;
    }
}