using System.ComponentModel.DataAnnotations;

namespace _2ndApiTest6.Models
{
    public class TblUser
    {
        [Key]
        public string Userid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
