using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public double? ConsultancyFee { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
