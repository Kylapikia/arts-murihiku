using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class GMapModel
    {
        [Key]
        public int GMapID { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public string GName { get; set; }
        public string GDisciplines { get; set; }
        public string GAddress { get; set; }
        public string GLinkProfile { get; set; }
        public string GProfilePic { get; set; }

        public string MondayOpen { get; set; }
        public string MondayClose { get; set; }

        public string TuesdayOpen { get; set; }
        public string TuesdayClose { get; set; }

        public string WednesdayOpen { get; set; }
        public string WednesdayClose { get; set; }

        public string ThursdayOpen { get; set; }
        public string ThursdayClose { get; set; }

        public string FridayOpen { get; set; }
        public string FridayClose { get; set; }

        public string SaturdayOpen { get; set; }
        public string SaturdayClose { get; set; }

        public string SundayOpen { get; set; }
        public string SundayClose { get; set; }
        
    }
}
