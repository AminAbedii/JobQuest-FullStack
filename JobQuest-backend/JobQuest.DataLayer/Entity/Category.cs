using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
