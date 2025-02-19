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
    public partial class FormEdiStudent : Form
    {
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;

        public FormEdiStudent(string ID)
        {
            InitializeComponent();
            txbId.Text = ID;
        }

        private void FormEdiStudent_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);
            lenh = @"SELECT hoten, gioitinh, lop, khoahoc FROM dbo.tbl_Hocsinh WHERE mahs = " + txbId.Text;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            txbEditName.Text = docdulieu[0].ToString();
            cbxEditSex.Text = docdulieu[1].ToString();
            txbEditLop.Text = docdulieu[2].ToString();
            txbEditKhoahoc.Text = docdulieu[3].ToString();
            ketnoi.Close();
        }

        public bool ktra()
        {
            if (txbEditQue.Text != "")
            {
                if (txbEditPhone.Text != "")
                {
                    return true;
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
                ulong z;
                bool a = ulong.TryParse(txbEditCccd.Text, out z);

                int cccd = z.ToString().Length;
                bool b = ulong.TryParse(txbEditPhone.Text, out z);

                int phone = z.ToString().Length;

                if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
                {
                    lenh = @"UPDATE dbo.tbl_Hocsinh
                        SET ngaysinh = '" + dtpEditDate.Value.ToShortDateString() + "', "
                         + "cccd = '" + txbEditCccd.Text + "', "
                         + "sdt = '" + txbEditPhone.Text + "', "
                         + "quequan = N'" + txbEditQue.Text + "'"
                         + "WHERE mahs = " + txbId.Text;
                    ketnoi.Open();
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();
                    ketnoi.Close();
                    this.Close();
                }
                else MessageBox.Show("Sai định dạng số điện thoại hoặc CCCD/CMT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
