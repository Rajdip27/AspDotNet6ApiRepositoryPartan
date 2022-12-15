using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Repository;
using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using EF.Core.Repository.Repository;

namespace _2ndApiTest6.Repository
{
    public class ProductRepository :CommonRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base( dbContext)
        {
        }
    }
}
