using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Advertisement
    {
        [Key]
        public int AdId { get; set; }
        public string AdTitle { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Workinghours")]
        public int WorkinghoursId { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }
        [ForeignKey("Sex")]
        public int SexId { get; set; }
        [ForeignKey("MilitaryPosition")]
        public int? MilitaryPositionId { get; set; }
        [ForeignKey("Exprience")]
        public int ExprienceId { get; set; }
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
        public string PicName { get; set; }




        //relation
        public Company Company { get; set; }
        public Category Category { get; set; }
        public Workinghours Workinghours { get; set; }
        public City City { get; set; }
        public Salary Salary { get; set; }
        public Sex Sex { get; set; }
        public MilitaryPosition MilitaryPosition { get; set; }
        public Exprience Exprience { get; set; }
        public Degree Degree { get; set; }
    }
}
