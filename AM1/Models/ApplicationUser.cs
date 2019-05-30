using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AM1.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool FirstTimeSetup { get; set; }
        public string Name { get; set; }

        [Display(Name = "Upload profile picture")]
        public string ProfilePic { get; set; } //artists or organizations profile pic

        [Display(Name = "City")]
        public string City { get; set; } //City visible 

        [Display(Name = "Address")]

        public string Address { get; set; } //address visible 
        [Display(Name = "Location")]
        public string Location { get; set; }

        public string Suburb { get; set; }

        public string PostCode { get; set; }

        public string FullAddress { get; set; }
        // is Email, Phone and Address visable?
        [Display(Name = "Show Email")]
        public bool IsEmailVisable { get; set; }
        [Display(Name = "Show Phone Number")]
        public bool IsPhoneVisable { get; set; }

        [Display(Name = "Show Address")]
        public bool IsAddressVisable { get; set; }
        // end if is Email, Phone and Address visable?
        [Display(Name = "Description")]
        public string ArtistDescription { get; set; }


        //creative type
        [Display(Name = "Individual")]
        public bool Individual { get; set; }

        [Display(Name = "Organisation")]
        public bool Organisation { get; set; }

        [Display(Name = "Creative Space")]
        public bool CreativeSpace { get; set; }

        [Display(Name = "Festival")]
        public bool Festival { get; set; }



        public List<string> Creatives()
        {
            List<string> list = new List<string>();
            if (Individual) list.Add("Individual");
            if (Organisation) list.Add("Organisation");
            if (CreativeSpace) list.Add("Creative Space");
            if (Festival) list.Add("Festival");
            return list;
        }


        public List<string> CreativesList
        {
            get { return Creatives(); }
        }








        //Discipline
        [Display(Name = "Paint")]
        public bool Paint { get; set; }

        [Display(Name = "Design")]
        public bool Design { get; set; }

        [Display(Name = "Education")]
        public bool Education { get; set; }

        [Display(Name = "Film")]
        public bool Film { get; set; }

        [Display(Name = "Literacy")]
        public bool Literacy { get; set; }

        [Display(Name = "Mixed Media")]
        public bool MixedMedia { get; set; }

        [Display(Name = "Multicultural")]
        public bool MultiCultural { get; set; }

        [Display(Name = "Music")]
        public bool Music { get; set; }

        [Display(Name = "Pasifika")]
        public bool Pasifika { get; set; }

        [Display(Name = "Photography")]
        public bool Photography { get; set; }

        [Display(Name = "Public Art")]
        public bool PublicArt { get; set; }

        [Display(Name = "Sculpture")]
        public bool Sculpture { get; set; }

        [Display(Name = "Textiles")]
        public bool Textiles { get; set; }

        [Display(Name = "Theatre")]
        public bool Theatre { get; set; }

        [Display(Name = "Toi Maori")]
        public bool ToiMaori { get; set; }

        public List<string> Disciplines()
        {
            List<string> list = new List<string>();
            if (Paint) list.Add("Paint");
            if (Design) list.Add("Design");
            if (Education) list.Add("Education");
            if (Film) list.Add("Film");
            if (Literacy) list.Add("Literacy");
            if (MixedMedia) list.Add("Mixed Media");
            if (MultiCultural) list.Add("Multicultural");
            if (Music) list.Add("Music");
            if (Pasifika) list.Add("Pasifika");
            if (Photography) list.Add("Photography");
            if (PublicArt) list.Add("Public Art");
            if (Sculpture) list.Add("Sculpture");
            if (Textiles) list.Add("Textiles");
            if (Theatre) list.Add("Theatre");
            if (ToiMaori) list.Add("Toi Maori");
            return list;
        }


        public List<string> DisciplineList
        {
            get { return Disciplines(); }
        }


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

        public DateTime AccountCreated { get; set; }
        public double CartID { get; set; }

        public bool AddedToMap { get; set; }

        public int MyGMapID { get; set; }

    }
}
