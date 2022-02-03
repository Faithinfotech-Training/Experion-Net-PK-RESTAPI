using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IRoleRepo
    {


        Task<int> AddRole(Role usr);

        Task UpdateRole(Role usr);

        //Get By Id
        Task<Role> GetByRoleId(int a);
        Task<List<Role>> GetAllRole();
    }
}
