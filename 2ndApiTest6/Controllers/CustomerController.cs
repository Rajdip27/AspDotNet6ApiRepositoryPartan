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
    public class CustomerController : BaseController
    {
        ApplicationDbContext _dbContext;
        ICustomerManager _customerManager;
        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
           _customerManager = new CustomerManager(_dbContext);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Result=_customerManager.GetAll().ToList();
            return CustomResult("Data Loaded Successfully", Result);

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result=_customerManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.BadRequest);

                }
                return CustomResult("Data Found", Result);
               

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult SarchCustomer(string text)
        {
            try
            {
                var Result=_customerManager.SarchCustomer(text);
                return CustomResult("Sarching Result", Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult CustomerPaging(int page = 1)
        {
            try
            {
                var Result = _customerManager.CustomerPaging(page, 5);
                return CustomResult("Data Loaded Successfull",Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            try
            {
                bool Result=_customerManager.Add(customer);
                if (Result)
                {
                    return CustomResult("Customer Save Successfully.!", Result);
                    
                }
                return CustomResult("Customer Saved Failed", HttpStatusCode.BadRequest);



            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }


        }
        [HttpPost]
        public IActionResult CustomerEdit(Customer customer)
        {
            try
            {
                if(customer == null)
                {
                    return CustomResult("Customer Is Massing",HttpStatusCode.BadRequest);
                }
                bool Result=_customerManager.Update(customer);
                if (Result)
                {
                    return CustomResult("Customer Update Successfully", customer);

                }
                return CustomResult("Customer Update Failed", HttpStatusCode.BadRequest);

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
                var Result = _customerManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                bool result = _customerManager.Delete(Result);
                if (result)
                {
                    return CustomResult("Customer Has been delete");
                }
                return CustomResult("Customer delete Failed", HttpStatusCode.BadRequest);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
    

}
