using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Manager;
using _2ndApiTest6.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2ndApiTest6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //ApplicationDbContext _dbContext;
        IPostManager _postManager;
        //public PostController(ApplicationDbContext dbContext)
        //{
        //    //_dbContext=dbContext;
        //    //_postManager=new PostManager(dbContext);

        //}
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }
        [HttpGet]
        public List<Post> GetAll()
        {
            var result = _postManager.GetAll().ToList();
            return result;
        }
        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            bool isSave = _postManager.Add(post);
            //_postManager.posts.Add(post);
            //bool isSave = _postManager.SaveChanges() > 0;
            if (isSave)
            {
                return post;
            }
            return null;

        }

    }
}
