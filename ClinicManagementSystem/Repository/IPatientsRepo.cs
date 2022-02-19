using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IPatientsRepo
    {

        Task<int> AddPatient(Patient usr);

        Task UpdatePatient(Patient usr);
        
        //Get By Id
        Task<Patient> GetByPatientId(int a);

        Task<List<Patient>> GetAllPatient();

        Task<BillDetails> GetBill(int AppointmentId);
    }
}
