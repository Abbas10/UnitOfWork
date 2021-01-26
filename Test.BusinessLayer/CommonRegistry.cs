using System;
using AutoMapper;
using StructureMap;
using Test.ORM;

namespace Test.BusinessLayer
{
    /// <summary>
    /// CommonRegistry class
    /// </summary>
    public class CommonRegistry : Registry
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRegistry"/> class.
        /// </summary>
        public CommonRegistry()
        {
            var mapperConfiguration = CreateConfiguration();
            For<IMapper>().Use<Mapper>().Ctor<MapperConfiguration>("configurationProvider").Is(mapperConfiguration);
            For<IUnitOfWork>().Use<UnitOfWork>();

        }


        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Test.ORM.Author, Test.Model.Author>(MemberList.None)
                    .ForMember(d => d.Name, e => e.ResolveUsing(x => x.AuthorName));
                cfg.CreateMap<Test.ORM.Blog, Test.Model.Blog>(MemberList.None);
            });

            return config;
        }
    }
}
