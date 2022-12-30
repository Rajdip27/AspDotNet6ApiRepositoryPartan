using System.ComponentModel.DataAnnotations.Schema;

namespace _2ndApiTest6.Models
{
    public class ImageUpload
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(max)")]
        public string imagepath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertOn { get; set; }
    }
}
