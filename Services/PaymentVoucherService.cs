using System.Collections.Generic;
using System.Linq;
using PaymentVoucherApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PaymentVoucherApp.Data.Services
{
    public class PaymentVoucherService
    {
        // DbContext instance to interact with the database
        private readonly PaymentVoucherDbContext _context;

        // Constructor to initialize the PaymentVoucherService with the database context
        public PaymentVoucherService(PaymentVoucherDbContext context)
        {
            _context = context;
        }

        // Method to get a list of all payment vouchers, ensuring no tracking for performance
        public IEnumerable<PaymentVoucher> GetVouchers()
        {
            // Fetching all vouchers without tracking for better performance (no changes will be tracked in this query)
            return _context.PaymentVouchers.AsNoTracking().ToList();
        }

        // Method to get a specific voucher by its number
        public PaymentVoucher GetVoucherByNumber(string voucherNumber)
        {
            // Returns a single voucher based on the provided voucher number, ensuring no tracking
            return _context.PaymentVouchers.AsNoTracking()
                                           .FirstOrDefault(v => v.VoucherNumber == voucherNumber);
        }

        // Method to save a payment voucher (add or update)
        public void SaveVoucher(PaymentVoucher voucher)
        {
            // Check if a voucher with the same number already exists in the database
            var existing = _context.PaymentVouchers.FirstOrDefault(v => v.VoucherNumber == voucher.VoucherNumber);

            if (existing != null)
            {
                // If voucher already exists, remove the existing record to allow adding the new one (update logic)
                _context.PaymentVouchers.Remove(existing);
            }

            // Add the voucher (it will either be an insert or update)
            _context.PaymentVouchers.Add(voucher);

            // Save changes to the database
            _context.SaveChanges();
        }

        // Method to delete a payment voucher by its voucher number
        public void DeleteVoucher(string voucherNumber)
        {
            // Find the voucher by voucher number
            var voucher = _context.PaymentVouchers.FirstOrDefault(v => v.VoucherNumber == voucherNumber);

            if (voucher == null)
            {
                // If the voucher is not found, throw an exception
                throw new KeyNotFoundException("Voucher not found.");
            }

            // Remove the voucher from the database
            _context.PaymentVouchers.Remove(voucher);

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}