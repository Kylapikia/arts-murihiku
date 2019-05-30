using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AM1.Data;
using AM1.Models;

namespace AM1.Controllers
{
    public class ArtistDirectoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistDirectoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtistDirectories
        public async Task<IActionResult> Index(
            string Byname,
            string creativetype,
            string artDiscipline,
            string location,
            string sortingmode)
        {

            var artists = _context.ApplicationUser.Where(a => a.Artist);

            if (!string.IsNullOrEmpty(Byname)) artists = artists.Where(a => a.Name.Equals(Byname));

            if (!string.IsNullOrEmpty(creativetype))
            {
                if (creativetype == "Individual")
                {
                    artists = artists.Where(a => a.Individual);
                }
                if (creativetype == "Organisation")
                {
                    artists = artists.Where(a => a.Organisation);
                }
                if (creativetype == "Festival")
                {
                    artists = artists.Where(a => a.Festival);
                }
                if (creativetype == "CreativeSpace")
                {
                    artists = artists.Where(a => a.CreativeSpace);
                }
            }

            if (!string.IsNullOrEmpty(artDiscipline))
            {

                if (artDiscipline == "Paint")
                {
                    artists = artists.Where(a => a.Paint);
                }
                if (artDiscipline == "Literacy")
                {
                    artists = artists.Where(a => a.Literacy);
                }
                if (artDiscipline == "Design")
                {
                    artists = artists.Where(a => a.Design);
                }
                if (artDiscipline == "MixedMedia")
                {
                    artists = artists.Where(a => a.MixedMedia);
                }
                if (artDiscipline == "Education")
                {
                    artists = artists.Where(a => a.Education);
                }
                if (artDiscipline == "Multiculture")
                {
                    artists = artists.Where(a => a.MultiCultural);
                }
                if (artDiscipline == "Film")
                {
                    artists = artists.Where(a => a.Film);
                }
                if (artDiscipline == "Music")
                {
                    artists = artists.Where(a => a.Music);
                }
                if (artDiscipline == "Photography")
                {
                    artists = artists.Where(a => a.Photography);
                }
                if (artDiscipline == "Pasifika")
                {
                    artists = artists.Where(a => a.Pasifika);
                }
                if (artDiscipline == "PubArt")
                {
                    artists = artists.Where(a => a.PublicArt);
                }
                if (artDiscipline == "Sculpture")
                {
                    artists = artists.Where(a => a.Sculpture);
                }
                if (artDiscipline == "Textiles")
                {
                    artists = artists.Where(a => a.Textiles);
                }
                if (artDiscipline == "ToiMaori")
                {
                    artists = artists.Where(a => a.ToiMaori);
                }
                if (artDiscipline == "Theatre")
                {
                    artists = artists.Where(a => a.Theatre);
                }
            }

            if (!string.IsNullOrEmpty(location))
            {
                if (location == "Invercargill") artists = artists.Where(a => a.City.Equals("Invercargill"));
                if (location == "Bluff") artists = artists.Where(a => a.City.Equals("Bluff"));
                if (location == "Gore") artists = artists.Where(a => a.City.Equals("Gore"));
                if (location == "Te Anau") artists = artists.Where(a => a.City.Equals("Te Anau"));
                if (location == "Queenstown") artists = artists.Where(a => a.City.Equals("Queenstown"));
                if (location == "Arrowtown") artists = artists.Where(a => a.City.Equals("Arrowtown"));
                if (location == "Mataura") artists = artists.Where(a => a.City.Equals("Mataura"));
                if (location == "Mossburn") artists = artists.Where(a => a.City.Equals("Mossburn"));
                if (location == "Riverton") artists = artists.Where(a => a.City.Equals("Riverton"));
                if (location == "Nightcaps") artists = artists.Where(a => a.City.Equals("Nightcaps"));
            }

            if (sortingmode == "old") artists = artists.OrderBy(a => a.AccountCreated);
            if (sortingmode == "new") artists = artists.OrderByDescending(a => a.AccountCreated);
            if (sortingmode == "asc") artists = artists.OrderBy(a => a.Name);
            if (sortingmode == "desc") artists = artists.OrderByDescending(a => a.Name);

            return View(await artists.ToListAsync());
        }

        // GET: ArtistDirectories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var Albums = _context.Album.Where(a => a.AlbumOwner.Equals(id));
            var contextPhotos = _context.Photos.Where(p => p.PhotoOwner.Equals(id));

            ViewBag.Albums = Albums.ToList();
            ViewBag.Thumbs = contextPhotos.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        //// GET: ArtistDirectories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ArtistDirectories/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FirstTimeSetup,Name,ProfilePic,City,Address,ArtistDescription,Individual,Organisation,CreativeSpace,Festival,Paint,Design,Education,Film,Literacy,MixedMedia,MultiCultural,Music,Pasifika,Photography,PublicArt,Sculpture,Textiles,Theatre,ToiMaori,FacebookLink,YoutubeLink,WebsiteLink,InstagramLink,DeviantArt,Artist,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(applicationUser);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicationUser);
        //}

        //// GET: ArtistDirectories/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
        //    if (applicationUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(applicationUser);
        //}

        //// POST: ArtistDirectories/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("FirstTimeSetup,Name,ProfilePic,City,Address,ArtistDescription,Individual,Organisation,CreativeSpace,Festival,Paint,Design,Education,Film,Literacy,MixedMedia,MultiCultural,Music,Pasifika,Photography,PublicArt,Sculpture,Textiles,Theatre,ToiMaori,FacebookLink,YoutubeLink,WebsiteLink,InstagramLink,DeviantArt,Artist,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        //{
        //    if (id != applicationUser.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(applicationUser);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ApplicationUserExists(applicationUser.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicationUser);
        //}

        //// GET: ArtistDirectories/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicationUser = await _context.ApplicationUser
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (applicationUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicationUser);
        //}

        //// POST: ArtistDirectories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.ApplicationUser.Remove(applicationUser);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
