using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Test
    {
        public Test()
        {
            TestPrice = new HashSet<TestPrice>();
            TestReport = new HashSet<TestReport>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public decimal? NormalRangeStart { get; set; }
        public decimal? NormalRangeEnd { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<TestPrice> TestPrice { get; set; }
        public virtual ICollection<TestReport> TestReport { get; set; }
    }
}
