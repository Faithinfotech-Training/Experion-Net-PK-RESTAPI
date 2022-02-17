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
    public class MedicineListRepo : IMedicineListRepo
    {
        private clinicalmanagementsystemContext _db;

        public MedicineListRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<MedicineList>> GetAllMedicineList()
        {
            return await _db.MedicineList.ToListAsync();
        }


        //------------------Add MedicineList--------------------------------------------------------------------------
        public async Task<int> AddMedicineList(MedicineList medList,int appoint)
        {
            if (_db != null)

            {
                var temp = await _db.MedicinePrescription.Where(x => x.AppointmentId == appoint).FirstOrDefaultAsync();
                if(temp==null)
                {
                    MedicinePrescription tempMedP = new MedicinePrescription();
                    tempMedP.AppointmentId = appoint;
                    tempMedP.Status = 1;
                   await _db.MedicinePrescription.AddAsync(tempMedP);
                   await _db.SaveChangesAsync();
                }
                temp = await _db.MedicinePrescription.Where(x => x.AppointmentId == appoint).FirstOrDefaultAsync();
                medList.MedicinePrescriptionId = temp.MedicinePrescriptionId;
                await _db.MedicineList.AddAsync(medList);
                await _db.SaveChangesAsync();
                return medList.MedicineListId;
            }
            return 0;
        }

        //------------------Update MedicineList--------------------------------------------------------------------------
        public async Task UpdateMedicineList(MedicineList medList)
        {
            _db.Entry(medList).State = EntityState.Modified;
            _db.MedicineList.Update(medList);
            await _db.SaveChangesAsync();
        }


        //------------------Get MedicineList By Id--------------------------------------------------------------------------
        public async Task<MedicineList> GetByMedicineListId(int id)
        {
            if (_db != null)
            {
                var result = await _db.MedicineList.FindAsync(id);
                return result;
            }
            return null;
        }

        //------------------Add Medicine Prescription then the List Of Meicines
        //------------------List Of Medicines Which comes under the prescription
        //--------------------------------------------------------
        public async Task<int> AddPresThenList(MedPresAndMedListInsertObject obj)
        {
            
            MedicinePrescription medPresObj = new MedicinePrescription();
            medPresObj.AppointmentId = obj.AppointmentId;
            medPresObj.PharmacistId = obj.PharmacistId;
            medPresObj.Status = obj.Status;

            await _db.MedicinePrescription.AddAsync(medPresObj);
            await _db.SaveChangesAsync();

            for (int i = 0; i < obj.MedicineId.Count; i++)
            {
                MedicineList medListObj = new MedicineList();
                medListObj.MedicinePrescriptionId = medPresObj.MedicinePrescriptionId;
                medListObj.MedicineId = obj.MedicineId[i];
                medListObj.Doze = obj.Doze[i];
                await _db.MedicineList.AddAsync(medListObj);
                await _db.SaveChangesAsync();
            }
            return 0;
        }


        public async Task RemoveMedFromList(int id)
        {
            var delObj = _db.MedicineList.Find(id);
            _db.Remove(delObj);
            await _db.SaveChangesAsync();
        }
    }
}
