using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Repository;
using _2ndApiTest6.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace _2ndApiTest6.Repository
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
