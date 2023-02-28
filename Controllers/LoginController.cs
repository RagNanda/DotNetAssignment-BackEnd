using Microsoft.AspNetCore.Mvc;
using DotnetAssignmentBackEnd.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using DotnetAssignmentBackEnd;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssignmentBackEnd.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;  
        private ProjectContext _context;

        public LoginController(IConfiguration _config,ProjectContext context)
        {
            _config= _config;
            _context= context;
        }
        [HttpPost, Route("login")]
        public IActionResult Login(loginDTO loginDTO)
        {
            try
            {
                User user =  _context.Users.Include(s=>s.Roles).SingleOrDefault(user=>user.UserName==loginDTO.UserName);
                if (user == null || string.IsNullOrEmpty(loginDTO.UserName) ||
                string.IsNullOrEmpty(loginDTO.Password)){
                    return BadRequest("Invalid username or password");
                }
                if (loginDTO.UserName.Equals(user.UserName) &&
                loginDTO.Password.Equals(user.Password))
                {   
                    var claims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role.RoleName));
                    List<Claim> Claims=new List<Claim>();
                    foreach (var i in user.Roles){
                        Claims.Add(new Claim(ClaimTypes.Role,i.RoleName.ToString()));
                    }
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Thisismysecretkey"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        "https://localhost:7239",  
                        "https://localhost:7239", 
                        claims:Claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
            }
            catch
            {
                return BadRequest
                ("An error occurred in generating the token");
            }
            return Unauthorized();
        }
    }