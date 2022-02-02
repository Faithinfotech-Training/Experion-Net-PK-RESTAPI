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
    public class MedicineItemPriceRepo : IMedicineItemPriceRepo
    {
        private clinicalmanagementsystemContext _db;

        public MedicineItemPriceRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<MedicineItemPrice>> GetAllMedicineItemPrice()
        {
            return await _db.MedicineItemPrice.ToListAsync();
        }


        //------------------Add MedicineItemPrice--------------------------------------------------------------------------
        public async Task<int> AddMedicineItemPrice(MedicineItemPrice usr)
        {
            if (_db != null)

            {
                await _db.MedicineItemPrice.AddAsync(usr);
                await _db.SaveChangesAsync();
                return usr.MedicinePriceId;
            }
            return 0;
        }

        //------------------Update MedicineItemPrice--------------------------------------------------------------------------
        public async Task UpdateMedicineItemPrice(MedicineItemPrice usr)
        {
            _db.Entry(usr).State = EntityState.Modified;
            _db.MedicineItemPrice.Update(usr);
            await _db.SaveChangesAsync();
        }

        //------------------Get MedicineItemPrice By Id--------------------------------------------------------------------------
        public async Task<MedicineItemPrice> GetByMedicineItemPriceId(int id)
        {
            if (_db != null)
            {
                var result = await _db.MedicineItemPrice.FindAsync(id);
                return result;
            }
            return null;
        }
    }
}
