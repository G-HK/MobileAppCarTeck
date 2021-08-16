﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarTeckM.Models
{
    public  class LoginDto
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "You should provide a Email value.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a Password value.")]
        public string Password { get; set; }

    }
}