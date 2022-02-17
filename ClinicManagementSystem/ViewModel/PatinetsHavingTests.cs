using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class PatinetsHavingTests
    {
        public int PatientId{get; set;} 
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public int TestPrescriptionID { get; set; }
       public string FirstName { get; set; }

        public int AppointmentId { get; set; }
        public string LastName { get; set; }
        public string DocFirstName { get; set; }
        public string DocLastName { get; set; }
        
        public int Token { get; set; }
    }
}
