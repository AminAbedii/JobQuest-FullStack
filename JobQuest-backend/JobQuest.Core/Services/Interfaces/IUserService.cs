using JobQuest.Core.DTOs;
using JobQuest.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<Company> GetUserByUserId(int userId);
        Task<Company> GetUserByUserName(string userName);




        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        //Task<string> LoginAsync(LoginDto loginDto); 
        Task<IEnumerable<ShowCompaniesDto>> ShowCompaniesAsync();
    }
}
