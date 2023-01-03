using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;

namespace Pronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandsController : Controller
    {
        readonly AppDbContext _context;

        public BrandsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Brands.AsQueryable());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Brand brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {

            if (!ModelState.IsValid) return View();
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            if (Id is null || Id <= 0) return BadRequest();

            Brand brand = _context.Brands.Find(Id);
            if (brand is null) return NotFound();


            return View(brand);
        }

        [HttpPost]
        public IActionResult Update(int? Id, Brand brand)
        {
            if (Id is null || Id <= 0 || Id != brand.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            Brand exist = _context.Brands.Find(Id);
            if (exist is null) return NotFound();

            exist.Image = brand.Image;
            exist.Link = brand.Link;

            _context.Brands.Update(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
