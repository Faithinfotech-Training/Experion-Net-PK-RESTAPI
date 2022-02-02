using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineBill
    {
        public MedicineBill()
        {
            MedicineItemPrice = new HashSet<MedicineItemPrice>();
        }

        public int MedicineBillId { get; set; }
        public int? MedicinePrescriptionId { get; set; }
        public int? Status { get; set; }

        public virtual MedicinePrescription MedicinePrescription { get; set; }
        public virtual ICollection<MedicineItemPrice> MedicineItemPrice { get; set; }
    }
}
