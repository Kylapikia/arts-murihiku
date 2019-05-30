using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Album
    {
        [Key]
        public string AlbumID { get; set; }

        [Display(Name = "Description")]
        public string AlbumDescription { get; set; }

        [Display(Name = "Created date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AlbumCreatedTime { get; set; }

        [Display(Name = "Title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Album owner")]
        public string AlbumOwner { get; set; }
    }
}
