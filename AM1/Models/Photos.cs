using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class Photos
    {
        [Key]
        public string PhotoID { get; set; }
        public string FileName { get; set; }
        public string FileFullPath { get; set; }
        public string PhotoAlbumID { get; set; }
        public string PhotoOwner { get; set; }
    }
}
