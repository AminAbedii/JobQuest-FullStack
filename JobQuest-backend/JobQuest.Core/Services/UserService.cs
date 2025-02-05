using AutoMapper;
using JobQuest.Core.DTOs;
using JobQuest.Core.Security;
using JobQuest.Core.Services.Interfaces;
using JobQuest.DataLayer.Context;
using JobQuest.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services
{
    public class UserService : IUserService
    {
        private readonly JobQuestContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(JobQuestContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }



        public async Task<Company> GetUserByUserId(int userId)
        {
            var user = await _context.Companies.FirstOrDefaultAsync(c=>c.CompanyId == userId);
            return user;
        }

        public async Task<Company> GetUserByUserName(string userName)
        {
            var user = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == userName);
            return user;
        }


        public async Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var isExistsUser = await GetUserByUserName(registerDto.CompanyName);
            if (isExistsUser is not null)
                return new GeneralServiceResponseDto()
                {
                    IsSucceed = false,
                    StatusCode = 409,
                    Message = "CompanyName Already Exists"
                };
            //pic
            if (registerDto.Image != null && registerDto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(registerDto.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await registerDto.Image.CopyToAsync(stream);
                }

                // Create the company entity
                var company = new Company
                {
                    CompanyName= registerDto.CompanyName,
                    Description= registerDto.Description,
                    RegisterDate = registerDto.RegisterDate,
                    Password= registerDto.Password,
                    RoleId=registerDto.RoleId,
                    
                    PicName = fileName // Save the file name
                };

                //var newCompany = _mapper.Map<Company>(registerDto);
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
            }

            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "Company Created Successfully"
            };
        }

        public async Task<IEnumerable<ShowCompaniesDto>> ShowCompaniesAsync()
        {
            var companies = await _context.Companies.OrderByDescending(c => c.RegisterDate).ToListAsync();
            var massegeDtos = _mapper.Map<IEnumerable<ShowCompaniesDto>>(companies);
            return massegeDtos;
        }





        //public async Task<string> LoginAsync(LoginDto loginDto)
        //{
        //    var user = ValidateUserCredentials(loginDto.CompanyName,loginDto.Password);
        //    //if (user == null)
        //    //{
        //    //    return Unauthorized();
        //    //}
        //    var secururityKey = new SymmetricSecurityKey(
        //        Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
        //    var signingCredentials = new SigningCredentials(
        //        secururityKey,SecurityAlgorithms.HmacSha256 );
        //    var claimsForToken = new List<Claim>();
        //    claimsForToken.Add(new Claim("companyName", loginDto.CompanyName));

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        _config["Authentication:Issuer"],
        //        _config["Authentication:Audience"],
        //        claimsForToken,
        //        DataTime.Ut
        //        )

        //    return "";
        //}












        //private async Task<Company> ValidateUserCredentials(string? userName, string? password)
        //{
        //    return await _context.Companies
        //.Where(c => c.CompanyName == userName && c.Password == password)
        //.FirstOrDefaultAsync();
        //}
    }
}
