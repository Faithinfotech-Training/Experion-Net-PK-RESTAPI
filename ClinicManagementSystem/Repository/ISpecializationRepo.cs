using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface ISpecializationRepo
    {

        Task<int> AddSpecialization(Specialization usr);

        Task UpdateSpecialization(Specialization usr);

        //Get By Id
        Task<Specialization> GetBySpecializationId(int a);

        Task<List<Specialization>> GetAllSpecialization();
    }
}
