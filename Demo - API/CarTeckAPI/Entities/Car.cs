using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Entities
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Transmission { get; set; } ///Handbak, auto

        [Required]
        public string BodyType { get; set; }
        [Required]
        public double Price { get; set; }
        public string Color { get; set; }
        [Required]
        public int Kilometer { get; set; }
      
        [Required]
        public string FuelType { get; set; }
        [Required]
        public int BouwJaar { get; set; }
        public int Power { get; set; } // Kw/Pk

        public int Doors  { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserID { get; set; }
        public User User { get; set; }


    }
}
