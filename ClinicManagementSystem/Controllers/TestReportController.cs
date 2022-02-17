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
    public class TestReportController : ControllerBase
    {

        private ITestReportRepo _intrface;

        public TestReportController(ITestReportRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<TestReport>> GetAllTestReport()
        {
            return await _intrface.GetAllTestReport();
        }






        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<TestReport>> GetTestReportById(int id)
        {
            try
            {
                var result = await _intrface.GetByTestReportId(id);
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



        [HttpGet("appointments/{id}")]
        public async Task<List<TestReportUsingTestPrescriptionId>> GetAllTestReportDetailsUsingAppointId(int id)
        {
            return await _intrface.GetAllTestReportDetailsUsingAppointId(id);
        }

            //Add TestReport
            [HttpPost]
        public async Task<IActionResult> AddTestReport([FromBody] TestReport apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddTestReport(apnt);
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


        //Update TestReport
        [HttpPut]
        public async Task<IActionResult> UpdTestReport([FromBody] TestReport apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateTestReport(apnt);
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
