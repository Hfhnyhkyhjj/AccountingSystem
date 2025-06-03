using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;  // for ConfigurationManager
using System.Data.SqlClient; // for SqlConnection
using System.Windows.Forms;
using AccountingSystem.Models;


namespace AccountingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Record> records = new List<Record>();

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("資料庫連線成功！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("資料庫連線失敗：" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
