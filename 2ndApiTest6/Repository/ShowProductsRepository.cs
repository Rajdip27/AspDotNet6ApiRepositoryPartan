using _2ndApiTest6.Interfaces.Repository;
using _2ndApiTest6.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace _2ndApiTest6.Repository
{
    public class ShowProductsRepository : CommonRepository<ShowProducts>, IShowProductsRepository
    {
        public ShowProductsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
