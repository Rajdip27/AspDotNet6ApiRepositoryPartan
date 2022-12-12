using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Manager;
using _2ndApiTest6.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _2ndApiTest6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController
    {
        //ApplicationDbContext _dbContext;

        //public PostController(ApplicationDbContext dbContext)
        //{
        //    //_dbContext=dbContext;
        //    //_postManager=new PostManager(dbContext);

        //}
        IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }
        [HttpGet]
        //public ActionResult<List<Post>> GetAll()
        public IActionResult GetAll()
        {
            try
            {
               // var result = _postManager.posts.ToList();
                var result = _postManager.GetAll().OrderBy(c=>c.Id).ToList();
                //return Ok(result);
                //return CustomResult(HttpStatusCode.OK);
                return CustomResult("Data Loaded Successfull", result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           
        }
        [HttpGet]
        public IActionResult GetAllDesc()
        {
            try
            {
                //.ThenByDescending(c=>c.Title)
                var post =_postManager.GetAll().OrderByDescending(c=>c.Id).ToList();
                return CustomResult("Data Loaded Successfull", post);


            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
        [HttpGet("title")]
        public IActionResult GetAll(string title)
        {
            try
            {
                var getall=_postManager.GetAll(title);
                return CustomResult("Data Loaded Successfull", getall.ToList());
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }
        [HttpGet]
        public IActionResult SarchPost(string text)
        {
            try
            {
                var post=_postManager.SarchPost(text);
                return CustomResult("Sarching Result", post);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }
        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            try
            {
                //var post = _postManager.GetFirstOrDefault(c => c.Id == id);
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found", post);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                bool isSave = _postManager.Add(post);
                //_postManager.posts.Add(post);
                //bool isSave = _postManager.SaveChanges() > 0;
                if (isSave)
                {
                    //return Created("", post);
                    return CustomResult("Post Has Been Create.", post);
                }
                //return BadRequest("Post Save Failed.");
                return CustomResult("Post Save Failed.",HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
           

        }
        [HttpPut]
        public IActionResult Edit(Post post)
        {
            try
            {
                if (post.Id == 0)
                {
                    return CustomResult("Id Is Missing.",HttpStatusCode.BadRequest);
                }
                bool isUpdate = _postManager.Update(post);
                if (isUpdate)
                {
                    return CustomResult("Post Updated Done.",post);

                }
                return CustomResult("Post Update Failed.",HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            

        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    // return "Data Not Found";
                    // return NotFound();
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                bool isDelete = _postManager.Delete(post);
                if (isDelete)
                {
                    // return "Post Has been delete";
                    return CustomResult("Post Has been delete");
                }
                return CustomResult("Post Delete Failed",HttpStatusCode.BadRequest);


            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }


        }


    }
}
