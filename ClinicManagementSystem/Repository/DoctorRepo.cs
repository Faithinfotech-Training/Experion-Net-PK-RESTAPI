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
    public class DoctorRepo : IDoctorRepo
    {
        private clinicalmanagementsystemContext _db;

        public DoctorRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }


        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Doctor>> GetAllDoctor()
        {
            return await _db.Doctor.ToListAsync();
        }


        //------------------Add Doctor--------------------------------------------------------------------------
        public async Task<int> AddDoctor(Doctor doc)
        {
            if (_db != null)

            {
                await _db.Doctor.AddAsync(doc);
                await _db.SaveChangesAsync();
                return doc.DoctorId;
            }
            return 0;
        }

        //------------------Update Doctor--------------------------------------------------------------------------
        public async Task UpdateDoctor(Doctor doc)
        {
            _db.Entry(doc).State = EntityState.Modified;
            _db.Doctor.Update(doc);
            await _db.SaveChangesAsync();
        }

        //------------------By Id------------------------------------------------------------------------------------
        public async Task<Doctor> GetDoctorById(int id)
        {
            if (_db != null)
            {
                var result = await _db.Doctor.FindAsync(id);
                return result;
            }
            return null;
        }

        public async Task<List<AllDrSpView>> GetAllDrSp()
        {
            return await (
                (from doc in _db.Doctor
                 join usr in _db.Users
                 on doc.UserId equals usr.UserId
                 join sp in _db.Specialization
                 on doc.SpecializationId equals sp.SpecializationId
                 select new AllDrSpView
                 {
                     doctorId = doc.DoctorId,
                     docFirstName = usr.FirstName,
                     docLastName = usr.LastName,
                     specializationID = sp.SpecializationId,
                     SpecializationName = sp.SpecializationName
                 }).ToListAsync()
                ) ;
        }
    }
}
