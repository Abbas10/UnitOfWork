using System;
using AutoMapper;
using Test.ORM;
using StructureMap;
using Blog = Test.Model.Blog;

namespace Test.BusinessLayer
{
    public class BlogManager: IBlogManager, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;
        
        public BlogManager()
        {
            unitOfWork = Container.For<CommonRegistry>().GetInstance<IUnitOfWork>();

            //Mapper = mapper;
            //Mapper = Container.For<CommonRegistry>().GetInstance<Mapper>();
            //Mapper = new Container(config => config.For<IMapper>().Use<Mapper>()).GetInstance<IMapper>("Mapper");
            //unitOfWork = new UnitOfWork(new TestDBContext(), Mapper);

        }

        public Test.Model.Blog GetBlog(int id)
        {
            return unitOfWork.Blogs.Get(id);
        }

        public void Dispose()
        {

        }

    }
}