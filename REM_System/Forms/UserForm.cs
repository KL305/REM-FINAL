using REM_System.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class UserForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox cmbUserRole;
        private CheckBox chkChangePassword;
        private Button btnSave;
        private Button btnCancel;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblUserRole;
        private Label lblPassword;
        private readonly UserViewModel _userToEdit;
        private readonly UserRepository _userRepo = new UserRepository();

        public bool UserSaved { get; private set; } = false;

        public UserForm(UserViewModel userToEdit = null)
        {
            _userToEdit = userToEdit;
            InitializeComponent();
            
            // Set form title based on mode
            Text = _userToEdit == null ? "Add User" : "Edit User";
            lblTitle.Text = _userToEdit == null ? "Add New User" : "Edit User";
            btnSave.Text = _userToEdit == null ? "Add User" : "Update User";
            
            // Configure checkbox for edit mode
            if (_userToEdit != null)
            {
                chkChangePassword.Visible = true;
                chkChangePassword.CheckedChanged += ChkChangePassword_CheckedChanged;
                txtPassword.Enabled = false;
            }
            else
            {
                chkChangePassword.Visible = false;
                txtPassword.Enabled = true;
            }
            
            if (userToEdit != null)
            {
                LoadUserData(userToEdit);
            }
        }

        private void ChkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = chkChangePassword.Checked;
            if (!chkChangePassword.Checked)
            {
                txtPassword.Text = string.Empty;
            }
        }

        private void LoadUserData(UserViewModel user)
        {
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            cmbUserRole.SelectedItem = user.UserRole;
            if (cmbUserRole.SelectedItem == null && cmbUserRole.Items.Count > 0)
            {
                cmbUserRole.SelectedIndex = 0;
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var userRole = Convert.ToString(cmbUserRole.SelectedItem);
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatus.Text = "Please enter a username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                lblStatus.Text = "Please enter an email.";
                return;
            }

            if (string.IsNullOrWhiteSpace(userRole))
            {
                lblStatus.Text = "Please select a role.";
                return;
            }

            if (_userToEdit == null && string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Please enter a password.";
                return;
            }

            if (_userToEdit != null && chkChangePassword.Checked && string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Please enter a password.";
                return;
            }

            try
            {
                if (_userToEdit == null)
                {
                    // Check if username already exists
                    if (_userRepo.UsernameExists(username))
                    {
                        lblStatus.Text = "Username already exists.";
                        return;
                    }

                    // Check if email already exists
                    if (_userRepo.EmailExists(email))
                    {
                        lblStatus.Text = "Email already exists.";
                        return;
                    }

                    var userId = _userRepo.CreateUser(username, password, email, userRole);
                    if (userId > 0)
                    {
                        UserSaved = true;
                        DialogResult = DialogResult.OK;
                        MessageBox.Show(cmbUserRole.SelectedItem +" created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblStatus.Text = "Failed to create user.";
                    }
                }
                else
                {
                    // Check if username already exists
                    if (username != _userToEdit.Username && _userRepo.UsernameExists(username))
                    {
                        lblStatus.Text = "Username already exists.";
                        return;
                    }

                    // Check if email already exists
                    if (email != _userToEdit.Email && _userRepo.EmailExists(email))
                    {
                        lblStatus.Text = "Email already exists.";
                        return;
                    }

                    string passwordToUpdate = chkChangePassword.Checked ? password : null;
                    if (_userRepo.UpdateUser(_userToEdit.UserId, username, email, userRole, passwordToUpdate))
                    {
                        UserSaved = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        lblStatus.Text = "Failed to update user.";
                    }
                }
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
    }
}

