using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Manager;

namespace _2ndApiTest6.Interfaces.Manager
{
    public interface IUserManager:ICommonManager<User>
    {
        User GetById(int id);
        ICollection<User> SarchUser(string text);
        ICollection<User> GetUsers(int page, int pageSize);
    }
}
