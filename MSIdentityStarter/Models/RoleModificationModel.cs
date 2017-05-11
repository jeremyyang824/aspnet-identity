using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSIdentityStarter.Models
{
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }

        public string[] IdsToAdd { get; set; }

        public string[] IdsToDelete { get; set; }
    }
}