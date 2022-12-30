using _2ndApiTest6.Context;
using _2ndApiTest6.Migrations;
using _2ndApiTest6.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Net;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ImageUpload = _2ndApiTest6.Models.ImageUpload;

namespace _2ndApiTest6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageUploadController : BaseController
    {
        ApplicationDbContext _dbContext;
        IHostingEnvironment _environment;
        public ImageUploadController(ApplicationDbContext dbContext,IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        [HttpPost]
        public ActionResult<string> UploadImages()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if(files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfileName="Image_"+DateTime.Now.TimeOfDay.Milliseconds+fi.Extension;
                        var path = Path.Combine("", _environment.ContentRootPath + "\\Images\\" + newfileName);
                        using(var stream=new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        ImageUpload imageUpload = new ImageUpload();
                        imageUpload.imagepath = path;
                        imageUpload.InsertOn = DateTime.Now;
                        _dbContext.Add(imageUpload);
                        _dbContext.SaveChanges();



                    }
                    return "Save Successfully";
                }
                else
                {
                    return "Select File";
                }


            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
       public ActionResult<List<ImageUpload>> GetImageUploade()
        {
            var Result = _dbContext.images.ToList();
            return Result;

        }



    }
}
