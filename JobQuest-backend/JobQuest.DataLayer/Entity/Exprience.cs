using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Exprience
    {
         [Key]
        public int ExprienceId { get; set; }
        public string ExprienceTitle { get; set; }


        //relation
        public List<Advertisement> Advertisements { get; set; }
    }
}
