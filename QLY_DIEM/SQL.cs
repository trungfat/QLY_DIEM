using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLY_DIEM
{
    internal class SQL
    {

        private string chuoi = @"Data Source=localhost;Initial Catalog=QLY_DIEMTHPT;Integrated Security=True";
        private bool ktra()
        {
            string chuoi1 = @"Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            SqlConnection ketnoi = new SqlConnection(chuoi1);
            ketnoi.Open();
            string lenh = @"SELECT name FROM sys.databases WHERE name = 'QLY_DIEMTHPT'";
            SqlCommand thaotac = new SqlCommand(lenh, ketnoi);
            SqlDataReader docdulieu = thaotac.ExecuteReader();
            string a = "";
            if (docdulieu.Read())  a = docdulieu[0].ToString();
            docdulieu.Close();
            ketnoi.Close();

            if (a != "")
            {
                return true;
            }
            return false;
        }

        public string getChuoi() {
            if(!ktra()) {
                Process process = new Process();
                process.StartInfo.FileName = "Tao_database.bat";
                process.Start();
            }
            return chuoi;
        }
    }
}
