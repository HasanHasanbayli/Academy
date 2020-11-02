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
    //[Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Sliders.ToList());
        }
        public IActionResult Create()
        {
            if (_db.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (slider.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            if (_db.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            string path = Path.Combine("images", "slider");
            string fileName = await slider.Photo.SaveImg(_env.WebRootPath, path);

            Slider newslider = new Slider();
            newslider.Title = slider.Title;
            newslider.Image = fileName;

            await _db.Sliders.AddAsync(newslider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null) return NotFound();
            Slider dbSlider = await _db.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();
            if (slider.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (slider.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 2mb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "slider");
                Helper.DeleteImage(_env.WebRootPath, path, dbSlider.Image);
                string fileName = await slider.Photo.SaveImg(_env.WebRootPath, path);
                dbSlider.Image = fileName;
            }
            dbSlider.Title = slider.Title;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _db.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            string path = Path.Combine("images", "slider");
            Helper.DeleteImage(_env.WebRootPath, path, slider.Image);
            _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
