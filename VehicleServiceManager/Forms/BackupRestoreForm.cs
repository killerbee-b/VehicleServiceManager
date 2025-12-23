using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class BackupRestoreForm : Form
    {
        private VehicleServiceContext context;

        public BackupRestoreForm()
        {
            InitializeComponent();
        }

        private void BackupRestoreForm_Load(object sender, EventArgs e)
        {
            try
            {
                context = new VehicleServiceContext();
                context.Database.EnsureCreated();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                int customersCount = context.Customers.Count();
                int vehiclesCount = context.Vehicles.Count();
                int serviceOrdersCount = context.ServiceOrders.Count();
                int partsCount = context.Parts.Count();

                lblCustomersCount.Text = $"👥 Customers: {customersCount}";
                lblVehiclesCount.Text = $"🚗 Vehicles: {vehiclesCount}";
                lblServiceOrdersCount.Text = $"🔧 Service Orders: {serviceOrdersCount}";
                lblPartsCount.Text = $"📦 Parts: {partsCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            MessageBox.Show("Statistics refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    FileName = $"VehicleServiceBackup_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                    Filter = "JSON Backup files (*.json)|*.json|All files (*.*)|*.*",
                    Title = "Save Database Backup"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Fetch all data WITHOUT tracking (clean entities)
                    var customers = context.Customers
                        .AsNoTracking()
                        .ToList();

                    var vehicles = context.Vehicles
                        .AsNoTracking()
                        .ToList();

                    var serviceOrders = context.ServiceOrders
                        .AsNoTracking()
                        .ToList();

                    var parts = context.Parts
                        .AsNoTracking()
                        .ToList();

                    // Create backup container
                    var backupData = new
                    {
                        BackupDate = DateTime.Now,
                        BackupVersion = "1.0",
                        ApplicationVersion = Application.ProductVersion,
                        Customers = customers,
                        Vehicles = vehicles,
                        ServiceOrders = serviceOrders,
                        Parts = parts
                    };

                    // Configure JSON serialization to handle circular references
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                        DefaultIgnoreCondition = JsonIgnoreCondition.Never
                    };

                    // Serialize to JSON
                    string jsonString = JsonSerializer.Serialize(backupData, options);

                    // Save to file
                    File.WriteAllText(sfd.FileName, jsonString);

                    var result = MessageBox.Show(
                        $"✅ Backup created successfully!\n\n" +
                        $"📊 Backup Statistics:\n" +
                        $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                        $"👥 Customers: {customers.Count}\n" +
                        $"🚗 Vehicles: {vehicles.Count}\n" +
                        $"🔧 Service Orders: {serviceOrders.Count}\n" +
                        $"📦 Parts: {parts.Count}\n\n" +
                        $"📁 File: {Path.GetFileName(sfd.FileName)}\n" +
                        $"📏 Size: {new FileInfo(sfd.FileName).Length / 1024} KB\n" +
                        $"🕒 Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n" +
                        "Would you like to open the folder?",
                        "✅ Backup Complete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe",
                            $"/select,\"{sfd.FileName}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error creating backup:\n\n{ex.Message}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}",
                    "Backup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "⚠️ WARNING: DESTRUCTIVE OPERATION ⚠️\n\n" +
                "This will DELETE ALL current data and replace it with backup data!\n\n" +
                "Before proceeding:\n" +
                "• Make sure you have a recent backup of current data\n" +
                "• Close all other forms that may be accessing the database\n" +
                "• Ensure the backup file is valid and uncorrupted\n\n" +
                "⚠️ This action CANNOT be undone! ⚠️\n\n" +
                "Do you want to continue?",
                "⚠️ Confirm Restore Operation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "JSON Backup files (*.json)|*.json|All files (*.*)|*.*",
                    Title = "Select Backup File to Restore"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Show processing message
                    this.Cursor = Cursors.WaitCursor;
                    this.Enabled = false;

                    try
                    {
                        // Read and deserialize JSON file
                        string jsonString = File.ReadAllText(ofd.FileName);

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            ReferenceHandler = ReferenceHandler.IgnoreCycles
                        };

                        var backupData = JsonSerializer.Deserialize<BackupContainer>(jsonString, options);

                        if (backupData == null)
                        {
                            MessageBox.Show("❌ Invalid backup file format!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validate backup data
                        if (backupData.Customers == null || backupData.Vehicles == null ||
                            backupData.ServiceOrders == null || backupData.Parts == null)
                        {
                            MessageBox.Show("❌ Backup file is missing required data sections!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // ✅ FIXED RESTORE LOGIC WITH IDENTITY_INSERT
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                // Step 1: Clear existing data (respecting foreign key constraints)
                                context.ServiceOrders.RemoveRange(context.ServiceOrders);
                                context.Vehicles.RemoveRange(context.Vehicles);
                                context.Customers.RemoveRange(context.Customers);
                                context.Parts.RemoveRange(context.Parts);
                                context.SaveChanges();

                                // ✅ Step 2: Restore Customers WITH IDENTITY_INSERT
                                if (backupData.Customers != null && backupData.Customers.Any())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers ON");

                                    foreach (var customer in backupData.Customers)
                                    {
                                        // Reset navigation properties to avoid tracking issues
                                        customer.Vehicles = null;
                                        context.Customers.Add(customer);
                                    }

                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers OFF");
                                }

                                // ✅ Step 3: Restore Parts WITH IDENTITY_INSERT
                                if (backupData.Parts != null && backupData.Parts.Any())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Parts ON");

                                    foreach (var part in backupData.Parts)
                                    {
                                        context.Parts.Add(part);
                                    }

                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Parts OFF");
                                }

                                // ✅ Step 4: Restore Vehicles WITH IDENTITY_INSERT
                                if (backupData.Vehicles != null && backupData.Vehicles.Any())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Vehicles ON");

                                    foreach (var vehicle in backupData.Vehicles)
                                    {
                                        // Reset navigation properties
                                        vehicle.Customer = null;
                                        vehicle.ServiceOrders = null;
                                        context.Vehicles.Add(vehicle);
                                    }

                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Vehicles OFF");
                                }

                                // ✅ Step 5: Restore Service Orders WITH IDENTITY_INSERT
                                if (backupData.ServiceOrders != null && backupData.ServiceOrders.Any())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceOrders ON");

                                    foreach (var serviceOrder in backupData.ServiceOrders)
                                    {
                                        // Reset navigation properties
                                        serviceOrder.Vehicle = null;
                                        context.ServiceOrders.Add(serviceOrder);
                                    }

                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ServiceOrders OFF");
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Refresh statistics
                                LoadStatistics();

                                MessageBox.Show(
                                    $"✅ Database restored successfully!\n\n" +
                                    $"📊 Restored Data:\n" +
                                    $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                    $"👥 Customers: {backupData.Customers?.Count ?? 0}\n" +
                                    $"🚗 Vehicles: {backupData.Vehicles?.Count ?? 0}\n" +
                                    $"🔧 Service Orders: {backupData.ServiceOrders?.Count ?? 0}\n" +
                                    $"📦 Parts: {backupData.Parts?.Count ?? 0}\n\n" +
                                    $"📅 Backup Date: {backupData.BackupDate:yyyy-MM-dd HH:mm:ss}\n" +
                                    $"📦 Backup Version: {backupData.BackupVersion}",
                                    "✅ Restore Complete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        this.Enabled = true;
                    }
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    $"❌ Error parsing backup file:\n\n{ex.Message}\n\n" +
                    "The backup file may be corrupted or in an invalid format.",
                    "Restore Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error restoring backup:\n\n{ex.Message}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}",
                    "Restore Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "⚠️ DANGER! DESTRUCTIVE OPERATION! ⚠️\n\n" +
                "This will permanently DELETE ALL DATA from the database!\n\n" +
                "📋 Data to be deleted:\n" +
                "━━━━━━━━━━━━━━━━━━━━━━\n" +
                "• All Customers\n" +
                "• All Vehicles\n" +
                "• All Service Orders\n" +
                "• All Parts Inventory\n\n" +
                "⚠️ This action CANNOT be undone unless you have a backup! ⚠️\n\n" +
                "Are you ABSOLUTELY SURE you want to proceed?",
                "⚠️ FINAL WARNING - CONFIRM DELETE ALL ⚠️",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
                return;

            // Second confirmation
            var secondConfirm = MessageBox.Show(
                "🛑 LAST CHANCE TO CANCEL! 🛑\n\n" +
                "You are about to permanently delete:\n\n" +
                $"👥 {context.Customers.Count()} Customers\n" +
                $"🚗 {context.Vehicles.Count()} Vehicles\n" +
                $"🔧 {context.ServiceOrders.Count()} Service Orders\n" +
                $"📦 {context.Parts.Count()} Parts\n\n" +
                "Type YES to confirm deletion, or click No to cancel.",
                "🛑 SECOND CONFIRMATION REQUIRED 🛑",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (secondConfirm != DialogResult.Yes)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Delete in correct order (respect foreign key constraints)
                int ordersDeleted = context.ServiceOrders.Count();
                int vehiclesDeleted = context.Vehicles.Count();
                int customersDeleted = context.Customers.Count();
                int partsDeleted = context.Parts.Count();

                context.ServiceOrders.RemoveRange(context.ServiceOrders);
                context.Vehicles.RemoveRange(context.Vehicles);
                context.Customers.RemoveRange(context.Customers);
                context.Parts.RemoveRange(context.Parts);

                context.SaveChanges();

                this.Cursor = Cursors.Default;

                LoadStatistics();

                MessageBox.Show(
                    $"✅ Database cleared successfully!\n\n" +
                    $"📊 Deleted Records:\n" +
                    $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                    $"👥 Customers: {customersDeleted}\n" +
                    $"🚗 Vehicles: {vehiclesDeleted}\n" +
                    $"🔧 Service Orders: {ordersDeleted}\n" +
                    $"📦 Parts: {partsDeleted}\n\n" +
                    "The database is now empty.",
                    "✅ Database Cleared",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(
                    $"❌ Error clearing database:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            context?.Dispose();
        }

        // Backup container class for deserialization
        private class BackupContainer
        {
            public DateTime BackupDate { get; set; }
            public string BackupVersion { get; set; }
            public string ApplicationVersion { get; set; }
            public List<Customer> Customers { get; set; }
            public List<Vehicle> Vehicles { get; set; }
            public List<ServiceOrder> ServiceOrders { get; set; }
            public List<Part> Parts { get; set; }
        }
    }
}
