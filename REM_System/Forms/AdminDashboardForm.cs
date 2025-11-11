using REM_System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private TabControl tabControl;
        private DataGridView dgvUsers;
        private DataGridView dgvProperties;
        private Button btnRefreshUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnRefreshProperties;
        private Button btnAddProperty;
        private Button btnEditProperty;
        private Button btnDeleteProperty;
        private Button btnLogout;
        private Label lblWelcome;
        private Label lblUsersStatus;
        private Label lblPropertiesStatus;
        private TabPage tabUsers;
        private TabPage tabProperties;
        private readonly string _username;
        private UserRepository _userRepo;
        private PropertyRepository _propertyRepo;

        public AdminDashboardForm(string username)
        {
            this.WindowState = FormWindowState.Maximized;
            _username = username;
            InitializeComponent();
            Text = $"Admin Dashboard - {_username}";
            lblWelcome.Text = $"Welcome, {_username}! System Administration";
            btnLogout.Click += (s, e) => DialogResult = DialogResult.OK;
            btnRefreshUsers.Click += (s, e) => LoadUsers();
            btnRefreshProperties.Click += (s, e) => LoadProperties();
            
            
            this.Load += (s, e) =>
            {
                _userRepo = new UserRepository();
                _propertyRepo = new PropertyRepository();
            };
            
            // Delay loading data
            this.Shown += (s, e) =>
            {
                
                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        LoadUsers();
                        LoadProperties();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error loading data in AdminDashboardForm: {ex.Message}");
                        MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
        }


        private void LoadUsers()
        {
            try
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository();
                }

                if (dgvUsers == null || lblUsersStatus == null)
                {
                    System.Diagnostics.Debug.WriteLine("LoadUsers: Controls not initialized in AdminDashboardForm");
                    return;
                }

                // Ensure we're on the UI thread
                if (dgvUsers.InvokeRequired)
                {
                    dgvUsers.Invoke(new Action(LoadUsers));
                    return;
                }

                var allUsers = _userRepo.GetAllUsers();

                if (allUsers == null)
                {
                    allUsers = new List<UserViewModel>();
                }

                // Filter to show only Buyers and Sellers, exclude Admins
                var users = allUsers.Where(u => u.UserRole == "Buyer" || u.UserRole == "Seller").ToList();

                if (users.Count > 0)
                {
                    try
                    {
                        var userData = users.Select(u => new
                        {
                            u.UserId,
                            u.Username,
                            u.Email,
                            u.UserRole
                        }).ToList();

                        dgvUsers.DataSource = null;
                        dgvUsers.DataSource = userData;

                        // Configure columns after data binding
                        DataGridViewBindingCompleteEventHandler bindingCompleteHandler = null;
                        bindingCompleteHandler = (s, e) =>
                        {
                            dgvUsers.DataBindingComplete -= bindingCompleteHandler;
                            try
                            {
                                ConfigureUserColumns();
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error configuring user columns: {ex.Message}");
                            }
                        };
                        dgvUsers.DataBindingComplete += bindingCompleteHandler;

                        // Try to configure immediately as fallback
                        try
                        {
                            ConfigureUserColumns();
                        }
                        catch
                        {
                            // Will be configured on DataBindingComplete event
                        }

                        lblUsersStatus.Text = $"Total Users: {users.Count}";
                        lblUsersStatus.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblUsersStatus.Text = $"Error displaying users: {ex.Message}";
                        lblUsersStatus.ForeColor = Color.Firebrick;
                        System.Diagnostics.Debug.WriteLine($"Error in LoadUsers display: {ex.Message}");
                    }
                }
                else
                {
                    dgvUsers.DataSource = null;
                    dgvUsers.Rows.Clear();
                    lblUsersStatus.Text = "No users found.";
                    lblUsersStatus.ForeColor = Color.Blue;
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 208) // Invalid object name
                {
                    dgvUsers.DataSource = null;
                    dgvUsers.Rows.Clear();
                    lblUsersStatus.Text = "Users table not found. Please run the database setup script first.";
                    lblUsersStatus.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblUsersStatus.Text = $"Database error: {sqlEx.Message}";
                    lblUsersStatus.ForeColor = Color.Firebrick;
                }
            }
            catch (Exception ex)
            {
                lblUsersStatus.Text = $"Error loading users: {ex.Message}";
                lblUsersStatus.ForeColor = Color.Firebrick;
                System.Diagnostics.Debug.WriteLine($"Error in LoadUsers: {ex.Message}");
            }
        }

        private void LoadProperties()
        {
            try
            {
                if (_propertyRepo == null)
                {
                    _propertyRepo = new PropertyRepository();
                }

                if (dgvProperties == null || lblPropertiesStatus == null)
                {
                    System.Diagnostics.Debug.WriteLine("LoadProperties: Controls not initialized in AdminDashboardForm");
                    return;
                }

                // Ensure we're on the UI thread
                if (dgvProperties.InvokeRequired)
                {
                    dgvProperties.Invoke(new Action(LoadProperties));
                    return;
                }

                var properties = _propertyRepo.GetAllPropertiesWithSeller();

                if (properties == null)
                {
                    properties = new List<PropertyViewModel>();
                }

                if (properties.Count > 0)
                {
                    try
                    {
                        var propertyData = properties.Select(p => new
                        {
                            p.PropertyId,
                            p.Title,
                            p.SellerName,
                            Description = p.Description ?? string.Empty,
                            p.PropertyType,
                            Address = p.Address ?? string.Empty,
                            Price = p.Price.ToString("C"),
                            Bedrooms = p.Bedrooms?.ToString() ?? "N/A",
                            Bathrooms = p.Bathrooms?.ToString() ?? "N/A",
                            Area = p.Area?.ToString("N2") ?? "N/A",
                            p.Status,
                            CreatedDate = p.CreatedDate.ToString("yyyy-MM-dd")
                        }).ToList();

                        dgvProperties.DataSource = null;
                        dgvProperties.DataSource = propertyData;

                        // Configure columns after data binding
                        DataGridViewBindingCompleteEventHandler bindingCompleteHandler = null;
                        bindingCompleteHandler = (s, e) =>
                        {
                            dgvProperties.DataBindingComplete -= bindingCompleteHandler;
                            try
                            {
                                ConfigurePropertyColumns();
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error configuring property columns: {ex.Message}");
                            }
                        };
                        dgvProperties.DataBindingComplete += bindingCompleteHandler;

                        // Try to configure immediately as fallback
                        try
                        {
                            ConfigurePropertyColumns();
                        }
                        catch
                        {
                            // Will be configured on DataBindingComplete event
                        }

                        lblPropertiesStatus.Text = $"Total Properties: {properties.Count}";
                        lblPropertiesStatus.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblPropertiesStatus.Text = $"Error displaying properties: {ex.Message}";
                        lblPropertiesStatus.ForeColor = Color.Firebrick;
                        System.Diagnostics.Debug.WriteLine($"Error in LoadProperties display: {ex.Message}");
                    }
                }
                else
                {
                    dgvProperties.DataSource = null;
                    dgvProperties.Rows.Clear();
                    lblPropertiesStatus.Text = "No properties found.";
                    lblPropertiesStatus.ForeColor = Color.Blue;
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 208) // Invalid object name
                {
                    dgvProperties.DataSource = null;
                    dgvProperties.Rows.Clear();
                    lblPropertiesStatus.Text = "Properties table not found. Please run the database setup script first.";
                    lblPropertiesStatus.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblPropertiesStatus.Text = $"Database error: {sqlEx.Message}";
                    lblPropertiesStatus.ForeColor = Color.Firebrick;
                }
            }
            catch (Exception ex)
            {
                lblPropertiesStatus.Text = $"Error loading properties: {ex.Message}";
                lblPropertiesStatus.ForeColor = Color.Firebrick;
                System.Diagnostics.Debug.WriteLine($"Error in LoadProperties: {ex.Message}");
            }
        }

        private void ConfigureUserColumns()
        {
            try
            {
                if (dgvUsers == null || dgvUsers.Columns == null || dgvUsers.Columns.Count == 0)
                    return;

                if (dgvUsers.InvokeRequired)
                {
                    dgvUsers.Invoke(new Action(ConfigureUserColumns));
                    return;
                }

                // Use safer column access
                var userIdCol = dgvUsers.Columns.Contains("UserId") ? dgvUsers.Columns["UserId"] : null;
                if (userIdCol != null)
                    userIdCol.Visible = false;

                var usernameCol = dgvUsers.Columns.Contains("Username") ? dgvUsers.Columns["Username"] : null;
                if (usernameCol != null)
                {
                    usernameCol.HeaderText = "Username";
                    usernameCol.Width = 200;
                }

                var emailCol = dgvUsers.Columns.Contains("Email") ? dgvUsers.Columns["Email"] : null;
                if (emailCol != null)
                {
                    emailCol.HeaderText = "Email";
                    emailCol.Width = 300;
                }

                var userRoleCol = dgvUsers.Columns.Contains("UserRole") ? dgvUsers.Columns["UserRole"] : null;
                if (userRoleCol != null)
                {
                    userRoleCol.HeaderText = "Role";
                    userRoleCol.Width = 150;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ConfigureUserColumns: {ex.Message}");
            }
        }

        private void ConfigurePropertyColumns()
        {
            try
            {
                if (dgvProperties == null || dgvProperties.Columns == null || dgvProperties.Columns.Count == 0)
                    return;

                if (dgvProperties.InvokeRequired)
                {
                    dgvProperties.Invoke(new Action(ConfigurePropertyColumns));
                    return;
                }

                // Use safer column access
                var propertyIdCol = dgvProperties.Columns.Contains("PropertyId") ? dgvProperties.Columns["PropertyId"] : null;
                if (propertyIdCol != null)
                    propertyIdCol.Visible = false;

                var titleCol = dgvProperties.Columns.Contains("Title") ? dgvProperties.Columns["Title"] : null;
                if (titleCol != null)
                {
                    titleCol.HeaderText = "Title";
                    titleCol.Width = 200;
                }

                var sellerNameCol = dgvProperties.Columns.Contains("SellerName") ? dgvProperties.Columns["SellerName"] : null;
                if (sellerNameCol != null)
                {
                    sellerNameCol.HeaderText = "Seller";
                    sellerNameCol.Width = 150;
                }

                var descriptionCol = dgvProperties.Columns.Contains("Description") ? dgvProperties.Columns["Description"] : null;
                if (descriptionCol != null)
                {
                    descriptionCol.HeaderText = "Description";
                    descriptionCol.Width = 200;
                }

                var propertyTypeCol = dgvProperties.Columns.Contains("PropertyType") ? dgvProperties.Columns["PropertyType"] : null;
                if (propertyTypeCol != null)
                {
                    propertyTypeCol.HeaderText = "Type";
                    propertyTypeCol.Width = 100;
                }

                var addressCol = dgvProperties.Columns.Contains("Address") ? dgvProperties.Columns["Address"] : null;
                if (addressCol != null)
                {
                    addressCol.HeaderText = "Address";
                    addressCol.Width = 200;
                }

                var priceCol = dgvProperties.Columns.Contains("Price") ? dgvProperties.Columns["Price"] : null;
                if (priceCol != null)
                {
                    priceCol.HeaderText = "Price";
                    priceCol.Width = 120;
                }

                var bedroomsCol = dgvProperties.Columns.Contains("Bedrooms") ? dgvProperties.Columns["Bedrooms"] : null;
                if (bedroomsCol != null)
                {
                    bedroomsCol.HeaderText = "Bedrooms";
                    bedroomsCol.Width = 80;
                }

                var bathroomsCol = dgvProperties.Columns.Contains("Bathrooms") ? dgvProperties.Columns["Bathrooms"] : null;
                if (bathroomsCol != null)
                {
                    bathroomsCol.HeaderText = "Bathrooms";
                    bathroomsCol.Width = 80;
                }

                var areaCol = dgvProperties.Columns.Contains("Area") ? dgvProperties.Columns["Area"] : null;
                if (areaCol != null)
                {
                    areaCol.HeaderText = "Area";
                    areaCol.Width = 100;
                }

                var statusCol = dgvProperties.Columns.Contains("Status") ? dgvProperties.Columns["Status"] : null;
                if (statusCol != null)
                {
                    statusCol.HeaderText = "Status";
                    statusCol.Width = 100;
                }

                var createdDateCol = dgvProperties.Columns.Contains("CreatedDate") ? dgvProperties.Columns["CreatedDate"] : null;
                if (createdDateCol != null)
                {
                    createdDateCol.HeaderText = "Created Date";
                    createdDateCol.Width = 120;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ConfigurePropertyColumns: {ex.Message}");
            }
        }

        private UserViewModel GetSelectedUser()
        {
            if (dgvUsers.SelectedRows.Count == 0)
                return null;

            var selectedRow = dgvUsers.SelectedRows[0];
            if (selectedRow.DataBoundItem == null)
                return null;

            try
            {
                var userId = Convert.ToInt32(selectedRow.Cells["UserId"].Value);
                return _userRepo.GetUserById(userId);
            }
            catch
            {
                return null;
            }
        }

        private PropertyViewModel GetSelectedProperty()
        {
            if (dgvProperties.SelectedRows.Count == 0)
                return null;

            var selectedRow = dgvProperties.SelectedRows[0];
            if (selectedRow.DataBoundItem == null)
                return null;

            try
            {
                var propertyId = Convert.ToInt32(selectedRow.Cells["PropertyId"].Value);
                var property = _propertyRepo.GetPropertyById(propertyId);
                if (property == null)
                    return null;

                // Get seller name
                var user = _userRepo.GetUserById(property.SellerId);
                return new PropertyViewModel
                {
                    PropertyId = property.PropertyId,
                    SellerId = property.SellerId,
                    SellerName = user?.Username ?? "Unknown",
                    Title = property.Title,
                    Description = property.Description,
                    PropertyType = property.PropertyType,
                    Address = property.Address,
                    Price = property.Price,
                    Bedrooms = property.Bedrooms,
                    Bathrooms = property.Bathrooms,
                    Area = property.Area,
                    Status = property.Status,
                    CreatedDate = property.CreatedDate,
                    ModifiedDate = property.ModifiedDate
                };
            }
            catch
            {
                return null;
            }
        }

        private void OnAddUserClick(object sender, EventArgs e)
        {
            using (var form = new UserForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.UserSaved)
                {
                    LoadUsers();
                    lblUsersStatus.Text = "User added successfully!";
                    lblUsersStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnEditUserClick(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new UserForm(user))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.UserSaved)
                {
                    LoadUsers();
                    lblUsersStatus.Text = "User updated successfully!";
                    lblUsersStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnDeleteUserClick(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete user '{user.Username}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_userRepo.DeleteUser(user.UserId))
                    {
                        LoadUsers();
                        lblUsersStatus.Text = "User deleted successfully!";
                        lblUsersStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblUsersStatus.Text = "Failed to delete user.";
                        lblUsersStatus.ForeColor = Color.Firebrick;
                    }
                }
                catch (Exception ex)
                {
                    lblUsersStatus.Text = $"Error deleting user: {ex.Message}";
                    lblUsersStatus.ForeColor = Color.Firebrick;
                }
            }
        }

        private void OnAddPropertyClick(object sender, EventArgs e)
        {
            // Get first seller ID for default (admin mode)
            var sellers = _userRepo.GetAllUsers().Where(u => u.UserRole == "Seller").ToList();
            if (sellers.Count == 0)
            {
                MessageBox.Show("No sellers found. Please create a seller account first.", "No Sellers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AddPropertyForm(sellers[0].UserId, null, true))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.PropertyAdded)
                {
                    LoadProperties();
                    lblPropertiesStatus.Text = "Property added successfully!";
                    lblPropertiesStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnEditPropertyClick(object sender, EventArgs e)
        {
            var propertyViewModel = GetSelectedProperty();
            if (propertyViewModel == null)
            {
                MessageBox.Show("Please select a property to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var property = _propertyRepo.GetPropertyById(propertyViewModel.PropertyId);
            if (property == null)
            {
                MessageBox.Show("Property not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new AddPropertyForm(property.SellerId, property, true))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.PropertyAdded)
                {
                    LoadProperties();
                    lblPropertiesStatus.Text = "Property updated successfully!";
                    lblPropertiesStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnDeletePropertyClick(object sender, EventArgs e)
        {
            var propertyViewModel = GetSelectedProperty();
            if (propertyViewModel == null)
            {
                MessageBox.Show("Please select a property to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete property '{propertyViewModel.Title}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_propertyRepo.DeleteProperty(propertyViewModel.PropertyId))
                    {
                        LoadProperties();
                        lblPropertiesStatus.Text = "Property deleted successfully!";
                        lblPropertiesStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblPropertiesStatus.Text = "Failed to delete property.";
                        lblPropertiesStatus.ForeColor = Color.Firebrick;
                    }
                }
                catch (Exception ex)
                {
                    lblPropertiesStatus.Text = $"Error deleting property: {ex.Message}";
                    lblPropertiesStatus.ForeColor = Color.Firebrick;
                }
            }
        }
    }
}

