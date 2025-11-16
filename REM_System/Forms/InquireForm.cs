using REM_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REM_System.Forms
{
    public partial class InquireForm : Form
    {
        public InquireForm()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                using (SmtpClient smtp = new SmtpClient())
                {
                    UserViewModel userViewModel = new UserViewModel();
                    var buyerName = userViewModel.Username;

                    // Sender details (Gmail address)
                    string fromEmail = "sampleuser.realestate@gmail.com"; // Gmail address
                    string appPassword = "nmjo drsy owum sxrm"; // Generated App Password

                    message.From = new MailAddress(fromEmail);
                    // Recipient details
                    message.To.Add(txtEmailAddress.Text); //Recipient's email
                    message.Subject = $"Real Estate Managment. Your inquiry on {lblRETitle.Text}";

                    message.Body = $"Dear {lblBuyerName.Text},\r\n\r\nI'm agent {lblSellerName.Text}. Thank you for reaching out the property {lblRETitle.Text} in Real Estate Management App." +
                    $"I would be happy to arrange a private showing for you. I have the following slots open this week:\r\n\r\nTuesday, [Date], at 4:30 PM\r\n\r\nWednesday, [Date], at 10:00 AM" +
                    $"\r\n\r\nPlease let me know which time works best for you, or if you require an alternative. If you are interested in discussing your search criteria further, I'd also be happy to schedule a quick 15-minute introductory call to ensure I don't miss any \"coming soon\" properties that match your perfect home profile." +
                    $"\r\n\r\nI look forward to hearing from you and helping you find your next property." +
                    $"\r\n\r\nBest regards," +
                    $"\r\n\r\nAgent {lblSellerName.Text}";


                    // SMTP settings
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587; // 587 for TLS
                    smtp.EnableSsl = true; // Enable SSL/TLS encryption
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    // Send the email
                    smtp.Send(message);
                    MessageBox.Show("Email sent successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Failed to send email. Make sure you input a correct email address (e.g. email@gmail.com)");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
