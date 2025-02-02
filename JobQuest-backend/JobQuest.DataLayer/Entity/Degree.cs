using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Degree
    {
         [Key]
        public int DegreeId { get; set; }
        public string DegreeTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
