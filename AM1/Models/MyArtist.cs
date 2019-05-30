using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class MyArtist
    {
        [Key]
        [Required]
        public int MyArtistID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Upload profile picture")]
        public string ProfilePic { get; set; } //artists or organizations profile pic

        [Display(Name = "Address")]
        public string Address { get; set; } //address visible 

        [Display(Name = "City")]
        public string City { get; set; } //City visible 

        [Display(Name = "Contact number")]
        public string PhoneNumber { get; set; } //Phone number visible

        [Display(Name = "Email Address")]
        public string Email { get; set; } //email visible for everyone to see on artist page

        [Display(Name = "Description")]
        public string ArtistDescription { get; set; }

        //creative type
        public bool Individual { get; set; }
        //[Display(Name = "Individual")]

        public bool Organisation { get; set; }
        //[Display(Name = "Organisation")]

        public bool CreativeSpace { get; set; }
        //[Display(Name = "Creative Space")]

        public bool Festival { get; set; }
        //[Display(Name = "Festival")]

        //Discipline
        public bool Paint { get; set; }
        //[Display(Name = "Paint")]

        public bool Design { get; set; }
        //[Display(Name = "Design")]

        public bool Education { get; set; }
        //[Display(Name = "Creative Space")]

        public bool Film { get; set; }
        //[Display(Name = "Film")]

        public bool Literacy { get; set; }
        //[Display(Name = "Literacy")]

        public bool MixedMedia { get; set; }
        //[Display(Name = "Mixed Media")]

        public bool MultiCultural { get; set; }
        //[Display(Name = "Multicultural")]

        public bool Music { get; set; }
        //[Display(Name = "Music")]

        public bool Pasifika { get; set; }
        //[Display(Name = "Pasifika")]

        public bool Photography { get; set; }
        //[Display(Name = "Photography")]

        public bool PublicArt { get; set; }
        //[Display(Name = "Public Art")]

        public bool Sculpture { get; set; }
        //[Display(Name = "Sculpture")]

        public bool Textiles { get; set; }
        //[Display(Name = "Textiles")]

        public bool Theatre { get; set; }
        //[Display(Name = "Theatre")]

        public bool ToiMaori { get; set; }
        //[Display(Name = "Toi Maori")]

        [Display(Name = "Add your Facebook profile link")]
        public string FacebookLink { get; set; } //make Facebook profile visible

        [Display(Name = "Add your YouTube link")]
        public string YoutubeLink { get; set; } //make Youtube profile visible

        [Display(Name = "Add your website link")]
        public string WebsiteLink { get; set; } //make website visible

        [Display(Name = "Add your Instagram link")]
        public string InstagramLink { get; set; } //make Instagram visible

        [Display(Name = "Add your DeviantArt link")]
        public string DeviantArt { get; set; } //make DeviantArt visible
    }
}
