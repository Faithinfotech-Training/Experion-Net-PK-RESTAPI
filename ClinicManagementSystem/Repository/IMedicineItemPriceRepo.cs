using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicineItemPriceRepo
    {

        Task<int> AddMedicineItemPrice(MedicineItemPrice usr);

        Task UpdateMedicineItemPrice(MedicineItemPrice usr);

        //Get By Id
        Task<MedicineItemPrice> GetByMedicineItemPriceId(int a);

        Task<List<MedicineItemPrice>> GetAllMedicineItemPrice();
    }
}
