using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface ITestPriceRepo
    {

        Task<int> AddTestPrice(TestPrice usr);

        Task UpdateTestPrice(TestPrice usr);

        //Get By Id
        Task<TestPrice> GetByTestPriceId(int a);
        Task<List<TestPrice>> GetAllTestPrice();
    }
}
