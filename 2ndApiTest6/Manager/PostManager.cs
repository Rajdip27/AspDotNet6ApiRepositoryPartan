using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Models;
using _2ndApiTest6.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using EF.Core.Repository.Repository;

namespace _2ndApiTest6.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager
    {
        public PostManager(ApplicationDbContext dbContext) : base(new PostRepository(dbContext))
        {
        }

        public ICollection<Post> GetAll(string title)
        {
            return Get(c => c.Title.ToLower() == title.ToLower());
        }

        public Post GetById(int id)
        {
           return GetFirstOrDefault(x=>x.Id== id);
        }

        public ICollection<Post> GetPosts(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 0;
            }
            int totalNumber=page*pageSize;
           return GetAll().Skip(totalNumber).Take(pageSize).ToList();   
        }

        public ICollection<Post> SarchPost(string text)
        {
            return Get(c=>c.Title.ToLower().Contains(text)||c.Decripation.ToLower().Contains(text));
            

        }
    }
}
