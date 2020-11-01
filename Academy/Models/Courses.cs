using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Star { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string AboutCourse { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [Required]
        public int StudentsCount { get; set; }
        [Required]
        public string Certification { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
