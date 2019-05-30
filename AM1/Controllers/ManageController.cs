using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AM1.Models;
using AM1.Models.ManageViewModels;
using AM1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AM1.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IHostingEnvironment he;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public ManageController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          IHostingEnvironment e)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
            he = e;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            // Kyla changed stuff here
            var model = new IndexViewModel
            {
                Namee = user.Name,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                // here
                Address = user.Address,
                ProfilePic = user.ProfilePic,
                City = user.City,
                WebsiteLink = user.WebsiteLink,
                FacebookLink = user.FacebookLink,
                InstagramLink = user.InstagramLink,
                YoutubeLink = user.YoutubeLink,
                ArtistDescription = user.ArtistDescription,
                Individual = user.Individual,
                Organisation = user.Organisation,
                CreativeSpace = user.CreativeSpace,
                Festival = user.Festival,
                Paint = user.Paint,
                Design = user.Design,
                Education = user.Education,
                Film = user.Film,
                Literacy = user.Literacy,
                MixedMedia = user.MixedMedia,
                MultiCultural = user.MultiCultural,
                Pasifika = user.Pasifika,
                Photography = user.Photography,
                PublicArt = user.PublicArt,
                Sculpture = user.Sculpture,
                Textiles = user.Textiles,
                Theatre = user.Theatre,
                ToiMaori = user.ToiMaori,
                DeviantArt = user.DeviantArt,
                Music = user.Music,
                Location = user.Location,
                FullAddress = user.FullAddress,
                PostCode = user.PostCode,
                Suburb = user.Suburb,
                // to here
                // are they visable?
                IsAddressVisable = user.IsAddressVisable,
                IsEmailVisable = user.IsEmailVisable,
                IsPhoneVisable = user.IsPhoneVisable,
                // are they visable?
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage

            };
            ViewData["fileLocation"] = "/images/resources/NoPic.jpg";

            if (!string.IsNullOrEmpty(user.ProfilePic))
            {
                ViewData["fileLocation"] = user.ProfilePic;
            }
            else
            {
                ViewData["fileLocation"] = "/images/resources/NoPic.jpg";
            }

            //henri
            if (user.Artist)
            {
                return View(model);
            }
            else
            {
                return View("Normal", model);
            }
            //return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model, IFormFile pic, string city)
        {
            //henri
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                //henri                
                if (user.Artist)
                {
                    return View("", model);
                }
                else
                {
                    return View("Normal", model);
                }
                //return View(model);
            }

            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }



            var Name = user.Name;
            if (model.Namee != Name)
            {
                user.Name = model.Namee;
                var setCityResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setCityResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }


            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            // Kyla This is a weird way to do it but it works. Setting the other fields through the email field....................... 
            var profilePic = user.ProfilePic;
            if (pic != null)
            {
                user.ProfilePic = "/images/profile/" + Path.GetFileName(pic.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/profile/", Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                var setProfilePicResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setProfilePicResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Location = user.Location;
            if (model.Location != Location)
            {
                user.Location = model.Location;
                user.Address = string.Format("{0}, {1}, {2}, {3}", model.Location, model.Suburb, model.City, model.PostCode);
                var setLocationResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setLocationResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            //user.Address = string.Format("{0}, {1}, {2}, {3}", user.Location, user.Suburb, user.City, user.PostCode);
            //var setAddressResult = await _userManager.SetEmailAsync(user, model.Email);
            //if (!setAddressResult.Succeeded)
            //{
            //    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
            //}



            user.Address = string.Format("{0}, {1}, {2}, {3}", model.Location, model.Suburb, model.City, model.PostCode);
            await _userManager.UpdateAsync(user);

            //var Address = user.Address;
            //if (model.Address != Address)
            //{

            //    var setSuburbResult = await _userManager.SetEmailAsync(user, model.Email);
            //    if (!setSuburbResult.Succeeded)
            //    {
            //        throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
            //    }
            //}



            var Suburb = user.Suburb;
            if (model.Suburb != Suburb)
            {
                user.Suburb = model.Suburb;
                var setSuburbResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setSuburbResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var City = user.City;
            if (model.City != City)
            {
                user.City = model.City;
                var setCityResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setCityResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var PostCode = user.PostCode;
            if (model.PostCode != PostCode)
            {
                user.PostCode = model.PostCode;
                var setPostCodeResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPostCodeResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var FullAddress = user.FullAddress;
            if (model.FullAddress != FullAddress)
            {
                user.FullAddress = string.Format("{0}, {1}, {2}, {3}", user.Location, user.Suburb, user.City, user.PostCode);
                var setFullAddressResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setFullAddressResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var isEmailVisable = user.IsEmailVisable;
            if (model.IsEmailVisable != isEmailVisable)
            {
                user.IsEmailVisable = model.IsEmailVisable;
                var setIsEmailVisableResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setIsEmailVisableResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var IsPhoneVisable = user.IsPhoneVisable;
            if (model.IsPhoneVisable != IsPhoneVisable)
            {
                user.IsPhoneVisable = model.IsPhoneVisable;
                var setIsPhoneVisableResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setIsPhoneVisableResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var IsAddressVisable = user.IsAddressVisable;
            if (model.IsAddressVisable != IsAddressVisable)
            {
                user.IsAddressVisable = model.IsAddressVisable;
                var setIsAddressVisableResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setIsAddressVisableResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            //var name = user.Name;
            //if (model.Username != name)
            //{
            //    user.Name = model.Username;
            //    var setNameResult = await _userManager.SetEmailAsync(user, model.Email);
            //    if (!setNameResult.Succeeded)
            //    {
            //        throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
            //    }
            //}

            var website = user.WebsiteLink;
            if (model.WebsiteLink != website)
            {
                user.WebsiteLink = model.WebsiteLink;
                var setWebsiteResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setWebsiteResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            var facebook = user.FacebookLink;
            if (model.FacebookLink != facebook)
            {
                user.FacebookLink = model.FacebookLink;
                var setFacebookResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setFacebookResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            var instagram = user.InstagramLink;
            if (model.InstagramLink != instagram)
            {
                user.InstagramLink = model.InstagramLink;
                var setInstagramResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setInstagramResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            var youTube = user.YoutubeLink;
            if (model.YoutubeLink != youTube)
            {
                user.YoutubeLink = model.YoutubeLink;
                var setYouTubeResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setYouTubeResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            var description = user.ArtistDescription;
            if (model.ArtistDescription != description)
            {
                user.ArtistDescription = model.ArtistDescription;
                var setDescriptionResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setDescriptionResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Individual = user.Individual;
            if (model.Individual != Individual)
            {
                user.Individual = model.Individual;
                var setIndividualResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setIndividualResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Organisation = user.Organisation;
            if (model.Organisation != Organisation)
            {
                user.Organisation = model.Organisation;
                var setOrganisationResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setOrganisationResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var CreativeSpace = user.CreativeSpace;
            if (model.CreativeSpace != CreativeSpace)
            {
                user.CreativeSpace = model.CreativeSpace;
                var setCreativeSpaceResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setCreativeSpaceResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Festival = user.Festival;
            if (model.Festival != Festival)
            {
                user.Festival = model.Festival;
                var setFestivalResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setFestivalResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Paint = user.Paint;
            if (model.Paint != Paint)
            {
                user.Paint = model.Paint;
                var setPaintResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPaintResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Design = user.Design;
            if (model.Design != Design)
            {
                user.Design = model.Design;
                var setDesignResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setDesignResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Education = user.Education;
            if (model.Education != Education)
            {
                user.Education = model.Education;
                var setEducationResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEducationResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Film = user.Film;
            if (model.Film != Film)
            {
                user.Film = model.Film;
                var setFilmResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setFilmResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Literacy = user.Literacy;
            if (model.Literacy != Literacy)
            {
                user.Literacy = model.Literacy;
                var setLiteracyResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setLiteracyResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var MixedMedia = user.MixedMedia;
            if (model.MixedMedia != MixedMedia)
            {
                user.MixedMedia = model.MixedMedia;
                var setMixedMediaResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setMixedMediaResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var MultiCultural = user.MultiCultural;
            if (model.MultiCultural != MultiCultural)
            {
                user.MultiCultural = model.MultiCultural;
                var setMultiCulturalResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setMultiCulturalResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Pasifika = user.Pasifika;
            if (model.Pasifika != Pasifika)
            {
                user.Pasifika = model.Pasifika;
                var setPasifikaResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPasifikaResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Photography = user.Photography;
            if (model.Photography != Photography)
            {
                user.Photography = model.Photography;
                var setPhotographyResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPhotographyResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var PublicArt = user.PublicArt;
            if (model.PublicArt != PublicArt)
            {
                user.PublicArt = model.PublicArt;
                var setPublicArtResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPublicArtResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Sculpture = user.Sculpture;
            if (model.Sculpture != Sculpture)
            {
                user.Sculpture = model.Sculpture;
                var setPublicArtResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setPublicArtResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Textiles = user.Textiles;
            if (model.Textiles != Textiles)
            {
                user.Textiles = model.Textiles;
                var setTextilesResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setTextilesResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Theatre = user.Theatre;
            if (model.Theatre != Theatre)
            {
                user.Theatre = model.Theatre;
                var setTheatreResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setTheatreResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var ToiMaori = user.ToiMaori;
            if (model.ToiMaori != ToiMaori)
            {
                user.ToiMaori = model.ToiMaori;
                var setToiMaoriResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setToiMaoriResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var DeviantArt = user.DeviantArt;
            if (model.DeviantArt != DeviantArt)
            {
                user.DeviantArt = model.DeviantArt;
                var setDeviantArtResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setDeviantArtResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            var Music = user.Music;
            if (model.Music != Music)
            {
                user.Music = model.Music;
                var setMusicResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setMusicResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            StatusMessage = "Your profile has been updated";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendVerificationEmail(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
            var email = user.Email;
            await _emailSender.SendEmailConfirmationAsync(email, callbackUrl);

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Your password has been set.";

            return RedirectToAction(nameof(SetPassword));
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLogins()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new ExternalLoginsViewModel { CurrentLogins = await _userManager.GetLoginsAsync(user) };
            model.OtherLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .Where(auth => model.CurrentLogins.All(ul => auth.Name != ul.LoginProvider))
                .ToList();
            model.ShowRemoveButton = await _userManager.HasPasswordAsync(user) || model.CurrentLogins.Count > 1;
            model.StatusMessage = StatusMessage;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkLogin(string provider)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Request a redirect to the external login provider to link a login for the current user
            var redirectUrl = Url.Action(nameof(LinkLoginCallback));
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, _userManager.GetUserId(User));
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> LinkLoginCallback()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync(user.Id);
            if (info == null)
            {
                throw new ApplicationException($"Unexpected error occurred loading external login info for user with ID '{user.Id}'.");
            }

            var result = await _userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred adding external login for user with ID '{user.Id}'.");
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            StatusMessage = "The external login was added.";
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var result = await _userManager.RemoveLoginAsync(user, model.LoginProvider, model.ProviderKey);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred removing external login for user with ID '{user.Id}'.");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "The external login was removed.";
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpGet]
        public async Task<IActionResult> TwoFactorAuthentication()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new TwoFactorAuthenticationViewModel
            {
                HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null,
                Is2faEnabled = user.TwoFactorEnabled,
                RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Disable2faWarning()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new ApplicationException($"Unexpected error occured disabling 2FA for user with ID '{user.Id}'.");
            }

            return View(nameof(Disable2fa));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disable2fa()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occured disabling 2FA for user with ID '{user.Id}'.");
            }

            _logger.LogInformation("User with ID {UserId} has disabled 2fa.", user.Id);
            return RedirectToAction(nameof(TwoFactorAuthentication));
        }

        [HttpGet]
        public async Task<IActionResult> EnableAuthenticator()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new EnableAuthenticatorViewModel();
            await LoadSharedKeyAndQrCodeUriAsync(user, model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableAuthenticator(EnableAuthenticatorViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadSharedKeyAndQrCodeUriAsync(user, model);
                return View(model);
            }

            // Strip spaces and hypens
            var verificationCode = model.Code.Replace(" ", string.Empty).Replace("-", string.Empty);

            var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(
                user, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

            if (!is2faTokenValid)
            {
                ModelState.AddModelError("Code", "Verification code is invalid.");
                await LoadSharedKeyAndQrCodeUriAsync(user, model);
                return View(model);
            }

            await _userManager.SetTwoFactorEnabledAsync(user, true);
            _logger.LogInformation("User with ID {UserId} has enabled 2FA with an authenticator app.", user.Id);
            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            TempData[RecoveryCodesKey] = recoveryCodes.ToArray();

            return RedirectToAction(nameof(ShowRecoveryCodes));
        }

        [HttpGet]
        public IActionResult ShowRecoveryCodes()
        {
            var recoveryCodes = (string[])TempData[RecoveryCodesKey];
            if (recoveryCodes == null)
            {
                return RedirectToAction(nameof(TwoFactorAuthentication));
            }

            var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes };
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetAuthenticatorWarning()
        {
            return View(nameof(ResetAuthenticator));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAuthenticator()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            _logger.LogInformation("User with id '{UserId}' has reset their authentication app key.", user.Id);

            return RedirectToAction(nameof(EnableAuthenticator));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateRecoveryCodesWarning()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new ApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' because they do not have 2FA enabled.");
            }

            return View(nameof(GenerateRecoveryCodes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateRecoveryCodes()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!user.TwoFactorEnabled)
            {
                throw new ApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' as they do not have 2FA enabled.");
            }

            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            _logger.LogInformation("User with ID {UserId} has generated new 2FA recovery codes.", user.Id);

            var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes.ToArray() };

            return View(nameof(ShowRecoveryCodes), model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
            }

            return result.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _urlEncoder.Encode("AM1"),
                _urlEncoder.Encode(email),
                unformattedKey);
        }

        private async Task LoadSharedKeyAndQrCodeUriAsync(ApplicationUser user, EnableAuthenticatorViewModel model)
        {
            var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(unformattedKey))
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
            }

            model.SharedKey = FormatKey(unformattedKey);
            model.AuthenticatorUri = GenerateQrCodeUri(user.Email, unformattedKey);
        }

        #endregion
    }
}
