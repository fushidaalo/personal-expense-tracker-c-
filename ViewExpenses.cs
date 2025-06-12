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

namespace ExpensesTracker
{

    public partial class ViewExpenses : Form

    {
        private int _userId;

        public ViewExpenses(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Manually attach the event
            this.Load += ViewExpenses_Load;
        }

        private void LoadExpenses()
        {
            string connectionString = "Data Source=DESKTOP-NI48BD8;Initial Catalog=daalo;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Title, Amount, Category, Date, Notes FROM Expenses WHERE UserID = @userID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userID", _userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    listView1.Items.Clear(); // Clear previous items

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Title"].ToString());
                        item.SubItems.Add(reader["Amount"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["Date"]).ToShortDateString());
                        item.SubItems.Add(reader["Notes"].ToString());

                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewExpenses_Load(object sender, EventArgs e)
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Title", 150);
            listView1.Columns.Add("Amount", 80);
            listView1.Columns.Add("Category", 100);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Notes", 200);

            LoadExpenses();
        }
    }
}
