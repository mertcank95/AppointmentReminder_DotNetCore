using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DateController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public DateController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public string Hello()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            var user = HttpContext.User;
            return "hello " + userIdClaim.Value +" "+ user.Identity.Name;
        }

        [HttpPost("createappoint")]
        public async Task<IActionResult> CreateAppointAsync([FromBody] AppointmentDto appointmentDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            var user = HttpContext.User;
            var appointment = await _manager.AppoinmentService.CreateOneAppointmentAsync(userIdClaim.Value, appointmentDto);
            return StatusCode(201, appointment);
        }

        [HttpGet("getalluserappointment")]
        public async Task<IActionResult> GetUserAppointmentAsync(){
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            var appoinmentList = await _manager.AppoinmentService.UserGetAllAppointmentAsync(userIdClaim.Value);
            return Ok(appoinmentList);
        }

    }
}
