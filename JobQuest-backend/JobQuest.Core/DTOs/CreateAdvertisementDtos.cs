using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.DTOs
{
    public class CreateAdvertisementDtos
    {
        public string AdTitle { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int WorkinghoursId { get; set; }
        public int CityId { get; set; }
        public int SalaryId { get; set; }
        public int SexId { get; set; }
        public int? MilitaryPositionId { get; set; }
        public int ExprienceId { get; set; }
        public int DegreeId { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
