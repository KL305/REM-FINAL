using REM_System.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblPassword;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void OnRegisterClick(object sender, EventArgs e)
        {
            using (var reg = new RegisterForm())
            {
                if (reg.ShowDialog(this) == DialogResult.OK)
                {
                    txtUsername.Text = reg.RegisteredUsername;
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Registration successful. You can now login.";
                }
            }
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = "Please enter username and password.";
                return;
            }

            try
            {
                var repo = new UserRepository();
                if (repo.ValidateCredentials(username, password, out var role, out var userId))
                {
                    Hide();
                    
                    if (role == "Admin")
                    {
                        using (var adminDashboard = new AdminDashboardForm(username))
                        {
                            adminDashboard.ShowDialog(this);
                        }
                    }
                    else if (role == "Seller")
                    {
                        using (var sellerDashboard = new SellerDashboardForm(userId, username))
                        {
                            sellerDashboard.ShowDialog(this);
                        }
                    }
                    else if (role == "Buyer")
                    {
                        using (var buyerDashboard = new BuyerDashboardForm(username, userId))
                        {
                            buyerDashboard.ShowDialog(this);
                        }
                    }
                    else
                    {
                        using (var main = new LoginForm())
                        {
                            main.Text = $"REM System - {username} ({role})";
                            main.StartPosition = FormStartPosition.CenterScreen;
                            main.ShowDialog(this);
                        }
                    }
                    Show();
                }
                else
                {
                    lblStatus.ForeColor = Color.Firebrick;
                    lblStatus.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


