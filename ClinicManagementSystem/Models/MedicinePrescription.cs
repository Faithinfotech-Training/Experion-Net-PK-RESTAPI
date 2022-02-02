using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicinePrescription
    {
        public MedicinePrescription()
        {
            MedicineBill = new HashSet<MedicineBill>();
            MedicineList = new HashSet<MedicineList>();
        }

        public int MedicinePrescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public int? PharmacistId { get; set; }
        public int? Status { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Users Pharmacist { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<MedicineList> MedicineList { get; set; }
    }
}
