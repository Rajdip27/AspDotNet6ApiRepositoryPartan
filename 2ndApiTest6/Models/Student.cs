using System.ComponentModel.DataAnnotations;

namespace _2ndApiTest6.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your RollNumber")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "Enter Your RegNumber")]
        public int RegNumber { get; set; }

        [Required(ErrorMessage = "Enter Your PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]
        public string Email { get; set; }
    }
}
