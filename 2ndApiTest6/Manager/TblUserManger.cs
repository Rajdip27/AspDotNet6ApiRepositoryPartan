using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace _2ndApiTest6.Manager
{
    public class TblUserManger : CommonManager<TblUser>, ITblUserManager
    {
        public TblUserManger(ApplicationDbContext dbContext) : base(new TblUserRepository(dbContext))
        {



        }

        public TblUser GetById(string UserName)
        {
            return GetFirstOrDefault(o=>o.Userid== UserName);
        }
    }
}
