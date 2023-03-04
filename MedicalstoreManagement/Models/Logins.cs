using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class Logins
    {
        public int LoginId { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; }
        public DateTime? ActionAt { get; set; }
    }
}
