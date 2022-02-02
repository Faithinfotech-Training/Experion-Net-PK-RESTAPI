using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Doctor Details API

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private IDoctorRepo _intrface;

        public DoctorsController(IDoctorRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        // GET: api/<DoctorController>/specialisation
        [HttpGet("specialisation")]
        public async Task<List<AllDrSpView>> GetAllDrSp()
        {
            return await _intrface.GetAllDrSp();
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Doctor>> GetAllDoctor()
        {
            return await _intrface.GetAllDoctor();
        }

        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            try
            {
                var result = await _intrface.GetDoctorById(id);
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


        //Add Doctor
        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddDoctor(apnt);
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


        //Update Doctor
        [HttpPut]
        public async Task<IActionResult> UpdDoctor([FromBody] Doctor apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateDoctor(apnt);
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
