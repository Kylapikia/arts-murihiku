using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int RegisterID { get; set; }
        [Required(ErrorMessage = "Name or Organization name required")] // Must enter name or organization name 
        [Display(Name = "Name/Organization")]
        [StringLength(50, ErrorMessage = "Name or Organization name cannot be longer than 30 characters.")]
        public string Name { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
                ErrorMessage = "Please provide valid email")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
        // is Email, Phone and Address visable?
        [Display(Name = "Show Email")]
        public bool IsEmailVisable { get; set; }
        [Display(Name = "Show Phone Number")]
        public bool IsPhoneVisable { get; set; }

        [Display(Name = "Show Address")]
        public bool IsAddressVisable { get; set; }
        // end if is Email, Phone and Address visable?
        [Required(ErrorMessage = "Must agree to terms and conditions before continuing")] // Terms and conditions check box
        [Display(Name = "I agree to Arts Murihikus' Terms and Conditions")]
        public bool TermsAndConditions { get; set; }

        [Display(Name = "Upload profile picture")]
        public string ProfilePic { get; set; } //artists or organizations profile pic

        [Display(Name = "City")]
        public string City { get; set; } //City visible 

        [Display(Name = "Address")]
        public string Address { get; set; } //address visible 
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

        public bool Artist { get; set; }
    }
}
