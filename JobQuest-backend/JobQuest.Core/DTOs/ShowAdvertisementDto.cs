using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.DTOs
{
    public class ShowAdvertisementDto
    {
        public string AdTitle { get; set; }
        public string CompanyName { get; set; } 
        public string CategoryName { get; set; } 
        public string WorkingHoursName { get; set; } 
        public string CityName { get; set; } 
        public string SalaryName { get; set; } 
        public string SexName { get; set; } 
        public string MilitaryPositionName { get; set; } 
        public string ExperienceName { get; set; } 
        public string DegreeName { get; set; } 
        public string Description { get; set; }
        public string PicName { get; set; }
    }
}
