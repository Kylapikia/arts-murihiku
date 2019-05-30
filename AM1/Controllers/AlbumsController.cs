using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AM1.Data;
using AM1.Models;
using Microsoft.AspNetCore.Identity;


namespace AM1.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AlbumsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        // GET: Albums
        public async Task<IActionResult> Index()
        {
            string currentUserID = _userManager.GetUserId(User);

            var context = _context.Album.Where(a => a.AlbumOwner.Equals(currentUserID));
            ViewBag.photoList = _context.Photos.ToList();

            return View(await context.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            ViewBag.PhotoList = _context.Photos.Where(p => p.PhotoAlbumID.Equals(id));

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,AlbumDescription,AlbumTitle")] Album album)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            string currentUserID = currentUser.Id;


            if (ModelState.IsValid)
            {
                album.AlbumOwner = currentUserID;
                album.AlbumCreatedTime = DateTime.Now;
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AlbumID,AlbumDescription,AlbumTitle")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .SingleOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumID == id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Albums");
        }

        private bool AlbumExists(string id)
        {
            return _context.Album.Any(e => e.AlbumID == id);
        }
    }
}
