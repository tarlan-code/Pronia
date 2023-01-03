using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class Color
    {
        public int Id { get; set; }
        [MinLength(2),MaxLength(10)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
