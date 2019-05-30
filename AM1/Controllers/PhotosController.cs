using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AM1.Data;
using AM1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace AM1.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public PhotosController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = hostingEnvironment;
            _userManager = userManager;
        }

        // GET: Photos
        public async Task<IActionResult> Index(string albumid)
        {
            var context = _context.Photos.Where(p => p.PhotoAlbumID.Equals(albumid));
            return View(await context.ToListAsync());
        }


        [HttpGet]
        public IActionResult PhotoUpload(string albumid)
        {
            ViewBag.Invalid = false;

            var dbcheck = _context.Album.Where(a => a.AlbumID.Equals(albumid));
            if (dbcheck.Count() == 0)
            {
                ViewBag.Invalid = true;
                return View();
            }

            ViewBag.albumID = albumid;
            return View();
        }

        [HttpPost]
        public IActionResult PhotoUpload(string albumID, IFormFile[] files)
        {
            string currentUserID = _userManager.GetUserId(User);

            foreach (IFormFile item in files)
            {
                string itemname = item.FileName;
                Photos photo = new Photos()
                {
                    FileName = itemname,
                    PhotoAlbumID = albumID,
                    FileFullPath = string.Format("/Album/{0}/{1}", albumID, itemname),
                    PhotoOwner = currentUserID
                };
                _context.Add(photo);
                _context.SaveChanges();

                string folderPath = string.Format("{0}/Album/{1}", _env.WebRootPath, albumID);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string serverfilepath = string.Format("{0}/Album/{1}/{2}", _env.WebRootPath, albumID, itemname);
                using (FileStream fs = new FileStream(serverfilepath, FileMode.Create))
                {
                    item.CopyTo(fs);
                }
            }
            ViewBag.Uploaded = "Uploaded!";

            return RedirectToAction("Index", "Albums");
           
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .SingleOrDefaultAsync(m => m.PhotoID == id);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoID,FileName,FileFullPath,PhotoAlbumID")] Photos photos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photos);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos.SingleOrDefaultAsync(m => m.PhotoID == id);
            if (photos == null)
            {
                return NotFound();
            }
            return View(photos);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PhotoID,FileName,FileFullPath,PhotoAlbumID")] Photos photos)
        {
            if (id != photos.PhotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotosExists(photos.PhotoID))
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
            return View(photos);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .SingleOrDefaultAsync(m => m.PhotoID == id);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var photos = await _context.Photos.SingleOrDefaultAsync(m => m.PhotoID == id);
            _context.Photos.Remove(photos);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Albums");
        }

        private bool PhotosExists(string id)
        {
            return _context.Photos.Any(e => e.PhotoID == id);
        }
    }
}
