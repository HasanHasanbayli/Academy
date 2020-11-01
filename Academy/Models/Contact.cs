using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required, MaxLength(15)]
        public string TelNumber { get; set; }
        [Required, MaxLength(200)]
        public string Message { get; set; }
        public bool IsArchived { get; set; }
    }
}
