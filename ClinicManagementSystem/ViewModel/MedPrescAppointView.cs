using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class MedPrescAppointView
    {
        public int appointmentId;
        public int patientId;
        public int status;
        public string time;
        public DateTime date;
        public string generalNotes;
        public string firstName;
        public string lastName;
        public string docFirstName;
        public string docLastName;
        public int token;
        public List<medicineWithMedId> medName = new List<medicineWithMedId>();
        //public string pharmaFirstName;
        //public string pharmaLastName;
    }
}
