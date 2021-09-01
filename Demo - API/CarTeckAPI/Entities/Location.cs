using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Entities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public int UserID { get; set; }
        public User user { get; set; }


    }
}
