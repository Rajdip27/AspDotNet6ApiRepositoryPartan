using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Manager;

namespace _2ndApiTest6.Interfaces.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
        Product GetById(int id);
        ICollection<Product> SarchProducts(string text);
        ICollection<Product> ProductsPaging(int page,int pageSize); 
        


    }
}
