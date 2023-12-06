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
using System.Data;

namespace NguyenNgocPhuQuy_2033210170
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeSqlConnection();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;

        

        private void InitializeSqlConnection()
        {
            string connectionString = "Data Source=your_server;Initial Catalog=your_database;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            // Define your SQL query
            string query = "SELECT MSSV, TenSv FROM SinhVien";

            // Set up the SqlCommand and SqlDataAdapter
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            dataAdapter.SelectCommand = sqlCommand;
        }

        private void LoadData()
        {
            try
            {
                sqlConnection.Open();
                dataAdapter.Fill(dataSet, "SinhVien");

                // Bind the data to DataGridView
                dataGridView.DataSource = dataSet.Tables["SinhVien"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
