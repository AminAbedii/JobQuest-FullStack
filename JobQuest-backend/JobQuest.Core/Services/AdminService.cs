using AutoMapper;
using JobQuest.Core.DTOs;
using JobQuest.Core.Services.Interfaces;
using JobQuest.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly JobQuestContext _context;
        private readonly IMapper _mapper;

        public AdminService(IMapper mapper, JobQuestContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ShowAdvertisementForAdminDto>> ShowAdForAdminAsync()
        {
            //var advertisement=await _context.Advertisements.Where(a=>!a.IsValid).ToListAsync();
            //var adDto= _mapper.Map<IEnumerable<ShowAdvertisementForAdminDto>>(advertisement);
            //return adDto;
            var advertisements = await _context.Advertisements
               .Where(a => !a.IsValid)
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
            var adDto = _mapper.Map<IEnumerable<ShowAdvertisementForAdminDto>>(advertisements);
            return adDto;
        }
    }
}
