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
    
       
    public partial class AddExpenseForm : Form
    {
        private int _userId;

        public AddExpenseForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }



        string connectionString = "Data Source=DESKTOP-NI48BD8;Initial Catalog=daalo;Integrated Security=True;";
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Expenses (UserID, Title, Amount, Category, Date, Notes) VALUES (@userID, @title, @amount, @category, @date, @notes)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", _userId);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(txtAmount.Text));
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Expense added.");
            }
        }

        private void textTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
