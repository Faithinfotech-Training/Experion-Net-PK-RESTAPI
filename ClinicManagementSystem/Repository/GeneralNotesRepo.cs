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
    public class GeneralNotesRepo : IGeneralNotesRepo
    {
        private clinicalmanagementsystemContext _db;

        public GeneralNotesRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<GeneralNotes>> GetAllNotes()
        {
            return await _db.GeneralNotes.ToListAsync();
        }


        //------------------Add Test--------------------------------------------------------------------------
        public async Task<int> AddGeneralNotes(GeneralNotes notes)
        {
            if (_db != null)

            {
                var temp = await _db.GeneralNotes.Where(x => x.AppointmentId == notes.AppointmentId).FirstOrDefaultAsync();
                if(temp!=null)
                {
                    _db.GeneralNotes.Remove(temp);
                    await _db.SaveChangesAsync();

                }
                var temp2= await _db.Appointment.Where(x => x.AppointmentId == notes.AppointmentId).FirstOrDefaultAsync();
                temp2.Status = 0;
                await _db.SaveChangesAsync();

                await _db.GeneralNotes.AddAsync(notes);
                await _db.SaveChangesAsync();
                return notes.GeneralNoteId;
            }
            return 0;
        }

        ////------------------Update Test--------------------------------------------------------------------------
        //public async Task UpdateTest(Test tst)
        //{
        //    _db.Entry(tst).State = EntityState.Modified;
        //    _db.Test.Update(tst);
        //    await _db.SaveChangesAsync();
        //}

        ////------------------Get Test By Id--------------------------------------------------------------------------
        //public async Task<Test> GetByTestId(int id)
        //{
        //    if (_db != null)
        //    {
        //        var result = await _db.Test.FindAsync(id);
        //        return result;
        //    }
        //    return null;
        //}

    }
}
