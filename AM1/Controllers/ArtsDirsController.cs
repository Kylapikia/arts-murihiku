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
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AM1.Controllers
{
    public class ArtsDirsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public ArtsDirsController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        // GET: ArtsDirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtsDir.ToListAsync());
        }

        // GET: ArtsDirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artsDir = await _context.ArtsDir
                .SingleOrDefaultAsync(m => m.ArtsDirID == id);
            if (artsDir == null)
            {
                return NotFound();
            }
            ViewData["fileLocation1"] = "/images/gallery/" + Path.GetFileName(artsDir.Picture1);
            ViewData["fileLocation2"] = "/images/gallery/" + Path.GetFileName(artsDir.Picture2);
            ViewData["fileLocation3"] = "/images/gallery/" + Path.GetFileName(artsDir.Picture3);
            ViewData["fileLocation4"] = "/images/gallery/" + Path.GetFileName(artsDir.Picture4);
            ViewData["fileLocation5"] = "/images/gallery/" + Path.GetFileName(artsDir.Picture5);
            return View(artsDir);
        }

        // GET: ArtsDirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtsDirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtsDirID,Picture1,Picture2,Picture3,Picture4,Picture5,ArtName,ProfileLink,Description,Paint,Design,Education,Film,Literacy,MixedMedia,MultiCultural,Music,Pasifika,Photography,PublicArt,Sculpture,Textiles,Theatre")] ArtsDir artsDir, IFormFile pic1, IFormFile pic2, IFormFile pic3, IFormFile pic4, IFormFile pic5)
        {
            if (pic1 != null)
            {
                artsDir.Picture1 = "/images/gallery/" + Path.GetFileName(pic1.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/gallery/", Path.GetFileName(pic1.FileName));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                pic1.CopyTo(fs);
                fs.Close();
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (pic2 != null)
            {
                artsDir.Picture2 = "/images/gallery/" + Path.GetFileName(pic2.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/gallery/", Path.GetFileName(pic2.FileName));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                pic2.CopyTo(fs);
                fs.Close();
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (pic3 != null)
            {
                artsDir.Picture3 = "/images/gallery/" + Path.GetFileName(pic3.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/gallery/", Path.GetFileName(pic3.FileName));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                pic3.CopyTo(fs);
                fs.Close();
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (pic4 != null)
            {
                artsDir.Picture4 = "/images/gallery/" + Path.GetFileName(pic4.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/gallery/", Path.GetFileName(pic4.FileName));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                pic4.CopyTo(fs);
                fs.Close();
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (pic5 != null)
            {
                artsDir.Picture5 = "/images/gallery/" + Path.GetFileName(pic5.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/gallery/", Path.GetFileName(pic5.FileName));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                pic5.CopyTo(fs);
                fs.Close();
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (ModelState.IsValid)
            {
                _context.Add(artsDir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artsDir);
        }

        // GET: ArtsDirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artsDir = await _context.ArtsDir.SingleOrDefaultAsync(m => m.ArtsDirID == id);
            if (artsDir == null)
            {
                return NotFound();
            }
            return View(artsDir);
        }

        // POST: ArtsDirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtsDirID,Picture1,Picture2,Picture3,Picture4,Picture5,ArtName,ProfileLink,Description,Paint,Design,Education,Film,Literacy,MixedMedia,MultiCultural,Music,Pasifika,Photography,PublicArt,Sculpture,Textiles,Theatre")] ArtsDir artsDir)
        {
            if (id != artsDir.ArtsDirID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artsDir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtsDirExists(artsDir.ArtsDirID))
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
            return View(artsDir);
        }

        // GET: ArtsDirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artsDir = await _context.ArtsDir
                .SingleOrDefaultAsync(m => m.ArtsDirID == id);
            if (artsDir == null)
            {
                return NotFound();
            }

            return View(artsDir);
        }

        // POST: ArtsDirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artsDir = await _context.ArtsDir.SingleOrDefaultAsync(m => m.ArtsDirID == id);
            _context.ArtsDir.Remove(artsDir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtsDirExists(int id)
        {
            return _context.ArtsDir.Any(e => e.ArtsDirID == id);
        }
    }
}
