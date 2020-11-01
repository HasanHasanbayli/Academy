﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Videos
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
