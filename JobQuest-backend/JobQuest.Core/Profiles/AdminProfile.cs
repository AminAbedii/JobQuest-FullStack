using AutoMapper;
using JobQuest.Core.DTOs;
using JobQuest.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Advertisement, ShowAdvertisementForAdminDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryTitle))
                .ForMember(dest => dest.WorkingHoursName, opt => opt.MapFrom(src => src.Workinghours.WorkinghoursTitle))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityTitle))
                .ForMember(dest => dest.SalaryName, opt => opt.MapFrom(src => src.Salary.SalaryTitle))
                .ForMember(dest => dest.SexName, opt => opt.MapFrom(src => src.Sex.SexTitle))
                .ForMember(dest => dest.MilitaryPositionName, opt => opt.MapFrom(src => src.MilitaryPosition.MilitaryPositionTitle))
                .ForMember(dest => dest.ExperienceName, opt => opt.MapFrom(src => src.Exprience.ExprienceTitle))
                .ForMember(dest => dest.DegreeName, opt => opt.MapFrom(src => src.Degree.DegreeTitle));
        }
    }
}
