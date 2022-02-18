using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class TestReportUsingAppointId
    {
        public int testReportId { get; set; }
        public int patientId { get; set; } 
        public string unit { get; set; }
        public int status { get; set; }
        public DateTime date { get; set; }
        public int testId { get; set; }
        public int appointId { get; set; }
        public int testPrescriptionID { get; set; }
        public double testStartVal  { get; set; }
        public double testEndVal { get; set; }
        public double testValueMeasured { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string docFirstName { get; set; }
        public string docLastName { get; set; }
        public int token { get; set; }
        public string testName { get; set; }
    }
}
