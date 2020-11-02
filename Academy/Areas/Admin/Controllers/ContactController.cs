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
    //[Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Contacts.Where(a=>a.IsArchived==false).ToList());
        }

        public async Task<IActionResult> IsArchived(int? id)
        {
            if (id == null) return NotFound();
            Contact dbContact = _db.Contacts.FirstOrDefault(a=>a.Id==id);
            if (dbContact == null) return NotFound();
            dbContact.IsArchived = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ArchivedList()
        {
            return View(_db.Contacts.Where(a => a.IsArchived == true).ToList());
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return NotFound();
            Contact dbContact = _db.Contacts.FirstOrDefault(a => a.Id == id);
            if (dbContact == null) return NotFound();
            dbContact.IsArchived = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ArchivedList));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Contact contact)
        {
            if (id == null) return NotFound();
            Contact dbContact = await _db.Contacts.FindAsync(id);
            if (dbContact == null) return NotFound();
            _db.Contacts.Remove(dbContact);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        public async Task<IActionResult> Message(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return View(contact);
        }
    }
}
