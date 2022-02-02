using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicineItemPrice = new HashSet<MedicineItemPrice>();
            MedicineList = new HashSet<MedicineList>();
        }

        public int MedicineId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<MedicineItemPrice> MedicineItemPrice { get; set; }
        public virtual ICollection<MedicineList> MedicineList { get; set; }
    }
}
