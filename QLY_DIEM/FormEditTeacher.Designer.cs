namespace QLY_DIEM
{
    partial class FormEditTeacher
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
            pnlEditInfTeacher = new Panel();
            dtpEditDate = new DateTimePicker();
            lbIdTeacher = new Label();
            txbId = new TextBox();
            lbEditMon = new Label();
            txbEditMon = new TextBox();
            cbxEditSex = new ComboBox();
            lbEditSex = new Label();
            label7 = new Label();
            lbEditEmail = new Label();
            txbEditEmail = new TextBox();
            lbEditPhone = new Label();
            txbEditPhone = new TextBox();
            lbEditAddress = new Label();
            txbEditAddress = new TextBox();
            lbEditQue = new Label();
            lbEditCccd = new Label();
            txbEditQue = new TextBox();
            lbEditDate = new Label();
            txbEditCccd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            lbChar = new Label();
            lbEditName = new Label();
            txbEditName = new TextBox();
            btnSave = new Button();
            pnlEditInfTeacher.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditInfTeacher
            // 
            pnlEditInfTeacher.BackColor = Color.Honeydew;
            pnlEditInfTeacher.Controls.Add(dtpEditDate);
            pnlEditInfTeacher.Controls.Add(lbIdTeacher);
            pnlEditInfTeacher.Controls.Add(txbId);
            pnlEditInfTeacher.Controls.Add(lbEditMon);
            pnlEditInfTeacher.Controls.Add(txbEditMon);
            pnlEditInfTeacher.Controls.Add(cbxEditSex);
            pnlEditInfTeacher.Controls.Add(lbEditSex);
            pnlEditInfTeacher.Controls.Add(label7);
            pnlEditInfTeacher.Controls.Add(lbEditEmail);
            pnlEditInfTeacher.Controls.Add(txbEditEmail);
            pnlEditInfTeacher.Controls.Add(lbEditPhone);
            pnlEditInfTeacher.Controls.Add(txbEditPhone);
            pnlEditInfTeacher.Controls.Add(lbEditAddress);
            pnlEditInfTeacher.Controls.Add(txbEditAddress);
            pnlEditInfTeacher.Controls.Add(lbEditQue);
            pnlEditInfTeacher.Controls.Add(lbEditCccd);
            pnlEditInfTeacher.Controls.Add(txbEditQue);
            pnlEditInfTeacher.Controls.Add(lbEditDate);
            pnlEditInfTeacher.Controls.Add(txbEditCccd);
            pnlEditInfTeacher.Controls.Add(label6);
            pnlEditInfTeacher.Controls.Add(label5);
            pnlEditInfTeacher.Controls.Add(label3);
            pnlEditInfTeacher.Controls.Add(label2);
            pnlEditInfTeacher.Controls.Add(label1);
            pnlEditInfTeacher.Controls.Add(label4);
            pnlEditInfTeacher.Controls.Add(lbChar);
            pnlEditInfTeacher.Controls.Add(lbEditName);
            pnlEditInfTeacher.Controls.Add(txbEditName);
            pnlEditInfTeacher.Controls.Add(btnSave);
            pnlEditInfTeacher.Location = new Point(0, 0);
            pnlEditInfTeacher.Name = "pnlEditInfTeacher";
            pnlEditInfTeacher.Size = new Size(538, 626);
            pnlEditInfTeacher.TabIndex = 33;
            // 
            // dtpEditDate
            // 
            dtpEditDate.Location = new Point(182, 179);
            dtpEditDate.Name = "dtpEditDate";
            dtpEditDate.Size = new Size(200, 23);
            dtpEditDate.TabIndex = 23;
            // 
            // lbIdTeacher
            // 
            lbIdTeacher.AutoSize = true;
            lbIdTeacher.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbIdTeacher.Location = new Point(49, 31);
            lbIdTeacher.Name = "lbIdTeacher";
            lbIdTeacher.Size = new Size(91, 19);
            lbIdTeacher.TabIndex = 21;
            lbIdTeacher.Text = "Mã giáo viên:";
            // 
            // txbId
            // 
            txbId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbId.Location = new Point(182, 28);
            txbId.Name = "txbId";
            txbId.ReadOnly = true;
            txbId.Size = new Size(196, 25);
            txbId.TabIndex = 20;
            // 
            // lbEditMon
            // 
            lbEditMon.AutoSize = true;
            lbEditMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditMon.Location = new Point(49, 131);
            lbEditMon.Name = "lbEditMon";
            lbEditMon.Size = new Size(105, 19);
            lbEditMon.TabIndex = 19;
            lbEditMon.Text = "Môn giảng dạy:";
            // 
            // txbEditMon
            // 
            txbEditMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditMon.Location = new Point(182, 128);
            txbEditMon.Name = "txbEditMon";
            txbEditMon.ReadOnly = true;
            txbEditMon.Size = new Size(181, 25);
            txbEditMon.TabIndex = 18;
            // 
            // cbxEditSex
            // 
            cbxEditSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEditSex.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbxEditSex.FormattingEnabled = true;
            cbxEditSex.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbxEditSex.Location = new Point(182, 238);
            cbxEditSex.Name = "cbxEditSex";
            cbxEditSex.Size = new Size(76, 25);
            cbxEditSex.TabIndex = 17;
            // 
            // lbEditSex
            // 
            lbEditSex.AutoSize = true;
            lbEditSex.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditSex.Location = new Point(49, 241);
            lbEditSex.Name = "lbEditSex";
            lbEditSex.Size = new Size(64, 19);
            lbEditSex.TabIndex = 16;
            lbEditSex.Text = "Giới tính:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(31, 582);
            label7.Name = "label7";
            label7.Size = new Size(133, 19);
            label7.TabIndex = 14;
            label7.Text = ": Thông tin bắt buộc";
            // 
            // lbEditEmail
            // 
            lbEditEmail.AutoSize = true;
            lbEditEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditEmail.Location = new Point(49, 511);
            lbEditEmail.Name = "lbEditEmail";
            lbEditEmail.Size = new Size(44, 19);
            lbEditEmail.TabIndex = 14;
            lbEditEmail.Text = "Email:";
            // 
            // txbEditEmail
            // 
            txbEditEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditEmail.Location = new Point(182, 508);
            txbEditEmail.Name = "txbEditEmail";
            txbEditEmail.Size = new Size(296, 25);
            txbEditEmail.TabIndex = 13;
            // 
            // lbEditPhone
            // 
            lbEditPhone.AutoSize = true;
            lbEditPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditPhone.Location = new Point(49, 456);
            lbEditPhone.Name = "lbEditPhone";
            lbEditPhone.Size = new Size(92, 19);
            lbEditPhone.TabIndex = 12;
            lbEditPhone.Text = "Số điện thoại:";
            // 
            // txbEditPhone
            // 
            txbEditPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditPhone.Location = new Point(182, 453);
            txbEditPhone.Name = "txbEditPhone";
            txbEditPhone.Size = new Size(296, 25);
            txbEditPhone.TabIndex = 11;
            // 
            // lbEditAddress
            // 
            lbEditAddress.AutoSize = true;
            lbEditAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditAddress.Location = new Point(49, 402);
            lbEditAddress.Name = "lbEditAddress";
            lbEditAddress.Size = new Size(97, 19);
            lbEditAddress.TabIndex = 10;
            lbEditAddress.Text = "Địa chỉ liên hệ:";
            // 
            // txbEditAddress
            // 
            txbEditAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditAddress.Location = new Point(182, 399);
            txbEditAddress.Name = "txbEditAddress";
            txbEditAddress.Size = new Size(296, 25);
            txbEditAddress.TabIndex = 9;
            // 
            // lbEditQue
            // 
            lbEditQue.AutoSize = true;
            lbEditQue.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditQue.Location = new Point(49, 350);
            lbEditQue.Name = "lbEditQue";
            lbEditQue.Size = new Size(73, 19);
            lbEditQue.TabIndex = 8;
            lbEditQue.Text = "Quê quán:";
            // 
            // lbEditCccd
            // 
            lbEditCccd.AutoSize = true;
            lbEditCccd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditCccd.Location = new Point(49, 296);
            lbEditCccd.Name = "lbEditCccd";
            lbEditCccd.Size = new Size(83, 19);
            lbEditCccd.TabIndex = 6;
            lbEditCccd.Text = "CCCD/CMT:";
            // 
            // txbEditQue
            // 
            txbEditQue.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditQue.Location = new Point(182, 347);
            txbEditQue.Name = "txbEditQue";
            txbEditQue.Size = new Size(296, 25);
            txbEditQue.TabIndex = 5;
            // 
            // lbEditDate
            // 
            lbEditDate.AutoSize = true;
            lbEditDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditDate.Location = new Point(49, 183);
            lbEditDate.Name = "lbEditDate";
            lbEditDate.Size = new Size(73, 19);
            lbEditDate.TabIndex = 4;
            lbEditDate.Text = "Ngày sinh:";
            // 
            // txbEditCccd
            // 
            txbEditCccd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditCccd.Location = new Point(182, 293);
            txbEditCccd.Name = "txbEditCccd";
            txbEditCccd.Size = new Size(296, 25);
            txbEditCccd.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(384, 31);
            label6.Name = "label6";
            label6.Size = new Size(23, 19);
            label6.TabIndex = 2;
            label6.Text = "(*)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(484, 350);
            label5.Name = "label5";
            label5.Size = new Size(23, 19);
            label5.TabIndex = 2;
            label5.Text = "(*)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(484, 456);
            label3.Name = "label3";
            label3.Size = new Size(23, 19);
            label3.TabIndex = 2;
            label3.Text = "(*)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(484, 296);
            label2.Name = "label2";
            label2.Size = new Size(23, 19);
            label2.TabIndex = 2;
            label2.Text = "(*)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(388, 183);
            label1.Name = "label1";
            label1.Size = new Size(23, 19);
            label1.TabIndex = 2;
            label1.Text = "(*)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(12, 582);
            label4.Name = "label4";
            label4.Size = new Size(23, 19);
            label4.TabIndex = 2;
            label4.Text = "(*)";
            // 
            // lbChar
            // 
            lbChar.AutoSize = true;
            lbChar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbChar.ForeColor = Color.Red;
            lbChar.Location = new Point(484, 81);
            lbChar.Name = "lbChar";
            lbChar.Size = new Size(23, 19);
            lbChar.TabIndex = 2;
            lbChar.Text = "(*)";
            // 
            // lbEditName
            // 
            lbEditName.AutoSize = true;
            lbEditName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditName.Location = new Point(49, 81);
            lbEditName.Name = "lbEditName";
            lbEditName.Size = new Size(54, 19);
            lbEditName.TabIndex = 2;
            lbEditName.Text = "Họ tên:";
            // 
            // txbEditName
            // 
            txbEditName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbEditName.Location = new Point(182, 78);
            txbEditName.Name = "txbEditName";
            txbEditName.ReadOnly = true;
            txbEditName.Size = new Size(296, 25);
            txbEditName.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(222, 565);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormEditTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 625);
            Controls.Add(pnlEditInfTeacher);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormEditTeacher";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa thông tin";
            Load += FormEditTeacher_Load;
            pnlEditInfTeacher.ResumeLayout(false);
            pnlEditInfTeacher.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditInfTeacher;
        private Label lbEditMon;
        private TextBox txbEditMon;
        private ComboBox cbxEditSex;
        private Label lbEditSex;
        private Label lbEditEmail;
        private TextBox txbEditEmail;
        private Label lbEditPhone;
        private TextBox txbEditPhone;
        private Label lbEditAddress;
        private TextBox txbEditAddress;
        private Label lbEditQue;
        private Label lbEditCccd;
        private TextBox txbEditQue;
        private Label lbEditDate;
        private TextBox txbEditCccd;
        private Label lbEditName;
        private TextBox txbEditName;
        private Button btnSave;
        private Label lbIdTeacher;
        private TextBox txbId;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label lbChar;
        private Label label7;
        private DateTimePicker dtpEditDate;
    }
}