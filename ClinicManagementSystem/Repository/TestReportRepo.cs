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
    public class TestReportRepo : ITestReportRepo
    {
        private clinicalmanagementsystemContext _db;

        public TestReportRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<TestReport>> GetAllTestReport()
        {
            return await _db.TestReport.ToListAsync();
        }


        //------------------Add TestReport--------------------------------------------------------------------------
        public async Task<int> AddTestReport(TestReport tstRp)
        {
            if (_db != null)

            {
                await _db.TestReport.AddAsync(tstRp);
                await _db.SaveChangesAsync();
                return tstRp.TestReportId;
            }
            return 0;
        }

        //------------------Update TestReport--------------------------------------------------------------------------
        public async Task UpdateTestReport(TestReport tstRp)
        {
            _db.Entry(tstRp).State = EntityState.Modified;
            _db.TestReport.Update(tstRp);
            await _db.SaveChangesAsync();
        }

        //------------------Get TestReport By Id--------------------------------------------------------------------------
        public async Task<TestReport> GetByTestReportId(int id)
        {
            if (_db != null)
            {
                var result = await _db.TestReport.FindAsync(id);
                return result;
            }
            return null;
        }
    }
}
