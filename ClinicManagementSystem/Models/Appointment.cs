using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Bill = new HashSet<Bill>();
            GeneralNotes = new HashSet<GeneralNotes>();
            MedicinePrescription = new HashSet<MedicinePrescription>();
            TestPrescription = new HashSet<TestPrescription>();
        }

        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ReceptionId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public int? TokenNumber { get; set; }
        public int? Status { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Users Reception { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<GeneralNotes> GeneralNotes { get; set; }
        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual ICollection<TestPrescription> TestPrescription { get; set; }
    }
}
