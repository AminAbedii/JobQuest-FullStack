using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.Core.DTOs
{
    public class RegisterDto
    {
        public string CompanyName { get; set; }
        public int? RoleId { get; set; } = 2;
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public DateTime? RegisterDate { get; set; } = DateTime.Now;
    }
}
