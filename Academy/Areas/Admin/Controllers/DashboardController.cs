using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public DashboardController(UserManager<AppUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.FullName = "";
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.FullName = user.FullName;
            }
            return View();
        }
    }
}
