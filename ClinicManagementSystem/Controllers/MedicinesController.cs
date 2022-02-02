using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {

        private IMedicineRepo _intrface;

        public MedicinesController(IMedicineRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Medicine>> GetAllMedicine()
        {
            return await _intrface.GetAllMedicine();
        }


        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicineById(int id)
        {
            try
            {
                var result = await _intrface.GetByMedicineId(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result; //return Ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //Add Medicine
        [HttpPost]
        public async Task<IActionResult> AddMedicine([FromBody] Medicine apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddMedicine(apnt);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //Update Medicine
        [HttpPut]
        public async Task<IActionResult> UpdMedicine([FromBody] Medicine apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateMedicine(apnt);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
