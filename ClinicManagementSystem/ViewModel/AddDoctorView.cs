using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModel
{
    public class AddDoctorView
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public DateTime UserDob { get; set; }
        public DateTime JoinDate { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Specialization { get; set; }
        public string State { get; set; }
        public string UserName { get; set; }

        public int RoleId { get; set; }


    }
}
