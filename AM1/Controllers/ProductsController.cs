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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public ProductsController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            // Kyla added HE
            he = e;
            // Kyla added HE
        }

        //public async Task<IActionResult> Shop()
        //{
        //    return View();
        //}

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }
        //public async Task<IActionResult> AddCart(int? id)
        //{
        //    return Redirect("/Carts/Create");
        //}

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            // Kyla added here
            ViewData["fileLocation"] = "/images/product/" + Path.GetFileName(product.ProductPicture);
            // Kyla added here

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price,ProductPicture,Category,Quantity")] Product product, IFormFile pic) // Kyla added IForm
        {
            product.ProductPicture = "/images/resources/NoBlog.jpg";

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                // Kyla added here
                string id = product.ProductID.ToString();
                if (pic != null)
                {
                    string filename = GeneratorFileName(pic.FileName);
                    string filepath = string.Format("/images/product/{0}/{1}", id, filename);
                    string folderpath = string.Format("{0}/images/product/{1}", he.WebRootPath, id);
                    string serverfilepath = string.Format("{0}/{1}", folderpath, filename);

                    Directory.CreateDirectory(folderpath);

                    product.ProductPicture = filepath;
                    pic.CopyTo(new FileStream(serverfilepath, FileMode.Create));

                    _context.Update(product);
                    _context.SaveChanges();
                    //dont forget to save again after updating the web filepath
                }
                // Kyla added here
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            if (product.ProductPicture != null)
            {
                ViewData["fileLocation"] = product.ProductPicture;
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price,ProductPicture,Category,Quantity")] Product product, IFormFile pic)// Kyla added
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Kyla added
                    if (pic != null)
                    {
                        string filename = GeneratorFileName(pic.FileName);
                        string filepath = string.Format("/images/product/{0}/{1}", id, filename);
                        string folderpath = string.Format("{0}/images/product/{1}", he.WebRootPath, id);
                        string serverfilepath = string.Format("{0}/{1}", folderpath, filename);

                        Directory.CreateDirectory(folderpath);

                        product.ProductPicture = filepath;
                        pic.CopyTo(new FileStream(serverfilepath, FileMode.Create));

                    }
                    // Kyla added

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }
        // Kyla added 
        private string GeneratorFileName(string fileName)
        {
            DateTime mtime = DateTime.Now;
            string s = string.Format("{0:HHmmssfff}{1}", mtime, fileName);
            return s;
        }
        // Kyla added 

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductID == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
