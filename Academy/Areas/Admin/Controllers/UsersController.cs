using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = _userManager.Users.ToList();
            List<UserVM> usersVM = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role= (await _userManager.GetRolesAsync(user))[0],
                    IsActivated=user.IsActivated
                };
                usersVM.Add(userVM); 
            }
            return View(usersVM);
        }

        //public async Task<IActionResult> IsActivated(string id)
        //{
        //    if (id == null) return NotFound();
        //    AppUser user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return NotFound();
        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Active(string id, bool IsActivated)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.IsActivated = IsActivated;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Disable(string id, bool IsActivated)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.IsActivated = !IsActivated;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
