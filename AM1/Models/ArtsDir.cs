using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class ArtsDir
    {
        [Key]
        public int ArtsDirID { get; set; }
        //picture1
        public string Picture1 { get; set; }
        //picture2
        public string Picture2 { get; set; }
        //picture3
        public string Picture3 { get; set; }
        //picture4
        public string Picture4 { get; set; }
        //picture5
        public string Picture5 { get; set; }
        //arts name
        [Display(Name = "Art Name")]
        public string ArtName { get; set; }
        //link to profile
        [Display(Name = "Profile Link")]
        public string ProfileLink { get; set; }
        //description of the arts
        [Display(Name = "Description")]
        public string Description { get; set; }
        //category        
        [Display(Name = "Paint")]
        public bool Paint { get; set; }

        [Display(Name = "Design")]
        public bool Design { get; set; }

        [Display(Name = "Creative Space")]
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
    }
}
