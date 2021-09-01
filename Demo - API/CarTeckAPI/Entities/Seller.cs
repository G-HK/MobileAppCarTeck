using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Entities
{
    public class Seller
    {
        [Key]
        public int SellerID { get; set; }
        [ForeignKey("UserId")]
        public int UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("CarID")]
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
