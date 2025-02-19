namespace QLY_DIEM
{
    partial class FormViewInf
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
            lbId = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lbName = new Label();
            txbPass = new TextBox();
            lbPass = new Label();
            txbPhanquyen = new TextBox();
            lbPhanquyen = new Label();
            txbCccd = new TextBox();
            lbCccd = new Label();
            txbPhone = new TextBox();
            lbPhone = new Label();
            SuspendLayout();
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbId.Location = new Point(20, 30);
            lbId.Name = "lbId";
            lbId.Size = new Size(93, 19);
            lbId.TabIndex = 23;
            lbId.Text = "Mã tài khoản:";
            // 
            // txbId
            // 
            txbId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbId.Location = new Point(153, 27);
            txbId.Name = "txbId";
            txbId.ReadOnly = true;
            txbId.Size = new Size(196, 25);
            txbId.TabIndex = 22;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbName.Location = new Point(153, 70);
            txbName.Name = "txbName";
            txbName.ReadOnly = true;
            txbName.Size = new Size(196, 25);
            txbName.TabIndex = 22;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbName.Location = new Point(20, 73);
            lbName.Name = "lbName";
            lbName.Size = new Size(54, 19);
            lbName.TabIndex = 23;
            lbName.Text = "Họ tên:";
            // 
            // txbPass
            // 
            txbPass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbPass.Location = new Point(153, 112);
            txbPass.Name = "txbPass";
            txbPass.ReadOnly = true;
            txbPass.Size = new Size(196, 25);
            txbPass.TabIndex = 22;
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbPass.Location = new Point(20, 115);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(71, 19);
            lbPass.TabIndex = 23;
            lbPass.Text = "Mật khẩu:";
            // 
            // txbPhanquyen
            // 
            txbPhanquyen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbPhanquyen.Location = new Point(153, 153);
            txbPhanquyen.Name = "txbPhanquyen";
            txbPhanquyen.ReadOnly = true;
            txbPhanquyen.Size = new Size(91, 25);
            txbPhanquyen.TabIndex = 22;
            // 
            // lbPhanquyen
            // 
            lbPhanquyen.AutoSize = true;
            lbPhanquyen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbPhanquyen.Location = new Point(20, 156);
            lbPhanquyen.Name = "lbPhanquyen";
            lbPhanquyen.Size = new Size(85, 19);
            lbPhanquyen.TabIndex = 23;
            lbPhanquyen.Text = "Phân quyền:";
            // 
            // txbCccd
            // 
            txbCccd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbCccd.Location = new Point(153, 193);
            txbCccd.Name = "txbCccd";
            txbCccd.ReadOnly = true;
            txbCccd.Size = new Size(196, 25);
            txbCccd.TabIndex = 22;
            // 
            // lbCccd
            // 
            lbCccd.AutoSize = true;
            lbCccd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbCccd.Location = new Point(20, 196);
            lbCccd.Name = "lbCccd";
            lbCccd.Size = new Size(83, 19);
            lbCccd.TabIndex = 23;
            lbCccd.Text = "CCCD/CMT:";
            // 
            // txbPhone
            // 
            txbPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbPhone.Location = new Point(153, 233);
            txbPhone.Name = "txbPhone";
            txbPhone.ReadOnly = true;
            txbPhone.Size = new Size(196, 25);
            txbPhone.TabIndex = 22;
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbPhone.Location = new Point(20, 236);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(92, 19);
            lbPhone.TabIndex = 23;
            lbPhone.Text = "Số điện thoại:";
            // 
            // FormViewInf
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(372, 289);
            Controls.Add(lbPhone);
            Controls.Add(lbCccd);
            Controls.Add(lbPhanquyen);
            Controls.Add(lbPass);
            Controls.Add(lbName);
            Controls.Add(lbId);
            Controls.Add(txbPhone);
            Controls.Add(txbCccd);
            Controls.Add(txbPhanquyen);
            Controls.Add(txbPass);
            Controls.Add(txbName);
            Controls.Add(txbId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormViewInf";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin tài khoản";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbId;
        private TextBox txbId;
        private TextBox txbName;
        private Label lbName;
        private TextBox txbPass;
        private Label lbPass;
        private TextBox txbPhanquyen;
        private Label lbPhanquyen;
        private TextBox txbCccd;
        private Label lbCccd;
        private TextBox txbPhone;
        private Label lbPhone;
    }
}