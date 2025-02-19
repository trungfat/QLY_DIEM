using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QLY_DIEM
{
    public partial class FormTeacher : Form
    {
        int i = 0;
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;

        public FormTeacher(string ID)
        {
            InitializeComponent();
            txbIdTeacher.Text = ID;
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);

            pnlInfTeacher.Hide();
            hienthiTeacher();
            sobaiktra();
            cbxHocky.Text = "1";
            cbxLop.Text = "Tất cả";
            hienthiDiem();
        }

        private void cbxHocky_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthiDiem();
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthiDiem();
        }

        public void sobaiktra()
        {
            lenh = @"SELECT sobaihs1, sobaihs2 FROM dbo.tbl_Mon WHERE tenmon = N'" + txbMon1.Text + "'";
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            
            int hs1 = 0, hs2 = 0;
            bool x = int.TryParse(docdulieu[0].ToString(), out hs1);
            bool y = int.TryParse(docdulieu[1].ToString(), out hs2);

            if (hs1 == 0) 
            {
                txbPoint1_1.Hide();
                txbPoint1_2.Hide();
                txbPoint1_3.Hide();
                txbPoint1_4.Hide();
            }
            else if (hs1 == 2)
            {
                txbPoint1_3.Hide();
                txbPoint1_4.Hide();
            }
            else if (hs1 == 3)
            {
                txbPoint1_4.Hide();
            }

            if (hs2 == 0)
            {
                txbPoint2_1.Hide();
                txbPoint2_2.Hide();
                txbPoint2_3.Hide();
            }
            else if (hs2 == 1)
            {
                txbPoint2_2.Hide();
                txbPoint2_3.Hide();
            }
            else if (hs2 == 2)
            {
                txbPoint2_3.Hide();
            }
            docdulieu.Close();
            ketnoi.Close();
        }

        public void hienthiDiem()
        {
            lvPoint.Items.Clear();
            ketnoi.Open();
            string lop, hk;
            if (cbxLop.Text == "Tất cả") lop = "%";
            else lop = cbxLop.Text;

            if (cbxHocky.Text == "Cả năm") hk = "12";
            else hk = cbxHocky.Text;

            //Lấy số lượng mã học sinh theo lớp để tạo mảng
            int n;
            lenh = @"SELECT COUNT (DISTINCT mahs) FROM dbo.tbl_Hocsinh WHERE lop LIKE '" + lop + "'";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            n = int.Parse(docdulieu[0].ToString());
            docdulieu.Close();

            //Lấy dữ liệu mã học sinh và họ tên ra bảng đồng thời dùng mảng lưu trữ mã học sinh theo lớp
            string[] mahs = new string[n];
            lenh = @"SELECT mahs, hoten FROM dbo.tbl_Hocsinh WHERE lop LIKE '" + lop + "'";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvPoint.Items.Add((i + 1).ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[1].ToString());
                mahs[i] = docdulieu[0].ToString();
                i++;
            }
            docdulieu.Close();

            //Xuất thông tin điểm của từng học sinh thoe lớp và mã học sinh trùng với phần tử trong mảng mã học sinh để tránh lặp dữ liệu
            i = 0;
            foreach (string x in mahs)
            {
                lenh = @"SELECT dbo.tbl_Diem.mahs, hoten, diem FROM dbo.tbl_Diem, dbo.tbl_Hocsinh
                         WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs" +
                           " AND dbo.tbl_Diem.mahs = " + x +
                           " AND lop LIKE '" + lop + "' " +
                           "AND tenmon = N'" + txbMon1.Text + "' " +
                           "AND hocky = " + hk;
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                while (docdulieu.Read())
                {
                    lvPoint.Items[i].SubItems.Add(docdulieu[2].ToString());
                }
                docdulieu.Close();
                i++;
            }
            ketnoi.Close();


            btnSave1.Enabled = false;
            btnTinh.Enabled = false;

            txbIdStudent.Text = "";
            txbNameStudent.Text = "";
            txbPoint1_1.Text = "";
            txbPoint1_2.Text = "";
            txbPoint1_3.Text = "";
            txbPoint1_4.Text = "";
            txbPoint2_1.Text = "";
            txbPoint2_2.Text = "";
            txbPoint2_3.Text = "";
            txbPoint3_1.Text = "";
            txbTb.Text = "";
        }

        public void hienthiTeacher()
        {
            lenh = @"SELECT * FROM dbo.tbl_Giaovien WHERE magv = " + txbIdTeacher.Text;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();

            txbMon1.Text = docdulieu[5].ToString();
            txbNameTeacher.Text = docdulieu[1].ToString();
            cbxSex.Text = docdulieu[2].ToString();
            dtpDateTeacher.Text = docdulieu[3].ToString();
            txbCccd.Text = docdulieu[4].ToString();
            txbMon2.Text = docdulieu[5].ToString();
            txbPhoneTeacher.Text = docdulieu[6].ToString();
            txbEmail.Text = docdulieu[7].ToString();
            txbQue.Text = docdulieu[8].ToString();
            txbAddressTeacher.Text = docdulieu[9].ToString();
            docdulieu.Close();
            ketnoi.Close();
        }

        //Lựa chọn dòng trong bảng
        private void lvPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPoint.SelectedItems.Count > 0)
            {
                txbIdStudent.Text = lvPoint.SelectedItems[0].SubItems[1].Text;
                txbNameStudent.Text = lvPoint.SelectedItems[0].SubItems[2].Text;
                txbPoint1_1.Text = lvPoint.SelectedItems[0].SubItems[3].Text;
                txbPoint1_2.Text = lvPoint.SelectedItems[0].SubItems[4].Text;
                txbPoint1_3.Text = lvPoint.SelectedItems[0].SubItems[5].Text;
                txbPoint1_4.Text = lvPoint.SelectedItems[0].SubItems[6].Text;
                txbPoint2_1.Text = lvPoint.SelectedItems[0].SubItems[7].Text;
                txbPoint2_2.Text = lvPoint.SelectedItems[0].SubItems[8].Text;
                txbPoint2_3.Text = lvPoint.SelectedItems[0].SubItems[9].Text;
                txbPoint3_1.Text = lvPoint.SelectedItems[0].SubItems[10].Text;
                txbTb.Text = lvPoint.SelectedItems[0].SubItems[11].Text;


                btnSave1.Enabled = true;
                btnTinh.Enabled = true;
            }
            else
            {

                btnSave1.Enabled = false;
                btnTinh.Enabled = false;

                txbIdStudent.Text = "";
                txbNameStudent.Text = "";
                txbPoint1_1.Text = "";
                txbPoint1_2.Text = "";
                txbPoint1_3.Text = "";
                txbPoint1_4.Text = "";
                txbPoint2_1.Text = "";
                txbPoint2_2.Text = "";
                txbPoint2_3.Text = "";
                txbPoint3_1.Text = "";
                txbTb.Text = "";
            }
        }

        public float tinh()
        {

            if (txbPoint1_1.Text == "") txbPoint1_1.Text = "0";
            if (txbPoint1_2.Text == "") txbPoint1_2.Text = "0";
            if (txbPoint1_3.Text == "") txbPoint1_3.Text = "0";
            if (txbPoint1_4.Text == "") txbPoint1_4.Text = "0";
            if (txbPoint2_1.Text == "") txbPoint2_1.Text = "0";
            if (txbPoint2_2.Text == "") txbPoint2_2.Text = "0";
            if (txbPoint2_3.Text == "") txbPoint2_3.Text = "0";
            if (txbPoint3_1.Text == "") txbPoint3_1.Text = "0";

            if (ktraDiem())
            {
                lenh = @"SELECT sobaihs1, sobaihs2 FROM dbo.tbl_Mon WHERE tenmon = N'" + txbMon1.Text + "'";

                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                docdulieu.Read();

                int hs1 = 0, hs2 = 0;
                bool x = int.TryParse(docdulieu[0].ToString(), out hs1);
                bool y = int.TryParse(docdulieu[1].ToString(), out hs2);

                docdulieu.Close();

                float tdhs1 = float.Parse(txbPoint1_1.Text) + float.Parse(txbPoint1_2.Text) + float.Parse(txbPoint1_3.Text) + float.Parse(txbPoint1_4.Text);
                float tdhs2 = 2 * (float.Parse(txbPoint2_1.Text) + float.Parse(txbPoint2_2.Text) + float.Parse(txbPoint2_3.Text));
                float tdhk = tdhs1 + tdhs2 + 3 * float.Parse(txbPoint3_1.Text);
                float tbhk = (float)tdhk / (hs1 + 2 * hs2 + 3);
                //Lấy sau dấu phẩy 1 chữ số

                tbhk = (float)Math.Round(tbhk, 1);
                return tbhk;
            }
            else MessageBox.Show("Sai định dạng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }

        public bool ktraDiem()
        {
            if (float.Parse(txbPoint1_1.Text) >= 0 && float.Parse(txbPoint1_1.Text) < 11)
            {
                if (float.Parse(txbPoint1_2.Text) >= 0 && float.Parse(txbPoint1_2.Text) < 11)
                {
                    if (float.Parse(txbPoint1_3.Text) >= 0 && float.Parse(txbPoint1_3.Text) < 11)
                    {
                        if (float.Parse(txbPoint1_4.Text) >= 0 && float.Parse(txbPoint1_4.Text) < 11)
                        {
                            if (float.Parse(txbPoint2_1.Text) >= 0 && float.Parse(txbPoint2_1.Text) < 11)
                            {
                                if (float.Parse(txbPoint2_2.Text) >= 0 && float.Parse(txbPoint2_2.Text) < 11)
                                {
                                    if (float.Parse(txbPoint2_3.Text) >= 0 && float.Parse(txbPoint2_3.Text) < 11)
                                    {
                                        if (float.Parse(txbPoint3_1.Text) >= 0 && float.Parse(txbPoint3_1.Text) < 11) return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            txbTb.Text = tinh().ToString();
            ketnoi.Close();
        }



        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (txbPoint1_1.Text == "") txbPoint1_1.Text = "0";
            if (txbPoint1_2.Text == "") txbPoint1_2.Text = "0";
            if (txbPoint1_3.Text == "") txbPoint1_3.Text = "0";
            if (txbPoint1_4.Text == "") txbPoint1_4.Text = "0";
            if (txbPoint2_1.Text == "") txbPoint2_1.Text = "0";
            if (txbPoint2_2.Text == "") txbPoint2_2.Text = "0";
            if (txbPoint2_3.Text == "") txbPoint2_3.Text = "0";
            if (txbPoint3_1.Text == "") txbPoint3_1.Text = "0";

            if (ktraDiem())
            {
                ketnoi.Open();
                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint1_1.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '15p1'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint1_2.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '15p2'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint1_3.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '15p3'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint1_4.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '15p4'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint2_1.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '1t1'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint2_2.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '1t2'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint2_3.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = '1t3'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbPoint3_1.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = 'hk'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                txbTb.Text = tinh().ToString();
                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + txbTb.Text +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = " + cbxHocky.Text +
                          " AND loaidiem = 'tb'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                float hk1, hk2;
                lenh = @"SELECT diem FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = 1" +
                          " AND loaidiem = 'tb'";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                docdulieu.Read();
                if (docdulieu[0].ToString() != "") hk1 = float.Parse(docdulieu[0].ToString());
                else hk1 = 0;
                docdulieu.Close();

                lenh = @"SELECT diem FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = 2" +
                          " AND loaidiem = 'tb'";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                docdulieu.Read();
                if (docdulieu[0].ToString() != "") hk2 = float.Parse(docdulieu[0].ToString());
                else hk2 = 0;
                docdulieu.Close();

                float tbcn = (hk1 + 2 * hk2) / 3;
                tbcn = (float)Math.Round(tbcn, 1);

                lenh = @"UPDATE dbo.tbl_Diem
                        SET diem = " + tbcn +
                          " WHERE mahs = " + txbIdStudent.Text +
                          " AND tenmon = N'" + txbMon1.Text + "' " +
                          " AND hocky = 12" +
                          " AND loaidiem = 'tb'";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                ketnoi.Close();
                hienthiDiem();
            }
            else MessageBox.Show("Sai định dạng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string lop, hk;
            if (cbxLop.Text == "Tất cả") lop = "%";
            else lop = cbxLop.Text;

            if (cbxHocky.Text == "Cả năm") hk = "12";
            else hk = cbxHocky.Text;

            lvPoint.Items.Clear();
            ketnoi.Open();

            //Lấy số lượng mã học sinh theo lớp để tạo mảng
            int n;
            lenh = @"SELECT COUNT (DISTINCT mahs) FROM dbo.tbl_Hocsinh WHERE lop LIKE '" + lop + "' " +
                                "AND (mahs LIKE '%" + txbSearch.Text + "%' " +
                                "OR hoten LIKE '%" + txbSearch.Text + "%')";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            n = int.Parse(docdulieu[0].ToString());
            docdulieu.Close();

            //Lấy dữ liệu mã học sinh và họ tên ra bảng đồng thời dùng mảng lưu trữ mã học sinh theo lớp
            string[] mahs = new string[n];
            lenh = @"SELECT mahs, hoten FROM dbo.tbl_Hocsinh
                     WHERE lop LIKE '" + lop + "' " +
                      "AND (mahs LIKE '%" + txbSearch.Text + "%' " +
                      "OR hoten LIKE '%" + txbSearch.Text + "%')";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvPoint.Items.Add((i + 1).ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[1].ToString());
                mahs[i] = docdulieu[0].ToString();
                i++;
            }
            docdulieu.Close();

            //Xuất thông tin điểm của từng học sinh thoe lớp và mã học sinh trùng với phần tử trong mảng mã học sinh để tránh lặp dữ liệu
            i = 0;
            foreach (string x in mahs)
            {
                lenh = @"SELECT dbo.tbl_Diem.mahs, hoten, diem FROM dbo.tbl_Diem, dbo.tbl_Hocsinh
                         WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs" +
                           " AND dbo.tbl_Diem.mahs = " + x +
                           " AND lop LIKE '" + lop + "' " +
                           "AND tenmon = N'" + txbMon1.Text + "' " +
                           "AND hocky = " + hk;
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                while (docdulieu.Read())
                {
                    lvPoint.Items[i].SubItems.Add(docdulieu[2].ToString());
                }
                docdulieu.Close();
                i++;
            }
            ketnoi.Close();


            btnSave1.Enabled = false;
            btnTinh.Enabled = false;

            txbIdStudent.Text = "";
            txbNameStudent.Text = "";
            txbPoint1_1.Text = "";
            txbPoint1_2.Text = "";
            txbPoint1_3.Text = "";
            txbPoint1_4.Text = "";
            txbPoint2_1.Text = "";
            txbPoint2_2.Text = "";
            txbPoint2_3.Text = "";
            txbPoint3_1.Text = "";
            txbTb.Text = "";
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            hienthiDiem();
        }


        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pnlInfTeacher.Hide();
            hienthiDiem();
        }

        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pnlInfTeacher.Show();
            hienthiTeacher();
        }

        private void chỉnhSửaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditTeacher fEditTeacher = new FormEditTeacher(txbIdTeacher.Text);
            fEditTeacher.ShowDialog();
            hienthiTeacher();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất chứ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đổiMậtkhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass fChangePass = new FormChangePass(txbIdTeacher.Text);
            fChangePass.ShowDialog();
        }

        private void btnExportPoint_Click(object sender, EventArgs e)
        {
            string hk;
            if (cbxHocky.Text == "1") hk = "I";
            else hk = "II";

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            //in tên bảng
            Excel.Range exPoint = (Excel.Range)exSheet.Cells[1, 1];
            exPoint.Font.Size = 15;
            exPoint.Font.Bold = true;
            exPoint.Value = "BẢNG ĐIỂM MÔN " + txbMon1.Text.ToUpper() + " HỌC KỲ " + hk;
            exSheet.Range["A1:E1"].MergeCells = true;
            exSheet.Range["A1:E1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A1:E1"].Font.Name = "Times New Roman";

            //in tên lớp
            Excel.Range exTeacher = (Excel.Range)exSheet.Cells[3, 1];
            exTeacher.Font.Size = 15;
            exTeacher.Font.Bold = true;
            exTeacher.Value = "Lớp: " + cbxLop.Text;
            exSheet.Range["A3:B3"].MergeCells = true;
            exSheet.Range["A3:B3"].Font.Name = "Times New Roman";

            //In tiêu đề
            exSheet.Range["A4:L4"].Font.Size = 12;
            exSheet.Range["A4:L4"].Font.Bold = true;
            exSheet.Range["A4:L4"].Borders.LineStyle = Excel.Constants.xlSolid;
            exSheet.Range["A4:L4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A4:L4"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            exSheet.Range["A4:L4"].Interior.Color = Color.LightSkyBlue;
            exSheet.Range["A4:L4"].Font.Name = "Times New Roman";
            exSheet.Range["A4:L4"].WrapText = true;
            exSheet.Range["A4:L4"].RowHeight = 33;

            exSheet.Range["A4"].Value = "STT";
            exSheet.Range["A4"].ColumnWidth = 5;

            exSheet.Range["B4"].Value = "Mã học sinh";
            exSheet.Range["B4"].ColumnWidth = 14;

            exSheet.Range["C4"].Value = "Họ tên";
            exSheet.Range["C4"].ColumnWidth = 20;

            exSheet.Range["D4"].Value = "Hệ số 1";
            exSheet.Range["D4"].ColumnWidth = 5;

            exSheet.Range["H4"].Value = "Hệ số 2";
            exSheet.Range["H4"].ColumnWidth = 5;

            exSheet.Range["K4"].Value = "Học kỳ";
            exSheet.Range["K4"].ColumnWidth = 5;

            exSheet.Range["L4"].Value = "Tổng kết";
            exSheet.Range["L4"].ColumnWidth = 6;

            exSheet.Range["D4:G4"].MergeCells = true;
            exSheet.Range["H4:J4"].MergeCells = true;
            //In nội dung
            int dong = 5;
            for (int i = 0; i < lvPoint.Items.Count; i++)
            {
                string dongs = (dong + i).ToString();
                exSheet.Range["A" + dongs].Value = lvPoint.Items[i].SubItems[0].Text;
                exSheet.Range["B" + dongs].Value = lvPoint.Items[i].SubItems[1].Text;
                exSheet.Range["C" + dongs].Value = lvPoint.Items[i].SubItems[2].Text;
                exSheet.Range["D" + dongs].Value = lvPoint.Items[i].SubItems[3].Text;
                exSheet.Range["E" + dongs].Value = lvPoint.Items[i].SubItems[4].Text;
                exSheet.Range["F" + dongs].Value = lvPoint.Items[i].SubItems[5].Text;
                exSheet.Range["G" + dongs].Value = lvPoint.Items[i].SubItems[6].Text;
                exSheet.Range["H" + dongs].Value = lvPoint.Items[i].SubItems[7].Text;
                exSheet.Range["I" + dongs].Value = lvPoint.Items[i].SubItems[8].Text;
                exSheet.Range["J" + dongs].Value = lvPoint.Items[i].SubItems[9].Text;
                exSheet.Range["K" + dongs].Value = lvPoint.Items[i].SubItems[10].Text;
                exSheet.Range["L" + dongs].Value = lvPoint.Items[i].SubItems[11].Text;

                exSheet.Range["A" + dongs + ":" + "L" + dongs].Borders.LineStyle = Excel.Constants.xlSolid;
                exSheet.Range["A" + dongs + ":" + "B" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["D" + dongs + ":" + "L" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["A" + dongs + ":" + "L" + dongs].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                exSheet.Range["A" + dongs + ":" + "L" + dongs].WrapText = true;
                exSheet.Range["A" + dongs + ":" + "L" + dongs].Font.Name = "Times New Roman";
            }

            //xuat file
            exSheet.Name = "bang_diem_mon";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel|*.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName);
            }
            exApp.Quit();
        }
    }
}
