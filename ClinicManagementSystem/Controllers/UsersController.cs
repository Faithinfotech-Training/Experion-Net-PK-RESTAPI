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
    public class UsersController : ControllerBase
    {

        private IUsersRepo _intrface;

        public UsersController(IUsersRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Users>> GetAllUsers()
        {
            return await _intrface.GetAllUsers();
        }



        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsersById(int id)
        {
            try
            {
                var result = await _intrface.GetByUsersId(id);
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


        //Add Users
        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] Users apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddUsers(apnt);
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


        //Update Users
        [HttpPut]
        public async Task<IActionResult> UpdUsers([FromBody] Users apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateUsers(apnt);
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
