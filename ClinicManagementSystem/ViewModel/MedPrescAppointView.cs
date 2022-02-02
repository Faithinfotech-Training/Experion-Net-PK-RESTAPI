using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class MedPrescAppointView
    {
        public int patientId;
        public int status;
        public DateTime date;
        public string firstName;
        public string lastName;
        public string docFirstName;
        public string docLastName;
        public int token;
        public List<string> medName = new List<string>();
        public string pharmaFirstName;
        public string pharmaLastName;
    }
}
