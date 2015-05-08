
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (CourseId, CourseName, CourseDescription) VALUES (@CourseId, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.CourseId;
            parameters.Add("CourseName", DbType.String).Value = Course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = Course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET CourseName = @CourseName, CourseDescription = @CourseDescription WHERE CourseId = @CourseId;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.CourseId;
            parameters.Add("CourseName", DbType.String).Value = Course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = Course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE CourseId = @CourseId";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.CourseId;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourse()
        {
            string command = @"SELECT * FROM Course ORDER BY CourseId ASC";
            IList<Course> course = ExecuteQueryWithRowMapper(command);
            return course;
        }

        /*public Course GetCourseById(string CourseId)
        {
            string command = @"SELECT * FROM Course WHERE CourseId = @CourseId";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = CourseId;

            IList<Course> course = ExecuteQueryWithRowMapper(command, parameters);
            if (Course.Count > 0)
            {
                return course[0];
            }

            return null;
        }*/

        public Course GetCourseByName(string CourseName)
        {
            string command = @"SELECT * FROM Course WHERE CourseName = @CourseName";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseName", DbType.String).Value = CourseName;

            IList<Course> course = ExecuteQueryWithRowMapper(command, parameters);
            if (course.Count > 0)
            {
                return course[0];
            }

            return null;
        }

    }
}
