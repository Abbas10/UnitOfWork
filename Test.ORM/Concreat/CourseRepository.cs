using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using AutoMapper;

namespace Test.ORM
{
    public partial class Course : Repository<Course, Model.Course>, ICourseRepository
    {
        public Course()
        {
        }

        public Course(TestDBContext context, IMapper mapper): base(context, mapper)
        {
        }

        public IEnumerable<Test.Model.Course> GetTopSellingCourses(int count)
        {
            return Mapper.Map<IList<Test.ORM.Course>,IList<Test.Model.Course>>(TestDbContext.Courses.OrderByDescending(c => c.Author.AuthorName).Take(count).ToList());
        }

        public IEnumerable<Test.Model.Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return Mapper.Map<IList<Test.ORM.Course>,IList <Test.Model.Course>> (TestDbContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList());
        }

        public TestDBContext TestDbContext => Context as TestDBContext;
    }
}
