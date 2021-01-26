using System.Data.Entity;
using System.Linq;
using Test.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Test.ORM
{
    public partial class Author : Repository<Author, Test.Model.Author>, IAuthorRepository
    {
        public Author(TestDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Model.Author GetAuthorWithCourses(int id)
        {
            //return TestDbContext.Authors.Include(a => a.Courses).ProjectTo<Model.Author>().SingleOrDefault(a => a.AuthorId == id);
            return
                Mapper.Map<Author, Model.Author>(
                    TestDbContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.AuthorId == id));
        }

        public TestDBContext TestDbContext => Context as TestDBContext;
    }
}
