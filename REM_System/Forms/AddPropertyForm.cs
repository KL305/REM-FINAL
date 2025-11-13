using REM_System.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class AddPropertyForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cmbPropertyType;
        private TextBox txtAddress;
        private NumericUpDown numPrice;
        private NumericUpDown numBedrooms;
        private NumericUpDown numBathrooms;
        private NumericUpDown numArea;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblSeller;
        private Label lblPropertyTitle;
        private Label lblPropertyType;
        private Label lblDescription;
        private Label lblAddress;
        private Label lblPrice;
        private Label lblBedrooms;
        private Label lblBathrooms;
        private Label lblArea;
        private Label lblStatusLabel;
        private ComboBox cmbSeller;
        private readonly int _sellerId;
        private readonly bool _isAdminMode;
        private Property _propertyToEdit;

        public bool PropertyAdded { get; private set; } = false;

        public AddPropertyForm(int sellerId, Property propertyToEdit = null, bool isAdminMode = true)
        {
            _sellerId = sellerId;
            _isAdminMode = isAdminMode;
            _propertyToEdit = propertyToEdit;
            InitializeComponent();
            
            // Configure form based on mode
            Text = _propertyToEdit == null ? "Add Property" : "Edit Property";
            lblTitle.Text = _propertyToEdit == null ? "Add New Property" : "Edit Property";
            btnSave.Text = _propertyToEdit == null ? "Add Property" : "Update Property";

            // Show/hide seller combobox based on admin mode
            if (lblTitle.Text.Equals("Add New Property"))
            {
                if (_isAdminMode)
                {
                    cmbStatus.Items.AddRange(new string[] { "Available" });
                    lblSeller.Visible = true;
                    cmbSeller.Visible = true;
                    LoadSellers();
                }
            }
            else
            {
                lblSeller.Visible = false;
                cmbSeller.Visible = false;
                cmbStatus.Items.AddRange(new string[] { "Available", "Under Contract", "Sold" });
            }
            
            if (propertyToEdit != null)
            {
                LoadPropertyData(propertyToEdit);
            }
        }

        private void LoadSellers()
        {
            try
            {
                var userRepo = new UserRepository();
                var allUsers = userRepo.GetAllUsers();
                var sellers = allUsers.Where(u => u.UserRole == "Seller").ToList();
                
                cmbSeller.Items.Clear();
                foreach (var seller in sellers)
                {
                    cmbSeller.Items.Add(new { SellerId = seller.UserId, SellerName = seller.Username });
                }
                
                if (cmbSeller.Items.Count > 0)
                {
                    cmbSeller.DisplayMember = "SellerName";
                    cmbSeller.ValueMember = "SellerId";
                    cmbSeller.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading sellers: {ex.Message}");
            }
        }

        private void LoadPropertyData(Property property)
        {
            txtTitle.Text = property.Title;
            cmbPropertyType.SelectedItem = property.PropertyType;
            txtDescription.Text = property.Description;
            txtAddress.Text = property.Address;
            numPrice.Value = property.Price;
            numBedrooms.Value = property.Bedrooms ?? 0;
            numBathrooms.Value = property.Bathrooms ?? 0;
            numArea.Value = property.Area ?? 0;
            cmbStatus.SelectedItem = property.Status;
            
            if (_isAdminMode && cmbSeller.Items.Count > 0)
            {
                // Find and select the seller
                for (int i = 0; i < cmbSeller.Items.Count; i++)
                {
                    dynamic item = cmbSeller.Items[i];
                    if (item.SellerId == property.SellerId)
                    {
                        cmbSeller.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var propertyType = Convert.ToString(cmbPropertyType.SelectedItem);
            var price = numPrice.Value;

            if (string.IsNullOrWhiteSpace(title))
            {
                lblStatus.Text = "Please enter a title.";
                return;
            }

            if (price <= 0)
            {
                lblStatus.Text = "Please enter a valid price.";
                return;
            }

            int selectedSellerId = _sellerId;
            if (_isAdminMode)
            {
                if (cmbSeller.SelectedItem == null)
                {
                    lblStatus.Text = "Please select a seller.";
                    return;
                }
                dynamic selectedSeller = cmbSeller.SelectedItem;
                selectedSellerId = selectedSeller.SellerId;
            }

            try
            {
                var repo = new PropertyRepository();
                Property property;

                if (_propertyToEdit != null)
                {
                    property = _propertyToEdit;
                    property.SellerId = selectedSellerId;
                    property.Title = title;
                    property.Description = txtDescription.Text.Trim();
                    property.PropertyType = propertyType;
                    property.Address = txtAddress.Text.Trim();
                    property.Price = price;
                    property.Bedrooms = numBedrooms.Value > 0 ? (int?)numBedrooms.Value : null;
                    property.Bathrooms = numBathrooms.Value > 0 ? (int?)numBathrooms.Value : null;
                    property.Area = numArea.Value > 0 ? (decimal?)numArea.Value : null;
                    property.Status = Convert.ToString(cmbStatus.SelectedItem);

                    bool success;
                    if (_isAdminMode)
                    {
                        success = repo.UpdatePropertyAdmin(property);
                    }
                    else
                    {
                        success = repo.UpdateProperty(property);
                    }

                    if (success)
                    {
                        PropertyAdded = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        lblStatus.Text = "Failed to update property.";
                    }
                }
                else
                {
                    property = new Property
                    {
                        SellerId = selectedSellerId,
                        Title = title,
                        Description = txtDescription.Text.Trim(),
                        PropertyType = propertyType,
                        Address = txtAddress.Text.Trim(),
                        Price = price,
                        Bedrooms = numBedrooms.Value > 0 ? (int?)numBedrooms.Value : null,
                        Bathrooms = numBathrooms.Value > 0 ? (int?)numBathrooms.Value : null,
                        Area = numArea.Value > 0 ? (decimal?)numArea.Value : null,
                        Status = cmbStatus.SelectedItem != null ? Convert.ToString(cmbStatus.SelectedItem) : "Available",
                    };

                    var propertyId = repo.CreateProperty(property);
                    if (propertyId > 0)
                    {
                        PropertyAdded = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        lblStatus.Text = "Failed to add property.";
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

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

