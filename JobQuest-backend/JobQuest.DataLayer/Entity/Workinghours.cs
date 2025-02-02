using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Workinghours
    {
        [Key]
        public int WorkinghoursId { get; set; }
        public string WorkinghoursTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
