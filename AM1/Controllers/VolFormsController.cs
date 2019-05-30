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
    public class VolFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VolForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.VolForm.ToListAsync());
        }

        // GET: VolForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volForm = await _context.VolForm
                .SingleOrDefaultAsync(m => m.VolFormID == id);
            if (volForm == null)
            {
                return NotFound();
            }

            return View(volForm);
        }

        // GET: VolForms/Create
        public IActionResult Create()
        {
            return View();
        }

        //taken out : RefOne,RefOneContact,RefTwo,RefTwoContact,
        // POST: VolForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VolFormID,FirstName,LastName,HomeAddress,PhoneNumber,EmailAddress,ContactMethod,PreviousExperience,FirstAidCertificate,PoliceVetCheck,TermsAndConditions,Lighting,Sound,SetBuilding,MakeUp,Hair,Costuming,Props,StageManagement,Prompt,FrontOfHouse,Catering,PublicityAndPromotion,AssistanceVisitors,AssistanceExhibitionsGen,AssistanceWorkshops,PublicityAndPromotion1,SupportOpenings,AssistanceVisitors1,AssistanceExhibitionsGen1,PublicityAndPromotion2,SupportOpenings1,AssistanceWorkshops1,WebsiteDevelopment,Instagram,SnapChat,Facebook,Twitter,AppDevelopment")] VolForm volForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volForm);
        }

        // GET: VolForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volForm = await _context.VolForm.SingleOrDefaultAsync(m => m.VolFormID == id);
            if (volForm == null)
            {
                return NotFound();
            }
            return View(volForm);
        }

        // POST: VolForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VolFormID,FirstName,LastName,HomeAddress,PhoneNumber,EmailAddress,RefOne,RefOneContact,RefTwo,RefTwoContact,ContactMethod,PreviousExperience,FirstAidCertificate,PoliceVetCheck,TermsAndConditions,Lighting,Sound,SetBuilding,MakeUp,Hair,Costuming,Props,StageManagement,Prompt,FrontOfHouse,Catering,PublicityAndPromotion,AssistanceVisitors,AssistanceExhibitionsGen,AssistanceWorkshops,PublicityAndPromotion1,SupportOpenings,AssistanceVisitors1,AssistanceExhibitionsGen1,PublicityAndPromotion2,SupportOpenings1,AssistanceWorkshops1,WebsiteDevelopment,Instagram,SnapChat,Facebook,Twitter,AppDevelopment")] VolForm volForm)
        {
            if (id != volForm.VolFormID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolFormExists(volForm.VolFormID))
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
            return View(volForm);
        }

        // GET: VolForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volForm = await _context.VolForm
                .SingleOrDefaultAsync(m => m.VolFormID == id);
            if (volForm == null)
            {
                return NotFound();
            }

            return View(volForm);
        }

        // POST: VolForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volForm = await _context.VolForm.SingleOrDefaultAsync(m => m.VolFormID == id);
            _context.VolForm.Remove(volForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolFormExists(int id)
        {
            return _context.VolForm.Any(e => e.VolFormID == id);
        }
    }
}
