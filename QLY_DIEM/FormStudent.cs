
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
    public partial class FormStudent : Form
    {
        int i = 0;
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;

        public FormStudent(string ID)
        {
            InitializeComponent();
            txbId1.Text = ID;
            txbId2.Text = ID;
        }
        private void FormStudent_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);

            pnlKetqua.Hide();
            pnlInfStudent.Hide();
            hienthiInf();
            cbxHk.Text = "1";
            hienthiDiem();
        }

        public void hienthiInf()
        {
            lenh = @"SELECT * FROM dbo.tbl_Hocsinh WHERE mahs = " + txbId2.Text;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();

            txbNameStudent1.Text = docdulieu[1].ToString();
            txbNameStudent2.Text = docdulieu[1].ToString();
            txbSex1.Text = docdulieu[2].ToString();
            txbSex2.Text = docdulieu[2].ToString();
            dtpDate1.Text = docdulieu[3].ToString();
            dtpDate2.Text = docdulieu[3].ToString();
            txbCccd.Text = docdulieu[4].ToString();
            txbKhoahoc1.Text = docdulieu[5].ToString();
            txbKhoahoc2.Text = docdulieu[5].ToString();
            txbLop1.Text = docdulieu[6].ToString();
            txbLop2.Text = docdulieu[6].ToString();
            txbPhone.Text = docdulieu[7].ToString();
            txbQue2.Text = docdulieu[8].ToString();
            docdulieu.Close();
            ketnoi.Close();
        }

        public void hienthiCn()
        {
            lvCanam.Items.Clear();
            ketnoi.Open();
            string[] mon = listMon();

            i = 0;
            foreach (string x in mon)
            {
                lvCanam.Items.Add((i + 1).ToString());
                lvCanam.Items[i].SubItems.Add(x);

                lenh = @"SELECT diem FROM dbo.tbl_Diem " +
                        "WHERE mahs = " + txbId2.Text +
                        "AND loaidiem = 'tb' " +
                        "AND tenmon = N'" + x + "'";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                while (docdulieu.Read())
                {
                    lvCanam.Items[i].SubItems.Add(docdulieu[0].ToString());
                }
                docdulieu.Close();

                lenh = @"SELECT dtbmon, xlrl, xlhl, xlhv FROM dbo.tbl_ketqua" +
                        " WHERE mahs = " + txbId2.Text +
                        " AND kieudanhgia = 12";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                docdulieu.Read();

                txbTbcn.Text = docdulieu[0].ToString();
                txbRl.Text = docdulieu[1].ToString();
                txbHl.Text = docdulieu[2].ToString();
                txbHv.Text = docdulieu[3].ToString();
                docdulieu.Close();
                i++;
            }
            ketnoi.Close();
        }

        public void hienthiDiem()
        {
            lvPoint1.Items.Clear();
            ketnoi.Open();
            string[] mon = listMon();
            i = 0;
            foreach (string x in mon)
            {
                lvPoint1.Items.Add((i + 1).ToString());
                lvPoint1.Items[i].SubItems.Add(x);

                lenh = @"SELECT sotiet FROM dbo.tbl_Mon WHERE tenmon = N'" + x + "'";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                docdulieu.Read();
                lvPoint1.Items[i].SubItems.Add(docdulieu[0].ToString());
                docdulieu.Close();

                lenh = @"SELECT diem FROM dbo.tbl_Diem " +
                        "WHERE tenmon = N'" + x + "' " +
                        "AND mahs = " + txbId1.Text +
                        " AND hocky = " + cbxHk.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                while (docdulieu.Read())
                {
                    lvPoint1.Items[i].SubItems.Add(docdulieu[0].ToString());
                }
                docdulieu.Close();

                i++;
            }

            lenh = @"SELECT dtbmon, xlrl, xlhl FROM dbo.tbl_ketqua " +
                        "WHERE mahs = " + txbId1.Text +
                        " AND kieudanhgia = " + cbxHk.Text;
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            txbTbhk.Text = docdulieu[0].ToString();
            txbRl1.Text = docdulieu[1].ToString();
            txbHl1.Text = docdulieu[2].ToString();
            docdulieu.Close();
            ketnoi.Close();
        }

        public string[] listMon()
        {
            lenh = @"SELECT COUNT(DISTINCT tenmon) FROM tbl_Mon";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            int n = int.Parse(docdulieu[0].ToString());
            docdulieu.Close();

            lenh = @"SELECT tenmon FROM tbl_Mon";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();

            i = 0;
            string[] a = new string[n];
            while (docdulieu.Read())
            {
                a[i] = docdulieu[0].ToString();
                i++;
            }
            docdulieu.Close();

            return a;
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlInfStudent.Hide();
            pnlKetqua.Hide();
            hienthiDiem();
        }

        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlKetqua.Hide();
            pnlInfStudent.Show();
            hienthiInf();
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEdiStudent fEdiSttudent = new FormEdiStudent(txbId1.Text);
            fEdiSttudent.ShowDialog();
            hienthiInf();
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlInfStudent.Hide();
            pnlKetqua.Show();
            hienthiCn();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất chứ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormChangePass fChangePass = new FormChangePass(txbId1.Text);
            fChangePass.ShowDialog();
        }

        private void cbxHk_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthiDiem();
        }
    }
}
