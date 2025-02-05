using AutoMapper;
using JobQuest.Core.DTOs;
using JobQuest.DataLayer;
using JobQuest.DataLayer.Entity;


namespace JobQuest.Core.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            //CreateMap<Company, RegisterDto>();
            CreateMap<RegisterDto, Company>();
            CreateMap<Company, ShowCompaniesDto>();
        }
    }
}
