using System.ComponentModel.DataAnnotations;

namespace PaymentVoucherApp.Data.Models
{
    public class PaymentVoucher
    {
        [Key]
        public int ID { get; set; }
        public string VoucherNumber { get; set; }
        public string ApAccount { get; set; }
        public string Names { get; set; }
        public string Cashbook { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string ManualPv { get; set; }
        public string ChequeNo { get; set; }
        public bool PettyCash { get; set; }
        public string Memos { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string CreateUser { get; set; }
        public string ActualPosting { get; set; }
    }
}