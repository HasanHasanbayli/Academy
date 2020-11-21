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
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public TestimonialsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Testimonials.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonials testimonials)
        {
            if (!ModelState.IsValid) return View();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!testimonials.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (testimonials.Photo.MaxLength(1000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            string path = Path.Combine("images", "testimonials");
            string filename = await testimonials.Photo.SaveImg(_env.WebRootPath, path);
            Testimonials newTestimonials = new Testimonials();
            newTestimonials.Image = filename;
            newTestimonials.FullName = testimonials.FullName;
            newTestimonials.Position = testimonials.Position;
            newTestimonials.Description = testimonials.Description;
            await _db.Testimonials.AddAsync(newTestimonials);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Testimonials testimonials = await _db.Testimonials.FindAsync(id);
            if (testimonials == null) return NotFound();
            return View(testimonials);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Testimonials testimonials)
        {
            if (id == null) return NotFound();
            Testimonials dbTestimonials = await _db.Testimonials.FindAsync(id);
            if (dbTestimonials == null) return NotFound();
            if (testimonials.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!testimonials.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (testimonials.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "testimonials");
                Helper.DeleteImage(_env.WebRootPath, path, dbTestimonials.Image);
                string fileName = await testimonials.Photo.SaveImg(_env.WebRootPath, path);
                dbTestimonials.Image = fileName;
            }
            dbTestimonials.FullName = testimonials.FullName;
            dbTestimonials.Position = testimonials.Position;
            dbTestimonials.Description = testimonials.Description;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Testimonials testimonials = await _db.Testimonials.FindAsync(id);
            if (testimonials == null) return NotFound();
            return View(testimonials);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Testimonials testimonials)
        {
            if (id == null) return NotFound();
            Testimonials dbTestimonial = await _db.Testimonials.FindAsync(id);
            if (dbTestimonial == null) return NotFound();
            string path = Path.Combine("Images", "Testimonials");
            Helper.DeleteImage(_env.WebRootPath, path, dbTestimonial.Image);
            _db.Testimonials.Remove(dbTestimonial);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Testimonials testimonials = await _db.Testimonials.FindAsync(id);
            if (testimonials == null) return NotFound();
            return View(testimonials);
        }
    }
}
