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
    public class RolesController : ControllerBase
    {
        private IRoleRepo _intrface;

        public RolesController(IRoleRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Role>> GetAllRole()
        {
            return await _intrface.GetAllRole();
        }


        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            try
            {
                var result = await _intrface.GetByRoleId(id);
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



        //Add Role
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role rl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddRole(rl);
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


        //Update Role
        [HttpPut]
        public async Task<IActionResult> UpdRole([FromBody] Role rl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateRole(rl);
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
