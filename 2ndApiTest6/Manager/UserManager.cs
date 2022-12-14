using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using EF.Core.Repository.Repository;

namespace _2ndApiTest6.Manager
{
    public class UserManager : CommonManager<User>, IUserManager
    {
        public UserManager(ApplicationDbContext dbContext) : base(new UserRepository(dbContext))
        {
        }

        public User GetById(int id)
        {
            return GetFirstOrDefault(c => c.Id == id);
        }

        public ICollection<User> GetUsers(int page, int pageSize)
        {
            if (page <= 0)
            {
                page = 0;
            }
            int totalNumber=page * pageSize;
            return GetAll().Skip(totalNumber).Take(pageSize).ToList();
        }

        public ICollection<User> SarchUser(string text)
        {
            return Get(c => c.Name.ToLower().Contains(text) || c.Address.ToLower().Contains(text));
        }
    }
}
