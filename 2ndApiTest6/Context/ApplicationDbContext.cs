using _2ndApiTest6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _2ndApiTest6.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }  
        public DbSet<Student> students { get; set; }
        public DbSet<ImageUpload> images { get; set; }
        public DbSet<TblUser> tblUsers { get; set; }
        public DbSet<ShowProducts> showProducts { get; set; }
       
    }
}
