namespace REM_System.Forms
{
    partial class AdminDashboardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.lblUsersStatus = new System.Windows.Forms.Label();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnEditProperty = new System.Windows.Forms.Button();
            this.btnDeleteProperty = new System.Windows.Forms.Button();
            this.btnRefreshProperties = new System.Windows.Forms.Button();
            this.lblPropertiesStatus = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Controls.Add(this.tabProperties);
            this.tabControl.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(41, 218);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(942, 475);
            this.tabControl.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.btnAddUser);
            this.tabUsers.Controls.Add(this.btnEditUser);
            this.tabUsers.Controls.Add(this.btnDeleteUser);
            this.tabUsers.Controls.Add(this.btnRefreshUsers);
            this.tabUsers.Controls.Add(this.lblUsersStatus);
            this.tabUsers.Location = new System.Drawing.Point(4, 35);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(934, 436);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "👥 Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Poppins Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvUsers.ColumnHeadersHeight = 35;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Location = new System.Drawing.Point(17, 52);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 40;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(899, 364);
            this.dgvUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(17, 13);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(111, 30);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "➕ Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.OnAddUserClick);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUser.FlatAppearance.BorderSize = 0;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnEditUser.Location = new System.Drawing.Point(134, 13);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(111, 30);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "✏️ Edit User";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.OnEditUserClick);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(251, 13);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(111, 30);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "🗑️ Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.OnDeleteUserClick);
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnRefreshUsers.Location = new System.Drawing.Point(368, 13);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(103, 30);
            this.btnRefreshUsers.TabIndex = 4;
            this.btnRefreshUsers.Text = "🔄 Refresh";
            this.btnRefreshUsers.UseVisualStyleBackColor = false;
            // 
            // lblUsersStatus
            // 
            this.lblUsersStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsersStatus.AutoSize = true;
            this.lblUsersStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsersStatus.ForeColor = System.Drawing.Color.Green;
            this.lblUsersStatus.Location = new System.Drawing.Point(17, 438);
            this.lblUsersStatus.Name = "lblUsersStatus";
            this.lblUsersStatus.Size = new System.Drawing.Size(0, 15);
            this.lblUsersStatus.TabIndex = 5;
            // 
            // tabProperties
            // 
            this.tabProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.tabProperties.Controls.Add(this.dgvProperties);
            this.tabProperties.Controls.Add(this.btnAddProperty);
            this.tabProperties.Controls.Add(this.btnEditProperty);
            this.tabProperties.Controls.Add(this.btnDeleteProperty);
            this.tabProperties.Controls.Add(this.btnRefreshProperties);
            this.tabProperties.Controls.Add(this.lblPropertiesStatus);
            this.tabProperties.Location = new System.Drawing.Point(4, 35);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(934, 436);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "🏠 Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.AllowUserToResizeRows = false;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProperties.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProperties.BackgroundColor = System.Drawing.Color.White;
            this.dgvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Poppins Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.dgvProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvProperties.ColumnHeadersHeight = 35;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProperties.Location = new System.Drawing.Point(17, 52);
            this.dgvProperties.MultiSelect = false;
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.ReadOnly = true;
            this.dgvProperties.RowHeadersVisible = false;
            this.dgvProperties.RowTemplate.Height = 40;
            this.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperties.Size = new System.Drawing.Size(899, 364);
            this.dgvProperties.TabIndex = 0;
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProperty.FlatAppearance.BorderSize = 0;
            this.btnAddProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProperty.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProperty.ForeColor = System.Drawing.Color.White;
            this.btnAddProperty.Location = new System.Drawing.Point(17, 13);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(111, 30);
            this.btnAddProperty.TabIndex = 1;
            this.btnAddProperty.Text = "➕ Add Property";
            this.btnAddProperty.UseVisualStyleBackColor = false;
            this.btnAddProperty.Click += new System.EventHandler(this.OnAddPropertyClick);
            // 
            // btnEditProperty
            // 
            this.btnEditProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEditProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProperty.FlatAppearance.BorderSize = 0;
            this.btnEditProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProperty.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProperty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnEditProperty.Location = new System.Drawing.Point(134, 13);
            this.btnEditProperty.Name = "btnEditProperty";
            this.btnEditProperty.Size = new System.Drawing.Size(111, 30);
            this.btnEditProperty.TabIndex = 2;
            this.btnEditProperty.Text = "✏️ Edit Property";
            this.btnEditProperty.UseVisualStyleBackColor = false;
            this.btnEditProperty.Click += new System.EventHandler(this.OnEditPropertyClick);
            // 
            // btnDeleteProperty
            // 
            this.btnDeleteProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProperty.FlatAppearance.BorderSize = 0;
            this.btnDeleteProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProperty.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProperty.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProperty.Location = new System.Drawing.Point(251, 13);
            this.btnDeleteProperty.Name = "btnDeleteProperty";
            this.btnDeleteProperty.Size = new System.Drawing.Size(111, 30);
            this.btnDeleteProperty.TabIndex = 3;
            this.btnDeleteProperty.Text = "🗑️ Delete Property";
            this.btnDeleteProperty.UseVisualStyleBackColor = false;
            this.btnDeleteProperty.Click += new System.EventHandler(this.OnDeletePropertyClick);
            // 
            // btnRefreshProperties
            // 
            this.btnRefreshProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRefreshProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshProperties.FlatAppearance.BorderSize = 0;
            this.btnRefreshProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProperties.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnRefreshProperties.Location = new System.Drawing.Point(368, 13);
            this.btnRefreshProperties.Name = "btnRefreshProperties";
            this.btnRefreshProperties.Size = new System.Drawing.Size(103, 30);
            this.btnRefreshProperties.TabIndex = 4;
            this.btnRefreshProperties.Text = "🔄 Refresh";
            this.btnRefreshProperties.UseVisualStyleBackColor = false;
            // 
            // lblPropertiesStatus
            // 
            this.lblPropertiesStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPropertiesStatus.AutoSize = true;
            this.lblPropertiesStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropertiesStatus.ForeColor = System.Drawing.Color.Green;
            this.lblPropertiesStatus.Location = new System.Drawing.Point(17, 438);
            this.lblPropertiesStatus.Name = "lblPropertiesStatus";
            this.lblPropertiesStatus.Size = new System.Drawing.Size(0, 15);
            this.lblPropertiesStatus.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Location = new System.Drawing.Point(878, 49);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout ⍈";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblWelcome.Location = new System.Drawing.Point(36, 149);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(73, 51);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(154, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(369, 48);
            this.label6.TabIndex = 13;
            this.label6.Text = "Real Estate Management";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 120);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::REM_System.Properties.Resources.RealEstateLogo;
            this.pictureBox1.Location = new System.Drawing.Point(20, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1029, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(859, 525);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.tabControl.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabProperties.ResumeLayout(false);
            this.tabProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

