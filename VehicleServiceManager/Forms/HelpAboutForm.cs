using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace VehicleServiceManager.Forms
{
    public partial class HelpAboutForm : Form
    {
        public HelpAboutForm()
        {
            InitializeComponent();
        }

        private void HelpAboutForm_Load(object sender, EventArgs e)
        {
            // You can customize the student name here
            lblStudent.Text = "Developed by [Your Name] - Visual Programming Course Project 2025";

            // Optional: Add app version dynamically
            lblVersion.Text = $"Version 1.0.0 - Built {DateTime.Now:MMMM yyyy}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Optional: Add keyboard shortcut to close (Escape key)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
