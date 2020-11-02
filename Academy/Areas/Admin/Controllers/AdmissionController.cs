using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Extentions;
using Academy.Helpers;
using Academy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    public class AdmissionController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AdmissionController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Admissions.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admissions admissions)
        {

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!admissions.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (admissions.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            string path = Path.Combine("images", "admissions");
            string fileName = await admissions.Photo.SaveImg(_env.WebRootPath, path);

            Admissions newAdmissions = new Admissions();
            newAdmissions.Image = fileName;
            newAdmissions.Title = admissions.Title;
            newAdmissions.Description = admissions.Description;
            newAdmissions.Form = admissions.Form;
            newAdmissions.Card = admissions.Card;
            newAdmissions.Transcript = admissions.Transcript;
            newAdmissions.Certificate = admissions.Certificate;
            newAdmissions.Picture = admissions.Picture;

            await _db.Admissions.AddAsync(newAdmissions);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Admissions admissions = await _db.Admissions.FindAsync(id);
            if (admissions == null) return NotFound();
            return View(admissions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Admissions admissions)
        {
            if (id == null) return NotFound();
            Admissions dbAdmissions = await _db.Admissions.FindAsync(id);
            if (dbAdmissions == null) return NotFound();
            if (admissions.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!admissions.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (admissions.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 2mb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "admissions");
                Helper.DeleteImage(_env.WebRootPath, path, dbAdmissions.Image);
                string fileName = await admissions.Photo.SaveImg(_env.WebRootPath, path);
                dbAdmissions.Image = fileName;
            }
            dbAdmissions.Title = admissions.Title;
            dbAdmissions.Description = admissions.Description;
            dbAdmissions.Form = admissions.Form;
            dbAdmissions.Card = admissions.Card;
            dbAdmissions.Transcript = admissions.Transcript;
            dbAdmissions.Certificate = admissions.Certificate;
            dbAdmissions.Picture = admissions.Picture;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Admissions admissions = await _db.Admissions.FindAsync(id);
            if (admissions == null) return NotFound();
            return View(admissions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Admissions admissions = await _db.Admissions.FindAsync(id);
            if (admissions == null) return NotFound();
            string path = Path.Combine("images", "admissions");
            Helper.DeleteImage(_env.WebRootPath, path, admissions.Image);
            _db.Admissions.Remove(admissions);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Admissions admissions = await _db.Admissions.FindAsync(id);
            if (admissions == null) return NotFound();
            return View(admissions);
        }
    }
}
