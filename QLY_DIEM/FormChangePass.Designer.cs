namespace QLY_DIEM
{
    partial class FormChangePass
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
            btnSave = new Button();
            lbOldPass = new Label();
            txbOldPass = new TextBox();
            lbNewPass = new Label();
            txbNewPass = new TextBox();
            lbConfirmPass = new Label();
            txbConfirmPass = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(132, 125);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbOldPass
            // 
            lbOldPass.AutoSize = true;
            lbOldPass.Location = new Point(18, 25);
            lbOldPass.Name = "lbOldPass";
            lbOldPass.Size = new Size(76, 15);
            lbOldPass.TabIndex = 1;
            lbOldPass.Text = "Mật khẩu cũ:";
            // 
            // txbOldPass
            // 
            txbOldPass.Location = new Point(160, 22);
            txbOldPass.Name = "txbOldPass";
            txbOldPass.Size = new Size(197, 23);
            txbOldPass.TabIndex = 2;
            txbOldPass.UseSystemPasswordChar = true;
            // 
            // lbNewPass
            // 
            lbNewPass.AutoSize = true;
            lbNewPass.Location = new Point(18, 54);
            lbNewPass.Name = "lbNewPass";
            lbNewPass.Size = new Size(84, 15);
            lbNewPass.TabIndex = 1;
            lbNewPass.Text = "Mật khẩu mới:";
            // 
            // txbNewPass
            // 
            txbNewPass.Location = new Point(160, 51);
            txbNewPass.Name = "txbNewPass";
            txbNewPass.Size = new Size(197, 23);
            txbNewPass.TabIndex = 2;
            txbNewPass.UseSystemPasswordChar = true;
            // 
            // lbConfirmPass
            // 
            lbConfirmPass.AutoSize = true;
            lbConfirmPass.Location = new Point(18, 83);
            lbConfirmPass.Name = "lbConfirmPass";
            lbConfirmPass.Size = new Size(136, 15);
            lbConfirmPass.TabIndex = 1;
            lbConfirmPass.Text = "Xác nhận mật khẩu mới:";
            // 
            // txbConfirmPass
            // 
            txbConfirmPass.Location = new Point(160, 80);
            txbConfirmPass.Name = "txbConfirmPass";
            txbConfirmPass.Size = new Size(197, 23);
            txbConfirmPass.TabIndex = 2;
            txbConfirmPass.UseSystemPasswordChar = true;
            // 
            // FormChangePass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(374, 166);
            Controls.Add(txbConfirmPass);
            Controls.Add(lbConfirmPass);
            Controls.Add(txbNewPass);
            Controls.Add(lbNewPass);
            Controls.Add(txbOldPass);
            Controls.Add(lbOldPass);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormChangePass";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            Load += FormChangePass_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label lbOldPass;
        private TextBox txbOldPass;
        private Label lbNewPass;
        private TextBox txbNewPass;
        private Label lbConfirmPass;
        private TextBox txbConfirmPass;
    }
}