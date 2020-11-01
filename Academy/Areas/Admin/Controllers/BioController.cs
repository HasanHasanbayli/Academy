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
    [Authorize(Roles = "Admin")]
    public class BioController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public BioController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Bios.FirstOrDefault());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bio bio)
        {
            if (!ModelState.IsValid) return View();
            if (ModelState["HeaderPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid ||
                  ModelState["FooterPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!bio.HeaderPhoto.IsImage())
            {
                ModelState.AddModelError("HeaderPhoto", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (!bio.FooterPhoto.IsImage())
            {
                ModelState.AddModelError("FooterPhoto", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (bio.HeaderPhoto.MaxLength(1000))
            {
                ModelState.AddModelError("HeaderPhoto", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            if (bio.FooterPhoto.MaxLength(1000))
            {
                ModelState.AddModelError("FooterPhoto", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            string path = Path.Combine("images", "logo");
            string headerPhoto = await bio.HeaderPhoto.SaveImg(_env.WebRootPath, path);
            string footerPhoto = await bio.FooterPhoto.SaveImg(_env.WebRootPath, path);
            Bio newBio = new Bio();
            newBio.HeaderLogo = headerPhoto;
            newBio.FooterLogo = footerPhoto;
            newBio.About = bio.About;
            newBio.Call = bio.Call;
            newBio.Facebook = bio.Facebook;
            newBio.Twitter = bio.Twitter;
            newBio.Linkedin = bio.Linkedin;
            newBio.Location = bio.Location;
            newBio.Email = bio.Email;
            await _db.Bios.AddAsync(newBio);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Bio bio = _db.Bios.FirstOrDefault(p => p.Id == id);
            if (bio == null) return NotFound();
            return View(bio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Bio bio)
        {
            Bio dbBio = _db.Bios.FirstOrDefault(p => p.Id == bio.Id);
            if (dbBio == null) return NotFound();
            if (bio.HeaderPhoto != null || bio.FooterPhoto != null)
            {
                if (ModelState["HeaderPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid ||
                   ModelState["FooterPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid )
                {
                    return View();
                }
                if (!bio.HeaderPhoto.IsImage())
                {
                    ModelState.AddModelError("HeaderPhoto", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (!bio.FooterPhoto.IsImage())
                {
                    ModelState.AddModelError("FooterPhoto", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (bio.HeaderPhoto.MaxLength(1000))
                {
                    ModelState.AddModelError("HeaderPhoto", "Shekilin olchusu max 1000kb ola biler");
                    return View();
                }
                if (bio.FooterPhoto.MaxLength(1000))
                {
                    ModelState.AddModelError("FooterPhoto", "Shekilin olchusu max 1000kb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "logo");
                Helper.DeleteImage(_env.WebRootPath, path, dbBio.HeaderLogo);
                Helper.DeleteImage(_env.WebRootPath, path, dbBio.FooterLogo);

                string headerPhoto = await bio.HeaderPhoto.SaveImg(_env.WebRootPath, path);
                string footerPhoto = await bio.FooterPhoto.SaveImg(_env.WebRootPath, path);
                dbBio.HeaderLogo = headerPhoto;
                dbBio.FooterLogo = footerPhoto;
            }
            dbBio.Call = bio.Call;
            dbBio.Email = bio.Email;
            dbBio.About = bio.About;
            dbBio.Facebook = bio.Facebook;
            dbBio.Twitter = bio.Twitter;
            dbBio.Linkedin = bio.Linkedin;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
