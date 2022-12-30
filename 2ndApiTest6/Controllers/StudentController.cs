﻿using _2ndApiTest6.Context;
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
    public class StudentController : BaseController
    {
        ApplicationDbContext _dbContext;
        IStudentManager _studentManager;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _studentManager = new StudentManager(_dbContext);
        }
        [HttpGet]
        public async Task< IActionResult> GetAllStudent()
        {
            try
            {
                var Result = _studentManager.GetAll().ToList();
                return CustomResult("Data Loaded Successfully", Result);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            try
            {
                bool IsSave = _studentManager.Add(student);
                if (IsSave)
                {
                    return CustomResult("Student Save Successfull", IsSave);
                }
                return CustomResult("Student Save Faild.!", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet]
        public async Task< IActionResult> GetById(int id)
        {
            try
            {
                if (id == null)
                {
                    return CustomResult("Id Not Found",HttpStatusCode.NotFound);

                }
                var Result=_studentManager.GetById(id);
                if(Result == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found.!",Result);
                

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }
    }
}
