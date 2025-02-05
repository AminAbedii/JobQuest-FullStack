using JobQuest.Core.DTOs;
using JobQuest.Core.Security;
using JobQuest.Core.Services.Interfaces;
using JobQuest.DataLayer.Context;
using JobQuest.DataLayer.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobQuest_backend.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserService _userService;
        private readonly JobQuestContext _context;

        public AuthenticationController(IConfiguration configuration, IUserService userService, JobQuestContext context)
        {
            _config = configuration;
            _userService = userService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromForm] RegisterDto registerDto)
        {
            var registerResult=await _userService.RegisterAsync(registerDto);
            return StatusCode(registerResult.StatusCode, registerResult.Message);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var user = await ValidateUserCredentials(loginDto.CompanyName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var secururityKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                secururityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("companyName", loginDto.CompanyName));

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
                );
            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ShowCompanies")]
        public async Task<ActionResult<IEnumerable<ShowCompaniesDto>>> ShowCompanies()
        {
            var companies = await _userService.ShowCompaniesAsync();
            return Ok(companies);
        }





        #region Token
        private async Task<Company> ValidateUserCredentials(string? userName, string? password)
        {
            return await _context.Companies
                .Where(c => c.CompanyName == userName && c.Password == password)
                .FirstOrDefaultAsync();
        }
        #endregion

    }
}
