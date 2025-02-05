using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.DTOs
{
    public class ShowCompaniesDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PicName { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
