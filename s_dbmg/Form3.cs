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

namespace s_dbmg
{
    public partial class Form3 : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        Form1 frm;
        List<string> tabele;

        public Form3(Form1 form1, SqlConnection conn, SqlCommand commd)
        {
            cmd = commd;
            cn = conn;
            frm = form1;
            InitializeComponent();
            cn.Open();
            DataTable schema = cn.GetSchema("Tables");
            tabele = new List<string>();
            foreach (DataRow row in schema.Rows)
            {
                tabele.Add(row[2].ToString());
            }
            comboBox1.Items.AddRange(tabele.ToArray());
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "DROP TABLE ["+comboBox1.SelectedItem.ToString()+"];";
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Deleted", "Deleted");
            frm.Show();
            this.Close();
        }
    }
}
