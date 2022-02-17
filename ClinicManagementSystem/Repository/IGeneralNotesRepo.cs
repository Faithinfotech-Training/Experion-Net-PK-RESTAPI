using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IGeneralNotesRepo
    {
        Task<int> AddGeneralNotes(GeneralNotes notes);
        Task<List<GeneralNotes>> GetAllNotes();

        //Task UpdateTest(Test usr);

        ////Get By Id
        //Task<Test> GetByTestId(int a);

        //Task<List<Test>> GetAllTest();
    }
}
