using JobQuest.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services.Interfaces
{
    public interface IAdminService
    {


        Task<IEnumerable<ShowAdvertisementForAdminDto>> ShowAdForAdminAsync();
    }
}
