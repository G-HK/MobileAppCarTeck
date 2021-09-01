using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public DateTime BirthDate { get; set; }

        public bool PremiunUser { get; set; }
        
    }
}
