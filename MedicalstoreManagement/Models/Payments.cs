using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public decimal? TransactionAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Reciept { get; set; }
        public DateTime? PaymentAt { get; set; }
    }
}
