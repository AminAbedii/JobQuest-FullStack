using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
