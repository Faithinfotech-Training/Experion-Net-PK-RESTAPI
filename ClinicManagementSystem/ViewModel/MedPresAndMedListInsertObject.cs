using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class MedPresAndMedListInsertObject
    {

        public int MedicineListId { get; set; }

        public List<int> MedicineId = new List<int>();

        public List<int> Doze = new List<int>();

        public int? AppointmentId { get; set; }
        public int? PharmacistId { get; set; }
        public int? Status { get; set; }
    }
}
