using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            Appointment = new HashSet<Appointment>();
            Doctor = new HashSet<Doctor>();
            MedicinePrescription = new HashSet<MedicinePrescription>();
            TestPrescription = new HashSet<TestPrescription>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? UserDob { get; set; }
        public string Phone { get; set; }
        public DateTime? JoinDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual ICollection<TestPrescription> TestPrescription { get; set; }
    }
}
