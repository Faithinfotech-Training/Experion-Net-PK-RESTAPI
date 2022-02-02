using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineList
    {
        public int MedicineListId { get; set; }
        public int? MedicinePrescriptionId { get; set; }
        public int? MedicineId { get; set; }
        public int? Doze { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual MedicinePrescription MedicinePrescription { get; set; }
    }
}
