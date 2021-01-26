using System.Data.Entity;
using System.Linq;
//using Test.Model;
using Test.ORM;

namespace Test.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(TestDBContext context) : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return TestDbContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.AuthorId == id);
        }

        public TestDBContext TestDbContext => Context as TestDBContext;
    }

    
}
