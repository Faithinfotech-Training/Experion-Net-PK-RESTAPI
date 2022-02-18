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
    public class MedicinePrescriptionRepo : IMedicinePrescriptionRepo
    {
        private clinicalmanagementsystemContext _db;

        public MedicinePrescriptionRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<MedicinePrescription>> GetAllMedicinePrescription()
        {
            return await _db.MedicinePrescription.ToListAsync();
        }


        //------------------Add MedicinePrescription--------------------------------------------------------------------------
        public async Task<int> AddMedicinePrescription(MedicinePrescription medPr)
        {
            if (_db != null)

            {
                await _db.MedicinePrescription.AddAsync(medPr);
                await _db.SaveChangesAsync();
                return medPr.MedicinePrescriptionId;
            }
            return 0;
        }

        //------------------Update MedicinePrescription--------------------------------------------------------------------------
        public async Task UpdateMedicinePrescription(MedicinePrescription medPr)
        {
            _db.Entry(medPr).State = EntityState.Modified;
            _db.MedicinePrescription.Update(medPr);
            await _db.SaveChangesAsync();
        }


        //-----------------------------Medicine Prescription for the Day----------------------------------------------------------

        public async Task<List<MedPrescAppointView>> GetAllMedPrescriptionForTheDay()
        {
            return await (
                (from ap in _db.Appointment
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




                

                 where ap.Date == DateTime.Today
                 select new MedPrescAppointView
                 {
                     appointmentId = ap.AppointmentId,
                     patientId = pt.PatientId,
                     status = (int)ap.Status,
                     date = (DateTime)ap.Date,
                     firstName = pt.FirstName,
                     lastName = pt.LastName,
                     docFirstName = usr.FirstName,
                     docLastName = usr.LastName
                 ,
                     token = (int)ap.TokenNumber
                 }).ToListAsync()
                );
        }


            //------------------Get MedicinePrescription For An Appointment-------------------------------------------------------------
            public async Task<MedPrescAppointView> GetAllMedPrescribedInAnAppointment(int id)
        {
            var tempObj = await (from ap in _db.Appointment
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

                                 join general in _db.GeneralNotes
                                 on ap.AppointmentId equals general.AppointmentId

                                 join medL in _db.MedicineList
                                 on medPres.MedicinePrescriptionId equals medL.MedicinePrescriptionId

                                 join med in _db.Medicine
                                 on medL.MedicineId equals med.MedicineId



                                 where ap.AppointmentId == id

                                 select new
                                 {
                                     time=ap.Time,
                                     general=general.Notes,
                                     medId=med.MedicineId,
                                     appointmentId =ap.AppointmentId,
                                     patientId = pt.PatientId,
                                     staus = ap.Status,
                                     date = ap.Date,
                                     doze=medL.Doze,
                                     firstName = pt.FirstName,
                                     lastName = pt.LastName,
                                     docFirstName = usr.FirstName,
                                     docLastName = usr.LastName
                                 ,
                                     token = ap.TokenNumber
                                 ,
                                     medName = med.Name
                                 }).ToListAsync();

            var result = tempObj.GroupBy(x=>x.patientId);
            MedPrescAppointView objResult = new MedPrescAppointView();



            foreach (var patientGroup in result)
            {
                objResult.patientId = patientGroup.Key;
                foreach(var patient in patientGroup)
                {
                    objResult.generalNotes = patient.general;
                    objResult.time = Convert.ToDateTime(patient.time).ToString("HH:mm");
                    objResult.patientId = patient.patientId;
                    objResult.firstName = patient.firstName;
                    objResult.lastName = patient.lastName;
                    medicineWithMedId medObj = new medicineWithMedId();
                    medObj.medName = patient.medName;
                    medObj.medId = patient.medId;
                    medObj.doze = (int)patient.doze;
                    objResult.medName.Add(medObj);
                    objResult.date = (DateTime)patient.date;
                    objResult.status = (int) patient.staus;
                    objResult.docFirstName = patient.docFirstName;
                    objResult.docLastName = patient.docLastName;
                    objResult.token = (int)patient.token;
                }
            }

            return objResult;
        }


        //------------------Get MedicinePrescription By Id--------------------------------------------------------------------------
        public async Task<MedicinePrescription> GetByMedicinePrescriptionId(int id)
        {
            if (_db != null)
            {
                var result = await _db.MedicinePrescription.FindAsync(id);
                return result;
            }
            return null;
        }



    }
}
