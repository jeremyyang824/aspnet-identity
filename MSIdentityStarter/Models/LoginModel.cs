using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSIdentityStarter.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}