using MemberSystem.Api.Models;
using MemberSystem.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MemberSystem.Api.Dtos;

namespace MemberSystem.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class UsersController : ControllerBase
     {
          private readonly IUserService _userService;
          private readonly IConfiguration _configuration; 
          public UsersController(IUserService userService, IConfiguration configuration)
          {
               _userService = userService;
               _configuration = configuration;
          }

          [HttpPost("register")]
          public async Task<IActionResult> Register(User user, string password)
          {
               try
               {
                    var createdUser = await _userService.RegisterAsync(user, password);

                    var userDto = new UserDto
                    {
                         Name = createdUser.Name,
                         Email = createdUser.Email,
                         CreatedAt = createdUser.CreatedAt
                    };

                    return Ok(userDto);
               }
               catch (Exception ex)
               {
                    return BadRequest(new { message = ex.Message });
               }
          }

          [HttpPost("Login")]
          public async Task<IActionResult> Login(string email, string password)
          { 
               var user = await _userService.LoginAsync(email, password);
               if (user == null) return Unauthorized("帳號或密碼錯誤");

               //making JWT
               var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
               };

               var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
               var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

               var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(1), // 門票有效期 1 天
                    signingCredentials: creds
               );

               return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
          }

     }
}
