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
    public class TestsController : ControllerBase
    {
        private ITestRepo _intrface;

        public TestsController(ITestRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Test>> GetAllTest()
        {
            return await _intrface.GetAllTest();
        }




        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTestById(int id)
        {
            try
            {
                var result = await _intrface.GetByTestId(id);
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


        //Add Test
        [HttpPost]
        public async Task<IActionResult> AddTest([FromBody] Test apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddTest(apnt);
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


        //Update Test
        [HttpPut]
        public async Task<IActionResult> UpdTest([FromBody] Test apnt)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    await _intrface.UpdateTest(apnt);
                    return Ok();
                //}
                //catch (Exception)
                //{
                //    return BadRequest();
                //}
            }
            return BadRequest();
        }
    }
}
