using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Models.ModelView
{
    public class CarDto
    {
        public int carID { get; set; }
        public string Brand { get; set; }
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
        public int Power{ get; set; } // vermogen
        public string TypeFuel { get; set; }
        public List<string> Image { get; set; }
        public FormFile Img { get; set; } // only the Fist Image for the WebPage.
        public string Doors { get; set; }
        public string UserImg { get; set; } // save as base64
        public string UserName { get; set; }
    }
}
