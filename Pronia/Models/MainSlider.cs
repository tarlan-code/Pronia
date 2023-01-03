using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class MainSlider
    {
        public int Id { get; set; }
        [Range(1,100)]
        public int Offer { get; set; }
        [MinLength(1),MaxLength(30)]
        public string Title { get; set; }
        [MinLength(1), MaxLength(100)]
        public string ShortDesc { get; set; }
        [MinLength(1), MaxLength(20)]
        public string BtnText { get; set; }
        public string Image { get; set; }
    }
}
