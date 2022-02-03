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
    public class MedicinePrescriptionController : ControllerBase
    {

        private IMedicinePrescriptionRepo _intrface;

        public MedicinePrescriptionController(IMedicinePrescriptionRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<MedicinePrescription>> GetAllMedicinePrescription()
        {
            return await _intrface.GetAllMedicinePrescription();
        }

        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicinePrescription>> GetMedicinePrescriptionById(int id)
        {
            try
            {
                var result = await _intrface.GetByMedicinePrescriptionId(id);
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

        //Add MedicinePrescription
        [HttpPost]
        public async Task<IActionResult> AddMedicinePrescription([FromBody] MedicinePrescription medPr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddMedicinePrescription(medPr);
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


        //Update MedicinePrescription
        [HttpPut]
        public async Task<IActionResult> UpdMedicinePrescription([FromBody] MedicinePrescription apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateMedicinePrescription(apnt);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet("appoitments/{id}")]
        public async Task<MedPrescAppointView> GetAllMedPrescribedInAnAppointment(int id)
        {
            return await _intrface.GetAllMedPrescribedInAnAppointment(id);
        }

        }
}
