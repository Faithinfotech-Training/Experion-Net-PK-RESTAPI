using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class ApointForTodayView
    {
        public int appointmentId;
        public int status;
        public DateTime date;
        public string time;
        public int patientId;
        public string firstName;
        public string lastName;
        public string docFirstName;
        public string docLastName;
        public string specialisation;
        public int token;
    }
}
