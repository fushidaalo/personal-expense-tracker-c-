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
    public partial class DashboardForm : Form
    {
        private int _userId;
        private string _username;


        public DashboardForm(int userId, string username)
        {
            InitializeComponent();
            _userId = userId;

            label1.Text = "Welcome, User ID: " + _userId.ToString(); // Example usage
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide dashboard
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // Show login form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddExpenseForm addForm = new AddExpenseForm(_userId); // Pass the user ID
            addForm.Show(); // Show the form
        }
       

        private void view_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening view with user ID: " + _userId); // ✅ Check this!
            ViewExpenses viewForm = new ViewExpenses(_userId);
            viewForm.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + _username + "!";
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
