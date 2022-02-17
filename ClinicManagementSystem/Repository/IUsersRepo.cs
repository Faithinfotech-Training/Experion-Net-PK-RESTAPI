using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IUsersRepo
    {

        Task<int> AddUsers(Users usr);

        Task UpdateUsers(Users usr);

        //Get By Id
        Task<Users> GetByUsersId(int a);
        Task<List<Users>> GetAllUsers();

        Task<Users> GetUserByUserNamePassword(string userName, string passWord);

        Task<AddDoctorView> GetDoctorDetailsByUserID(int id);

        Task<int> AddDoctor(AddDoctorView usr);

        Task UpdDoctor(AddDoctorView usr);
    }
}
