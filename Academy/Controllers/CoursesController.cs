using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Courses = _db.Courses
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Courses courses = await _db.Courses.FindAsync(id);
            if (courses == null) return NotFound();
            return View(_db.Courses.Include(x => x.Teacher).FirstOrDefault(x=>x.Id==id));
        }
    }
}
