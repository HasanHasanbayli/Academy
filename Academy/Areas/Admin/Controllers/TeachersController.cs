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
    public class TeachersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public TeachersController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_db.Teachers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid) return View();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!teacher.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (teacher.Photo.MaxLength(1000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            string path = Path.Combine("images", "teachers");
            string filename = await teacher.Photo.SaveImg(_env.WebRootPath, path);
            Teacher newTeacher = new Teacher();
            newTeacher.Image = filename;
            newTeacher.FullName = teacher.FullName;
            newTeacher.Position = teacher.Position;
            newTeacher.About = teacher.About;
            await _db.Teachers.AddAsync(newTeacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _db.Teachers.FirstOrDefault(p => p.Id == id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Teacher teacher)
        {
            if (id == null) return NotFound();
            Teacher dbTeacher = await _db.Teachers.FindAsync(id);
            if (dbTeacher == null) return NotFound();
            if (teacher.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!teacher.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (teacher.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "teachers");
                Helper.DeleteImage(_env.WebRootPath, path, dbTeacher.Image);
                string fileName = await teacher.Photo.SaveImg(_env.WebRootPath, path);
                dbTeacher.Image = fileName;
            }
            dbTeacher.FullName = teacher.FullName;
            dbTeacher.Position = teacher.Position;
            dbTeacher.About = teacher.About;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Teacher teacher)
        {
            if (id == null) return NotFound();
            Teacher dbTeacher = await _db.Teachers.FindAsync(id);
            if (dbTeacher == null) return NotFound();
            _db.Teachers.Remove(dbTeacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
