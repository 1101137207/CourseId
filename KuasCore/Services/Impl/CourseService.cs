using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddEmployee(Course course)
        {
            CourseDao.AddCourse(course);
        }

        public void UpdateCourse(Employee course)
        {
            CourseDao.UpdateCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            course = CourseDao.GetCourseById(Course.CourseId);

            if (course != null)
            {
                CourseDao.DeleteCourse(course);
            }
        }

        public IList<Course> GetAllCourse()
        {
            return CourseeDao.GetAllCourse();
        }

        

        public Course GetCourseByName(string CourseName)
        {
            return CourseDao.GetCourseByName(CourseName);
        }

    }

}
