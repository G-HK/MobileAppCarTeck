using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Models.ModelView
{
    public class CarDto
    {
        public int carID { get; set; }
        public string Merk { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        //price
        public int Price { get; set; }
        public string BodyType { get; set; }
        //jaars
        public DateTime BouwJaar { get; set; }
        // kilometer
        public int Kilometer { get; set; }
        // Vermogen
        public int PK { get; set; } // vermogen
        public string Description { get; set; }
        public string Fuel { get; set; }
        public List<string> Image { get; set; }
        public byte [] Img { get; set; }

        public int UserID { get; set; }
    }
}
