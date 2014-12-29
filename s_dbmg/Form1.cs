using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using s_dbmg.model;

namespace s_dbmg
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dimitrije\documents\visual studio 2013\Projects\s_dbmg\s_dbmg\db.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        static ListaAutora a;
        static ListaKnjiga k;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            a = new ListaAutora();
            k = new ListaKnjiga();
            cn.Open();
            cmd.CommandText = "select * from Autor";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    a.dodajAutora(dr[1].ToString());
                }
            }
            for (int i = 0; i < a.N; i++)
            {
                listBox1.Items.Add(a[i]);
            }
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                cn.Open();
                cmd.CommandText="insert into Autor (ime_autora,knjige) values ('"+textBox1.Text+"','"+textBox2.Text+"')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();
                MessageBox.Show("Done");
                a.dodajAutora(textBox1.Text);
                listBox1.Items.Clear();
                for (int i = 0; i < a.N; i++)
                {
                    listBox1.Items.Add(a[i]);
                }
            }
                
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                cn.Open();
                cmd.CommandText = "delete from Autor where ime_autora='"+textBox1.Text+"' and knjige= '"+textBox2.Text+"'";
                cmd.ExecuteNonQuery();
                a.remove(new Autor(textBox1.Text));
                cn.Close();

            }
            else if (listBox1.SelectedIndex != -1)
            {
                cn.Open();
                cmd.CommandText = "delete from Autor where ime_autora='" + listBox1.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                a.remove(new Autor(listBox1.SelectedItem.ToString()));
                cn.Close();
            }
            listBox1.Items.Clear();
            for (int i = 0; i < a.N; i++)
            {
                listBox1.Items.Add(a[i]);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this, cn, cmd);
            frm2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(this, cn, cmd);
            frm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "select ime from Knjige where autor='"+listBox1.SelectedItem.ToString()+"'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    k.dodajKnjigu(dr[0].ToString(), new Autor(listBox1.SelectedItem.ToString())); //this
                }
            }
            for (int i = 0; i < k.N; i++)
            {
                listBox2.Items.Add(k[i]);
            }
            cn.Close();
        }
    }
}
