using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid) return View();
            Contact newContact= new Contact();
            newContact.FirstName = contact.FirstName;
            newContact.LastName = contact.LastName;
            newContact.EmailAddress = contact.EmailAddress;
            newContact.TelNumber = contact.TelNumber;
            newContact.EmailAddress = contact.EmailAddress;
            newContact.Message = contact.Message;
            await _db.Contacts.AddAsync(newContact);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Thanks));
        }
        public IActionResult Thanks()
        {
            return View();
        }
    }
}
