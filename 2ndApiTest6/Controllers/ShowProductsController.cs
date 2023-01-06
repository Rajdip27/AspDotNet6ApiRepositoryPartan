using _2ndApiTest6.Context;
using _2ndApiTest6.Interfaces.Manager;
using _2ndApiTest6.Manager;
using _2ndApiTest6.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        public IActionResult PaggingAllProducts(int page = 1)
        {
            try
            {
                var Result = _showProductsManager.Pagging(page, 5);
                return CustomResult("Data Loaded Successfully", Result);

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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                var Result=_showProductsManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("ID Is Missing", HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found Successfully", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public IActionResult Update(ShowProducts showProducts)
        {
            try
            {
                if(showProducts == null)
                {
                    return CustomResult("Product Is Missing", HttpStatusCode.NotFound);

                }

                var Result=_showProductsManager.Update(showProducts);
                if (Result == null)
                {
                    return CustomResult("Data Not Found!", HttpStatusCode.NotFound);
                }
                return CustomResult("Products Update Successfull",Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _showProductsManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);

                }
                bool IsDelete=_showProductsManager.Delete(Result);
                if (IsDelete)
                {
                    return CustomResult("Products has Been Deleted Successfull",IsDelete);
                }
                return CustomResult("Products Delete Failed",HttpStatusCode.BadRequest);


            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

    }
}
