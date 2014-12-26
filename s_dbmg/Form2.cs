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
    public partial class Form2 : Form
    {
        Form1 frm;
        SqlConnection cn;
        SqlCommand cmd;
        TextBox[] tb;
        public Form2(Form1 form1, SqlConnection conn, SqlCommand commd)
        {
            frm = form1;
            cn = conn;
            cmd = commd;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = true;
                tb = new TextBox[1]{(textBox1)};
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                tb = new TextBox[2] { (textBox1), (textBox2) };
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                tb = new TextBox[3] { (textBox1), (textBox2), (textBox3) };
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                tb = new TextBox[4] { (textBox1), (textBox2), (textBox3), (textBox4) };
            }
            if (comboBox1.SelectedIndex == 4)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                tb = new TextBox[5] { (textBox1), (textBox2), (textBox3), (textBox4), (textBox5) };
            }
            if (comboBox1.SelectedIndex == 5)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                tb = new TextBox[6] { (textBox1), (textBox2), (textBox3), (textBox4), (textBox5), (textBox6) };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText="CREATE TABLE [dbo].["+textBox7.Text+"] ( [Id] INT IDENTITY (1, 1) NOT NULL,";
            foreach (TextBox texb in tb)
            {
                cmd.CommandText += "[" + texb.Text + "] NVARCHAR (50) NOT NULL,";
            }
            cmd.CommandText+="PRIMARY KEY CLUSTERED ([Id] ASC));";
            cmd.ExecuteNonQuery();
            cn.Close();
            frm.Show();
            this.Close();
        }
    }
}
