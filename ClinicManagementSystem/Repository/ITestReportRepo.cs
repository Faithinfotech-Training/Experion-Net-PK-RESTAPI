using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface ITestReportRepo
    {

        Task<int> AddTestReport(TestReport usr);

        Task UpdateTestReport(TestReport usr);

        //Get By Id
        Task<TestReport> GetByTestReportId(int a);
        Task<List<TestReport>> GetAllTestReport();
    }
}
