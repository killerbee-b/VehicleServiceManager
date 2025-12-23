using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Data
{
    public class VehicleServiceContext : DbContext
    {
        // ALL 7 DbSets (Tables)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<ServicePart> ServiceParts { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ErrorCode> ErrorCodes { get; set; }
        public DbSet<VehicleErrorCode> VehicleErrorCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // RELATIONSHIPS

            // Customer -> Vehicles (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Vehicles)
                .WithOne(v => v.Customer)
                .HasForeignKey(v => v.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Vehicle -> ServiceOrders (One-to-Many)
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.ServiceOrders)
                .WithOne(so => so.Vehicle)
                .HasForeignKey(so => so.VehicleID)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceOrder -> ServiceParts (One-to-Many)
            modelBuilder.Entity<ServicePart>()
                .HasKey(sp => sp.ServicePartID);

            modelBuilder.Entity<ServicePart>()
                .HasOne(sp => sp.ServiceOrder)
                .WithMany()
                .HasForeignKey(sp => sp.ServiceOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicePart>()
                .HasOne(sp => sp.Part)
                .WithMany()
                .HasForeignKey(sp => sp.PartID)
                .OnDelete(DeleteBehavior.Restrict);

            // Vehicle -> VehicleErrorCodes -> ErrorCode (Many-to-Many)
            modelBuilder.Entity<VehicleErrorCode>()
                .HasKey(ve => ve.VehicleErrorCodeID);

            modelBuilder.Entity<VehicleErrorCode>()
                .HasOne(ve => ve.Vehicle)
                .WithMany()
                .HasForeignKey(ve => ve.VehicleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleErrorCode>()
                .HasOne(ve => ve.ErrorCode)
                .WithMany()
                .HasForeignKey(ve => ve.ErrorCodeID)
                .OnDelete(DeleteBehavior.Cascade);

            // DECIMAL PRECISION (Money Fields)


            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.LaborHours)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.LaborRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.PartsCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.Subtotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.TaxRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.TaxAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.TotalCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceOrder>()
                .Property(so => so.AmountPaid)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Part>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);


            // INDEXES (Performance Optimization)


            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.VIN)
                .IsUnique();

            modelBuilder.Entity<ServiceOrder>()
                .HasIndex(so => so.InvoiceNumber);


            // TABLE NAMES (Explicit)

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<ServiceOrder>().ToTable("ServiceOrders");
            modelBuilder.Entity<ServicePart>().ToTable("ServiceParts");
            modelBuilder.Entity<Part>().ToTable("Parts");
            modelBuilder.Entity<ErrorCode>().ToTable("ErrorCodes");
            modelBuilder.Entity<VehicleErrorCode>().ToTable("VehicleErrorCodes");


            // PRIMARY KEYS (Explicit)

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<Vehicle>().HasKey(v => v.VehicleID);
            modelBuilder.Entity<ServiceOrder>().HasKey(so => so.ServiceOrderID);
            modelBuilder.Entity<Part>().HasKey(p => p.PartID);
            modelBuilder.Entity<ErrorCode>().HasKey(e => e.ErrorCodeID);
        }
    }
}
