using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Manager;
using _2ndApiTest6.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace _2ndApiTest6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        IUserManager _useManger;
        ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _useManger = new UserManager(_dbContext);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result= _useManger.GetAll().ToList();
                return CustomResult("Data Loaded Successful..", result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result=_useManger.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found", Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult SarchUser(string text)
        {
            try
            {
                var Result=_useManger.SarchUser(text);
                return CustomResult("Sarching Result", Result);


            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult GetUsers(int page = 1)
        {
            //paginig
            try
            {
                var result = _useManger.GetUsers(page, 5);
                return CustomResult("Paging data for page No :" + page, result.ToList());

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
       





        [HttpPost]
        public IActionResult Add(User user)
        {
            try {
                bool IsSave = _useManger.Add(user);
                if (IsSave)
                {
                    return CustomResult("User Has Been Create.", user);

                }
                return CustomResult("User Save Failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            

        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                if (user == null)
                {
                    return CustomResult("Id Is Missing.", HttpStatusCode.BadRequest);
                }
                bool IsUpdate = _useManger.Update(user);
                if (IsUpdate)
                {
                    return CustomResult("User Updated Done.", user);
                }
                return CustomResult("User Update Failed.", HttpStatusCode.BadRequest);
            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           

        }
        [HttpDelete("id")]
        public IActionResult Delete( int id)
        {
            try
            {
                var user=_useManger.GetById(id);
                if(user == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                bool IsDelete=_useManger.Delete(user);
                if (IsDelete)
                {
                    return CustomResult("User Has been delete");
                }
                return CustomResult("User Delete Failed", HttpStatusCode.BadRequest);

            }catch(Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }



    }
}
