using REM_System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class BuyerDashboardForm : Form
    {
        private DataGridView dgvProperties;
        private Button btnRefresh;
        private Button btnLogout;
        private ComboBox cmbStatusFilter;
        public Label lblWelcome;
        private Label lblStatus;
        private Label lblFilter;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private readonly string _username;
        private readonly int _userId;
        private PropertyRepository _propertyRepo;
        private System.Windows.Forms.Timer _searchTimer;

        public BuyerDashboardForm(string username, int userId = 0)
        {
            this.WindowState = FormWindowState.Maximized;
            _username = username;
            _userId = userId;
            _propertyRepo = new PropertyRepository();
            
            // If userId not provided, get it from username
            if (_userId == 0)
            {
                var userRepo = new UserRepository();
                var user = userRepo.GetUserByUsername(username);
                if (user != null)
                {
                    _userId = user.UserId;
                }
            }
            InitializeComponent();
            Text = $"Buyer Dashboard - {_username}";
            lblWelcome.Text = $"Welcome, {_username}! Browse Available Properties";
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadProperties();
            btnRefresh.Click += (s, e) => LoadProperties();
            btnLogout.Click += (s, e) => DialogResult = DialogResult.OK;
            btnSearch.Click += (s, e) => LoadProperties();
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadProperties(); };
            /*btnEditProfile.Click += (s, e) => OnEditProfileClick();*/
            
            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 500; // 500ms delay
            _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); LoadProperties(); };
            txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
            
            // Delay loading properties until form is shown
            this.Shown += (s, e) => LoadProperties();
        }

        /*private void OnEditProfileClick()
        {
            if (_userId == 0)
            {
                MessageBox.Show("Unable to load user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new EditProfileForm(_userId))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.ProfileUpdated)
                {
                    // If username was changed, update the welcome label
                    if (!string.IsNullOrEmpty(form.UpdatedUsername))
                    {
                        lblWelcome.Text = $"Welcome, {form.UpdatedUsername}! Browse Available Properties";
                        Text = $"Buyer Dashboard - {form.UpdatedUsername}";
                    }
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }*/

        private void LoadProperties()
        {
            try
            {
                if (_propertyRepo == null)
                {
                    _propertyRepo = new PropertyRepository();
                }

                if (dgvProperties == null || lblStatus == null)
                {
                    return;
                }

                string statusFilter = null;
                if (cmbStatusFilter != null && cmbStatusFilter.SelectedItem != null)
                {
                    var selectedStatus = Convert.ToString(cmbStatusFilter.SelectedItem);
                    if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All")
                    {
                        statusFilter = selectedStatus;
                    }
                }

                var allProperties = _propertyRepo.GetAllPropertiesWithSeller();
                
                // Filter by status if needed
                var properties = allProperties;
                if (!string.IsNullOrEmpty(statusFilter))
                {
                    properties = allProperties.Where(p => p.Status == statusFilter).ToList();
                }
                
                // Filter by search term if provided
                if (txtSearch != null && !string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var searchTerm = txtSearch.Text.Trim().ToLower();
                    properties = properties.Where(p =>
                        (p.Title ?? string.Empty).ToLower().Contains(searchTerm) ||
                        (p.Description ?? string.Empty).ToLower().Contains(searchTerm) ||
                        (p.Address ?? string.Empty).ToLower().Contains(searchTerm) ||
                        (p.PropertyType ?? string.Empty).ToLower().Contains(searchTerm) ||
                        (p.SellerName ?? string.Empty).ToLower().Contains(searchTerm) ||
                        (p.Price.ToString().Contains(searchTerm)) ||
                        (p.Bedrooms?.ToString() ?? string.Empty).Contains(searchTerm) ||
                        (p.Bathrooms?.ToString() ?? string.Empty).Contains(searchTerm) ||
                        (p.Area?.ToString() ?? string.Empty).Contains(searchTerm)
                    ).ToList();
                }

                if (properties != null && properties.Count > 0)
                {
                    try
                    {
                        var propertyData = properties.Select(p => new
                        {
                            p.PropertyId,
                            p.Title,
                            p.SellerName,
                            p.PropertyType,
                            Description = p.Description ?? string.Empty,
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
                                ConfigureColumns();
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error configuring columns: {ex.Message}");
                            }
                        };
                        dgvProperties.DataBindingComplete += bindingCompleteHandler;
                        
                        // Try to configure immediately as fallback
                        try
                        {
                            ConfigureColumns();
                        }
                        catch
                        {
                            // Will be configured on DataBindingComplete event
                        }

                        string statusText = $"🏠︎ Total Properties: {properties.Count}";
                        if (txtSearch != null && !string.IsNullOrWhiteSpace(txtSearch.Text))
                        {
                            statusText += $" (filtered by search)";
                        }
                        lblStatus.Text = statusText;
                        lblStatus.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"Error displaying properties: {ex.Message}";
                        lblStatus.ForeColor = Color.Firebrick;
                    }
                }
                else
                {
                    dgvProperties.DataSource = null;
                    dgvProperties.Rows.Clear();
                    string selectedStatusText = statusFilter ?? "All";
                    string noResultsText = selectedStatusText == "All" 
                        ? "No properties found." 
                        : $"No {selectedStatusText.ToLower()} properties found.";
                    
                    if (txtSearch != null && !string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        noResultsText += $" No matches for '{txtSearch.Text}'.";
                    }
                    
                    lblStatus.Text = noResultsText;
                    lblStatus.ForeColor = Color.Blue;
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 208)
                {
                    dgvProperties.DataSource = null;
                    dgvProperties.Rows.Clear();
                    lblStatus.Text = "Properties table not found. Please run the database setup script first.";
                    lblStatus.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblStatus.Text = $"Database error: {sqlEx.Message}";
                    lblStatus.ForeColor = Color.Firebrick;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error loading properties: {ex.Message}";
                lblStatus.ForeColor = Color.Firebrick;
            }
        }

        private void ConfigureColumns()
        {
            try
            {
                if (dgvProperties == null || dgvProperties.Columns == null || dgvProperties.Columns.Count == 0)
                    return;

                if (dgvProperties.InvokeRequired)
                {
                    dgvProperties.Invoke(new Action(ConfigureColumns));
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
                    sellerNameCol.Width = 120;
                }

                var propertyTypeCol = dgvProperties.Columns.Contains("PropertyType") ? dgvProperties.Columns["PropertyType"] : null;
                if (propertyTypeCol != null)
                {
                    propertyTypeCol.HeaderText = "Type";
                    propertyTypeCol.Width = 100;
                }

                var descriptionCol = dgvProperties.Columns.Contains("Description") ? dgvProperties.Columns["Description"] : null;
                if (descriptionCol != null)
                {
                    descriptionCol.HeaderText = "Description";
                    descriptionCol.Width = 250;
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
                    priceCol.Width = 100;
                }

                var bedroomsCol = dgvProperties.Columns.Contains("Bedrooms") ? dgvProperties.Columns["Bedrooms"] : null;
                if (bedroomsCol != null)
                {
                    bedroomsCol.HeaderText = "Bedrooms";
                    bedroomsCol.Width = 70;
                }

                var bathroomsCol = dgvProperties.Columns.Contains("Bathrooms") ? dgvProperties.Columns["Bathrooms"] : null;
                if (bathroomsCol != null)
                {
                    bathroomsCol.HeaderText = "Bathrooms";
                    bathroomsCol.Width = 70;
                }

                var areaCol = dgvProperties.Columns.Contains("Area") ? dgvProperties.Columns["Area"] : null;
                if (areaCol != null)
                {
                    areaCol.HeaderText = "Area (sq ft)";
                    areaCol.Width = 100;
                }

                var statusCol = dgvProperties.Columns.Contains("Status") ? dgvProperties.Columns["Status"] : null;
                if (statusCol != null)
                {
                    statusCol.HeaderText = "Status";
                    statusCol.Width = 80;
                }

                var createdDateCol = dgvProperties.Columns.Contains("CreatedDate") ? dgvProperties.Columns["CreatedDate"] : null;
                if (createdDateCol != null)
                {
                    createdDateCol.HeaderText = "Listed Date";
                    createdDateCol.Width = 100;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ConfigureColumns: {ex.Message}");
            }
        }

        private void dgvProperties_DoubleClick(object sender, EventArgs e)
        {
            string message = "Do you want to submit an inquiry about this property?";
            string caption = "Real Estate Inquiry";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;

            DialogResult result = MessageBox.Show(message, caption, buttons, icon);

            if (result == DialogResult.Yes)
            {
                UserViewModel userViewModel = new UserRepository().GetUserById(_userId);

                InquireForm inquireForm = new InquireForm();
                inquireForm.lblSellerName.Text = dgvProperties.CurrentRow.Cells["SellerName"].Value.ToString();
                inquireForm.lblRETitle.Text = dgvProperties.CurrentRow.Cells["Title"].Value.ToString();
                inquireForm.txtEmailAddress.Text = userViewModel.Email;
                inquireForm.lblBuyerName.Text = userViewModel.Username;
                inquireForm.ShowDialog();
            }
            else
            {
                result = DialogResult.No;
            }
        }
    }
}

