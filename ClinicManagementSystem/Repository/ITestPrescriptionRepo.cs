using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface ITestPrescriptionRepo
    {

        Task<int> AddTestPrescription(TestPrescription usr);

        Task UpdateTestPrescription(TestPrescription usr);

        //Get By Id
        Task<TestPrescription> GetByTestPrescriptionId(int a);
        Task<List<TestPrescription>> GetAllTestPrescription();

        Task<List<PatinetsHavingTests>> GetAllTestPrescribedForTheDay();
    }
}
