using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ApplyController : Controller
    {
        private readonly AppDbContext _db;
        public ApplyController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Applies.Where(a=>a.IsArchived==false).ToList());
        }

        public async Task<IActionResult> IsArchived(int? id)
        {
            if (id == null) return NotFound();
            Apply dbApply = _db.Applies.FirstOrDefault(a=>a.Id==id);
            if (dbApply == null) return NotFound();
            dbApply.IsArchived = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ArchivedList()
        {
            return View(_db.Applies.Where(a => a.IsArchived == true).ToList());
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return NotFound();
            Apply dbApply = _db.Applies.FirstOrDefault(a => a.Id == id);
            if (dbApply == null) return NotFound();
            dbApply.IsArchived = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ArchivedList));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Apply apply = await _db.Applies.FindAsync(id);
            if (apply == null) return NotFound();
            return View(apply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Apply apply)
        {
            if (id == null) return NotFound();
            Apply dbApply = await _db.Applies.FindAsync(id);
            if (dbApply == null) return NotFound();
            _db.Applies.Remove(dbApply);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        public async Task<IActionResult> Message(int? id)
        {
            if (id == null) return NotFound();
            Apply apply = await _db.Applies.FindAsync(id);
            if (apply == null) return NotFound();
            return View(apply);
        }
    }
}
