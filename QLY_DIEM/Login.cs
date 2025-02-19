using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLY_DIEM
{
    public partial class Login : Form
    {
        string chuoi = new SQL().getChuoi();

        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);

        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbShow_MouseHover(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = false;
        }

        private void lbShow_MouseLeave(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = true;
        }


        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult clickbtnClose = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Gán sự kiện vào 1 biến để kiểm tra

            if (clickbtnClose != DialogResult.OK) // Kiểm tra lựa chọn 
            {
                e.Cancel = true; // Không cho phép đóng chương trình
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (tbxPassword.Text == "" || tbxUser.Text == "") // Kiểm tra xem người dùng đã nhập thông tin đăng nhập chưa
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int matk;
                bool a = int.TryParse(tbxUser.Text, out matk);
                if (a)
                {
                    string magv;
                    ketnoi.Open();
                    string lenh = @"SELECT magv FROM dbo.tbl_Giaovien WHERE magv = " + matk;
                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();
                    if (docdulieu.Read()) magv = docdulieu[0].ToString();
                    else magv = "";
                    docdulieu.Close();

                    lenh = @"SELECT phanquyen FROM dbo.tbl_Account WHERE matk = " + matk + " AND pass = '" + tbxPassword.Text + "'";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();

                    if (!docdulieu.Read())
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        this.Hide();
                        if ((docdulieu[0].ToString() == "GV" || docdulieu[0].ToString() == "AD") && cbxPhanquyen.Checked && magv != "")      // Kiểm tra người dùng là giáo viên hay học sinh
                        {
                            FormTeacher fTeacher = new FormTeacher(matk.ToString());
                            fTeacher.ShowDialog();
                        }
                        else if (docdulieu[0].ToString() == "HS" && !cbxPhanquyen.Checked)
                        {
                            FormStudent fStudent = new FormStudent(matk.ToString());
                            fStudent.ShowDialog();
                        }
                        else if (docdulieu[0].ToString() == "AD" && !cbxPhanquyen.Checked)
                        {
                            FormAdmin fAdmin = new FormAdmin();
                            fAdmin.ShowDialog();
                        }
                        else MessageBox.Show("Tài khoản của bạn không thuộc quyền này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Show();
                    }
                    docdulieu.Close();
                    ketnoi.Close();
                }
                else MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbShow_Click(object sender, EventArgs e)
        {

        }
    }
}