using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicineListRepo
    {

        Task<int> AddMedicineList(MedicineList usr);

        Task UpdateMedicineList(MedicineList usr);

        //Get By Id
        Task<MedicineList> GetByMedicineListId(int a);

        Task<List<MedicineList>> GetAllMedicineList();

        Task<int> AddPresThenList(MedPresAndMedListInsertObject obj);
    }
}
