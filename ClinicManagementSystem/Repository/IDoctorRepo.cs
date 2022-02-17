using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IDoctorRepo
    {
        Task<List<AllDrSpView>> GetAllDrSp(int id);

        Task<int> AddDoctor(Doctor doc);

        Task UpdateDoctor(Doctor doc);

        Task<Doctor> GetDoctorById(int a);
        Task<List<Doctor>> GetAllDoctor();
    }
}

