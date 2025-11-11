using REM_System.Data;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class RegisterForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirm;
        private ComboBox cmbRole;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirm;
        private Label lblRole;

        public string RegisteredUsername { get; private set; } = string.Empty;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void OnSubmitClick(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var confirm = txtConfirm.Text;
            var role = Convert.ToString(cmbRole.SelectedItem) ?? "User";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Please fill in all required fields.";
                return;
            }

            if (!IsValidEmail(email))
            {
                lblStatus.Text = "Please enter a valid email address.";
                return;
            }

            if (password.Length < 6)
            {
                lblStatus.Text = "Password must be at least 6 characters.";
                return;
            }

            if (!string.Equals(password, confirm, StringComparison.Ordinal))
            {
                lblStatus.Text = "Passwords do not match.";
                return;
            }

            try
            {
                var repo = new UserRepository();
                if (repo.UsernameExists(username))
                {
                    lblStatus.Text = "Username already exists.";
                    return;
                }

                if (repo.EmailExists(email))
                {
                    lblStatus.Text = "Email already exists.";
                    return;
                }

                var userId = repo.CreateUser(username, password, email, role);
                if (userId > 0)
                {
                    RegisteredUsername = username;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    lblStatus.Text = "Registration failed.";
                }
            }
            catch (SqlException ex)
            {
                lblStatus.Text = $"Database error: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}


