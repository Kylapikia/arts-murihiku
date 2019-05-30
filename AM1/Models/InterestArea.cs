using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AM1.Models
{
    public class InterestArea
    {
        [Key]
        public int AreaOfInterestID { get; set; }

        [Display(Name = "Lighting")]
        public bool Lighting { get; set; }

        [Display(Name = "Sound")]
        public bool Sound { get; set; }

        [Display(Name = "Set Building")]
        public bool SetBuilding { get; set; }

        [Display(Name = "Make-up")]
        public bool MakeUp { get; set; }

        [Display(Name = "Hair")]
        public bool Hair { get; set; }

        [Display(Name = "Costuming")]
        public bool Costuming { get; set; }

        [Display(Name = "Props")]
        public bool Props { get; set; }

        [Display(Name = "Stage Management")]
        public bool StageManagement { get; set; }

        [Display(Name = "Prompt")]
        public bool Prompt { get; set; }

        [Display(Name = "Front of House")]
        public bool FrontOfHouse { get; set; }

        [Display(Name = "Catering")]
        public bool Catering { get; set; }

        [Display(Name = "Publicity and Promotion")]
        public bool PublicityAndPromotion { get; set; }

        //Visual Arts and Craft

        [Display(Name = "Assistance with Hosting Visitors")]
        public bool AssistanceVisitors { get; set; }

        [Display(Name = "Assistance with Exhibitions-General")]
        public bool AssistanceExhibitionsGen { get; set; }

        [Display(Name = "Assistance with Workshops")]
        public bool AssistanceWorkshops { get; set; }

        [Display(Name = "Publicity and Promotion")]
        public bool PublicityAndPromotion1 { get; set; }

        [Display(Name = "Support with Openings")]
        public bool SupportOpenings { get; set; }

        //Literary, Multi-media, Festivals

        [Display(Name = "Assistance with Hosting Visitors")]
        public bool AssistanceVisitors1 { get; set; }

        [Display(Name = "Assistance with Exhibitions-General")]
        public bool AssistanceExhibitionsGen1 { get; set; }

        [Display(Name = "Publicity and Promotion")]
        public bool PublicityAndPromotion2 { get; set; }

        [Display(Name = "Support with Openings")]
        public bool SupportOpenings1 { get; set; }

        [Display(Name = "Assistance with Workshops")]
        public bool AssistanceWorkshops1 { get; set; }

        //Overall assistance with Social Media and Web development

        [Display(Name = "Website Development")]
        public bool WebsiteDevelopment { get; set; }

        [Display(Name = "Instagram")]
        public bool Instagram { get; set; }

        [Display(Name = "Snapchat")]
        public bool SnapChat { get; set; }

        [Display(Name = "Facebook")]
        public bool Facebook { get; set; }

        [Display(Name = "Twitter")]
        public bool Twitter { get; set; }

        [Display(Name = "App Development")]
        public bool AppDevelopment { get; set; }
    }
}
