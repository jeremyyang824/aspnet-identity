using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSIdentityStarter.Models
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Remark1 { get; set; }
    }
}