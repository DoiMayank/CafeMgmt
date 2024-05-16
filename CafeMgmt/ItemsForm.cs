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
using System.Data.SqlClient;

namespace CafeMgmt
{
    public partial class ItemsForm : Form
    {
        public ItemsForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            Con.Open();
            string query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemsGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder order = new UserOrder();
            order.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ItemsGV.Rows.Count) // Check if a valid row index
            {
                DataGridViewRow selectedRow = ItemsGV.Rows[e.RowIndex];
                ItemNumTb.Text = selectedRow.Cells[0].Value?.ToString(); // Use null-conditional operator to handle null values
                ItemNameTb.Text = selectedRow.Cells[1].Value?.ToString();
                CatCb.SelectedItem = selectedRow.Cells[2].Value?.ToString();
                PriceCb.Text = selectedRow.Cells[3].Value?.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm user = new UsersForm();
            user.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ItemNameTb.Text == "" || ItemNumTb.Text == "" || PriceCb.Text == "")
            {
                MessageBox.Show("User Successfully Created");
            }
            else
            {

                Con.Open();
                string query = "insert into ItemTbl values(" + ItemNumTb.Text + ", '" + ItemNameTb.Text + "', '" + CatCb.SelectedItem.ToString() + "' , "+PriceCb.Text+")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Created");
                Con.Close();
                populate();

            }
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ItemNumTb.Text == "")
            {
                MessageBox.Show("Select the Item to be Deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from ItemTbl where ItemNum = '" + ItemNumTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (ItemNumTb.Text == "" || ItemNameTb.Text == "" || PriceCb.Text == "")
            //{
            //    MessageBox.Show("Fill All The Fields");
            //}
            //else
            //{
            //    Con.Open();
            //    //string query = "update ItemTbl set ItemName = '" + ItemNameTb.Text + "',Itemcat = '" + CatCb.SelectedItem.ToString() + "' where ItemPrice = '" + PriceCb.Text + "";
            //    string query = "UPDATE ItemTbl SET ItemName = '" + ItemNameTb.Text + "', Itemcat = '" + CatCb.SelectedItem.ToString() + "' WHERE ItemNum = '" + ItemNumTb + "'";

            //    SqlCommand cmd = new SqlCommand(query, Con);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Item Successfully Updated");
            //    Con.Close();
            //    populate();
            //}
            if (ItemNumTb.Text == "" || ItemNameTb.Text == "" || PriceCb.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                Con.Open();
                string query = "UPDATE ItemTbl SET ItemName = '" + ItemNameTb.Text + "', Itemcat = '" + CatCb.SelectedItem.ToString() + "' WHERE ItemNum = '" + ItemNumTb.Text + "'";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Updated");
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
