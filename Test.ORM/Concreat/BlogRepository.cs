using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Test.ORM
{
    public partial class Blog: Repository<Blog,Test.Model.Blog>, IBlogRepository
    {
        public Blog()
        {
        }

        public Blog(TestDBContext context, IMapper mapper): base(context, mapper)
        {
        }
        public TestDBContext TestDbContext => Context as TestDBContext;
    }
}
