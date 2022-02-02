using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? AppointmentId { get; set; }
        public int? Status { get; set; }
        public decimal? Amount { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
