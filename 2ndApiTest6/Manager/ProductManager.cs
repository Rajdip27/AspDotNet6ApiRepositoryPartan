using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Manager;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace _2ndApiTest6.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager(ApplicationDbContext dbContext) : base(new ProductRepository(dbContext))
        {
        }

        public Product GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);  
        }

        public ICollection<Product> ProductsPaging(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 0;
               
            }
            int TotalNumber = page * pageSize;
            return GetAll().Skip(page).Take(pageSize).ToList();
            



        }

        public ICollection<Product> SarchProducts(string text)
        {
            return Get(c=>c.Name.ToLower().Contains(text) ||c.ProductColor.ToLower().Contains(text));
        }
    }
}
