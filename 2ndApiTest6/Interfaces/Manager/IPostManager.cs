using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Manager;

namespace _2ndApiTest6.Interfaces.Manager
{
    public interface IPostManager:ICommonManager<Post>
    {
        Post GetById(int id);
        ICollection<Post> GetAll(string title);
        ICollection<Post> SarchPost(string text);
        ICollection<Post> GetPosts(int page, int pageSize);
        

    }
}
