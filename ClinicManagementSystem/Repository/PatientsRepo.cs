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


        //------------------Get Patient By Id--------------------------------------------------------------------------
        public async Task<Patient> GetByPatientId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Patient.FindAsync(id);
                return result;
            }
            return null;
        }



        //-------------------------Final Bill-------------------------------------------------------------------------
        public async Task<BillDetails> GetBill(int AppointmentId)
        {
            var total = 0;
            var tempListTest = await (from ap in _db.Appointment
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
                                where ap.AppointmentId ==AppointmentId
                                select new
                                {
                                    TestName = tst.TestName,
                                    Price = tst.Price
                                }).ToListAsync() ;



            var temListMed = await (from ap in _db.Appointment
                                    join pt in _db.Patient
                                    on ap.PatientId equals pt.PatientId

                                    join doc in _db.Doctor
                                    on ap.DoctorId equals doc.DoctorId

                                    join usr in _db.Users
                                    on doc.UserId equals usr.UserId

                                    join rl in _db.Role
                                    on usr.RoleId equals rl.RoleId

                                    join medPres in _db.MedicinePrescription
                                    on ap.AppointmentId equals medPres.AppointmentId

                                    join medL in _db.MedicineList
                                    on medPres.MedicinePrescriptionId equals medL.MedicinePrescriptionId

                                    join med in _db.Medicine
                                    on medL.MedicineId equals med.MedicineId


                                    where ap.AppointmentId == AppointmentId


                                    select new
                                    {
                                        medName = med.Name,
                                        medPrice = med.Price
                                    }).ToListAsync();

            var generalDetails = await (from ap in _db.Appointment
                                        join pt in _db.Patient
                                        on ap.PatientId equals pt.PatientId

                                        join doc in _db.Doctor
                                        on ap.DoctorId equals doc.DoctorId

                                        join sp in _db.Specialization
                                        on doc.SpecializationId equals sp.SpecializationId
                                        join usr in _db.Users
                                        on doc.UserId equals usr.UserId

                                        where ap.AppointmentId == AppointmentId

                                        select new
                                        {
                                            patientName = pt.FirstName,
                                            patientLast = pt.LastName,
                                            docFName = usr.FirstName,
                                            docLName = usr.LastName,
                                            specialization = sp.SpecializationName,
                                            fee = sp.ConsultancyFee,
                                            dateOfAppoint = ap.Date,
                                            patientId = pt.PatientId,
                                            appointId = ap.AppointmentId
                                        }).ToListAsync();

            BillDetails returnDetails = new BillDetails();
            returnDetails.medList = new List<Medicine>();
            returnDetails.testList = new List<Test>();
            returnDetails.total = 0;
            foreach (var item in generalDetails)
            {
                returnDetails.appointId = item.appointId;
                returnDetails.patientId = item.patientId;
                returnDetails.patientName = item.patientName;
                returnDetails.docFName = item.docFName;
                returnDetails.patientLast = item.patientLast;
                returnDetails.specialization = item.specialization;
                returnDetails.fee = (double)item.fee;
                returnDetails.total = returnDetails.total + (double)item.fee;
                returnDetails.dateOfAppoint = Convert.ToString(item.dateOfAppoint);
            }

            foreach (var item in temListMed)
            {
                Medicine med = new Medicine();
                med.Name = item.medName;
                med.Price = item.medPrice;
                returnDetails.total = returnDetails.total + (double)item.medPrice;
                returnDetails.medList.Add(med);
            }
            foreach (var item in tempListTest)
            {
                Test tst = new Test();
                tst.TestName = item.TestName;
                tst.Price = item.Price;
                returnDetails.total = returnDetails.total + (double)item.Price;
                returnDetails.testList.Add(tst);
            }


            return  returnDetails;


        }

    }
}
