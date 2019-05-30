using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM1.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event name required")] // Must enter event name
        [Display(Name = "Event Name")]
        [StringLength(50, ErrorMessage = "Event name cannot be longer than 50 characters.")]
        public string EventName { get; set; }



        [Display(Name = "Start of Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartEventDate { get; set; } //date and time of start event

        [Display(Name = "Finish of Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FinishEventDate { get; set; } //date and time of end event

        [Display(Name = "Start time")]        
        public string StartTime { get; set; }

        [Display(Name = "Finish time")]        
        public string FinishTime { get; set; }

        [Required(ErrorMessage = "Event description required")] // Must enter event description
        [Display(Name = "Event Description")]
        [StringLength(200, ErrorMessage = "Event description cannot be longer than 200 characters.")]
        public string EventDescription { get; set; }
        [Display(Name = "Category")]
        public string EventCategory { get; set; } //dropdown of category event belongs too
        [Display(Name = "Event Picture")]
        public string EventPicture { get; set; } //picture for the event

        [Display(Name = "Location")]
        public string Location { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }

        public string FullAddress { get; set; }

        [Display(Name = "Theme Colour")]
        public string ThemeColour { get; set; }
        [Display(Name = "Full Day")]
        public bool FullDay { get; set; }

        public bool Free { get; set; }


        public int? Price { get; set; }
    }
}
