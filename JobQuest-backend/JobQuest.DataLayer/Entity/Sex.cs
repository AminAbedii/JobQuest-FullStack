using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Sex
    {
        [Key]
        public int SexId { get; set; }
        public string SexTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
