using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int BlogID { get; set; }
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
                ErrorMessage = "Please provide valid email")]
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        [StringLength(500, ErrorMessage = "Message is required")]
        [Display(Name = "Message/Comment")]
        public string Message { get; set; }
        public DateTime SubmitDate { get; set; } // this will be hidden and should get the time when they submit
    }
}
