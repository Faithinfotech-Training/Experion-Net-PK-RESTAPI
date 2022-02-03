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
    public class SpecializationController : ControllerBase
    {

        private ISpecializationRepo _intrface;

        public SpecializationController(ISpecializationRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Specialization>> GetAllSpecialization()
        {
            return await _intrface.GetAllSpecialization();
        }




        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> GetSpecializationById(int id)
        {
            try
            {
                var result = await _intrface.GetBySpecializationId(id);
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



        //Add Specialization
        [HttpPost]
        public async Task<IActionResult> AddSpecialization([FromBody] Specialization apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddSpecialization(apnt);
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


        //Update Specialization
        [HttpPut]
        public async Task<IActionResult> UpdSpecialization([FromBody] Specialization apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateSpecialization(apnt);
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
