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
    public class MedicineItemPriceController : ControllerBase
    {

        private IMedicineItemPriceRepo _intrface;

        public MedicineItemPriceController(IMedicineItemPriceRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<MedicineItemPrice>> GetAllMedicineItemPrice()
        {
            return await _intrface.GetAllMedicineItemPrice();
        }


        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineItemPrice>> GetByMedicineItemPriceId(int id)
        {
            try
            {
                var result = await _intrface.GetByMedicineItemPriceId(id);
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


        //Add MedicineItemPrice
        [HttpPost]
        public async Task<IActionResult> AddMedicineItemPrice([FromBody] MedicineItemPrice medPrcList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddMedicineItemPrice(medPrcList);
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


        //Update MedicineItemPrice
        [HttpPut]
        public async Task<IActionResult> UpdMedicineItemPrice([FromBody] MedicineItemPrice apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateMedicineItemPrice(apnt);
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
