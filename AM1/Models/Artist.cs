using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistDescription { get; set; }

    }
}
