using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class CourseController : ApiController
    {
        public ICourseService CourseService { get; set; }

        [HttpGet]
        public IList<Course> GetAllCourse()
        {
            return CourseService.GetAllCourse();
        }

        [HttpGet]
        public Course GetCourseById(string CourseId)
        {
            return CourseService.GetCourseById(CourseId);
        }

        [HttpGet]
        public Course GetCourseByName(string CourseName)
        {
            return CourseService.GetCourseByName(CourseName);
        }




    }
}
