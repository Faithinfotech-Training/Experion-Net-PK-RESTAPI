using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class MedicineListRepo : IMedicineListRepo
    {
        private clinicalmanagementsystemContext _db;

        public MedicineListRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<MedicineList>> GetAllMedicineList()
        {
            return await _db.MedicineList.ToListAsync();
        }


        //------------------Add MedicineList--------------------------------------------------------------------------
        public async Task<int> AddMedicineList(MedicineList medList)
        {
            if (_db != null)

            {
                await _db.MedicineList.AddAsync(medList);
                await _db.SaveChangesAsync();
                return medList.MedicineListId;
            }
            return 0;
        }

        //------------------Update MedicineList--------------------------------------------------------------------------
        public async Task UpdateMedicineList(MedicineList medList)
        {
            _db.Entry(medList).State = EntityState.Modified;
            _db.MedicineList.Update(medList);
            await _db.SaveChangesAsync();
        }


        //------------------Get MedicineList By Id--------------------------------------------------------------------------
        public async Task<MedicineList> GetByMedicineListId(int id)
        {
            if (_db != null)
            {
                var result = await _db.MedicineList.FindAsync(id);
                return result;
            }
            return null;
        }
    }
}
