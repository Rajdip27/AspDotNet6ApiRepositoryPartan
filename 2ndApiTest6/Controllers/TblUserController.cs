using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Manager;
using _2ndApiTest6.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _2ndApiTest6.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class TblUserController : BaseController
    {
        ApplicationDbContext _dbContext;
        ITblUserManager _userManager;
        public TblUserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = new TblUserManger(_dbContext);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var Result = _userManager.GetAll().ToList();
                return CustomResult("Data Loaded Successfull",Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crate( TblUser user)
        {
            try
            {
                bool IsSave=_userManager.Add(user);
                if (IsSave)
                {
                    return CustomResult("User Save Successfully",IsSave);
                }
                return CustomResult("User Save Failed", HttpStatusCode.BadRequest);


            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetByUserName(string uName)
        {
            try
            {
                var Result=_userManager.GetById(uName);
                if (Result == null)
                {
                    return CustomResult("User Name is Messing",HttpStatusCode.NotFound);

                }
                return CustomResult("Data is Found",Result.ToString());

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }







    }
}
