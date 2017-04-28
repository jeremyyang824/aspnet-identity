using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MSIdentityStarter.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(500)]
        public string Remark1 { get; set; }
    }
}