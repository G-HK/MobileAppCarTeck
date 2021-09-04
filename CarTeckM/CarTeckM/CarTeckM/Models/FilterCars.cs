using System;
using System.Collections.Generic;
using System.Text;

namespace CarTeckM.Models
{
    public  class FilterCars
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public string Transmission { get; set; } ///Handbak, auto

        public string BodyType { get; set; }

        public string FuelType { get; set; }

        public char Currency { get; set; }

        public decimal LowerPrice { get; set; } = 0;
        public decimal UpperPrice { get; set; }

        public string Color { get; set; }

        public string RangeType { get; set; } //KM or Mile
        public int UpperRange { get; set; }
        public int LowerRange { get; set; } = 0;


        public int BeginBuildYear { get; set; }
        public int EndBuildYear { get; set; } = 0;

        public string Torque { get; set; } 

        public string UpperPower { get; set; } // Kw/Pk
        public string LowerPower { get; set; } = "0";

       
    }
}
