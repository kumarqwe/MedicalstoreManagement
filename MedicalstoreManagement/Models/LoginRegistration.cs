using System;
using System.Collections.Generic;

namespace MedicalstoreManagement.Models
{
    public partial class LoginRegistration
    {
        public int UserId { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
