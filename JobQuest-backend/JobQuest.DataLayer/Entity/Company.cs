using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Entity
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string PicName { get; set; }
        public DateTime RegisterDate { get; set; }





        //Relation
        public Role Role { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
