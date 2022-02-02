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
    public class TestPriceRepo : ITestPriceRepo
    {
        private clinicalmanagementsystemContext _db;

        public TestPriceRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<TestPrice>> GetAllTestPrice()
        {
            return await _db.TestPrice.ToListAsync();
        }


        //------------------Add TestPrice--------------------------------------------------------------------------
        public async Task<int> AddTestPrice(TestPrice tstPr)
        {
            if (_db != null)

            {
                await _db.TestPrice.AddAsync(tstPr);
                await _db.SaveChangesAsync();
                return tstPr.TestPriceId;
            }
            return 0;
        }

        //------------------Update TestPrice--------------------------------------------------------------------------
        public async Task UpdateTestPrice(TestPrice tstPr)
        {
            _db.Entry(tstPr).State = EntityState.Modified;
            _db.TestPrice.Update(tstPr);
            await _db.SaveChangesAsync();
        }


        //------------------Get TestPrice By Id--------------------------------------------------------------------------
        public async Task<TestPrice> GetByTestPriceId(int id)
        {
            if (_db != null)
            {
                var result = await _db.TestPrice.FindAsync(id);
                return result;
            }
            return null;
        }

    }
}
