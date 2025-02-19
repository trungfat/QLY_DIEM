using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_DIEM
{
    public partial class FormEditTeacher : Form
    {
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;

        public FormEditTeacher(string ID)
        {
            InitializeComponent();
            txbId.Text = ID;
        }

        private void FormEditTeacher_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);
            ketnoi.Open();
            lenh = @"SELECT hoten, mon, gioitinh FROM dbo.tbl_Giaovien WHERE magv = " + txbId.Text;
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            txbEditName.Text = docdulieu[0].ToString();
            txbEditMon.Text = docdulieu[1].ToString();
            cbxEditSex.Text = docdulieu[2].ToString();
            docdulieu.Close();
            ketnoi.Close();
        }

        public bool ktra()
        {
           if (txbEditCccd.Text != "")
           {
               if (txbEditQue.Text != "")
               {
                   if (txbEditPhone.Text != "")
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
                ulong z;
                bool a = ulong.TryParse(txbEditCccd.Text, out z);

                int cccd = z.ToString().Length;
                bool b = ulong.TryParse(txbEditPhone.Text, out z);

                int phone = z.ToString().Length;

                if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
                {
                    lenh = @"UPDATE dbo.tbl_Giaovien
                      SET ngaysinh = '" + dtpEditDate.Value.ToShortDateString() + "', "
                       + "cccd = '" + txbEditCccd.Text + "', "
                       + "sdt = '" + txbEditPhone.Text + "', "
                       + "email = '" + txbEditEmail.Text + "', "
                       + "quequan = N'" + txbEditQue.Text + "', "
                       + "diachilh = N'" + txbEditAddress.Text + "' "
                       + "WHERE magv = " + txbId.Text;
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
