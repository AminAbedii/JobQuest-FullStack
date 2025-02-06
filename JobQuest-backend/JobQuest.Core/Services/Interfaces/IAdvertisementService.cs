using JobQuest.Core.DTOs;
using JobQuest.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services.Interfaces
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdByAdId(int adId);
        Task<Advertisement> GetAdByAdName(string adName);



        Task<IEnumerable<ShowAdvertisementDto>> ShowAdvertisementsAsync();
        Task<GeneralServiceResponseDto> CreateAdvertisement(/*ClaimsPrincipal User,*/ CreateAdvertisementDtos createAdvertisementDtos);
    }
}
