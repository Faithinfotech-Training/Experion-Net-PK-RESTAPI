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
    public class PatientsRepo : IPatientsRepo
    {
        private clinicalmanagementsystemContext _db;

        public PatientsRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Patient>> GetAllPatient()
        {
            return await _db.Patient.ToListAsync();
        }


        //------------------Add Patient--------------------------------------------------------------------------
        public async Task<int> AddPatient(Patient pt)
        {
            if (_db != null)

            {
                await _db.Patient.AddAsync(pt);
                await _db.SaveChangesAsync();
                return pt.PatientId;
            }
            return 0;
        }

        //------------------Update Patient--------------------------------------------------------------------------
        public async Task UpdatePatient(Patient pt)
        {
            _db.Entry(pt).State = EntityState.Modified;
            _db.Patient.Update(pt);
            await _db.SaveChangesAsync();
        }

    }
}
