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

namespace CafeMgmt
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            Con.Open();
            string query = "select * from Users_Tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UserOrder uorder = new UserOrder();
            uorder.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemsForm item = new ItemsForm();
            item.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into Users_Tbl values('" + unameTb.Text + "', '" + UphoneTb.Text + "', '" + UpassTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created");
            Con.Close();
            populate();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        //private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)

        //{
        //    unameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
        //    UphoneTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
        //    UpassTb.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
        //}
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < UsersGV.Rows.Count) // Check if a valid row index
            {
                DataGridViewRow selectedRow = UsersGV.Rows[e.RowIndex];
                unameTb.Text = selectedRow.Cells[0].Value?.ToString(); // Use null-conditional operator to handle null values
                UphoneTb.Text = selectedRow.Cells[1].Value?.ToString();
                UpassTb.Text = selectedRow.Cells[2].Value?.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(UphoneTb.Text == "")
            {
                MessageBox.Show("Select the User to be Deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from Users_Tbl where Uphone = '" + UphoneTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text == "" || UpassTb.Text == "" || unameTb.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                Con.Open();
                string query = "update Users_Tbl set Uname='" + unameTb.Text + "',Upassword = '" + UpassTb.Text + "' where Uphone = '"+UphoneTb.Text+"'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");
                Con.Close();
                populate();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
