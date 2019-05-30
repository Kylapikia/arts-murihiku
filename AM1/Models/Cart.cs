using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public string ArtistID { get; set; }

        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
