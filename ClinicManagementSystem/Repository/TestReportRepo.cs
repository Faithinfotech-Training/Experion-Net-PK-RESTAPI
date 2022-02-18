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
        public async Task<int> AddTestReport(TestReport tstRp,int appointId)
        {
            if (_db != null)

            {
                var temp = _db.TestPrescription.Where(x => x.AppointmentId == appointId).FirstOrDefault();
                if(temp==null)
                {
                    TestPrescription testPre = new TestPrescription();
                    testPre.AppointmentId = appointId;
                    testPre.Status = 1;
                    await _db.TestPrescription.AddAsync(testPre);
                    await _db.SaveChangesAsync();
                }
                temp = _db.TestPrescription.Where(x => x.AppointmentId == appointId).FirstOrDefault();
                tstRp.TestPrescriptionId = temp.TestPrescriptionId;
                await _db.TestReport.AddAsync(tstRp);
                await _db.SaveChangesAsync();
                return tstRp.TestReportId;
            }
            return 0;
        }

        //------------------Update TestReport- Patch--------------------------------------------------------------------------
        public async Task UpdateTestReport(PatchTestValueOfReport tstRp)
        {
           var updTestRp= _db.TestReport.Find(tstRp.TestReportId);
            updTestRp.TestValue = tstRp.TestValue;
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

        //------------------Get TestReport And all Details Using Appointment Id / Can Use That Same for geting using TestPrescriptionId--------------------------------------------------------------------------

        public async Task<List<TestReportUsingAppointId>> GetAllTestReportDetailsUsingAppointId(int id)
        {
            return await (
                (from ap in _db.Appointment
                 join pt in _db.Patient
                 on ap.PatientId equals pt.PatientId
                 join doc in _db.Doctor
                 on ap.DoctorId equals doc.DoctorId
                 join usr in _db.Users
                 on doc.UserId equals usr.UserId
                 join testPres in _db.TestPrescription
                 on ap.AppointmentId equals testPres.AppointmentId
                 join testR in _db.TestReport
                 on testPres.TestPrescriptionId equals testR.TestPrescriptionId
                 join tst in _db.Test
                 on testR.TestId equals tst.TestId
                 where ap.AppointmentId == id
                 select new TestReportUsingAppointId
                 {
                     testReportId=testR.TestReportId,
                     unit=tst.Unit,
                     patientId = pt.PatientId,
                     status = (int)ap.Status,
                     date = (DateTime)ap.Date,
                     testId = tst.TestId,
                     appointId = ap.AppointmentId,
                     testPrescriptionID = testPres.TestPrescriptionId,
                     testStartVal = (double)tst.NormalRangeStart,
                     testEndVal = (double)tst.NormalRangeEnd,
                     testValueMeasured = (double)testR.TestValue,
                     firstName = pt.FirstName,
                     lastName = pt.LastName,
                     docFirstName = usr.FirstName,
                     docLastName = usr.LastName
                 ,
                     token = (int)ap.TokenNumber
                 ,
                     testName = tst.TestName
                 }).ToListAsync()
                );
        }

        public async Task deleteFromList(int id)
        {
            _db.TestReport.Remove(_db.TestReport.Find(id));
            await _db.SaveChangesAsync();
        }
    }
}
