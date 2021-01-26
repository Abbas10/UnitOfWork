using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Test.ORM;

namespace Test.Repositories
{
    internal class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(TestDBContext context)
           : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return TestDbContext.Courses.OrderByDescending(c => c.Author.AuthorName).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return TestDbContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public TestDBContext TestDbContext => Context as TestDBContext;
    }
}
