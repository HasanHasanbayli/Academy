using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders=_db.Sliders,
                Courses=_db.Courses,
                News=_db.News,
                Testimonials=_db.Testimonials,
                Videos=_db.Videos
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            News news = await _db.News.FindAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }
    }
}
