using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2ndApiTest6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        //[Route("[action]")]
        //[Route("GetName")]
        public string GetName()
        {
            return "Haeri bol";
        }
        [HttpGet]
        //[Route("[action]")]
        //[Route("GetFullName")]
        public string GetFullName()
        {
            return "Rajdip Raj Santanu";
        }
    }
}
