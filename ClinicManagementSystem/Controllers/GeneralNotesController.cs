using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralNotesController : ControllerBase
    {
        private IGeneralNotesRepo _intrface;

        public GeneralNotesController(IGeneralNotesRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<GeneralNotes>> GetAllRole()
        {
            return await _intrface.GetAllNotes();
        }

        [HttpPost]

        public async Task<int> AddGeneralNotes(GeneralNotes notes)
        {
            return await _intrface.AddGeneralNotes(notes);
        }

    }


}
