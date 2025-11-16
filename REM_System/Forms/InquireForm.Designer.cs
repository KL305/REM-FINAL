namespace REM_System.Forms
{
    partial class InquireForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSellerName = new System.Windows.Forms.Label();
            this.lblBuyerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.lblRETitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSellerName
            // 
            this.lblSellerName.AutoEllipsis = true;
            this.lblSellerName.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerName.Location = new System.Drawing.Point(530, 262);
            this.lblSellerName.Name = "lblSellerName";
            this.lblSellerName.Size = new System.Drawing.Size(402, 56);
            this.lblSellerName.TabIndex = 0;
            this.lblSellerName.Text = "-placeholder-";
            this.lblSellerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuyerName
            // 
            this.lblBuyerName.AutoSize = true;
            this.lblBuyerName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerName.Location = new System.Drawing.Point(982, 668);
            this.lblBuyerName.Name = "lblBuyerName";
            this.lblBuyerName.Size = new System.Drawing.Size(31, 22);
            this.lblBuyerName.TabIndex = 1;
            this.lblBuyerName.Text = "---";
            this.lblBuyerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBuyerName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(497, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "will email you regarding your inquiries";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::REM_System.Properties.Resources.RealEstateLogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(67, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(564, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "--------------------------";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendEmail.Location = new System.Drawing.Point(609, 547);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(146, 36);
            this.btnSendEmail.TabIndex = 9;
            this.btnSendEmail.Text = "Send email";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // lblRETitle
            // 
            this.lblRETitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRETitle.Font = new System.Drawing.Font("Poppins", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRETitle.Location = new System.Drawing.Point(447, 141);
            this.lblRETitle.Name = "lblRETitle";
            this.lblRETitle.Size = new System.Drawing.Size(566, 53);
            this.lblRETitle.TabIndex = 10;
            this.lblRETitle.Text = "-placeholder-";
            this.lblRETitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(761, 547);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::REM_System.Properties.Resources.BackDrop;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEmailAddress);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lblBuyerName);
            this.panel1.Controls.Add(this.btnSendEmail);
            this.panel1.Controls.Add(this.lblRETitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblSellerName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 719);
            this.panel1.TabIndex = 14;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmailAddress.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(567, 498);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(325, 23);
            this.txtEmailAddress.TabIndex = 14;
            this.txtEmailAddress.Text = "<enter your email (e.g. email@gmail.com)>";
            this.txtEmailAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 42);
            this.label1.TabIndex = 15;
            this.label1.Text = "Real estate agent";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InquireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1054, 717);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InquireForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblSellerName;
        public System.Windows.Forms.Label lblBuyerName;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendEmail;
        public System.Windows.Forms.Label lblRETitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtEmailAddress;
        public System.Windows.Forms.Label label1;
    }
}