using System.ComponentModel.DataAnnotations;

namespace _2ndApiTest6.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }
        [Display(Name = "Product Image")]
        public string Image { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
    }
}
