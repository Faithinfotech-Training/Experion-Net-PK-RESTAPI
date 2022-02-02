using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicineRepo
    {

        Task<int> AddMedicine(Medicine usr);

        Task UpdateMedicine(Medicine usr);

        //Get By Id
        Task<Medicine> GetByMedicineId(int a);

        Task<List<Medicine>> GetAllMedicine();
    }
}
