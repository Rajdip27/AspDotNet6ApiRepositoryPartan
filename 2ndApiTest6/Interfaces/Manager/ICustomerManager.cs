using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Manager;

namespace _2ndApiTest6.Interfaces.Manager
{
    public interface ICustomerManager:ICommonManager<Customer>
    {
        Customer GetById(int id);
        ICollection<Customer> SarchCustomer(string text);
        ICollection<Customer>CustomerPaging(int page, int pageSize);
    }
}
