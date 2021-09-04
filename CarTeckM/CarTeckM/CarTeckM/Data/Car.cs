using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarTeckM.Data
{
    public class Car
    {

        [PrimaryKey, AutoIncrement]
        public int CarID { get; set; }

        //[DataType(DataType.Text)]
        public string Brand { get; set; }

        //  //[Required]
        //  //[DataType(DataType.Text)]
        public string Model { get; set; }

        //  [Required]
        public string Transmission { get; set; } ///Handbak, auto

        //  [Required]
        public string BodyType { get; set; }

        [Required]
        public string FuelType { get; set; }

        public char Currency { get; set; }

        //  [Required]
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Color { get; set; }
        //  [Required]
        public string RangeType { get; set; } //KM or Mile
        public int Range { get; set; }


        [Required]
        public int BuildYear { get; set; }

        public string Torque { get; set; }

        public string Power { get; set; } // Kw/Pk

        public string Doors { get; set; }

        public string Description { get; set; }

        //  path of the images are been save in db; split by;
        public string Picture { get; set; }

        [Indexed]
        public string UserID { get; set; }
        // id of the car onwer or Dealer.
        //public User User { get; set; }

        //  // QR Code

        //   //public QRCode qRCode { get; set; }
    }
}
