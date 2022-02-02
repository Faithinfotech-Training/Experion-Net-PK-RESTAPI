using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineItemPrice
    {
        public int MedicinePriceId { get; set; }
        public int? MedicineBillId { get; set; }
        public int? MedicineId { get; set; }
        public decimal? Price { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual MedicineBill MedicineBill { get; set; }
    }
}
