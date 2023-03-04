using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class EventDetails
    {
        public string EventId { get; set; }
        public string EventName { get; set; }
        public decimal Discount { get; set; }
    }
}
