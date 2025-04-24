using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HrInternalTool.Application.Commands;
using HrInternalTool.Application.Queries;
using HrInternalTool.Domain.Entities;
using HrInternalTool.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HrInternalTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender, IConfiguration configuration) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersEntity user)
        {
            var result = await sender.Send(new AddUserCommand(user));
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersEntity user)
        {
            var result = await sender.Send(new GetUserDetailQuery(user));
            if (result == null) return Unauthorized("Invalid credentials");

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenValue, user = new UsersEntity { Username = user.Username,PasswordHash = user.PasswordHash } });
        }
    }
}
