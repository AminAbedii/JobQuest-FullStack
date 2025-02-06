using AutoMapper;
using JobQuest.Core.DTOs;
using JobQuest.Core.Services.Interfaces;
using JobQuest.DataLayer.Context;
using JobQuest.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly JobQuestContext _context;
        private readonly IMapper _mapper;
        public AdvertisementService(JobQuestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Advertisement> GetAdByAdId(int adId)
        {
            var Ad = await _context.Advertisements.FirstOrDefaultAsync(c => c.AdId == adId);
            return Ad;
        }

        public async Task<Advertisement> GetAdByAdName(string adName)
        {
            var Ad = await _context.Advertisements.FirstOrDefaultAsync(c => c.AdTitle == adName);
            return Ad;
        }

        public async Task<IEnumerable<ShowAdvertisementDto>> ShowAdvertisementsAsync()
        {
            //var advertisement = await _context.Advertisements.Where(a => a.IsValid).ToListAsync();
            //var adDto = _mapper.Map<IEnumerable<ShowAdvertisementDto>>(advertisement);
            //return adDto;
            var advertisements = await _context.Advertisements
               .Where(a => a.IsValid)
               .Include(a => a.Company) 
               .Include(a => a.Category) 
               .Include(a => a.Workinghours) 
               .Include(a => a.City) 
               .Include(a => a.Salary) 
               .Include(a => a.Sex) 
               .Include(a => a.MilitaryPosition) 
               .Include(a => a.Exprience) 
               .Include(a => a.Degree) 
               .ToListAsync();
            var adDto = _mapper.Map<IEnumerable<ShowAdvertisementDto>>(advertisements);
            return adDto;
        }

        public async Task<GeneralServiceResponseDto> CreateAdvertisement(/*ClaimsPrincipal User,*/ CreateAdvertisementDtos createAdvertisementDtos)
        {
            if (createAdvertisementDtos.Image != null && createAdvertisementDtos.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Ad");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(createAdvertisementDtos.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createAdvertisementDtos.Image.CopyToAsync(stream);
                }
                var ad = new Advertisement
                {
                    AdTitle=createAdvertisementDtos.AdTitle,
                    CompanyId=createAdvertisementDtos.CompanyId,
                   CategoryId=createAdvertisementDtos.CategoryId,
                   CityId=createAdvertisementDtos.CityId,
                   DegreeId=createAdvertisementDtos.DegreeId,
                   Description=createAdvertisementDtos.Description,
                   ExprienceId=createAdvertisementDtos.ExprienceId,
                   MilitaryPositionId=createAdvertisementDtos.MilitaryPositionId,
                   SalaryId=createAdvertisementDtos.SalaryId,
                   SexId=createAdvertisementDtos.SexId,
                   WorkinghoursId=createAdvertisementDtos.WorkinghoursId,
                   
                    PicName = fileName // save the file name
                };
                //ad.Company.CompanyName = User.Identity.Name;
                await _context.Advertisements.AddAsync(ad);
                await _context.SaveChangesAsync();
            }
            //var advertisement = _mapper.Map<Advertisement>(createAdvertisementDtos);
            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "Advertisement saved successfully",
            };
        }
    }
}
