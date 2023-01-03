using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class TestimonialArea
    {
        public int Id { get; set; }
        [MinLength(2),MaxLength(20)]
        public string Title { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Desc { get; set; }
    }
}
