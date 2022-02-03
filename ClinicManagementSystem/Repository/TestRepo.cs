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
    public class TestRepo : ITestRepo
    {
        private clinicalmanagementsystemContext _db;

        public TestRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Test>> GetAllTest()
        {
            return await _db.Test.ToListAsync();
        }


        //------------------Add Test--------------------------------------------------------------------------
        public async Task<int> AddTest(Test tst)
        {
            if (_db != null)

            {
                await _db.Test.AddAsync(tst);
                await _db.SaveChangesAsync();
                return tst.TestId;
            }
            return 0;
        }

        //------------------Update Test--------------------------------------------------------------------------
        public async Task UpdateTest(Test tst)
        {
            _db.Entry(tst).State = EntityState.Modified;
            _db.Test.Update(tst);
            await _db.SaveChangesAsync();
        }

        //------------------Get Test By Id--------------------------------------------------------------------------
        public async Task<Test> GetByTestId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Test.FindAsync(id);
                return result;
            }
            return null;
        }
    }
}
