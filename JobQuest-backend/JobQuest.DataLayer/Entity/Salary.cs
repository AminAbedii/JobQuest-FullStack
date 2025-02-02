using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public string SalaryTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
