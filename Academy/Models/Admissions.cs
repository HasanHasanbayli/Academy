﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Admissions
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
        public string Card { get; set; }
        public string Transcript { get; set; }
        public string Certificate { get; set; }
        public string Picture { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
