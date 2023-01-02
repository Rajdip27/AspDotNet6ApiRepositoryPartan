using _2ndApiTest6.Interfaces.Repository;
using _2ndApiTest6.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace _2ndApiTest6.Repository
{
    public class TblUserRepository : CommonRepository<TblUser>, ITblUserRepository
    {
        public TblUserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
