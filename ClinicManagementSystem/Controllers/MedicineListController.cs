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
    public class MedicineListController : ControllerBase
    {

        private IMedicineListRepo _intrface;

        public MedicineListController(IMedicineListRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<MedicineList>> GetAllMedicineList()
        {
            return await _intrface.GetAllMedicineList();
        }

        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineList>> GetMedicineListById(int id)
        {
            try
            {
                var result = await _intrface.GetByMedicineListId(id);
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

        //Add MedicineList
        [HttpPost]
        public async Task<IActionResult> AddMedicineList([FromBody] MedicineList medList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddMedicineList(medList);
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


        //Update MedicineList
        [HttpPut]
        public async Task<IActionResult> UpdMedicineList([FromBody] MedicineList apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateMedicineList(apnt);
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
