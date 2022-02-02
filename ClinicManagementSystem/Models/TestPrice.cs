using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestPrice
    {
        public int TestPriceId { get; set; }
        public int? TestBillId { get; set; }
        public int? TestId { get; set; }
        public decimal? Price { get; set; }

        public virtual Test Test { get; set; }
        public virtual TestBill TestBill { get; set; }
    }
}
