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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        ApplicationDbContext _db;
        IProductManager _productManager;
        public ProductsController(ApplicationDbContext db)
        {
            _db=db;
            _productManager=new ProductManager(_db);

        }
        [HttpGet]
        public IActionResult GetAllDesc()
        {
            try
            {
                var Result = _productManager.GetAll().OrderByDescending(c => c.Id).ToList();
                return CustomResult("Data Loaded Successfull", Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Result =_productManager.GetAll().ToList();
                if (Result==null) 
                { 
                    return CustomResult("Data Not Found.!",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Loaded Successful.!", Result);
    
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult SarchProducts(string text)
        {
            try
            {
                var Result=_productManager.SarchProducts(text);
                return CustomResult("Sarching Result", Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult ProductPaging(int page=1)
        {
            try
            {
                var Result =_productManager.ProductsPaging(page,5);
                return CustomResult("Paging data for page No :" + page, Result);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result=_productManager.GetById(id);
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
        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            try
            {
                bool Result = _productManager.Add(product);
                if (Result)
                {
                    return CustomResult("Product Create Successful.!", Result);
                   
                }
                return CustomResult("Product Save Failed.!", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }

        }
        [HttpPost]
        public IActionResult ProductEdit(Product product)
        {
            try
            {
                if (product == null)
                {
                    return CustomResult("Id is Not Found", HttpStatusCode.NotFound);
                }
                bool Result=_productManager.Update(product);
                if (Result)
                {
                    return CustomResult("Product Updated Done.", product);
                }
                return CustomResult("Product Updated Failed..!", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete("id")]
        public IActionResult ProductDelete(int id)
        {
            try
            {
                var Result=_productManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                bool IsDelete = _productManager.Delete(Result);
                if (IsDelete)
                {
                    return CustomResult("Product Has been delete..!");
                }
                return CustomResult("Data Not Found", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
