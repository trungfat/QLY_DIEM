using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLY_DIEM
{
    public partial class FormAdmin : Form
    {
        int i = 0;
        string lenh;
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;
        string matk;

        public FormAdmin()
        {
            InitializeComponent();
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoi);
            cbxLop1.Text = "Tất cả";
            cbxHocky.Text = "1";
            cbxLop2.Text = "Tất cả";

            hienthiStudent();
            hienthiTeacher();
            hienthiAccount();
            hienthiMon();
        }

        //Phần hiển thị
        public void hienthiStudent()
        {
            lvStudent.Items.Clear();
            ketnoi.Open();
            lenh = @"SELECT * FROM dbo.tbl_Hocsinh";


            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                DateTimePicker dtpAdd = new DateTimePicker();
                dtpAdd.Text = docdulieu[3].ToString();
                lvStudent.Items.Add((i + 1).ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvStudent.Items[i].SubItems.Add(dtpAdd.Value.ToShortDateString());
                lvStudent.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[6].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[5].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[7].ToString());
                lvStudent.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();

            btnSave1.Enabled = false;
            btnDelete1.Enabled = false;
            btnAdd1.Enabled = true;
            txbIdStudent.Text = "";
            txbNameStudent.Text = "";
            txbCccdStudent.Text = "";
            dtpDateStudent.Value = DateTime.Now;
            cbxSexStudent.Text = " ";
            cbxLop1.Text = " ";
            txbKhoahoc.Text = "";
            txbPhoneStudent.Text = "";
            txbQueStudent.Text = "";
        }

        private void cbxLop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthiDiem();
        }

        private void cbxHocky_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthiDiem();
        }

        public void hienthiDiem()
        {
            string lop, hk;

            if (cbxLop2.Text != "Tất cả") lop = cbxLop2.Text;
            else lop = "%";

            if (cbxHocky.Text == "Cả năm") hk = "12";
            else hk = cbxHocky.Text;

            lvPoint.Items.Clear();
            ketnoi.Open();
            lenh = @"SELECT dbo.tbl_Hocsinh.mahs, hoten, diem FROM dbo.tbl_Hocsinh, dbo.tbl_Diem
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs AND loaidiem = 'tb' AND tenmon = N'Công nghệ'" +
                      " AND hocky = " + hk +
                      " AND lop like '" + lop + "'";

            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();

            i = 0;
            while (docdulieu.Read())
            {
                lvPoint.Items.Add((i + 1).ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[2].ToString());
                i++;
            }
            docdulieu.Close();

            string[] a = listMon();

            foreach (string x in a)
            {
                if (x == "Công nghệ") continue;
                lenh = @"SELECT diem FROM dbo.tbl_Hocsinh, dbo.tbl_Diem
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs AND loaidiem = 'tb' AND tenmon = N'" + x + "'" +
                     " AND hocky = " + hk +
                     " AND lop like '" + lop + "'";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                i = 0;
                while (docdulieu.Read())
                {
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    i++;
                }
                docdulieu.Close();
            }

            lenh = @"SELECT dtbmon, xlrl, xlhl, xlhv FROM dbo.tbl_Hocsinh, dbo.tbl_ketqua
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_ketqua.mahs AND kieudanhgia = " + hk + " AND lop like '" + lop + "'";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvPoint.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            docdulieu.Close();

            ketnoi.Close();

            btnSave2.Enabled = false;
            btnDelete2.Enabled = false;

            txbIdStudent2.Text = "";
            txbNameStudent2.Text = "";
            txbCn.Text = "";
            txbDia.Text = "";
            txbGdcd.Text = "";
            txbHoa.Text = "";
            txbSu.Text = "";
            txbVan.Text = "";
            txbSinh.Text = "";
            txbTd.Text = "";
            txbAnh.Text = "";
            txbTin.Text = "";
            txbToan.Text = "";
            txbLy.Text = "";
            txbTbmon.Text = "";
            cbxRl.Text = " ";
            txbXlhl.Text = "";
            txbXlhv.Text = "";
        }

        public void hienthiTeacher()
        {
            lvTeacher.Items.Clear();
            lenh = @"SELECT * FROM dbo.tbl_Giaovien";
            ketnoi.Open();

            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                DateTimePicker dtpAdd = new DateTimePicker();
                dtpAdd.Text = docdulieu[3].ToString();
                lvTeacher.Items.Add((i + 1).ToString());

                lvTeacher.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvTeacher.Items[i].SubItems.Add(dtpAdd.Value.ToShortDateString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[5].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[6].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[7].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[8].ToString());
                lvTeacher.Items[i].SubItems.Add(docdulieu[9].ToString());
                i++;
            }
            ketnoi.Close();

            btnSave3.Enabled = false;
            btnAdd3.Enabled = true;
            btnDelete3.Enabled = false;

            txbIdTeacher.Text = "";
            txbNameTeacher.Text = "";
            txbCccdTeacher.Text = "";
            dtpDateTeacher.Value = DateTime.Now;
            cbxSexTeacher.Text = " ";
            cbxMon.Text = "";
            txbEmail.Text = "";
            txbPhoneTeacher.Text = "";
            txbQueTeacher.Text = "";
            txbAddressTeacher.Text = "";
        }

        private void rdStudent_CheckedChanged(object sender, EventArgs e)
        {
            hienthiAccount();
        }

        public void hienthiAccount()
        {
            lvAccount.Items.Clear();
            if (rdStudent.Checked)
            {
                lenh = @"SELECT matk, hoten, phanquyen FROM dbo.tbl_Account, dbo.tbl_Hocsinh
                         WHERE dbo.tbl_Hocsinh.mahs = matk";
            }
            else
            {
                lenh = @"SELECT matk, hoten, phanquyen FROM dbo.tbl_Account, dbo.tbl_Giaovien
                         WHERE dbo.tbl_Giaovien.magv = matk";
            }
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvAccount.Items.Add((i + 1).ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[2].ToString());
                i++;
            }
            ketnoi.Close();

            btnSave4.Enabled = false;
            btnView.Enabled = false;
            btnDelete4.Enabled = false;
            btnReset.Enabled = false;
            matk = "";
            cbxPhanquyen.Text = " ";
        }

        public void hienthiMon()
        {
            lvMon.Items.Clear();
            ketnoi.Open();
            lenh = @"SELECT *, sobaihs2 FROM dbo.tbl_Mon";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;

            while (docdulieu.Read())
            {
                lvMon.Items.Add((i + 1).ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();

            btnSave5.Enabled = false;
            txbMonhoc.Text = "";
            cbxSotiet.Text = " ";
            cbxHs1.Text = " ";
            cbxHs2.Text = " ";
        }

        //Phần lựa chọn theo dòng
        private void lvStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudent.SelectedItems.Count > 0)
            {
                txbIdStudent.Text = lvStudent.SelectedItems[0].SubItems[1].Text;
                txbNameStudent.Text = lvStudent.SelectedItems[0].SubItems[2].Text;
                txbCccdStudent.Text = lvStudent.SelectedItems[0].SubItems[3].Text;
                dtpDateStudent.Text = lvStudent.SelectedItems[0].SubItems[4].Text;
                cbxSexStudent.Text = lvStudent.SelectedItems[0].SubItems[5].Text;
                cbxLop1.Text = lvStudent.SelectedItems[0].SubItems[6].Text;
                txbKhoahoc.Text = lvStudent.SelectedItems[0].SubItems[7].Text;
                txbPhoneStudent.Text = lvStudent.SelectedItems[0].SubItems[8].Text;
                txbQueStudent.Text = lvStudent.SelectedItems[0].SubItems[9].Text;
                btnDelete1.Enabled = true;
                btnAdd1.Enabled = false;
                btnSave1.Enabled = true;
            }
            else
            {
                btnSave1.Enabled = false;
                btnDelete1.Enabled = false;
                btnAdd1.Enabled = true;
                txbIdStudent.Text = "";
                txbNameStudent.Text = "";
                txbCccdStudent.Text = "";
                dtpDateStudent.Value = DateTime.Now;
                cbxSexStudent.Text = " ";
                cbxLop1.Text = " ";
                txbKhoahoc.Text = "";
                txbPhoneStudent.Text = "";
                txbQueStudent.Text = "";
            }
        }

        private void lvPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLop2.Text != "")
            {
                if (lvPoint.SelectedItems.Count > 0)
                {
                    txbIdStudent2.Text = lvPoint.SelectedItems[0].SubItems[1].Text;
                    txbNameStudent2.Text = lvPoint.SelectedItems[0].SubItems[2].Text;
                    txbCn.Text = lvPoint.SelectedItems[0].SubItems[3].Text;
                    txbDia.Text = lvPoint.SelectedItems[0].SubItems[4].Text;
                    txbGdcd.Text = lvPoint.SelectedItems[0].SubItems[5].Text;
                    txbHoa.Text = lvPoint.SelectedItems[0].SubItems[6].Text;
                    txbSu.Text = lvPoint.SelectedItems[0].SubItems[7].Text;
                    txbVan.Text = lvPoint.SelectedItems[0].SubItems[8].Text;
                    txbSinh.Text = lvPoint.SelectedItems[0].SubItems[9].Text;
                    txbTd.Text = lvPoint.SelectedItems[0].SubItems[10].Text;
                    txbAnh.Text = lvPoint.SelectedItems[0].SubItems[11].Text;
                    txbTin.Text = lvPoint.SelectedItems[0].SubItems[12].Text;
                    txbToan.Text = lvPoint.SelectedItems[0].SubItems[13].Text;
                    txbLy.Text = lvPoint.SelectedItems[0].SubItems[14].Text;
                    txbTbmon.Text = lvPoint.SelectedItems[0].SubItems[15].Text;
                    cbxRl.Text = lvPoint.SelectedItems[0].SubItems[16].Text;
                    txbXlhl.Text = lvPoint.SelectedItems[0].SubItems[17].Text;
                    txbXlhv.Text = lvPoint.SelectedItems[0].SubItems[18].Text;

                    btnDelete2.Enabled = true;
                    btnSave2.Enabled = true;
                }
                else
                {
                    btnSave2.Enabled = false;
                    btnDelete2.Enabled = false;

                    txbIdStudent2.Text = "";
                    txbNameStudent2.Text = "";
                    txbCn.Text = "";
                    txbDia.Text = "";
                    txbGdcd.Text = "";
                    txbHoa.Text = "";
                    txbSu.Text = "";
                    txbVan.Text = "";
                    txbSinh.Text = "";
                    txbTd.Text = "";
                    txbAnh.Text = "";
                    txbTin.Text = "";
                    txbToan.Text = "";
                    txbLy.Text = "";
                    txbTbmon.Text = "";
                    cbxRl.Text = " ";
                    txbXlhl.Text = "";
                    txbXlhv.Text = "";
                }
            }
            else MessageBox.Show("Vui lòng chọn lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lvTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTeacher.SelectedItems.Count > 0)
            {
                txbIdTeacher.Text = lvTeacher.SelectedItems[0].SubItems[1].Text;
                txbNameTeacher.Text = lvTeacher.SelectedItems[0].SubItems[2].Text;
                txbCccdTeacher.Text = lvTeacher.SelectedItems[0].SubItems[3].Text;
                cbxSexTeacher.Text = lvTeacher.SelectedItems[0].SubItems[4].Text;
                dtpDateTeacher.Text = lvTeacher.SelectedItems[0].SubItems[5].Text;
                cbxMon.Text = lvTeacher.SelectedItems[0].SubItems[6].Text;
                txbPhoneTeacher.Text = lvTeacher.SelectedItems[0].SubItems[7].Text;
                txbEmail.Text = lvTeacher.SelectedItems[0].SubItems[8].Text;
                txbQueTeacher.Text = lvTeacher.SelectedItems[0].SubItems[9].Text;
                txbAddressTeacher.Text = lvTeacher.SelectedItems[0].SubItems[10].Text;
                btnDelete3.Enabled = true;
                btnAdd3.Enabled = false;
                btnSave3.Enabled = true;
            }
            else
            {
                btnSave3.Enabled = false;
                btnAdd3.Enabled = true;
                btnDelete3.Enabled = false;
                txbIdTeacher.Text = "";
                txbNameTeacher.Text = "";
                txbCccdTeacher.Text = "";
                dtpDateTeacher.Value = DateTime.Now;
                cbxSexTeacher.Text = " ";
                cbxMon.Text = "";
                txbEmail.Text = "";
                txbPhoneTeacher.Text = "";
                txbQueTeacher.Text = "";
                txbAddressTeacher.Text = "";
            }
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0)
            {
                matk = lvAccount.SelectedItems[0].SubItems[1].Text;
                cbxPhanquyen.Text = lvAccount.SelectedItems[0].SubItems[3].Text;
                btnView.Enabled = true;
                btnDelete4.Enabled = true;
                btnReset.Enabled = true;
                btnSave4.Enabled = true;
            }
            else
            {
                btnSave4.Enabled = false;
                btnView.Enabled = false;
                btnDelete4.Enabled = false;
                btnReset.Enabled = false;
                matk = "";
                cbxPhanquyen.Text = " ";
            }
        }

        private void lvMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count > 0)
            {
                txbMonhoc.Text = lvMon.SelectedItems[0].SubItems[1].Text;
                cbxSotiet.Text = lvMon.SelectedItems[0].SubItems[2].Text;
                cbxHs1.Text = lvMon.SelectedItems[0].SubItems[3].Text;
                cbxHs2.Text = lvMon.SelectedItems[0].SubItems[4].Text;

                btnSave5.Enabled = true;
            }
            else
            {
                btnSave5.Enabled = false;

                txbMonhoc.Text = "";
                cbxSotiet.Text = " ";
                cbxHs1.Text = " ";
                cbxHs2.Text = " ";
            }
        }

        //Xem thong tin tài khoản
        private void btnView_Click(object sender, EventArgs e)
        {
            if (rdStudent.Checked)
            {
                lenh = @"SELECT matk, hoten, cccd, sdt, pass, phanquyen FROM dbo.tbl_Account,dbo.tbl_Hocsinh
                         WHERE   dbo.tbl_Account.matk = dbo.tbl_Hocsinh.mahs AND matk = " + matk;
            }
            else
            {
                lenh = @"SELECT matk, hoten, cccd, sdt, pass, phanquyen FROM dbo.tbl_Account,dbo.tbl_Giaovien
                         WHERE   dbo.tbl_Account.matk = dbo.tbl_Giaovien.magv AND matk = " + matk;
            }
            FormViewInf fViewInf = new FormViewInf(lenh);
            fViewInf.ShowDialog();
        }

        //Khôi phục mật khẩu
        private void btnReset_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE dbo.tbl_Account 
                     SET pass = '" + matk + "' WHERE matk = " + matk;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            thaotac.ExecuteNonQuery();
            ketnoi.Close();

            MessageBox.Show("Đã reset mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        //Phần thêm dữ liệu

        public bool ktraStudent()
        {
            if (txbNameStudent.Text != "")
            {
                if (cbxSexStudent.Text != "")
                {
                    if (txbPhoneStudent.Text != "")
                    {
                        if (cbxLop1.Text != "")
                        {
                            if (txbQueStudent.Text != "")
                            {
                                if (txbKhoahoc.Text != "")
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool ktraTeacher()
        {
            if (txbNameTeacher.Text != "")
            {
                if (cbxSexTeacher.Text != "")
                {
                    if (txbPhoneTeacher.Text != "")
                    {
                        if (txbCccdTeacher.Text != "")
                        {
                            if (cbxMon.Text != "")
                            {
                                if (txbQueTeacher.Text != "")
                                {
                                    if (txbAddressTeacher.Text != "")
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (ktraStudent())
            {
                ulong z;
                bool a = ulong.TryParse(txbCccdStudent.Text, out z);

                int cccd = z.ToString().Length;
                bool b = ulong.TryParse(txbPhoneStudent.Text, out z);

                int phone = z.ToString().Length;

                if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
                {
                    ketnoi.Open();
                    lenh = @"INSERT dbo.tbl_Hocsinh(hoten,gioitinh,ngaysinh,cccd,khoahoc,lop,sdt,quequan)
                    VALUES( N'" + txbNameStudent.Text + "', N'"
                                     + cbxSexStudent.Text + "', '"
                                     + dtpDateStudent.Value.ToShortDateString() + "', '"
                                     + txbCccdStudent.Text + "', '"
                                     + txbKhoahoc.Text + "', '"
                                     + cbxLop1.Text + "', '"
                                     + txbPhoneStudent.Text + "', N'"
                                     + txbQueStudent.Text + "')";

                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    lenh = @"SELECT mahs FROM dbo.tbl_Hocsinh WHERE mahs = (SELECT MAX(mahs) FROM dbo.tbl_Hocsinh)";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();
                    docdulieu.Read();

                    int mahs = int.Parse(docdulieu[0].ToString());
                    docdulieu.Close();

                    lenh = @"INSERT dbo.tbl_account(matk, pass, phanquyen)
                     VALUES( " + mahs + ", '" + mahs + "', 'HS')";

                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    addPoint1(mahs);

                    ketnoi.Close();
                    hienthiStudent();
                    hienthiDiem();
                    hienthiAccount();
                }
                else MessageBox.Show("Sai định dạng số điện thoại hoặc CCCD/CMT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin học sinh trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void addPoint1(int mahs)
        {
            string[] a = listMon();

            foreach (string x in a)
            {
                addPoint2(mahs, x);
            }

            lenh = @"INSERT INTO tbl_ketqua(mahs, kieudanhgia)
                     VALUES (" + mahs + @", 1)," +
                            "(" + mahs + @", 2)," +
                            "(" + mahs + @", 12)";
            thaotac = new SqlCommand(lenh, ketnoi);
            thaotac.ExecuteNonQuery();
        }

        public void addPoint2(int mahs, string a)
        {

            lenh = @"INSERT INTO tbl_Diem(mahs, tenmon, hocky, loaidiem)
                    VALUES	 (" + mahs + @", N'" + a + "', 1, '15p1')," +
                            "(" + mahs + @", N'" + a + "', 1, '15p2')," +
                            "(" + mahs + @", N'" + a + "', 1, '15p3')," +
                            "(" + mahs + @", N'" + a + "', 1, '15p4')," +
                            "(" + mahs + @", N'" + a + "', 1, '1t1')," +
                            "(" + mahs + @", N'" + a + "', 1, '1t2')," +
                            "(" + mahs + @", N'" + a + "', 1, '1t3')," +
                            "(" + mahs + @", N'" + a + "', 1, 'hk')," +
                            "(" + mahs + @", N'" + a + "', 1, 'tb')," +

                            "(" + mahs + @", N'" + a + "', 2, '15p1')," +
                            "(" + mahs + @", N'" + a + "', 2, '15p2')," +
                            "(" + mahs + @", N'" + a + "', 2, '15p3')," +
                            "(" + mahs + @", N'" + a + "', 2, '15p4')," +
                            "(" + mahs + @", N'" + a + "', 2, '1t1')," +
                            "(" + mahs + @", N'" + a + "', 2, '1t2')," +
                            "(" + mahs + @", N'" + a + "', 2, '1t3')," +
                            "(" + mahs + @", N'" + a + "', 2, 'hk')," +
                            "(" + mahs + @", N'" + a + "', 2, 'tb')," +
                            "(" + mahs + @", N'" + a + "', 12, 'tb')";
            thaotac = new SqlCommand(lenh, ketnoi);
            thaotac.ExecuteNonQuery();
        }

        //form giáo viên
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (ktraTeacher())
            {
                ulong z;
                bool a = ulong.TryParse(txbCccdTeacher.Text, out z);
                int cccd = z.ToString().Length;

                bool b = ulong.TryParse(txbPhoneTeacher.Text, out z);
                int phone = z.ToString().Length;
                if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
                {
                    ketnoi.Open();
                    lenh = @"INSERT dbo.tbl_Giaovien(hoten,gioitinh,ngaysinh,cccd,mon,sdt,email,quequan,diachilh)
                    VALUES( N'" + txbNameTeacher.Text + "', N'"
                                     + cbxSexTeacher.Text + "', '"
                                     + dtpDateTeacher.Value.ToShortDateString() + "', '"
                                     + txbCccdTeacher.Text + "', N'"
                                     + cbxMon.Text + "', '"
                                     + txbPhoneTeacher.Text + "', '"
                                     + txbEmail.Text + "', N'"
                                     + txbQueTeacher.Text + "', N'"
                                     + txbAddressTeacher.Text + "')";

                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    lenh = @"SELECT magv FROM dbo.tbl_Giaovien WHERE magv = (SELECT MAX(magv) FROM dbo.tbl_Giaovien)";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();
                    docdulieu.Read();

                    int magv = docdulieu[0].GetHashCode();
                    docdulieu.Close();

                    lenh = @"INSERT dbo.tbl_account(matk, pass, phanquyen)
                     VALUES( " + magv + ", '" + magv + "', 'GV')";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    ketnoi.Close();
                    hienthiTeacher();
                    hienthiAccount();
                }
                else MessageBox.Show("Sai định dạng số điện thoại hoặc CCCD/CMT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin giáo viên trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Phần cập nhật sửa dữ liệu
        private void btnSave1_Click(object sender, EventArgs e)
        {
            ulong z;
            bool a = ulong.TryParse(txbCccdStudent.Text, out z);

            int cccd = z.ToString().Length;
            bool b = ulong.TryParse(txbPhoneStudent.Text, out z);

            int phone = z.ToString().Length;

            if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
            {
                lenh = @"UPDATE dbo.tbl_Hocsinh
                        SET hoten = N'" + txbNameStudent.Text + "', "
                             + "ngaysinh = '" + dtpDateStudent.Value.ToShortDateString() + "', "
                             + "gioitinh = N'" + cbxSexStudent.Text + "', "
                             + "cccd = '" + txbCccdStudent.Text + "', "
                             + "sdt = '" + txbPhoneStudent.Text + "', "
                             + "khoahoc = '" + txbKhoahoc.Text + "', "
                             + "lop = '" + cbxLop1.Text + "', "
                             + "quequan = N'" + txbQueStudent.Text + "' "
                             + "WHERE mahs = " + txbIdStudent.Text;
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();
                ketnoi.Close();
                MessageBox.Show("Đã lưu chỉnh sửa!", "Thông báo", MessageBoxButtons.OK);

                hienthiStudent();
                hienthiDiem();
                hienthiAccount();
            }
            else MessageBox.Show("Sai định dạng số điện thoại hoặc CCCD/CMT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ktraDiem()
        {
            if (float.Parse(txbCn.Text) >= 0 && float.Parse(txbCn.Text) < 11)
            {
                if (float.Parse(txbDia.Text) >= 0 && float.Parse(txbDia.Text) < 11)
                {
                    if (float.Parse(txbGdcd.Text) >= 0 && float.Parse(txbGdcd.Text) < 11)
                    {
                        if (float.Parse(txbHoa.Text) >= 0 && float.Parse(txbHoa.Text) < 11)
                        {
                            if (float.Parse(txbSu.Text) >= 0 && float.Parse(txbSu.Text) < 11)
                            {
                                if (float.Parse(txbVan.Text) >= 0 && float.Parse(txbVan.Text) < 11)
                                {
                                    if (float.Parse(txbSinh.Text) >= 0 && float.Parse(txbSinh.Text) < 11)
                                    {
                                        if (float.Parse(txbTd.Text) >= 0 && float.Parse(txbTd.Text) < 11)
                                        {
                                            if (float.Parse(txbAnh.Text) >= 0 && float.Parse(txbAnh.Text) < 11)
                                            {
                                                if (float.Parse(txbTin.Text) >= 0 && float.Parse(txbTin.Text) < 11)
                                                {
                                                    if (float.Parse(txbToan.Text) >= 0 && float.Parse(txbToan.Text) < 11)
                                                    {
                                                        if (float.Parse(txbLy.Text) >= 0 && float.Parse(txbLy.Text) < 11) return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }


        public void tinh()
        {
            if (txbToan.Text == "") txbToan.Text = "0";
            if (txbVan.Text == "") txbVan.Text = "0";
            if (txbAnh.Text == "") txbAnh.Text = "0";
            if (txbLy.Text == "") txbLy.Text = "0";
            if (txbHoa.Text == "") txbHoa.Text = "0";
            if (txbSinh.Text == "") txbSinh.Text = "0";
            if (txbSu.Text == "") txbSu.Text = "0";
            if (txbDia.Text == "") txbDia.Text = "0";
            if (txbGdcd.Text == "") txbGdcd.Text = "0";
            if (txbTin.Text == "") txbTin.Text = "0";
            if (txbCn.Text == "") txbCn.Text = "0";
            if (txbTd.Text == "") txbTd.Text = "0";

            if (ktraDiem())
            {
                float td = float.Parse(txbToan.Text) + float.Parse(txbVan.Text) + float.Parse(txbAnh.Text);
                td = td + float.Parse(txbLy.Text) + float.Parse(txbHoa.Text) + float.Parse(txbSinh.Text);
                td = td + float.Parse(txbSu.Text) + float.Parse(txbDia.Text) + float.Parse(txbGdcd.Text);
                td = td + float.Parse(txbTin.Text) + float.Parse(txbCn.Text) + float.Parse(txbTd.Text);

                float tbmon = (float)td / 12;
                tbmon = (float)Math.Round(tbmon, 1);

                txbTbmon.Text = tbmon.ToString();

                if (tbmon < 5)
                {
                    txbXlhl.Text = "Yếu";
                }
                else if (tbmon < 7)
                {
                    txbXlhl.Text = "Trung bình";
                }
                else if (tbmon < 8)
                {
                    txbXlhl.Text = "Khá";
                }
                else txbXlhl.Text = "Giỏi";


                if (cbxRl.Text == "Yếu")
                {
                    txbXlhv.Text = "Học lại";
                }
                else if (txbXlhl.Text == "Yếu")
                {
                    txbXlhv.Text = "Học lại";
                }
                else txbXlhv.Text = "Học tiếp";
            }
            else MessageBox.Show("Sai định dạng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            tinh();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (txbToan.Text == "") txbToan.Text = "0";
            if (txbVan.Text == "") txbVan.Text = "0";
            if (txbAnh.Text == "") txbAnh.Text = "0";
            if (txbLy.Text == "") txbLy.Text = "0";
            if (txbHoa.Text == "") txbHoa.Text = "0";
            if (txbSinh.Text == "") txbSinh.Text = "0";
            if (txbSu.Text == "") txbSu.Text = "0";
            if (txbDia.Text == "") txbDia.Text = "0";
            if (txbGdcd.Text == "") txbGdcd.Text = "0";
            if (txbTin.Text == "") txbTin.Text = "0";
            if (txbCn.Text == "") txbCn.Text = "0";
            if (txbTd.Text == "") txbTd.Text = "0";

            if (ktraDiem())
            {
                string hk;
                if (cbxHocky.Text == "Cả năm") hk = "12";
                else hk = cbxHocky.Text;
                ketnoi.Open();
                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbToan.Text + "WHERE tenmon = N'Toán' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbVan.Text + "WHERE tenmon = N'Ngữ văn' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbAnh.Text + "WHERE tenmon = N'Tiếng anh' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbLy.Text + "WHERE tenmon = N'Vật lý' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbHoa.Text + "WHERE tenmon = N'Hóa học' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbSinh.Text + "WHERE tenmon = N'Sinh học' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbSu.Text + "WHERE tenmon = N'Lịch sử' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbDia.Text + "WHERE tenmon = N'Địa lý' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbGdcd.Text + "WHERE tenmon = N'GDCD' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbTin.Text + "WHERE tenmon = N'Tin học' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbCn.Text + "WHERE tenmon = N'Công nghệ' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                lenh = @"UPDATE dbo.tbl_Diem
                     SET diem = " + txbTd.Text + "WHERE tenmon = N'Thể dục' AND loaidiem = 'tb' AND hocky = " + hk + " AND mahs = " + txbIdStudent2.Text;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                tinh();

                lenh = @"UPDATE dbo.tbl_ketqua
                     SET dtbmon = " + txbTbmon.Text + ", " +
                            "xlrl = N'" + cbxRl.Text + "', " +
                            "xlhl = N'" + txbXlhl.Text + "', " +
                            "xlhv = N'" + txbXlhv.Text + "' " +
                            "WHERE mahs = " + txbIdStudent2.Text +
                             " AND kieudanhgia = " + hk;
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                float tbmoncn = 0;
                string[] mon = listMon();
                foreach (string x in mon)
                {
                    float hk1, hk2;
                    lenh = @"SELECT diem FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent2.Text +
                              " AND tenmon = N'" + x + "' " +
                              " AND hocky = 1" +
                              " AND loaidiem = 'tb'";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();
                    docdulieu.Read();
                    if (docdulieu[0].ToString() != "") hk1 = float.Parse(docdulieu[0].ToString());
                    else hk1 = 0;
                    docdulieu.Close();

                    lenh = @"SELECT diem FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent2.Text +
                              " AND tenmon = N'" + x + "' " +
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
                              " WHERE mahs = " + txbIdStudent2.Text +
                              " AND tenmon = N'" + x + "' " +
                              " AND hocky = 12" +
                              " AND loaidiem = 'tb'";
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();
                    tbmoncn += tbcn;
                }
                tbmoncn = tbmoncn / 12;
                tbmoncn = (float)Math.Round(tbmoncn, 1);

                lenh = @"UPDATE dbo.tbl_ketqua
                     SET dtbmon = " + tbmoncn + ", " +
                            "xlrl = N'" + cbxRl.Text + "', " +
                            "xlhl = N'" + txbXlhl.Text + "', " +
                            "xlhv = N'" + txbXlhv.Text + "' " +
                            "WHERE mahs = " + txbIdStudent2.Text +
                             " AND kieudanhgia = 12";
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();

                ketnoi.Close();
                MessageBox.Show("Đã lưu chỉnh sửa!", "Thông báo", MessageBoxButtons.OK);

                hienthiDiem();
            }
            else MessageBox.Show("Sai định dạng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            ulong z;
            bool a = ulong.TryParse(txbCccdTeacher.Text, out z);

            int cccd = z.ToString().Length;
            bool b = ulong.TryParse(txbPhoneTeacher.Text, out z);

            int phone = z.ToString().Length;

            if (a && b && cccd >= 10 && cccd <= 12 && phone == 10)
            {
                lenh = @"UPDATE dbo.tbl_Giaovien
                        SET hoten = N'" + txbNameTeacher.Text + "', "
                             + "ngaysinh = '" + dtpDateTeacher.Value.ToShortDateString() + "', "
                             + "gioitinh = N'" + cbxSexTeacher.Text + "', "
                             + "cccd = '" + txbCccdTeacher.Text + "', "
                             + "mon = N'" + cbxMon.Text + "', "
                             + "sdt = '" + txbPhoneTeacher.Text + "', "
                             + "email = '" + txbEmail.Text + "', "
                             + "quequan = N'" + txbQueTeacher.Text + "', "
                             + "diachilh = N'" + txbAddressTeacher.Text + "' "
                             + "WHERE magv = " + txbIdTeacher.Text;
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();
                ketnoi.Close();
                MessageBox.Show("Đã lưu chỉnh sửa!", "Thông báo", MessageBoxButtons.OK);

                hienthiTeacher();
                hienthiAccount();
            }
            else MessageBox.Show("Sai định dạng số điện thoại hoặc CCCD/CMT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave4_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE dbo.tbl_Account
                        SET phanquyen = '" + cbxPhanquyen.Text + "' "
                         + "WHERE matk = " + matk;
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            thaotac.ExecuteNonQuery();
            ketnoi.Close();
            MessageBox.Show("Đã lưu chỉnh sửa!", "Thông báo", MessageBoxButtons.OK);

            hienthiAccount();
        }

        private void btnSave5_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE dbo.tbl_Mon
                        SET sotiet = " + cbxSotiet.Text + ", "
                         + "sobaihs1 = " + cbxHs1.Text + ", "
                         + "sobaihs2 = " + cbxHs2.Text
                         + " WHERE tenmon = N'" + txbMonhoc.Text + "'";
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            thaotac.ExecuteNonQuery();
            ketnoi.Close();
            MessageBox.Show("Đã lưu chỉnh sửa!", "Thông báo", MessageBoxButtons.OK);

            hienthiMon();
        }


        //Phần xóa thông tin
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thông tin học sinh này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lenh = @"DELETE FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent.Text +
                        " DELETE FROM dbo.tbl_ketqua WHERE mahs = " + txbIdStudent.Text +
                        " DELETE FROM dbo.tbl_Hocsinh WHERE mahs = " + txbIdStudent.Text +
                        " DELETE FROM dbo.tbl_account WHERE matk = " + txbIdStudent.Text;
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();
                ketnoi.Close();
                MessageBox.Show("Đã xóa thông tin người dùng!", "Thông báo", MessageBoxButtons.OK);
            }
            hienthiStudent();
            hienthiDiem();
            hienthiAccount();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa điểm học sinh này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lenh = @"DELETE FROM dbo.tbl_Diem WHERE mahs = " + txbIdStudent2.Text +
                        " DELETE FROM dbo.tbl_ketqua WHERE mahs = " + txbIdStudent2.Text +
                        " DELETE FROM dbo.tbl_Hocsinh WHERE mahs = " + txbIdStudent2.Text +
                        " DELETE FROM dbo.tbl_account WHERE matk = " + txbIdStudent2.Text;
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();
                ketnoi.Close();
                MessageBox.Show("Đã xóa thông tin người dùng!", "Thông báo", MessageBoxButtons.OK);
            }

            hienthiStudent();
            hienthiDiem();
            hienthiAccount();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                lenh = @"DELETE FROM dbo.tbl_Giaovien WHERE magv = " + txbIdTeacher.Text +
                        " DELETE FROM dbo.tbl_Account WHERE matk = " + txbIdTeacher.Text;
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                thaotac.ExecuteNonQuery();
                ketnoi.Close();
                MessageBox.Show("Đã xóa thông tin người dùng!", "Thông báo", MessageBoxButtons.OK);
            }
            hienthiTeacher();
            hienthiAccount();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (rdStudent.Checked)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa thông tin học sinh này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lenh = @" DELETE FROM dbo.tbl_Diem WHERE mahs = " + matk +
                            " DELETE FROM dbo.tbl_ketqua WHERE mahs = " + matk +
                            " DELETE FROM dbo.tbl_Hocsinh WHERE mahs = " + matk +
                            " DELETE FROM dbo.tbl_Account WHERE matk = " + matk;
                    ketnoi.Open();
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    ketnoi.Close();
                    MessageBox.Show("Đã xóa thông tin người dùng!", "Thông báo", MessageBoxButtons.OK);
                }
                hienthiStudent();
                hienthiDiem();
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa thông tin giáo viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lenh = @"DELETE FROM dbo.tbl_Giaovien WHERE magv = " + matk +
                            " DELETE FROM dbo.tbl_Account WHERE matk = " + matk;
                    ketnoi.Open();
                    thaotac = new SqlCommand(lenh, ketnoi);
                    thaotac.ExecuteNonQuery();

                    ketnoi.Close();
                    MessageBox.Show("Đã xóa thông tin người dùng!", "Thông báo", MessageBoxButtons.OK);
                }
                hienthiTeacher();
            }
            hienthiAccount();
        }

        // Phần tìm kiếm
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            if (txbSearch1.Text != "")
            {
                lvStudent.Items.Clear();
                lenh = @"SELECT * FROM dbo.tbl_Hocsinh 
                     WHERE mahs LIKE '%" + txbSearch1.Text + "%' OR "
                            + "hoten LIKE N'%" + txbSearch1.Text + "%' OR "
                            + "cccd LIKE '%" + txbSearch1.Text + "%' OR "
                            + "sdt LIKE '%" + txbSearch1.Text + "%' OR "
                            + "lop LIKE '%" + txbSearch1.Text + "%' OR "
                            + "quequan LIKE N'%" + txbSearch1.Text + "%'";
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                i = 0;
                while (docdulieu.Read())
                {
                    DateTimePicker dtpAdd = new DateTimePicker();
                    dtpAdd.Text = docdulieu[3].ToString();
                    lvStudent.Items.Add((i + 1).ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[1].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[4].ToString());
                    lvStudent.Items[i].SubItems.Add(dtpAdd.Value.ToShortDateString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[2].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[6].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[5].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[7].ToString());
                    lvStudent.Items[i].SubItems.Add(docdulieu[8].ToString());
                    i++;
                }
                ketnoi.Close();
                txbSearch1.Text = "";
            }
            else MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {

            if (txbSearch2.Text != "" && cbxLop2.Text != "")
            {
                string hk, lop;
                if (cbxHocky.Text == "Cả năm") hk = "12";
                else hk = cbxHocky.Text;

                if (cbxLop2.Text == "Tất cả") lop = "%";
                else lop = cbxHocky.Text;

                ketnoi.Open();
                lvPoint.Items.Clear();
                lenh = @"SELECT dbo.tbl_Hocsinh.mahs, hoten, diem FROM dbo.tbl_Hocsinh, dbo.tbl_Diem
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs AND loaidiem = 'tb' "
                            + "AND lop LIKE '" + lop + "' "
                            + "AND hocky = " + hk
                            + "AND tenmon = N'Công nghệ' AND ("
                            + "hoten LIKE N'%" + txbSearch2.Text + "%' OR "
                            + "dbo.tbl_Diem.mahs LIKE '%" + txbSearch2.Text + "%')";

                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                i = 0;
                while (docdulieu.Read())
                {
                    lvPoint.Items.Add((i + 1).ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[1].ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[2].ToString());

                    i++;
                }
                docdulieu.Close();

                string[] a = listMon();

                foreach (string x in a)
                {
                    if (x == "Toán") continue;
                    lenh = @"SELECT diem FROM dbo.tbl_Hocsinh, dbo.tbl_Diem
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_Diem.mahs AND loaidiem = 'tb' "
                            + "AND lop LIKE '" + lop + "' "
                            + "AND hocky = " + hk
                            + "AND tenmon = N'" + x + "' AND ("
                            + "hoten LIKE N'%" + txbSearch2.Text + "%' OR "
                            + "dbo.tbl_Diem.mahs LIKE '%" + txbSearch2.Text + "%')";

                    thaotac = new SqlCommand(lenh, ketnoi);
                    docdulieu = thaotac.ExecuteReader();

                    i = 0;
                    while (docdulieu.Read())
                    {
                        lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                        i++;
                    }
                    docdulieu.Close();
                }


                lenh = @"SELECT dtbmon, xlrl, xlhl, xlhv FROM dbo.tbl_Hocsinh, dbo.tbl_ketqua
                     WHERE dbo.tbl_Hocsinh.mahs = dbo.tbl_ketqua.mahs AND kieudanhgia = 12 AND lop LIKE '" + lop + "' AND ("
                            + "hoten LIKE N'%" + txbSearch2.Text + "%' OR "
                            + "dbo.tbl_ketqua.mahs LIKE '%" + txbSearch2.Text + "%')";
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();

                i = 0;
                while (docdulieu.Read())
                {
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvPoint.Items[i].SubItems.Add(docdulieu[0].ToString());
                    i++;
                }
                docdulieu.Close();

                ketnoi.Close();
                txbSearch2.Text = "";
            }
            else MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            if (txbSearch3.Text != "")
            {
                lvTeacher.Items.Clear();
                lenh = @"SELECT * FROM dbo.tbl_Giaovien 
                     WHERE magv LIKE '%" + txbSearch3.Text + "%' OR "
                            + "hoten LIKE N'%" + txbSearch3.Text + "%' OR "
                            + "cccd LIKE '%" + txbSearch3.Text + "%' OR "
                            + "mon LIKE N'%" + txbSearch3.Text + "%' OR "
                            + "sdt LIKE '%" + txbSearch3.Text + "%' OR "
                            + "email LIKE '%" + txbSearch3.Text + "%' OR "
                            + "quequan LIKE N'%" + txbSearch3.Text + "%' OR "
                            + "diachilh LIKE N'%" + txbSearch3.Text + "%'";
                ketnoi.Open();
                thaotac = new SqlCommand(lenh, ketnoi);
                docdulieu = thaotac.ExecuteReader();
                i = 0;
                while (docdulieu.Read())
                {
                    DateTimePicker dtpAdd = new DateTimePicker();
                    dtpAdd.Text = docdulieu[3].ToString();
                    lvTeacher.Items.Add((i + 1).ToString());

                    lvTeacher.Items[i].SubItems.Add(docdulieu[0].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[1].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[4].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[2].ToString());
                    lvTeacher.Items[i].SubItems.Add(dtpAdd.Value.ToShortDateString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[5].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[6].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[7].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[8].ToString());
                    lvTeacher.Items[i].SubItems.Add(docdulieu[9].ToString());
                    i++;
                }

                ketnoi.Close();
                txbSearch3.Text = "";
            }
            else MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch4_Click(object sender, EventArgs e)
        {
            lvAccount.Items.Clear();

            if (rdStudent.Checked)
            {
                lenh = @"SELECT matk, hoten, phanquyen FROM dbo.tbl_Account, dbo.tbl_Hocsinh
                        WHERE mahs = matk AND "
                        + "(mahs LIKE '%" + txbSearch4.Text + "%' OR "
                        + "hoten LIKE N'%" + txbSearch4.Text + "%' OR "
                        + "cccd LIKE '%" + txbSearch4.Text + "%' OR "
                        + "lop LIKE '%" + txbSearch4.Text + "%' OR "
                        + "sdt LIKE '%" + txbSearch4.Text + "%' OR "
                        + "quequan LIKE N'%" + txbSearch4.Text + "%')";
            }
            else
            {
                lenh = @"SELECT matk, hoten, phanquyen FROM dbo.tbl_Account, dbo.tbl_Giaovien
                        WHERE magv = matk AND "
                            + "(magv LIKE '%" + txbSearch4.Text + "%' OR "
                            + "hoten LIKE N'%" + txbSearch4.Text + "%' OR "
                            + "cccd LIKE '%" + txbSearch4.Text + "%' OR "
                            + "mon LIKE N'%" + txbSearch4.Text + "%' OR "
                            + "sdt LIKE '%" + txbSearch4.Text + "%' OR "
                            + "email LIKE '%" + txbSearch4.Text + "%' OR "
                            + "quequan LIKE N'%" + txbSearch4.Text + "%' OR "
                            + "diachilh LIKE N'%" + txbSearch4.Text + "%')";
            }
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvAccount.Items.Add((i + 1).ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvAccount.Items[i].SubItems.Add(docdulieu[2].ToString());
                i++;
            }
            ketnoi.Close();
            txbSearch4.Text = "";
        }

        private void btnSearch5_Click(object sender, EventArgs e)
        {
            lvMon.Items.Clear();
            ketnoi.Open();
            lenh = @"SELECT * FROM dbo.tbl_Mon WHERE tenmon like N'%" + txbSearch5.Text + "%'";
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvMon.Items.Add((i + 1).ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[0].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvMon.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
            txbSearch5.Text = "";
        }

        //Phần bỏ qua
        private void btnSkip1_Click(object sender, EventArgs e)
        {
            hienthiStudent();
        }

        private void btnSkip2_Click(object sender, EventArgs e)
        {
            hienthiDiem();
        }

        private void btnSkip3_Click(object sender, EventArgs e)
        {
            hienthiTeacher();
        }

        private void btnSkip4_Click(object sender, EventArgs e)
        {
            hienthiAccount();
        }

        private void btnSkip5_Click(object sender, EventArgs e)
        {
            hienthiMon();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            //in ten
            Excel.Range exStudent = (Excel.Range)exSheet.Cells[1, 1];
            exStudent.Font.Size = 15;
            exStudent.Font.Bold = true;
            exStudent.Value = "DANH SÁCH HỌC SINH";
            exSheet.Range["A1:E1"].MergeCells = true;
            exSheet.Range["A1:E1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A1:E1"].Font.Name = "Times New Roman";

            //In tiêu đề
            exSheet.Range["A2:J2"].Font.Size = 14;
            exSheet.Range["A2:J2"].Font.Bold = true;
            exSheet.Range["A2:J2"].Borders.LineStyle = Excel.Constants.xlSolid;
            exSheet.Range["A2:J2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A2:J2"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            exSheet.Range["A2:J2"].WrapText = true;
            exSheet.Range["A2:J2"].Interior.Color = Color.LightSkyBlue;
            exSheet.Range["A2:J2"].Font.Name = "Times New Roman";
            exSheet.Range["A2:J2"].RowHeight = 39;

            exSheet.Range["A2"].Value = "STT";
            exSheet.Range["A2"].ColumnWidth = 6;


            exSheet.Range["B2"].Value = "Mã học sinh";
            exSheet.Range["B2"].ColumnWidth = 10;

            exSheet.Range["C2"].Value = "Họ tên";
            exSheet.Range["C2"].ColumnWidth = 21;

            exSheet.Range["D2"].Value = "CCCD/CMT";
            exSheet.Range["D2"].ColumnWidth = 20;

            exSheet.Range["E2"].Value = "Ngày sinh";
            exSheet.Range["E2"].ColumnWidth = 12;

            exSheet.Range["F2"].Value = "Giới tính";
            exSheet.Range["F2"].ColumnWidth = 10;

            exSheet.Range["G2"].Value = "Lớp";
            exSheet.Range["G2"].ColumnWidth = 10;

            exSheet.Range["H2"].Value = "Khóa học";
            exSheet.Range["H2"].ColumnWidth = 12;

            exSheet.Range["I2"].Value = "Số điện thoại";
            exSheet.Range["I2"].ColumnWidth = 20;

            exSheet.Range["J2"].Value = "Quê quán";
            exSheet.Range["J2"].ColumnWidth = 30;

            //In nội dung
            int dong = 3;
            for (int i = 0; i < lvStudent.Items.Count; i++)
            {
                string dongs = (dong + i).ToString();
                exSheet.Range["A" + dongs].Value = lvStudent.Items[i].SubItems[0].Text;
                exSheet.Range["B" + dongs].Value = lvStudent.Items[i].SubItems[1].Text;
                exSheet.Range["C" + dongs].Value = lvStudent.Items[i].SubItems[2].Text;
                exSheet.Range["D" + dongs].NumberFormat = "@";
                exSheet.Range["D" + dongs].Value = lvStudent.Items[i].SubItems[3].Text;
                exSheet.Range["E" + dongs].NumberFormat = "dd/MM/yyyy";
                exSheet.Range["E" + dongs].Value = lvStudent.Items[i].SubItems[4].Text;
                exSheet.Range["F" + dongs].Value = lvStudent.Items[i].SubItems[5].Text;
                exSheet.Range["G" + dongs].Value = lvStudent.Items[i].SubItems[6].Text;
                exSheet.Range["H" + dongs].Value = lvStudent.Items[i].SubItems[7].Text;
                exSheet.Range["I" + dongs].NumberFormat = "@";
                exSheet.Range["I" + dongs].Value = lvStudent.Items[i].SubItems[8].Text;
                exSheet.Range["J" + dongs].Value = lvStudent.Items[i].SubItems[9].Text;

                exSheet.Range["A" + dongs + ":" + "J" + dongs].Borders.LineStyle = Excel.Constants.xlSolid;
                exSheet.Range["A" + dongs + ":" + "B" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["E" + dongs + ":" + "H" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["A" + dongs + ":" + "J" + dongs].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                exSheet.Range["A" + dongs + ":" + "J" + dongs].WrapText = true;
                exSheet.Range["A" + dongs + ":" + "J" + dongs].Font.Name = "Times New Roman";

            }

            //xuat file
            exSheet.Name = "hoc_sinh";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel|*.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName);
            }
            exApp.Quit();
        }

        private void btnExportTeacher_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            //in ten
            Excel.Range exTeacher = (Excel.Range)exSheet.Cells[1, 1];
            exTeacher.Font.Size = 15;
            exTeacher.Font.Bold = true;
            exTeacher.Value = "DANH SÁCH GIÁO VIÊN";
            exSheet.Range["A1:E1"].MergeCells = true;
            exSheet.Range["A1:E1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A1:E1"].Font.Name = "Times New Roman";

            //In tiêu đề
            exSheet.Range["A2:K2"].Font.Size = 14;
            exSheet.Range["A2:K2"].Font.Bold = true;
            exSheet.Range["A2:K2"].Borders.LineStyle = Excel.Constants.xlSolid;
            exSheet.Range["A2:K2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A2:K2"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            exSheet.Range["A2:K2"].WrapText = true;
            exSheet.Range["A2:K2"].Interior.Color = Color.LightSkyBlue;
            exSheet.Range["A2:K2"].Font.Name = "Times New Roman";
            exSheet.Range["A2:K2"].RowHeight = 36;

            exSheet.Range["A2"].Value = "STT";
            exSheet.Range["A2"].ColumnWidth = 6;

            exSheet.Range["B2"].Value = "Mã giáo viên";
            exSheet.Range["B2"].ColumnWidth = 11;

            exSheet.Range["C2"].Value = "Họ tên";
            exSheet.Range["C2"].ColumnWidth = 20;

            exSheet.Range["D2"].Value = "CCCD/CMT";
            exSheet.Range["D2"].ColumnWidth = 20;

            exSheet.Range["E2"].Value = "Giới tính";
            exSheet.Range["E2"].ColumnWidth = 10;

            exSheet.Range["F2"].Value = "Ngày sinh";
            exSheet.Range["F2"].ColumnWidth = 12;

            exSheet.Range["G2"].Value = "Môn giảng dạy";
            exSheet.Range["G2"].ColumnWidth = 12;

            exSheet.Range["H2"].Value = "Số điện thoại";
            exSheet.Range["H2"].ColumnWidth = 17;

            exSheet.Range["I2"].Value = "Email";
            exSheet.Range["I2"].ColumnWidth = 30;

            exSheet.Range["J2"].Value = "Quê quán";
            exSheet.Range["J2"].ColumnWidth = 40;

            exSheet.Range["K2"].Value = "Địa chỉ liên hệ";
            exSheet.Range["K2"].ColumnWidth = 40;
            //In nội dung
            int dong = 3;
            for (int i = 0; i < lvTeacher.Items.Count; i++)
            {
                string dongs = (dong + i).ToString();
                exSheet.Range["A" + dongs].Value = lvTeacher.Items[i].SubItems[0].Text;
                exSheet.Range["B" + dongs].Value = lvTeacher.Items[i].SubItems[1].Text;
                exSheet.Range["C" + dongs].Value = lvTeacher.Items[i].SubItems[2].Text;
                exSheet.Range["D" + dongs].NumberFormat = "@";
                exSheet.Range["D" + dongs].Value = lvTeacher.Items[i].SubItems[3].Text;
                exSheet.Range["E" + dongs].Value = lvTeacher.Items[i].SubItems[4].Text;
                exSheet.Range["F" + dongs].NumberFormat = "dd/MM/yyyy";
                exSheet.Range["F" + dongs].Value = lvTeacher.Items[i].SubItems[5].Text;
                exSheet.Range["G" + dongs].Value = lvTeacher.Items[i].SubItems[6].Text;
                exSheet.Range["H" + dongs].NumberFormat = "@";
                exSheet.Range["H" + dongs].Value = lvTeacher.Items[i].SubItems[7].Text;
                exSheet.Range["I" + dongs].Value = lvTeacher.Items[i].SubItems[8].Text;
                exSheet.Range["J" + dongs].Value = lvTeacher.Items[i].SubItems[9].Text;
                exSheet.Range["K" + dongs].Value = lvTeacher.Items[i].SubItems[10].Text;

                exSheet.Range["A" + dongs + ":" + "K" + dongs].Borders.LineStyle = Excel.Constants.xlSolid;
                exSheet.Range["A" + dongs + ":" + "B" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["E" + dongs + ":" + "G" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["A" + dongs + ":" + "K" + dongs].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                exSheet.Range["A" + dongs + ":" + "K" + dongs].WrapText = true;
                exSheet.Range["A" + dongs + ":" + "K" + dongs].Font.Name = "Times New Roman";
            }

            //xuat file
            exSheet.Name = "giao_vien";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel|*.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName);
            }
            exApp.Quit();
        }

        private void btnExportPoint_Click(object sender, EventArgs e)
        {
            string hk;
            if (cbxHocky.Text == "1") hk = "HỌC KỲ I";
            else if (cbxHocky.Text == "2") hk = "HỌC KỲ II";
            else hk = "CẢ NĂM";
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            //in ten
            Excel.Range exPoint = (Excel.Range)exSheet.Cells[1, 1];
            exPoint.Font.Size = 16;
            exPoint.Font.Bold = true;
            exPoint.Value = "BẢNG TỔNG HỢP KẾT QUẢ HỌC TẬP, KẾT QUẢ RÈN LUYỆN " + hk;
            exSheet.Range["A1:P1"].MergeCells = true;
            exSheet.Range["A1:P1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A1:P1"].Font.Name = "Times New Roman";

            Excel.Range exClass = (Excel.Range)exSheet.Cells[3, 1];
            exClass.Font.Size = 15;
            exClass.Font.Bold = true;
            exClass.Value = "Lớp: " + cbxLop2.Text;
            exSheet.Range["A3:S3"].MergeCells = true;
            exSheet.Range["A3:H3"].Font.Name = "Times New Roman";

            //In tiêu đề
            exSheet.Range["A5:S5"].Font.Size = 10;
            exSheet.Range["A5:S5"].Font.Bold = true;
            exSheet.Range["A5:S5"].Borders.LineStyle = Excel.Constants.xlSolid;
            exSheet.Range["A5:S5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A5:S5"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            exSheet.Range["A5:S5"].Interior.Color = Color.LightSkyBlue;
            exSheet.Range["A5:S5"].Font.Name = "Times New Roman";
            exSheet.Range["A5:S5"].RowHeight = 30;
            exSheet.Range["A5:S5"].WrapText = true;

            exSheet.Range["A5"].Value = "STT";
            exSheet.Range["A5"].ColumnWidth = 5;

            exSheet.Range["B5"].Value = "Mã Học Sinh";
            exSheet.Range["B5"].ColumnWidth = 11;

            exSheet.Range["C5"].Value = "Họ tên";
            exSheet.Range["C5"].ColumnWidth = 17;

            exSheet.Range["D5"].Value = "Công nghệ";
            exSheet.Range["D5"].ColumnWidth = 5;

            exSheet.Range["E5"].Value = "Địa lý";
            exSheet.Range["E5"].ColumnWidth = 5;

            exSheet.Range["F5"].Value = "GDCD";
            exSheet.Range["F5"].ColumnWidth = 5;

            exSheet.Range["G5"].Value = "Hóa học";
            exSheet.Range["G5"].ColumnWidth = 5;

            exSheet.Range["H5"].Value = "Lịch sử";
            exSheet.Range["H5"].ColumnWidth = 5;

            exSheet.Range["I5"].Value = "Ngữ văn";
            exSheet.Range["I5"].ColumnWidth = 5;

            exSheet.Range["J5"].Value = "Sinh học";
            exSheet.Range["J5"].ColumnWidth = 5;

            exSheet.Range["K5"].Value = "Thể dục";
            exSheet.Range["K5"].ColumnWidth = 5;

            exSheet.Range["L5"].Value = "Tiếng anh";
            exSheet.Range["L5"].ColumnWidth = 5;

            exSheet.Range["M5"].Value = "Tin học";
            exSheet.Range["M5"].ColumnWidth = 5;

            exSheet.Range["N5"].Value = "Toán";
            exSheet.Range["N5"].ColumnWidth = 5;

            exSheet.Range["O5"].Value = "Vật lý";
            exSheet.Range["O5"].ColumnWidth = 5;

            exSheet.Range["P5"].Value = "Tổng kết";
            exSheet.Range["P5"].ColumnWidth = 5;

            exSheet.Range["Q5"].Value = "KQRL";
            exSheet.Range["Q5"].ColumnWidth = 6;

            exSheet.Range["R5"].Value = "KQHT";
            exSheet.Range["R5"].ColumnWidth = 10;

            exSheet.Range["S5"].Value = "XLHV";
            exSheet.Range["S5"].ColumnWidth = 8;

            //In nội dung
            int dong = 6;
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
                exSheet.Range["M" + dongs].Value = lvPoint.Items[i].SubItems[12].Text;
                exSheet.Range["N" + dongs].Value = lvPoint.Items[i].SubItems[13].Text;
                exSheet.Range["O" + dongs].Value = lvPoint.Items[i].SubItems[14].Text;
                exSheet.Range["P" + dongs].Value = lvPoint.Items[i].SubItems[15].Text;
                exSheet.Range["Q" + dongs].Value = lvPoint.Items[i].SubItems[16].Text;
                exSheet.Range["R" + dongs].Value = lvPoint.Items[i].SubItems[17].Text;
                exSheet.Range["S" + dongs].Value = lvPoint.Items[i].SubItems[18].Text;

                exSheet.Range["A" + dongs + ":" + "S" + dongs].Borders.LineStyle = Excel.Constants.xlSolid;
                exSheet.Range["A" + dongs + ":" + "B" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["D" + dongs + ":" + "S" + dongs].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.Range["A" + dongs + ":" + "S" + dongs].Font.Name = "Times New Roman";

            }

            int a = dong + lvPoint.Items.Count + 1;
            //de muc
            Excel.Range exHl = (Excel.Range)exSheet.Cells[a, 3];
            exHl.Font.Size = 10;
            exHl.Font.Bold = true;
            exHl.Interior.Color = Color.Yellow;
            exHl.Value = "KQHT";

            Excel.Range exRl = (Excel.Range)exSheet.Cells[a, 7];
            exRl.Font.Size = 10;
            exRl.Font.Bold = true;
            exRl.Interior.Color = Color.Yellow;
            exRl.Value = "KQRL";

            //Tiểu mục học lực
            Excel.Range exHl1_1 = (Excel.Range)exSheet.Cells[a + 1, 3];
            exHl1_1.Font.Size = 10;
            exHl1_1.Font.Bold = true;
            exHl1_1.Value = "Giỏi";

            Excel.Range exHl1_2 = (Excel.Range)exSheet.Cells[a + 1, 4];
            exHl1_2.Font.Size = 10;
            exHl1_2.Font.Bold = true;
            exHl1_2.Value = "Khá";

            Excel.Range exHl1_3 = (Excel.Range)exSheet.Cells[a + 1, 5];
            exHl1_3.Font.Size = 10;
            exHl1_3.Font.Bold = true;
            exHl1_3.Value = "Trung bình";

            Excel.Range exHl1_4 = (Excel.Range)exSheet.Cells[a + 1, 6];
            exHl1_4.Font.Size = 10;
            exHl1_4.Font.Bold = true;
            exHl1_4.Value = "Yếu";

            //Tiểu mục rèn luyện
            Excel.Range exRl1_1 = (Excel.Range)exSheet.Cells[a + 1, 7];
            exRl1_1.Font.Size = 10;
            exRl1_1.Font.Bold = true;
            exRl1_1.Value = "Tốt";

            Excel.Range exRl1_2 = (Excel.Range)exSheet.Cells[a + 1, 8];
            exRl1_2.Font.Size = 10;
            exRl1_2.Font.Bold = true;
            exRl1_2.Value = "Khá";

            Excel.Range exRl1_3 = (Excel.Range)exSheet.Cells[a + 1, 9];
            exRl1_3.Font.Size = 10;
            exRl1_3.Font.Bold = true;
            exRl1_3.Value = "Trung bình";

            Excel.Range exRl1_4 = (Excel.Range)exSheet.Cells[a + 1, 10];
            exRl1_4.Font.Size = 10;
            exRl1_4.Font.Bold = true;
            exRl1_4.Value = "Yếu";

            //
            Excel.Range exHl2_1 = (Excel.Range)exSheet.Cells[a + 2, 3];
            exHl2_1.Font.Size = 10;
            exHl2_1.Font.Bold = true;
            exHl2_1.Value = "=COUNTIF(R" + dong + ":R" + (a - 1) + ", \"Giỏi\")";

            Excel.Range exHl2_2 = (Excel.Range)exSheet.Cells[a + 2, 4];
            exHl2_2.Font.Size = 10;
            exHl2_2.Font.Bold = true;
            exHl2_2.Value = "=COUNTIF(R" + dong + ":R" + (a - 1) + ", \"Khá\")";

            Excel.Range exHl2_3 = (Excel.Range)exSheet.Cells[a + 2, 5];
            exHl2_3.Font.Size = 10;
            exHl2_3.Font.Bold = true;
            exHl2_3.Value = "=COUNTIF(R" + dong + ":R" + (a - 1) + ", \"Trung bình\")";

            Excel.Range exHl2_4 = (Excel.Range)exSheet.Cells[a + 2, 6];
            exHl2_4.Font.Size = 10;
            exHl2_4.Font.Bold = true;
            exHl2_4.Value = "=COUNTIF(R" + dong + ":R" + (a - 1) + ", \"Yếu\")";

            //
            Excel.Range exRl2_1 = (Excel.Range)exSheet.Cells[a + 2, 7];
            exRl2_1.Font.Size = 10;
            exRl2_1.Font.Bold = true;
            exRl2_1.Value = "=COUNTIF(Q" + dong + ":Q" + (a - 1) + ", \"Tốt\")";

            Excel.Range exRl2_2 = (Excel.Range)exSheet.Cells[a + 2, 8];
            exRl2_2.Font.Size = 10;
            exRl2_2.Font.Bold = true;
            exRl2_2.Value = "=COUNTIF(Q" + dong + ":Q" + (a - 1) + ", \"Khá\")";

            Excel.Range exRl2_3 = (Excel.Range)exSheet.Cells[a + 2, 9];
            exRl2_3.Font.Size = 10;
            exRl2_3.Font.Bold = true;
            exRl2_3.Value = "=COUNTIF(Q" + dong + ":Q" + (a - 1) + ", \"Trung bình\")";

            Excel.Range exRl2_4 = (Excel.Range)exSheet.Cells[a + 2, 10];
            exRl2_4.Font.Size = 10;
            exRl2_4.Font.Bold = true;
            exRl2_4.Value = "=COUNTIF(Q" + dong + ":Q" + (a - 1) + ", \"Yếu\")";

            exSheet.Range["C" + a.ToString() + ":F" + a.ToString()].MergeCells = true;
            exSheet.Range["G" + a.ToString() + ":J" + a.ToString()].MergeCells = true;
            exSheet.Range["C" + (a + 1).ToString() + ":J" + (a + 1).ToString()].RowHeight = 30;
            exSheet.Range["C" + a.ToString() + ":J" + (a + 2).ToString()].Font.Name = "Times New Roman";
            exSheet.Range["C" + a.ToString() + ":J" + (a + 2).ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exSheet.Range["C" + a.ToString() + ":J" + (a + 2).ToString()].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            exSheet.Range["C" + a.ToString() + ":J" + (a + 2).ToString()].Borders.LineStyle = Excel.Constants.xlSolid;
            exSheet.Range["C" + a.ToString() + ":J" + (a + 2).ToString()].WrapText = true;

            //xuat file
            exSheet.Name = "bang_diem";
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