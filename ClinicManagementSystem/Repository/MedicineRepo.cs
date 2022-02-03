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
    public class MedicineRepo : IMedicineRepo
    {
        private clinicalmanagementsystemContext _db;

        public MedicineRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Medicine>> GetAllMedicine()
        {
            return await _db.Medicine.ToListAsync();
        }


        //------------------Add Medicine--------------------------------------------------------------------------
        public async Task<int> AddMedicine(Medicine med)
        {
            if (_db != null)

            {
                await _db.Medicine.AddAsync(med);
                await _db.SaveChangesAsync();
                return med.MedicineId;
            }
            return 0;
        }

        //------------------Update Medicine--------------------------------------------------------------------------
        public async Task UpdateMedicine(Medicine med)
        {
            _db.Entry(med).State = EntityState.Modified;
            _db.Medicine.Update(med);
            await _db.SaveChangesAsync();
        }


        //------------------Get Medicine By Id--------------------------------------------------------------------------
        public async Task<Medicine> GetByMedicineId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Medicine.FindAsync(id);
                return result;
            }
            return null;
        }


    }
}
