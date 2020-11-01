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
        public async Task<IActionResult> Create(Apply apply)
        {
            if (!ModelState.IsValid) return View();
            Apply newApply = new Apply();
            newApply.FirstName = apply.FirstName;
            newApply.LastName = apply.LastName;
            newApply.EmailAddress = apply.EmailAddress;
            newApply.TelNumber = apply.TelNumber;
            newApply.EmailAddress = apply.EmailAddress;
            newApply.Message = apply.Message;
            await _db.Applies.AddAsync(newApply);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Thanks));
        }
        public IActionResult Thanks()
        {
            return View();
        }
    }
}
