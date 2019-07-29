using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedSpark.Thot.Api.Application.Interfaces;
using RedSpark.Thot.Api.Application.Models.Users.Input;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Register(UserCreateModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(registerUser);

            var result = await _authService.Register(registerUser);
            if(result.Erros != null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
