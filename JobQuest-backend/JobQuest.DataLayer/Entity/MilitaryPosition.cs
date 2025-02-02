using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class MilitaryPosition
    {
        [Key]
        public int MilitaryPositionId { get; set; }
        public string MilitaryPositionTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
