using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string About { get; set; }
        public string Image { get; set; }
        public ICollection<Courses> Courses { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
