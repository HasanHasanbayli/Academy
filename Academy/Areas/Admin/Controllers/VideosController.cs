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
    [Authorize(Roles = "Admin")]
    public class VideosController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public VideosController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Videos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Videos videos)
        {

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!videos.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (videos.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            if (_db.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            string path = Path.Combine("images", "videos");
            string fileName = await videos.Photo.SaveImg(_env.WebRootPath, path);

            Videos newVideos = new Videos();
            newVideos.Video = videos.Video;
            newVideos.Image = fileName;

            await _db.Videos.AddAsync(newVideos);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Videos videos = await _db.Videos.FindAsync(id);
            if (videos == null) return NotFound();
            return View(videos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Videos videos)
        {
            if (id == null) return NotFound();
            Videos dbVideos = await _db.Videos.FindAsync(id);
            if (dbVideos == null) return NotFound();
            if (videos.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!videos.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }
                if (videos.Photo.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 2mb ola biler");
                    return View();
                }
                string path = Path.Combine("images", "videos");
                Helper.DeleteImage(_env.WebRootPath, path, dbVideos.Image);
                string fileName = await videos.Photo.SaveImg(_env.WebRootPath, path);
                dbVideos.Image = fileName;
            }
            dbVideos.Video = videos.Video;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Videos videos = await _db.Videos.FindAsync(id);
            if (videos == null) return NotFound();
            return View(videos);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Videos videos = await _db.Videos.FindAsync(id);
            if (videos == null) return NotFound();
            return View(videos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Videos videos = await _db.Videos.FindAsync(id);
            if (videos == null) return NotFound();
            string path = Path.Combine("images", "videos");
            Helper.DeleteImage(_env.WebRootPath, path, videos.Image);
            _db.Videos.Remove(videos);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
