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
    [Route("api/[controller]/[action")]
    [ApiController]
    public class StudentController : BaseController
    {
        ApplicationDbContext _dbContext;
        IstudentManager _istudentManager;
        public StudentController(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
            _istudentManager = new StudentManager(_dbContext);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var Result = _istudentManager.GetAllAsync();
                if (Result == null)
                {
                    return CustomResult("Data Not Found.", HttpStatusCode.NotFound);
                }
                return CustomResult("Data Loaded Successfully.", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        //[HttpPost]
        //public async Task<IActionResult> Create( Student student)
        //{
        //    try
        //    {
        //        bool IsSave = await _istudentManager.AddAsync(student);
        //        if (IsSave)
        //        {
        //            return CustomResult("Student Create Successfully", student);
        //        }
        //        return CustomResult("Student Save Failed.", HttpStatusCode.BadRequest);

        //    }
        //    catch(Exception ex)
        //    {
        //        return CustomResult(ex.Message, HttpStatusCode.BadRequest);
        //    }
        //}
    }
}
