using Academy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<News> News{ get; set; }
        public DbSet<Apply> Applies { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<Admissions> Admissions { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}
