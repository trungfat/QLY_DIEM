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
    public partial class FormViewInf : Form
    {
        string chuoi = new SQL().getChuoi();
        SqlConnection ketnoi;
        SqlCommand thaotac;
        SqlDataReader docdulieu;
        public FormViewInf(string lenh)
        {
            InitializeComponent();
            ketnoi = new SqlConnection(chuoi);
            ketnoi.Open();
            thaotac = new SqlCommand(lenh, ketnoi);
            docdulieu = thaotac.ExecuteReader();
            docdulieu.Read();
            txbId.Text = docdulieu[0].ToString();
            txbName.Text = docdulieu[1].ToString();
            txbCccd.Text = docdulieu[2].ToString();
            txbPhone.Text = docdulieu[3].ToString();
            txbPass.Text = docdulieu[4].ToString();
            txbPhanquyen.Text = docdulieu[5].ToString();
            ketnoi.Close();
        }
    }
}