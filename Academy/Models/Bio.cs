using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Bio
    {
        public int Id { get; set; }
        public string Call { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string HeaderLogo { get; set; }
        public string FooterLogo { get; set; }
        public string About { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        [NotMapped]
        public IFormFile HeaderPhoto { get; set; }
        [NotMapped]
        public IFormFile FooterPhoto { get; set; }


    }
}
