using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Manager;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace _2ndApiTest6.Manager
{
    public class CustomerManager : CommonManager<Customer>, ICustomerManager
    {
        public CustomerManager(ApplicationDbContext dbContext) : base(new CustomerRepository(dbContext))
        {

        }

        public ICollection<Customer> CustomerPaging(int page, int pageSize)
        {
            if(page <= 1)
            {
                page = 0;
            }
            int total = page * pageSize;
            return GetAll().Skip(total).Take(pageSize).ToList();
        }

        public Customer GetById(int id)
        {
            return GetFirstOrDefault(x=>x.Id==id);
        }

        public ICollection<Customer> SarchCustomer(string text)
        {
            return Get(x=>x.Name.ToLower().Contains(text)||x.Address.ToLower().Contains(text));
        }
    }
}
