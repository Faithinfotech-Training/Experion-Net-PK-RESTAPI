using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestReport
    {
        public int TestReportId { get; set; }
        public int? TestPrescriptionId { get; set; }
        public int? TestId { get; set; }
        public decimal? TestValue { get; set; }

        public virtual Test Test { get; set; }
        public virtual TestPrescription TestPrescription { get; set; }
    }
}
