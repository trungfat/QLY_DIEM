namespace QLY_DIEM
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLogin = new Panel();
            lblName = new Label();
            pnlControlLogin = new Panel();
            cbxPhanquyen = new CheckBox();
            btnOut = new Button();
            btnLogin = new Button();
            pnlPassword = new Panel();
            lbShow = new Label();
            lblPassword = new Label();
            tbxPassword = new TextBox();
            pnlUser = new Panel();
            lblUser = new Label();
            tbxUser = new TextBox();
            pnlLogin.SuspendLayout();
            pnlControlLogin.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlUser.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.SkyBlue;
            pnlLogin.Controls.Add(lblName);
            pnlLogin.Controls.Add(pnlControlLogin);
            pnlLogin.Controls.Add(pnlPassword);
            pnlLogin.Controls.Add(pnlUser);
            pnlLogin.Location = new Point(-1, 0);
            pnlLogin.Margin = new Padding(3, 4, 3, 4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(587, 312);
            pnlLogin.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(128, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(364, 46);
            lblName.TabIndex = 5;
            lblName.Text = "HỆ THỐNG ĐIỂM THPT";
            // 
            // pnlControlLogin
            // 
            pnlControlLogin.Controls.Add(cbxPhanquyen);
            pnlControlLogin.Controls.Add(btnOut);
            pnlControlLogin.Controls.Add(btnLogin);
            pnlControlLogin.Location = new Point(15, 217);
            pnlControlLogin.Margin = new Padding(3, 4, 3, 4);
            pnlControlLogin.Name = "pnlControlLogin";
            pnlControlLogin.Size = new Size(560, 85);
            pnlControlLogin.TabIndex = 4;
            // 
            // cbxPhanquyen
            // 
            cbxPhanquyen.AutoSize = true;
            cbxPhanquyen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbxPhanquyen.Location = new Point(6, 4);
            cbxPhanquyen.Margin = new Padding(3, 4, 3, 4);
            cbxPhanquyen.Name = "cbxPhanquyen";
            cbxPhanquyen.Size = new Size(180, 27);
            cbxPhanquyen.TabIndex = 3;
            cbxPhanquyen.Text = "Dành cho giáo viên";
            cbxPhanquyen.UseVisualStyleBackColor = true;
            // 
            // btnOut
            // 
            btnOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOut.Location = new Point(447, 19);
            btnOut.Margin = new Padding(3, 4, 3, 4);
            btnOut.Name = "btnOut";
            btnOut.Size = new Size(110, 52);
            btnOut.TabIndex = 2;
            btnOut.Text = "Thoát";
            btnOut.UseVisualStyleBackColor = true;
            btnOut.Click += btnOut_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(302, 19);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(110, 52);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlPassword
            // 
            pnlPassword.Controls.Add(lbShow);
            pnlPassword.Controls.Add(lblPassword);
            pnlPassword.Controls.Add(tbxPassword);
            pnlPassword.Location = new Point(15, 141);
            pnlPassword.Margin = new Padding(3, 4, 3, 4);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(560, 68);
            pnlPassword.TabIndex = 3;
            // 
            // lbShow
            // 
            lbShow.AutoSize = true;
            lbShow.BackColor = Color.White;
            lbShow.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbShow.Location = new Point(518, 20);
            lbShow.Name = "lbShow";
            lbShow.Size = new Size(33, 23);
            lbShow.TabIndex = 3;
            lbShow.Text = "👁️";
            lbShow.MouseLeave += lbShow_MouseLeave;
            lbShow.MouseHover += lbShow_MouseHover;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(6, 12);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(134, 37);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPassword.Location = new Point(197, 8);
            tbxPassword.Margin = new Padding(3, 4, 3, 4);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(359, 43);
            tbxPassword.TabIndex = 1;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // pnlUser
            // 
            pnlUser.AutoSize = true;
            pnlUser.Controls.Add(lblUser);
            pnlUser.Controls.Add(tbxUser);
            pnlUser.Location = new Point(15, 65);
            pnlUser.Margin = new Padding(3, 4, 3, 4);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(560, 71);
            pnlUser.TabIndex = 0;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.Location = new Point(6, 13);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(198, 37);
            lblUser.TabIndex = 2;
            lblUser.Text = "Tên đăng nhập:";
            // 
            // tbxUser
            // 
            tbxUser.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUser.Location = new Point(197, 9);
            tbxUser.Margin = new Padding(3, 4, 3, 4);
            tbxUser.Name = "tbxUser";
            tbxUser.Size = new Size(359, 43);
            tbxUser.TabIndex = 1;
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 312);
            Controls.Add(pnlLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlControlLogin.ResumeLayout(false);
            pnlControlLogin.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Panel pnlUser;
        private TextBox tbxUser;
        private Label lblUser;
        private Panel pnlPassword;
        private Label lblPassword;
        private TextBox tbxPassword;
        private Panel pnlControlLogin;
        private Button btnOut;
        private Button btnLogin;
        private Label lblName;
        private Label lbShow;
        private CheckBox cbxPhanquyen;
    }
}