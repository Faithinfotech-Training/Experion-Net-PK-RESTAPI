using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class BillDetails
    {
        public double total { get; set; }
        public string patientName { get; set; }
        public string patientLast { get; set; }
        public string docFName { get; set; }
        public string docLName { get; set; }
        public string specialization { get; set; }
        public double fee { get; set; }
        public string dateOfAppoint { get; set; }
        public int patientId { get; set; }
        public int appointId { get; set; }
        public List<Medicine> medList { get; set; }
        public List<Test> testList  { get; set; }
    }
}
