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
    public class AppointmentRepo : IAppointmentRepo
    {
        private clinicalmanagementsystemContext _db;

        public AppointmentRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Appointment>> GetAllAppointment()
        {
            return await _db.Appointment.ToListAsync();
        }
        //------------------Add Appointment--------------------------------------------------------------------------
        public async Task<int> AddAppointment(Appointment apnt)
        {
            if (_db != null)

            {
                await _db.Appointment.AddAsync(apnt);
                await _db.SaveChangesAsync();
                return apnt.AppointmentId;
            }
            return 0;
        }

        //------------------Update Appointment--------------------------------------------------------------------------
        public async Task UpdateAppointment(Appointment apnt)
        {
            _db.Entry(apnt).State = EntityState.Modified;
            _db.Appointment.Update(apnt);
            await _db.SaveChangesAsync();
        }


        //------------------By Id------------------------------------------------------------------------------------
        public async Task<Appointment> GetAppointmentById(int id)
        {
            if (_db != null)
            {
                var result = await _db.Appointment.FindAsync(id);
                return result;
            }
            return null;
        }

  

        //------------------View - View Model Appointment-------------------------------------------------------------
        public async Task<List<ApointForTodayView>> GetAllApointmentForTheDay()
        {
            return await  (

               ( from ap in _db.Appointment
                join pt in _db.Patient
                on ap.PatientId equals pt.PatientId
                join doc in _db.Doctor
                on ap.DoctorId equals doc.DoctorId
                join usr in _db.Users
                on doc.UserId equals usr.UserId
                where ap.Date == DateTime.Today
                select new ApointForTodayView
                {
                    patientId=(int)pt.PatientId,
                    status = (int)ap.Status,
                    date = (DateTime)ap.Date,
                    firstName = pt.FirstName,
                    lastName = pt.LastName,
                    docFirstName = usr.FirstName,
                    docLastName = usr.LastName,
                    token = (int)ap.TokenNumber
                } ).ToListAsync()
                );
        }

        


    }
}
