using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace _2ndApiTest6.Manager
{
    public class StudentManager : CommonManager<Student>, IstudentManager
    {
        public StudentManager(ApplicationDbContext dbContext) : base(new StudentRepository(dbContext))
        {
        }
    }
}
