using Academy.DAL;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.ViewComponents
{
    public class DetailViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public DetailViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Detail> model = _db.Details.ToList();
            return View(await Task.FromResult(model));
        }
    }
}
