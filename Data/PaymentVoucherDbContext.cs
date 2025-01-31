using Microsoft.EntityFrameworkCore;
using PaymentVoucherApp.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PaymentVoucherApp.Data
{
    public class PaymentVoucherDbContext : DbContext
    {
        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }

        public PaymentVoucherDbContext(DbContextOptions<PaymentVoucherDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentVoucher>()
                .HasKey(p => p.ID); // Set ID as the primary key

            modelBuilder.Entity<PaymentVoucher>()
                .HasIndex(p => p.VoucherNumber) // Create a unique index on VoucherNumber
                .IsUnique(); // Enforce uniqueness for VoucherNumber
        }
    }
}