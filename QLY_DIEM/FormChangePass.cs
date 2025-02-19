using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_DIEM
{
    public partial class FormChangePass : Form
    {
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;
        string matk, pass;

        public FormChangePass(string ID)
        {
            InitializeComponent();
            matk = ID;
        }

        private void FormChangePass_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);
            lenh = @"SELECT pass FROM dbo.tbl_Account WHERE matk = " + matk;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            pass = docdulieu[0].ToString();
            ketnoi.Close();
        }

        public bool ktra()
        {
            if (txbOldPass.Text != "")
            {
                if (txbNewPass.Text != "")
                {
                    if (txbConfirmPass.Text != "")
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ktra())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (txbNewPass.Text == txbConfirmPass.Text && txbOldPass.Text == pass)
                {
                    lenh = @"UPDATE dbo.tbl_Account 
                             SET pass = '" + txbConfirmPass.Text + "'"
                             + "WHERE matk = " + matk;
                    ketnoi.Open();
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();
                    ketnoi.Close();
                    this.Close();
                }
                else MessageBox.Show("Mật khẩu sai!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
