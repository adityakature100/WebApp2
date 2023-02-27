using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;

namespace WebApp2.Services
{
    public class CourseService
    {
        private SqlConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Course> GetCourses(string connectionString)
        {
            List<Course> courses = new List<Course>();
            string sql = "select CourseId,CourseName,Rating from Course";
            SqlConnection sqlConnection = GetConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseId = reader.GetInt32(0),
                        CourseName = reader.GetString(1),
                        Rating = reader.GetDecimal(2)
                    };
                    courses.Add(course);
                }
            }
            sqlConnection.Close();
            return courses;
        }
    }
}
