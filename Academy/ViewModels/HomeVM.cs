using Academy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Courses> Courses { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Testimonials> Testimonials { get; set; }
        public IEnumerable<Videos> Videos { get; set; }
    }
}
