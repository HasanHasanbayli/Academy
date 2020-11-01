using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly AppDbContext _db;
        public AdmissionController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Admissions.ToList());
        }
    }
}
