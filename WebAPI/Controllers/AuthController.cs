using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto loginDto)
        {
            var res = _authService.Login(loginDto);
            if (!res.Success)
            {
                return BadRequest(res);
            }

            var token = _authService.CreateAccessToken(res.Data);

            if (!token.Success)
            {
                return BadRequest(token);
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto registerDto)
        {
            var userExists = _authService.UserExists(registerDto.Email);

            if (userExists.Success)
            {
                return BadRequest(userExists);
            }

            var register = _authService.Register(registerDto);
            if (!register.Success)
            {
                return BadRequest(register);
            }

            var token = _authService.CreateAccessToken(register.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }

            return Ok(token);
        }
    }
}
