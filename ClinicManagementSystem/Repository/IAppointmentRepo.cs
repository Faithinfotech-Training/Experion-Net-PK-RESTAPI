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

        Task<int> AddAppointment(Appointment apnt);

        Task UpdateAppointment(Appointment apnt);

        //Get By Id
        Task<Appointment> GetAppointmentById(int a);

        Task<List<Appointment>> GetAllAppointment();
    }
}
