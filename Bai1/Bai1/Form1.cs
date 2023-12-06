using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Bai1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_sinhvien;
        DataSet ds_sinhvien;
        DataColumn[] key = new DataColumn[1];
        SqlCommand cmd = new SqlCommand();
        string strsql;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=A209PC04;Initial Catalog=SinhVien;Integrated Security=True");
            string strSelect = "select * from SinhVien";
            da_sinhvien = new SqlDataAdapter(strSelect, conn);
            ds_sinhvien = new DataSet();
            da_sinhvien.Fill(ds_sinhvien, "SinhVien");
            key[0] = ds_sinhvien.Tables["SinhVien"].Columns[0];
            ds_sinhvien.Tables["SinhVien"].PrimaryKey = key;
        }
        void Databingding(DataTable pDT)
        {
            txtMaSV.DataBindings.Clear();
            txtTenSV.DataBindings.Clear();

            txtMaSV.DataBindings.Add("Text", pDT, "MSSV");
            txtTenSV.DataBindings.Add("Text", pDT, "TenSv");
        }
        void loadGrid()
        {
            dgvDSSV.DataSource = ds_sinhvien.Tables[0];
            Databingding(ds_sinhvien.Tables[0]);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow newrow = ds_sinhvien.Tables[0].NewRow();
            newrow["MaSinhvien"] = txtMaSV.Text;
            newrow["TenSinhvien"] = txtTenSV.Text;
            ds_sinhvien.Tables[0].Rows.Add(newrow);
            SqlCommandBuilder cB = new SqlCommandBuilder(da_sinhvien);
            da_sinhvien.Update(ds_sinhvien, "SinhVien");
            txtMaSV.Clear();
            txtTenSV.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_sinhvien.Tables[0].Rows.Find(txtMaSV.Text);
            if (dr != null)
            {
                dr.Delete();
            }
            //cap nhap trong database
            SqlCommandBuilder cB = new SqlCommandBuilder(da_sinhvien);
            //cap nhat dataset
            da_sinhvien.Update(ds_sinhvien, "Sinhvien");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_sinhvien.Tables[0].Rows.Find(txtMaSV.Text);
            if (dr != null)
            {
                dr["TenSinhvien"] = txtTenSV.Text;
            }
            SqlCommandBuilder cB = new SqlCommandBuilder(da_sinhvien);
            da_sinhvien.Update(ds_sinhvien, "Sinhvien");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}