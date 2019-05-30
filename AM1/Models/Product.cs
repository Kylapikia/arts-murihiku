using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name required")]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Product Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price required")]
        public double Price { get; set; }
        [Display(Name = "Product Picture")]
        public string ProductPicture { get; set; }
        [Display(Name = "Category")]
        [StringLength(50, ErrorMessage = "Category cannot be longer than 50 characters.")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Quantity required")]
        [Display(Name = "In Stock")]
        public int Quantity { get; set; }
    }
}
