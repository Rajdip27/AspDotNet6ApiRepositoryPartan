using System.ComponentModel.DataAnnotations;

namespace _2ndApiTest6.Models
{
    public class ShowProducts
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable
        {
            get; set;
        }
    }
}
