using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;

namespace Test.ORM
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDBContext _context;

        public UnitOfWork(TestDBContext context, IMapper mapper)
        {
            _context = context;

            Courses = new Course(_context, mapper);
            Authors = new Author(_context, mapper);
            Blogs = new Blog(_context, mapper);
            
        }

        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }
        public IBlogRepository Blogs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            //Mapper.Reset();
        }
    }
}
