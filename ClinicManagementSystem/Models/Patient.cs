using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Date { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
