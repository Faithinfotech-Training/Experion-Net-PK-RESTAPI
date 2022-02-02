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

        Task<List<Patient>> GetAllPatient();
    }
}
