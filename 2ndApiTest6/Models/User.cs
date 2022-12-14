using System.ComponentModel.DataAnnotations;

namespace _2ndApiTest6.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Enter Your Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Enter Your Age")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Enter Your Address")]
        public string Address { get; set; }
    }
}
