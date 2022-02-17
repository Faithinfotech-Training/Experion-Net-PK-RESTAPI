using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.ViewModel;
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
    public class TestPrescriptionController : ControllerBase
    {

        private ITestPrescriptionRepo _intrface;

        public TestPrescriptionController(ITestPrescriptionRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<TestPrescription>> GetAllTestPrescription()
        {
            return await _intrface.GetAllTestPrescription();
        }

        [HttpGet("todaysTests")]
        public async Task<List<PatinetsHavingTests>> GetAllTestPrescribedForTheDay()
        {
            return await _intrface.GetAllTestPrescribedForTheDay();
        }


            //GET By Id
            [HttpGet("{id}")]
        public async Task<ActionResult<TestPrescription>> GetTestPrescriptionById(int id)
        {
            try
            {
                var result = await _intrface.GetByTestPrescriptionId(id);
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




        //Add TestPrescription
        [HttpPost]
        public async Task<IActionResult> AddTestPrescription([FromBody] TestPrescription apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddTestPrescription(apnt);
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


        //Update TestPrescription
        [HttpPut]
        public async Task<IActionResult> UpdTestPrescription([FromBody] TestPrescription apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateTestPrescription(apnt);
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
