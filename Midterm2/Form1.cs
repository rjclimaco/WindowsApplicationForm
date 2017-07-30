using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Midterm2
{
    public partial class Form1 : Form
    {
        string myCon = "server=localhost;database=database_login;Uid=root;Password=;";
        string userid = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            View();
        }
        public void View()
        {
            listView1.Items.Clear();
            MySqlConnection con = new MySqlConnection(myCon);
            con.Open();
            MySqlCommand retrieve = con.CreateCommand();
            retrieve.Connection = con;
            retrieve.CommandText = "Select * from tbl_users";
            MySqlDataReader reader = retrieve.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem list = new ListViewItem(reader["Lastname"].ToString());
                list.SubItems.Add(reader["Firstname"].ToString());
                list.SubItems.Add(reader["Username"].ToString());
                list.SubItems.Add(reader["Password"].ToString());
                list.SubItems.Add(reader["id"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            MySqlConnection con = new MySqlConnection(myCon);
            con.Open ();
            MySqlCommand insert = con.CreateCommand();
            insert.Connection = con;
            insert.CommandText = "Insert into tbl_users(Lastname, Firstname, Username, Password) values ('" + txtlastname.Text +"' , '" + txtfirstname.Text + "', '" + txtusername.Text + "' , '" + txtpassword.Text + "')";
            insert.ExecuteNonQuery();
            con.Close();
   
            MessageBox.Show("Success");
            View();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public void Update()
        {
            MySqlConnection con = new MySqlConnection(myCon);
            con.Open();
            MySqlCommand insert = con.CreateCommand();
            insert.Connection = con;
            insert.CommandText = "UPDATE `tbl_users` SET `id`=[value - 1],`Lastname`=[value - 2],`Firstname`=[value - 3],`Username`=[value - 4],`Password`=[value - 5] WHERE 1";
            insert.ExecuteNonQuery();
            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
               
            }
        }
    }
}
