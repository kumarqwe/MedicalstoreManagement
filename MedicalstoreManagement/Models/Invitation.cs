using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class Invitation
    {
        public int InvitationId { get; set; }
        public string UserEmail { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
