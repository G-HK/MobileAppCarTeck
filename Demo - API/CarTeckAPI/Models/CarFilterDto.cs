using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Models
{
    public class CarFilterDto
    {
        public string Merk { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        //price
        public int LowerPrice { get; set; }
        public int UpperPrice { get; set; }
        public string BodyType { get; set; }

        //jaars
        public int BeginJaar { get; set; }
        public int EndJaar { get; set; }

        // kilometer
        public int KilometerUpperLimit { get; set; }
        public int KilometerLowerLimit { get; set; }

        // Vermogen
        public int PK { get; set; } // vermogen

        public string Fuel { get; set; }

    }
}
