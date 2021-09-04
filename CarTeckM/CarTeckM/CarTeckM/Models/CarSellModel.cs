using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTeckM.Models
{
    class CarSellModel
    {
        public int CarID { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }

        public string Transmission { get; set; } ///Handbak, auto

        public string BodyType { get; set; }

        public string FuelType { get; set; }

        public char Currency { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string RangeType { get; set; } //KM or Mile
        public int Range { get; set; }


        public int BuildYear { get; set; }

        public string Torque { get; set; }

        public string Power { get; set; } // Kw/Pk

        //  path of the images are been save in db; split by;
        public FormFile [] Picture { get; set; }

        public string Description { get; set; }

        public string IdentityID { get; set; }
        // id of the car onwer or Dealer.
    }
}
