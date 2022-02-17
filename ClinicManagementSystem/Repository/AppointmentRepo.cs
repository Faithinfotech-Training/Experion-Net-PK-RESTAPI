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
                    appointmentId=ap.AppointmentId,
                    time=Convert.ToDateTime(ap.Time).ToString("HH:mm"),
                    patientId =(int)pt.PatientId,
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



        //------------------View - View Model Appointment For a Docttor-------------------------------------------------------------
        public async Task<List<ApointForTodayView>> GetAllApointmentForTheDayFoADoctor(int id)
        {
            return await (

              (from ap in _db.Appointment
               join pt in _db.Patient
               on ap.PatientId equals pt.PatientId
               join doc in _db.Doctor
               on ap.DoctorId equals doc.DoctorId
               join usr in _db.Users
               on doc.UserId equals usr.UserId
               where ap.Date == DateTime.Today && doc.UserId == id
               select new ApointForTodayView
               {
                
                   appointmentId=ap.AppointmentId,
                   patientId = (int)pt.PatientId,
                   status = (int)ap.Status,
                   date = (DateTime)ap.Date,
                   time= Convert.ToDateTime(ap.Time).ToString("HH:mm"),
                   firstName = pt.FirstName, 
                   lastName = pt.LastName,
                   docFirstName = usr.FirstName,
                   docLastName = usr.LastName,
                   token = (int)ap.TokenNumber
               }).ToListAsync()
               );
        }


        //----------------------------Next Token ------------------------------------------------------------------------------------

        public  int GetNextToken(DateTime appointDate)
        {
            if(_db.Appointment.Where(x=>x.Date== appointDate).Count()==0)
            {
                return 0;
            }
            return (
                (int)(from ap in _db.Appointment
                 where ap.Date == appointDate
                 select ap.TokenNumber).Max(x => x)
                );
        }


        public async Task patchUpdAppointment()
        {

        }
    }
}
