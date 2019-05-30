using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace AM1.Models
{
    public class VolForm
    {
        [Key]
        public int VolFormID { get; set; }
        [Required(ErrorMessage = "First name required")] // Must enter first name 
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "First name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")] // Must enter last name
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address required")] // Must enter address
        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "Phone number required")] // Must enter phone number
        [Display(Name = "Phone Number")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide valid email")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Referee one name required")] // Must enter referee one name
        //[Display(Name = "Referee One Name")]
        //[StringLength(50, ErrorMessage = "Referee one name cannot be longer than 50 characters.")]
        //public string RefOne { get; set; }

        //[Required(ErrorMessage = "Referee one contact required")] // Must enter referee one contact details
        //[Display(Name = "Referee One Contact Details")]
        //[StringLength(50, ErrorMessage = "Referee one contact details cannot be longer than 50 characters.")]
        //public string RefOneContact { get; set; }

        //[Required(ErrorMessage = "Referee two name required")] // Must enter referee two name
        //[Display(Name = "Referee Two Name")]
        //[StringLength(50, ErrorMessage = "Referee two name cannot be longer than 50 characters.")]
        //public string RefTwo { get; set; }

        //[Required(ErrorMessage = "Referee two contact details required")] // Must enter referee two contact details
        //[Display(Name = "Referee Two Contact Details")]
        //[StringLength(50, ErrorMessage = "Referee two contact details cannot be longer than 50 characters.")]
        //public string RefTwoContact { get; set; }

        [Required(ErrorMessage = "Preferred method of contact required")] // Must select preferred method
        [Display(Name = "How do you want us to contact you")]
        public string ContactMethod { get; set; }
        //public IEnumerable<SelectListItem> Contact { get; set; }

        //public virtual AreaOfInterest AoI { get; set; }

        [Required(ErrorMessage = "Previous experience required")] // Must enter previous experience
        [Display(Name = "Previous experience volunteering")]
        [StringLength(200, ErrorMessage = "Referee two contact details cannot be longer than 200 characters.")]
        public string PreviousExperience { get; set; }

        [Required(ErrorMessage = "First aid certificate required")] // First aid certificate radio buttons yes or no
        [Display(Name = "Do you have a current first aid certificate?")]
        public bool FirstAidCertificate { get; set; }

        [Required(ErrorMessage = "Police vet check required selection required")] // Police vet check buttons yes or no
        [Display(Name = "Do you consent to a police vet check?")]
        public bool PoliceVetCheck { get; set; }

        [Required(ErrorMessage = "Must agree to terms and conditions before continuing")] // Terms and conditions check box
        [Display(Name = "Do you agree to Arts Murihiku's Terms and Conditions ")]
        public bool TermsAndConditions { get; set; }

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

        //public InterestArea InterestArea { get; set; }
        //public int AreaOfInterestID { get; set; }

    }
}
