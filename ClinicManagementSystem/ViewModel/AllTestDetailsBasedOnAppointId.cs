using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class AllTestDetailsBasedOnAppointId
    {
        public int appointId { get; set; }
        public int testId { get; set; }
        public string testName{ get; set; }
        public string teststartVal{ get; set; }
        public string testEndVal{ get; set; }
        public string testMeasureVal{ get; set; }
    }
}
