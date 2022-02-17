using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private IAppointmentRepo _intrface;

        public AppointmentsController(IAppointmentRepo intrfaceDI)
        {
            _intrface = intrfaceDI;
        }

        //Get Raw Table Data
        [HttpGet("raw")]
        public async Task<List<Appointment>> GetAllAppointment()
        {
            return await _intrface.GetAllAppointment();
        }

        // GET View Model 
        [HttpGet]
        public Task<List<ApointForTodayView>> GetAllApointmentForTheDay()
        {
            return _intrface.GetAllApointmentForTheDay();
        }

        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            try
            {
                var result = await _intrface.GetAppointmentById(id);
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


        //GET By Doc Id
        [HttpGet("doctors/{id}")]
        public async Task<ActionResult<List<ApointForTodayView>>> GetAllApointmentForTheDayFoADoctor(int id)
        {
            try
            {
                var result = await _intrface.GetAllApointmentForTheDayFoADoctor(id);
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

        //Add Appointment
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrface.AddAppointment(apnt);
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


        //Update Appointment
        [HttpPut]
        public async Task<IActionResult> UpdAppointment([FromBody] Appointment apnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrface.UpdateAppointment(apnt);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet("token/{date}")]

        public int GetNextToken(DateTime date)
        {
            return _intrface.GetNextToken(date)+1;
        }



    }
}
