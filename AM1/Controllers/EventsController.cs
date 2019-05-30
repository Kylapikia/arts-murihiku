using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AM1.Data;
using AM1.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace AM1.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment he;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment e)
        {
            _context = context;
            //_userManager = userManager;
            he = e;
        }

        // GET: Events
        public async Task<IActionResult> Index(
            string byname,
            string bylocation,
            string category,
            string sortingmode
            )
        {
            var eventt = _context.Event.AsQueryable();

            if (!String.IsNullOrEmpty(byname)) eventt = eventt.Where(s => s.EventName.Contains(byname));

            if (!String.IsNullOrEmpty(bylocation)) eventt = eventt.Where(s => s.Location.Contains(bylocation));

            if (!string.IsNullOrEmpty(category)) eventt = eventt.Where(s => s.EventCategory.Contains(category));

            if (sortingmode == "asc") eventt = eventt.OrderBy(s => s.EventName);
            if (sortingmode == "desc") eventt = eventt.OrderByDescending(s => s.EventName);
            if (sortingmode == "free") eventt = eventt.Where(s => s.Free);
            if (sortingmode == "old") eventt = eventt.OrderBy(s => s.StartEventDate);
            if (sortingmode == "new") eventt = eventt.OrderByDescending(s => s.StartEventDate);

            return View(await eventt.ToListAsync());
        }

        [Route("Calendar")]
        // go to Events/Calendar
        public async Task<IActionResult> Calendar()
        {
            return View(await _context.Event.ToListAsync());
        }
        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(@event.EventPicture);
            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventName,StartEventDate,FinishEventDate,EventDescription,EventCategory,EventPicture,Location,Suburb,City,PostCode,ThemeColour,FullDay,Price,StartTime,FinishTime,Free")] Event @event, IFormFile pic)
        {
            @event.EventPicture = "/images/resources/NoBlog.jpg";
            if (pic != null)
            {
                @event.EventPicture = "/images/car/" + Path.GetFileName(pic.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/car/", Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                //ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (ModelState.IsValid)
            {
                @event.FullAddress = string.Format("{0}, {1}, {2}, {3}", @event.Location, @event.Suburb, @event.City, @event.PostCode);
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            if (@event.EventPicture != null)
            {
                ViewData["fileLocation"] = @event.EventPicture;
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,StartEventDate,FinishEventDate,EventDescription,EventCategory,EventPicture,Location,ThemeColour,FullDay,Price,Free")] Event @event, IFormFile pic)
        {
            if (pic != null)
            {
                @event.EventPicture = "/images/event/" + Path.GetFileName(pic.FileName);
                var fileName = Path.Combine(he.WebRootPath + "/images/event/", Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/images/event/" + Path.GetFileName(pic.FileName);
            }
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.SingleOrDefaultAsync(m => m.EventID == id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }
    }
}
