using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestBill
    {
        public TestBill()
        {
            TestPrice = new HashSet<TestPrice>();
        }

        public int TestBillId { get; set; }
        public int? TestPrescriptionId { get; set; }
        public int? Status { get; set; }

        public virtual TestPrescription TestPrescription { get; set; }
        public virtual ICollection<TestPrice> TestPrice { get; set; }
    }
}
