using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class AllVideosController : Controller
    {
        private readonly AppDbContext _db;
        public AllVideosController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Videos.ToList());
        }
    }
}
