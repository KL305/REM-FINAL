using REM_System.Data;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class SellerDashboardForm : Form
    {
        private DataGridView dgvProperties;
        private Button btnAddProperty;
        private Button btnEditProperty;
        private Button btnDeleteProperty;
        private Button btnRefresh;
        private Label lblWelcome;
        private readonly int _sellerId;
        private readonly string _username;
        private PropertyRepository _propertyRepo;

        public SellerDashboardForm(int sellerId, string username)
        {
            this.WindowState = FormWindowState.Maximized;
            _sellerId = sellerId;
            _username = username;
            _propertyRepo = new PropertyRepository();
            InitializeComponent();
            Text = $"Seller Dashboard - {_username}";
            lblWelcome.Text = $"Welcome, {_username}!";
            btnRefresh.Click += (s, e) => LoadProperties();
            btnLogout.Click += (s, e) => DialogResult = DialogResult.OK;
            /*btnEditProfile.Click += (s, e) => OnEditProfileClick();*/
            LoadProperties();
        }
        
        /*private void OnEditProfileClick()
        {
            using (var form = new EditProfileForm(_sellerId))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.ProfileUpdated)
                {
                    // If username was changed, update the welcome label
                    if (!string.IsNullOrEmpty(form.UpdatedUsername))
                    {
                        lblWelcome.Text = $"Welcome, {form.UpdatedUsername}!";
                        Text = $"Seller Dashboard - {form.UpdatedUsername}";
                    }
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }*//*
        }*/

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            try
            {
                var properties = _propertyRepo.GetPropertiesBySellerId(_sellerId);
                
                if (properties != null && properties.Count > 0)
                {
                    var propertyData = properties.Select(p => new
                    {
                        p.PropertyId,
                        p.Title,
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
                    
                    
                    try
                    {
                        ConfigureColumns();
                    }
                    catch
                    {
                        
                    }

                    lblStatus.Text = $"Total Properties: {properties.Count}";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    dgvProperties.DataSource = null;
                    dgvProperties.Rows.Clear();
                    lblStatus.Text = "No properties found. Click 'Add Property' to create your first listing.";
                    lblStatus.ForeColor = Color.Blue;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
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

        private Property GetSelectedProperty()
        {
            if (dgvProperties.SelectedRows.Count == 0)
                return null;

            var selectedRow = dgvProperties.SelectedRows[0];
            if (selectedRow.DataBoundItem == null)
                return null;

            var propertyId = Convert.ToInt32(selectedRow.Cells["PropertyId"].Value);
            var properties = _propertyRepo.GetPropertiesBySellerId(_sellerId);
            return properties.FirstOrDefault(p => p.PropertyId == propertyId);
        }

        private void OnAddPropertyClick(object sender, EventArgs e)
        {
            using (var form = new AddPropertyForm(_sellerId))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.PropertyAdded)
                {
                    LoadProperties();
                    lblStatus.Text = "Property added successfully!";
                    lblStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnEditPropertyClick(object sender, EventArgs e)
        {
            var property = GetSelectedProperty();
            if (property == null)
            {
                MessageBox.Show("Please select a property to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new AddPropertyForm(_sellerId, property))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.PropertyAdded)
                {
                    LoadProperties();
                    lblStatus.Text = "Property updated successfully!";
                    lblStatus.ForeColor = Color.Green;
                }
            }
        }

        private void OnDeletePropertyClick(object sender, EventArgs e)
        {
            var property = GetSelectedProperty();
            if (property == null)
            {
                MessageBox.Show("Please select a property to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            if (dgvProperties.SelectedRows.Equals("Under Contract"))
            {
                MessageBox.Show("Cannot delete a property that is under contract.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var result = MessageBox.Show(
                $"Are you sure you want to delete '{property.Title}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_propertyRepo.DeleteProperty(property.PropertyId, _sellerId))
                    {
                        LoadProperties();
                        lblStatus.Text = "Property deleted successfully!";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Failed to delete property.";
                        lblStatus.ForeColor = Color.Firebrick;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error deleting property: {ex.Message}";
                    lblStatus.ForeColor = Color.Firebrick;
                }
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

                
                var propertyIdCol = dgvProperties.Columns.Contains("PropertyId") ? dgvProperties.Columns["PropertyId"] : null;
                if (propertyIdCol != null)
                    propertyIdCol.Visible = false;

                var titleCol = dgvProperties.Columns.Contains("Title") ? dgvProperties.Columns["Title"] : null;
                if (titleCol != null)
                {
                    titleCol.HeaderText = "Title";
                }

                var propertyTypeCol = dgvProperties.Columns.Contains("PropertyType") ? dgvProperties.Columns["PropertyType"] : null;
                if (propertyTypeCol != null)
                {
                    propertyTypeCol.HeaderText = "Type";
                }

                var descriptionCol = dgvProperties.Columns.Contains("Description") ? dgvProperties.Columns["Description"] : null;
                if (descriptionCol != null)
                {
                    descriptionCol.HeaderText = "Description";
                }

                var addressCol = dgvProperties.Columns.Contains("Address") ? dgvProperties.Columns["Address"] : null;
                if (addressCol != null)
                {
                    addressCol.HeaderText = "Address";
                }

                var priceCol = dgvProperties.Columns.Contains("Price") ? dgvProperties.Columns["Price"] : null;
                if (priceCol != null)
                {
                    priceCol.HeaderText = "Price";
                }

                var bedroomsCol = dgvProperties.Columns.Contains("Bedrooms") ? dgvProperties.Columns["Bedrooms"] : null;
                if (bedroomsCol != null)
                {
                    bedroomsCol.HeaderText = "Bedrooms";
                }

                var bathroomsCol = dgvProperties.Columns.Contains("Bathrooms") ? dgvProperties.Columns["Bathrooms"] : null;
                if (bathroomsCol != null)
                {
                    bathroomsCol.HeaderText = "Bathrooms";
                }

                var areaCol = dgvProperties.Columns.Contains("Area") ? dgvProperties.Columns["Area"] : null;
                if (areaCol != null)
                {
                    areaCol.HeaderText = "Area (sq ft)";
                }

                var statusCol = dgvProperties.Columns.Contains("Status") ? dgvProperties.Columns["Status"] : null;
                if (statusCol != null)
                {
                    statusCol.HeaderText = "Status";
                }

                var createdDateCol = dgvProperties.Columns.Contains("CreatedDate") ? dgvProperties.Columns["CreatedDate"] : null;
                if (createdDateCol != null)
                {
                    createdDateCol.HeaderText = "Created Date";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ConfigureColumns: {ex.Message}");
            }
        }
    }
}