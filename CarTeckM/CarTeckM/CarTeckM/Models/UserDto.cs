using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarTeckM.Models
{
    public class UserDto
    {
        public string IdentityID { get; set; }

        [Required(ErrorMessage = "You should provide a Username value.")]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You should provide a Email value.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a Password value.")]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
