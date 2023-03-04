using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class BookingMedicine
    {
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int? AvailabilityMd { get; set; }
    }
}
