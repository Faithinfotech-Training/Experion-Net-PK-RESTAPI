using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestPrescription
    {
        public TestPrescription()
        {
            TestBill = new HashSet<TestBill>();
            TestReport = new HashSet<TestReport>();
        }

        public int TestPrescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public int? LabTechnicianId { get; set; }
        public int? Status { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Users LabTechnician { get; set; }
        public virtual ICollection<TestBill> TestBill { get; set; }
        public virtual ICollection<TestReport> TestReport { get; set; }
    }
}
