using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class AllNewsController : Controller
    {
        private readonly AppDbContext _db;
        public AllNewsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.News.ToList());
        }

    }
}
