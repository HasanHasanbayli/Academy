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
using Microsoft.EntityFrameworkCore;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CoursesController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Courses.Include(x=>x.Teacher).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Teachers = _db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses courses)
        {
            ViewBag.Teachers = _db.Teachers.ToList();
            if (!ModelState.IsValid) return View();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!courses.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (courses.Photo.MaxLength(1000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            string path = Path.Combine("images", "courses");
            string filename = await courses.Photo.SaveImg(_env.WebRootPath, path);

            Courses newCourses = new Courses();
            newCourses.Image = filename;
            newCourses.Name = courses.Name;
            newCourses.Title = courses.Title;
            newCourses.Description = courses.Description;
            newCourses.Price = courses.Price;
            newCourses.AboutCourse = courses.AboutCourse;
            newCourses.SkillLevel = courses.SkillLevel;
            newCourses.StudentsCount = courses.StudentsCount;
            newCourses.TeacherId = courses.TeacherId;
            newCourses.Certification = courses.Certification;
            newCourses.Star = courses.Star;
            newCourses.StartTime = courses.StartTime;
            newCourses.EndTime = courses.EndTime;
            newCourses.Duration = courses.Duration;
            await _db.Courses.AddAsync(newCourses);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Teachers = _db.Teachers.ToList();
            if (id == null) return NotFound();
            Courses dbCourses = await _db.Courses.FindAsync(id);
            if (dbCourses == null) return NotFound();
            return View(dbCourses);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Courses courses)
        {
            ViewBag.Teachers = _db.Teachers.ToList();
            if (id == null) return NotFound();
            Courses dbCourses = await _db.Courses.FindAsync(id);
            if (dbCourses == null) return NotFound();
            if (courses.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!courses.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (courses.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "courses");
                Helper.DeleteImage(_env.WebRootPath, path, dbCourses.Image);
                string fileName = await courses.Photo.SaveImg(_env.WebRootPath, path);
                dbCourses.Image = fileName;
            }
            dbCourses.Name = courses.Name;
            dbCourses.Title = courses.Title;
            dbCourses.Description = courses.Description;
            dbCourses.Price = courses.Price;
            dbCourses.AboutCourse = courses.AboutCourse;
            dbCourses.SkillLevel = courses.SkillLevel;
            dbCourses.StudentsCount = courses.StudentsCount;
            dbCourses.TeacherId = courses.TeacherId;
            dbCourses.Certification = courses.Certification;
            dbCourses.Star = courses.Star;
            dbCourses.StartTime = courses.StartTime;
            dbCourses.EndTime = courses.EndTime;
            dbCourses.Duration = courses.Duration;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Courses courses = await _db.Courses.FindAsync(id);
            if (courses == null) return NotFound();
            return View(courses);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Courses courses = await _db.Courses.FindAsync(id);
            if (courses == null) return NotFound();
            return View(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Courses courses)
        {
            string path = Path.Combine("images", "courses");
            if (id == null) return NotFound();
            Courses dbCourses = await _db.Courses.FindAsync(id);
            Helper.DeleteImage(_env.WebRootPath, path, dbCourses.Image);
            if (dbCourses == null) return NotFound();
            _db.Courses.Remove(dbCourses);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
