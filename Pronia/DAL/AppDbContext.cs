using Microsoft.EntityFrameworkCore;
using Pronia.Models;

namespace Pronia.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MainSlider> MainSliders { get; set; }
        public DbSet<ShippingArea> ShippingAreas { get; set; }
        public DbSet<TestimonialArea> TestimonialAreas { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }


    }
}
