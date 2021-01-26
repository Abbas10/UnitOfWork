using System;
using System.Collections.Generic;
using Test.ORM;
using Test.Model;

namespace Test.ORM
{
    public interface ICourseRepository : IRepository<Course,Model.Course>
    {
        IEnumerable<Test.Model.Course> GetTopSellingCourses(int count);
        IEnumerable<Test.Model.Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}
