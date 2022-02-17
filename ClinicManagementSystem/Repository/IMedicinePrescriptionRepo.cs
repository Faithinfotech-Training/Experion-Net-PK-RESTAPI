using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicinePrescriptionRepo
    {

        Task<int> AddMedicinePrescription(MedicinePrescription usr);

        Task UpdateMedicinePrescription(MedicinePrescription usr);

        Task<List<MedicinePrescription>> GetAllMedicinePrescription();

        //Get By Id
        Task<MedicinePrescription> GetByMedicinePrescriptionId(int a);

        //View For List Of Medicine Prescribed in an Appointment
        Task<MedPrescAppointView> GetAllMedPrescribedInAnAppointment(int id);

        Task<List<MedPrescAppointView>> GetAllMedPrescriptionForTheDay();
    }
}
