using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;

namespace Pronia.Areas.Manage.Controllers
{
    [Area(nameof(Manage))]
    public class MainSliderController : Controller
    {

        readonly AppDbContext _context;

        public MainSliderController(AppDbContext context)
        {
            _context = context;
        }

      

        public IActionResult Index()
        {
            return View(_context.MainSliders.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            MainSlider ms = _context.MainSliders.Find(id);
            if (ms == null) return NotFound();
            _context.MainSliders.Remove(ms);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MainSlider ms)
        {
            if (!ModelState.IsValid) return View();
            _context.MainSliders.Add(ms);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            if (Id is null || Id <= 0) return BadRequest();

            MainSlider ms = _context.MainSliders.Find(Id);
            if (ms is null) return NotFound();


            return View(ms);
        }

        [HttpPost]
        public IActionResult Update(int? Id, MainSlider ms)
        {
            if (Id is null || Id <= 0 || Id != ms.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            MainSlider exist = _context.MainSliders.Find(Id);
            if (exist is null) return NotFound();

            exist.Offer = ms.Offer;
            exist.Title = ms.Title;
            exist.ShortDesc = ms.ShortDesc;
            exist.Image = ms.Image;
            exist.BtnText = ms.BtnText;
        

            _context.MainSliders.Update(exist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
