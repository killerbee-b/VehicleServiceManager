using System;
using System.Windows.Forms;
using QuestPDF.Infrastructure;

namespace VehicleServiceManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // QuestPDF Community License Activation
            QuestPDF.Settings.License = LicenseType.Community;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}