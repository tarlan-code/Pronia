using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;
using System.Diagnostics;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.MainSliders = _context.MainSliders.ToList();
            ViewBag.ShippingAreas = _context.ShippingAreas.ToList();
            ViewBag.TestimonialAreas = _context.TestimonialAreas.FirstOrDefault();
            ViewBag.Testimonials = _context.Testimonials.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View();


        }


    }
}