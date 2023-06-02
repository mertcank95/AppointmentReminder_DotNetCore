using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistrationDto)
        {
            var result = await _service
                .AuthenticationService
                .RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
          
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto user)
        {
            
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();
            var tokenDto = await _service
                .AuthenticationService
                .CreateToken(populateExp: true);
            return Ok(tokenDto); 
        }


        [HttpPost("vertify")]
        public async Task<IActionResult> Vertify([FromBody] string token)
        {

            if (await _service.AuthenticationService.Verify(token))
                return Ok("Vertify True");

            return BadRequest();
           
        }

        [HttpPost("refresh")]

        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service
                .AuthenticationService
                .RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }


        







    }
}
