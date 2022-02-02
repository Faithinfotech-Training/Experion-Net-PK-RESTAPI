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
    public class TestPriceController : ControllerBase
    {

        private ITestPriceRepo _intrface;

        public TestPriceController(ITestPriceRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<TestPrice>> GetAllTestPrice()
        {
            return await _intrface.GetAllTestPrice();
        }





        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<TestPrice>> GetTestPriceById(int id)
        {
            try
            {
                var result = await _intrface.GetByTestPriceId(id);
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



        //Add TestPrice
        [HttpPost]
        public async Task<IActionResult> AddTestPrice([FromBody] TestPrice tstPr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddTestPrice(tstPr);
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


        //Update TestPrice
        [HttpPut]
        public async Task<IActionResult> UpdTestPrice([FromBody] TestPrice apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateTestPrice(apnt);
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
