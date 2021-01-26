using System;
using System.Collections.Generic;
using Test.ORM;
//using Test.Model;

namespace Test.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}
