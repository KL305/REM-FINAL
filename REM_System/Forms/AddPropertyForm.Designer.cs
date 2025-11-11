namespace REM_System.Forms
{
    partial class AddPropertyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbPropertyType = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numBedrooms = new System.Windows.Forms.NumericUpDown();
            this.numBathrooms = new System.Windows.Forms.NumericUpDown();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.lblPropertyTitle = new System.Windows.Forms.Label();
            this.lblPropertyType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblBedrooms = new System.Windows.Forms.Label();
            this.lblBathrooms = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.cmbSeller = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBedrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(106, 118);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(317, 30);
            this.txtTitle.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(52, 196);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(925, 77);
            this.txtDescription.TabIndex = 8;
            // 
            // cmbPropertyType
            // 
            this.cmbPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropertyType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPropertyType.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPropertyType.FormattingEnabled = true;
            this.cmbPropertyType.Items.AddRange(new object[] {
            "Commercial",
            "Industrial",
            "Residential",
            "Land"});
            this.cmbPropertyType.Location = new System.Drawing.Point(530, 115);
            this.cmbPropertyType.Name = "cmbPropertyType";
            this.cmbPropertyType.Size = new System.Drawing.Size(162, 34);
            this.cmbPropertyType.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(151, 293);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(826, 30);
            this.txtAddress.TabIndex = 10;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrice.Location = new System.Drawing.Point(151, 333);
            this.numPrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(292, 30);
            this.numPrice.TabIndex = 12;
            // 
            // numBedrooms
            // 
            this.numBedrooms.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBedrooms.Location = new System.Drawing.Point(572, 333);
            this.numBedrooms.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBedrooms.Name = "numBedrooms";
            this.numBedrooms.Size = new System.Drawing.Size(134, 30);
            this.numBedrooms.TabIndex = 14;
            // 
            // numBathrooms
            // 
            this.numBathrooms.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBathrooms.Location = new System.Drawing.Point(843, 333);
            this.numBathrooms.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBathrooms.Name = "numBathrooms";
            this.numBathrooms.Size = new System.Drawing.Size(134, 30);
            this.numBathrooms.TabIndex = 16;
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 2;
            this.numArea.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numArea.Location = new System.Drawing.Point(151, 376);
            this.numArea.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(292, 30);
            this.numArea.TabIndex = 18;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStatus.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Available",
            "Sold",
            "Pending"});
            this.cmbStatus.Location = new System.Drawing.Point(572, 376);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(318, 34);
            this.cmbStatus.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(711, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 30);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Add Property";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnCancel.Location = new System.Drawing.Point(848, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 30);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStatus.Location = new System.Drawing.Point(68, 416);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 23;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(47, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Property";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblSeller.Location = new System.Drawing.Point(730, 117);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(64, 26);
            this.lblSeller.TabIndex = 1;
            this.lblSeller.Text = "Seller *";
            // 
            // lblPropertyTitle
            // 
            this.lblPropertyTitle.AutoSize = true;
            this.lblPropertyTitle.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblPropertyTitle.Location = new System.Drawing.Point(47, 120);
            this.lblPropertyTitle.Name = "lblPropertyTitle";
            this.lblPropertyTitle.Size = new System.Drawing.Size(53, 26);
            this.lblPropertyTitle.TabIndex = 3;
            this.lblPropertyTitle.Text = "Title *";
            // 
            // lblPropertyType
            // 
            this.lblPropertyType.AutoSize = true;
            this.lblPropertyType.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblPropertyType.Location = new System.Drawing.Point(466, 120);
            this.lblPropertyType.Name = "lblPropertyType";
            this.lblPropertyType.Size = new System.Drawing.Size(58, 26);
            this.lblPropertyType.TabIndex = 5;
            this.lblPropertyType.Text = "Type *";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblDescription.Location = new System.Drawing.Point(47, 167);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(98, 26);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAddress.Location = new System.Drawing.Point(47, 295);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(73, 26);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblPrice.Location = new System.Drawing.Point(47, 335);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(60, 26);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Price *";
            // 
            // lblBedrooms
            // 
            this.lblBedrooms.AutoSize = true;
            this.lblBedrooms.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBedrooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBedrooms.Location = new System.Drawing.Point(477, 335);
            this.lblBedrooms.Name = "lblBedrooms";
            this.lblBedrooms.Size = new System.Drawing.Size(89, 26);
            this.lblBedrooms.TabIndex = 13;
            this.lblBedrooms.Text = "Bedrooms";
            // 
            // lblBathrooms
            // 
            this.lblBathrooms.AutoSize = true;
            this.lblBathrooms.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBathrooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBathrooms.Location = new System.Drawing.Point(742, 335);
            this.lblBathrooms.Name = "lblBathrooms";
            this.lblBathrooms.Size = new System.Drawing.Size(95, 26);
            this.lblBathrooms.TabIndex = 15;
            this.lblBathrooms.Text = "Bathrooms";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblArea.Location = new System.Drawing.Point(48, 378);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(97, 26);
            this.lblArea.TabIndex = 17;
            this.lblArea.Text = "Area (sq ft)";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(496, 380);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(70, 26);
            this.lblStatusLabel.TabIndex = 19;
            this.lblStatusLabel.Text = "Status *";
            // 
            // cmbSeller
            // 
            this.cmbSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeller.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSeller.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeller.FormattingEnabled = true;
            this.cmbSeller.Location = new System.Drawing.Point(800, 114);
            this.cmbSeller.Name = "cmbSeller";
            this.cmbSeller.Size = new System.Drawing.Size(177, 34);
            this.cmbSeller.TabIndex = 2;
            // 
            // AddPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1034, 534);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.numBathrooms);
            this.Controls.Add(this.lblBathrooms);
            this.Controls.Add(this.numBedrooms);
            this.Controls.Add(this.lblBedrooms);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbPropertyType);
            this.Controls.Add(this.lblPropertyType);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblPropertyTitle);
            this.Controls.Add(this.cmbSeller);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AddPropertyForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBedrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

