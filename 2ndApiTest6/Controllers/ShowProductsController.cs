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
    public class ShowProductsController : BaseController
    {
       private readonly ApplicationDbContext _dbContext;
        private readonly IShowProductsManager _showProductsManager;
        public ShowProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _showProductsManager=new ShowProductsManager(_dbContext);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Result=_showProductsManager.GetAll();
                return CustomResult("Data Loaded Successfull",Result);


            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public IActionResult Create(ShowProducts showProducts )
        {
            try
            {
                bool IsSave =_showProductsManager.Add(showProducts);
                if (IsSave)
                {
                    return CustomResult("Products Save Successfull",IsSave);
                }
                return CustomResult("Products Save Failed",HttpStatusCode.BadRequest);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
    }
}
