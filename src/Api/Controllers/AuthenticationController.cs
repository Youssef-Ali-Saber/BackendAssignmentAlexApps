using Application.DTOs;
using Domain.Entities;
using Domain.IUnitOfWork;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUnitOfWork unitOfWork, JwtHandlerService jwtHandler) : ControllerBase
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = unitOfWork.UserRepository.GetByFilter(user => user.Email == userDto.Email).FirstOrDefault();
                if (user != null)
                    return BadRequest(new { message = "This email is already Used" });
                user = new ApplicationUser
                {
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    IsMerchant = userDto.IsMerchant
                };
                var result = await unitOfWork.UserRepository.CreateUserAsync(user, userDto.Password);
                if (!result.Succeeded)
                    return BadRequest(new { message = "Invalid Data , try " });
                if (user.IsMerchant)
                    result = await unitOfWork.UserRepository.AddToRoleAsync(user, "Merchant");
                else
                    result = await unitOfWork.UserRepository.AddToRoleAsync(user, "User");
                if (!result.Succeeded)
                {
                    await unitOfWork.UserRepository.DeleteAsync(user.Id);
                    return BadRequest(new { message = "Invalid Data" });
                }
                return Ok(new { message = "User Created Successfully" });
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto credentials)
        {
            try 
            { 
                var user = unitOfWork.UserRepository.GetByFilter(user => user.Email == credentials.Email).FirstOrDefault();
                if (user == null)
                    return BadRequest(new {message = "Invalid Email or Password"});
                if (!await unitOfWork.UserRepository.CheckPasswordAsync(user, credentials.Password))
                    return BadRequest(new {message = "Invalid Email or Password"});
                var token = await jwtHandler.GenerateToken(user);
                var role = unitOfWork.UserRepository.GetRolesAsync(user).Result[0];
                return Ok(new {message = "Logged In Successfully" ,role = role , JWT_token = token});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
