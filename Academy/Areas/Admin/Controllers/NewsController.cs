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
    public class NewsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public NewsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env=env;
        }
        public IActionResult Index()
        {
            return View(_db.News.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (!ModelState.IsValid) return View();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!news.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }
            if (news.Photo.MaxLength(1000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 1000kb ola biler");
                return View();
            }
            string path = Path.Combine("images", "news");
            string filename = await news.Photo.SaveImg(_env.WebRootPath, path);
            News newNews = new News();
            newNews.Image = filename;
            newNews.Title = news.Title;
            newNews.Description = news.Description;
            newNews.Date = news.Date;
            await _db.News.AddAsync(newNews);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            News news = _db.News.FirstOrDefault(p => p.Id == id);
            if (news == null) return NotFound();
            return View(news);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, News news)
        {
            if (id == null) return NotFound();
            News dbNews = await _db.News.FindAsync(id);
            if (dbNews == null) return NotFound();
            if (news.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!news.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (news.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "news");
                Helper.DeleteImage(_env.WebRootPath, path, dbNews.Image);
                string fileName = await news.Photo.SaveImg(_env.WebRootPath, path);
                dbNews.Image = fileName;
            }
            dbNews.Title = news.Title;
            dbNews.Description = news.Description;
            dbNews.Date = news.Date;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            News news = await _db.News.FindAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteNews(int? id)
        {
            if (id == null) return NotFound();
            News dbNews = _db.News.FirstOrDefault(n=>n.Id==id);
            if (dbNews == null) return NotFound();
            string path = Path.Combine("images","news");
            Helper.DeleteImage(_env.WebRootPath, path, dbNews.Image);
            _db.News.Remove(dbNews);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
