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
    public class SpecializationRepo : ISpecializationRepo
    {
        private clinicalmanagementsystemContext _db;

        public SpecializationRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Specialization>> GetAllSpecialization()
        {
            return await _db.Specialization.ToListAsync();
        }


        //------------------Add Specialization--------------------------------------------------------------------------
        public async Task<int> AddSpecialization(Specialization sp)
        {
            if (_db != null)

            {
                await _db.Specialization.AddAsync(sp);
                await _db.SaveChangesAsync();
                return sp.SpecializationId;
            }
            return 0;
        }

        //------------------Update Specialization----------------------------------Specialization----------------------------------------
        public async Task UpdateSpecialization(Specialization sp)
        {
            _db.Entry(sp).State = EntityState.Modified;
            _db.Specialization.Update(sp);
            await _db.SaveChangesAsync();
        }


        //------------------Get Specialization By Id--------------------------------------------------------------------------
        public async Task<Specialization> GetBySpecializationId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Specialization.FindAsync(id);
                return result;
            }
            return null;
        }

    }
}
