using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;

namespace Pronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ShippingAreaController : Controller
    {
        readonly AppDbContext _context;

        public ShippingAreaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ShippingAreas.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            ShippingArea sa = _context.ShippingAreas.Find(id);
            if (sa == null) return NotFound();
            _context.ShippingAreas.Remove(sa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Create()
        {
            if (_context.ShippingAreas.ToList().Count >= 3)
            {
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShippingArea sa)
        {

            if (!ModelState.IsValid) return View();
            _context.ShippingAreas.Add(sa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            if (Id is null || Id <= 0) return BadRequest();

            ShippingArea sa = _context.ShippingAreas.Find(Id);
            if (sa is null) return NotFound();


            return View(sa);
        }

        [HttpPost]
        public IActionResult Update(int? Id, ShippingArea sa)
        {
            if (Id is null || Id <= 0 || Id != sa.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            ShippingArea exist = _context.ShippingAreas.Find(Id);
            if (exist is null) return NotFound();

            exist.Icon = sa.Icon;
            exist.Title = sa.Title;
            exist.ShortDesc = sa.ShortDesc;



            _context.ShippingAreas.Update(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
