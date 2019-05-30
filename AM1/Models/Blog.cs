using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM1.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Blog Title required")] // Must blog title
        [Display(Name = "Title")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author required")] // Must blog title
        [Display(Name = "Author")]
        [StringLength(50, ErrorMessage = "Author cannot be longer than 50 characters.")]
        public string Author { get; set; }
        [Display(Name = "Date Published")]
        public DateTime PublishDate { get; set; } // Time and date of blogpost
        [Display(Name = "Blog Description")]
        public string BlogPost { get; set; } // the blog posting
        public string Category { get; set; } //drop down list (categoery of blog post type)
        [Display(Name = "Blog Picture")]
        public string BlogPic { get; set; } // pic for blog


    }
}
