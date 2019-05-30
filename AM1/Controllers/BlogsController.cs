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
using System.Web;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Hosting.Server;

namespace AM1.Controllers
{
    public class BlogsController : Controller
    {
        private string GeneratorFileName(string str)
        {
            System.DateTime mtime = DateTime.Now;
            string s = string.Format("{0:HHmmssfff}{1}", mtime, str);
            return s;
        }

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public BlogsController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        // GET: Blogs
        public async Task<IActionResult> Index(
            string byname,
            string sortingmode)
        {
            var blogs = _context.Blog.AsQueryable();
            if (!String.IsNullOrEmpty(byname)) blogs = blogs.Where(s => s.Title.Contains(byname));

            if (sortingmode == "old") blogs = blogs.OrderBy(a => a.PublishDate);
            if (sortingmode == "new") blogs = blogs.OrderByDescending(a => a.PublishDate);
            if (sortingmode == "asc") blogs = blogs.OrderBy(a => a.Title);
            if (sortingmode == "desc") blogs = blogs.OrderByDescending(a => a.Title);

            if (sortingmode == "Other") blogs = blogs.Where(a => a.Category.Equals("Other"));
            if (sortingmode == "Guest blog") blogs = blogs.Where(a => a.Category.Equals("Guest blog"));
            if (sortingmode == "In the media") blogs = blogs.Where(a => a.Category.Equals("In the media"));

            return View(await blogs.ToListAsync());
        }

        // GET: Blogs
        public async Task<IActionResult> BlogList()
        {
            return View(await _context.Blog.ToListAsync());
        }


        public IActionResult Placeholder(int? id)
        {
            return View();
        }


        public async Task<IActionResult> Minidetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(blog.BlogPic);
            return View(blog);
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(blog.BlogPic);
            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogID,Title,Author,BlogPost,Category")] Blog blog, IFormFile pic)
        {
            blog.BlogPic = "/images/resources/NoBlog.jpg";

            if (ModelState.IsValid)
            {
                blog.PublishDate = DateTime.Now;

                _context.Add(blog);
                await _context.SaveChangesAsync();
                //blog id only available after its added to database AKA .SaveChangesAsync()
                string id = blog.BlogID.ToString();
                //file upload process must be inside/under "if(ModelState.IsValid)" for clarity and validation
                if (pic != null)
                {
                    //henri                    
                    string filename = GeneratorFileName(pic.FileName);
                    string filepath = string.Format("/images/blog/{0}/{1}", id, filename);
                    string folderpath = string.Format("{0}/images/blog/{1}", he.WebRootPath, id);
                    string serverfilepath = string.Format("{0}/{1}", folderpath, filename);

                    Directory.CreateDirectory(folderpath);

                    blog.BlogPic = filepath;
                    pic.CopyTo(new FileStream(serverfilepath, FileMode.Create));

                    _context.Update(blog);
                    _context.SaveChanges();
                    //dont forget to save again after updating the web filepath
                }

                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogID,Title,Author,PublishDate,BlogPost,Category,BlogPic")] Blog blog, IFormFile pic)
        {

            if (id != blog.BlogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pic != null)
                    {
                        string filename = GeneratorFileName(pic.FileName);
                        string filepath = string.Format("/images/blog/{0}/{1}", id, filename);
                        string folderpath = string.Format("{0}/images/blog/{1}", he.WebRootPath, id);
                        string serverfilepath = string.Format("{0}/{1}", folderpath, filename);

                        blog.BlogPic = filepath;
                        pic.CopyTo(new FileStream(serverfilepath, FileMode.Create));
                        //no need to use ViewData 
                        //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
                    }

                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogID))
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
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.BlogID == id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.BlogID == id);
        }
    }
}
