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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30");
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void populate()
        {
            Con.Open();
            string query = "select * from OrdersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OrdersGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ViewOrders_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void ItemsGVOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======MyCafe Orders======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(200, 40));
            e.Graphics.DrawString("======Order Summary======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(208, 70));
            //e.Graphics.DrawString("Number : " +OrdersGV.SelectedRows[0].Cells[0].Value.ToString() , new Font("Abeezee", 14, FontStyle.Regular), Brushes.Black, new Point(200, 40));
            //e.Graphics.DrawString("Date : " + OrdersGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Abeezee", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
            //e.Graphics.DrawString("Seller : " + OrdersGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Abeezee", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
            //e.Graphics.DrawString("Amount : " + OrdersGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Abeezee", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
            //e.Graphics.DrawString("Order Number: " +OrdersGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Abeezee", 12, FontStyle.Regular), Brushes.Black, new Point(120, 100));
            e.Graphics.DrawString("======Powered By Mayank Doi======", new Font("Abeezee", 20, FontStyle.Bold), Brushes.Red, new Point(208, 340));



        }
    }
}
