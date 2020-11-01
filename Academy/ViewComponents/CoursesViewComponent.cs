using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.ViewComponents
{
    public class CoursesViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public CoursesViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Courses> model = _db.Courses.ToList();
            return View(await Task.FromResult(model));
        }
    }
}
