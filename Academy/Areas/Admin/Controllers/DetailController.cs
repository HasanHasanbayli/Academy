using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DetailController : Controller
    {
        private readonly AppDbContext _db;
        public DetailController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Details.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Detail detail)
        {
            if (!ModelState.IsValid) return View();
            Detail newDetail = new Detail();
            newDetail.Title = detail.Title;
            newDetail.Description = detail.Description;
            newDetail.Icon = detail.Icon;
            await _db.Details.AddAsync(newDetail);
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
            Detail detail = _db.Details.FirstOrDefault(p => p.Id == id);
            if (detail == null) return NotFound();
            return View(detail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Detail detail)
        {
            if (id == null) return NotFound();
            Detail dbDetail = await _db.Details.FindAsync(id);
            if (dbDetail == null) return NotFound();
           
            dbDetail.Title = detail.Title;
            dbDetail.Description = detail.Description;
            dbDetail.Icon = detail.Icon;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id, Detail detail)
        {
            if (id == null) return NotFound();
            Detail dbDetail = await _db.Details.FindAsync(id);
            if (dbDetail == null) return NotFound();
            _db.Details.Remove(dbDetail);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
