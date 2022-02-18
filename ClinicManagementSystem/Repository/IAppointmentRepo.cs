using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IAppointmentRepo
    {
        
        Task<List<ApointForTodayView>> GetAllApointmentForTheDay();

        Task<List<ApointForTodayView>> GetAllApointmentForTheDayFoADoctor(int id);
        Task<int> AddAppointment(Appointment apnt);

        Task UpdateAppointment(Appointment apnt);

        //Get By Id
        Task<Appointment> GetAppointmentById(int a);

        Task<List<Appointment>> GetAllAppointment();

        //ApointForTodayView is used here becoz it have all the details which i want for the.. All appointments for a patients 
        Task<List<ApointForTodayView>> GetAllAppointmentOfAPatient(int id);

        int GetNextToken(DateTime appointDate);

    }
}
