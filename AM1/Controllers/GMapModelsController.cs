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
    public class GMapModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GMapModelsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: GMapModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GMapModel.ToListAsync());
        }

        // GET: GMapModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gMapModel = await _context.GMapModel
                .SingleOrDefaultAsync(m => m.GMapID == id);
            if (gMapModel == null)
            {
                return NotFound();
            }

            return View(gMapModel);
        }

        // GET: GMapModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GMapModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GMapID,Lat,Lng,GName,GDisciplines,GAddress,GLinkProfile,GProfilePic,MondayOpen,MondayClose,TuesdayOpen,TuesdayClose,WednesdayOpen,WednesdayClose,ThursdayOpen,ThursdayClose,FridayOpen,FridayClose,SaturdayOpen,SaturdayClose,SundayOpen,SundayClose")] GMapModel gMapModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                _context.Add(gMapModel);
                await _context.SaveChangesAsync();
                user.AddedToMap = true;
                user.MyGMapID = gMapModel.GMapID;
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(gMapModel);
        }

        // GET: GMapModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gMapModel = await _context.GMapModel.SingleOrDefaultAsync(m => m.GMapID == id);
            if (gMapModel == null)
            {
                return NotFound();
            }
            return View(gMapModel);
        }

        // POST: GMapModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GMapID,Lat,Lng,GName,GDisciplines,GAddress,GLinkProfile,GProfilePic,MondayOpen,MondayClose,TuesdayOpen,TuesdayClose,WednesdayOpen,WednesdayClose,ThursdayOpen,ThursdayClose,FridayOpen,FridayClose,SaturdayOpen,SaturdayClose,SundayOpen,SundayClose")] GMapModel gMapModel)
        {
            if (id != gMapModel.GMapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gMapModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GMapModelExists(gMapModel.GMapID))
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
            return View(gMapModel);
        }

        // GET: GMapModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gMapModel = await _context.GMapModel
                .SingleOrDefaultAsync(m => m.GMapID == id);
            if (gMapModel == null)
            {
                return NotFound();
            }

            return View(gMapModel);
        }

        // POST: GMapModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gMapModel = await _context.GMapModel.SingleOrDefaultAsync(m => m.GMapID == id);
            _context.GMapModel.Remove(gMapModel);
            await _context.SaveChangesAsync();

            var user = await _userManager.GetUserAsync(User);
            user.AddedToMap = false;
            user.MyGMapID = -1;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        private bool GMapModelExists(int id)
        {
            return _context.GMapModel.Any(e => e.GMapID == id);
        }
    }
}
