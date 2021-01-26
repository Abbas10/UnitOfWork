using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Test.Repositories;
using Test.ORM;
using Test.Model;
using AutoMapper;
using StructureMap;

namespace Test.BusinessLayer
{
    public class AuthorManager : IAuthorManager, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;
        
        public AuthorManager()
        {
            unitOfWork = Container.For<CommonRegistry>().GetInstance<IUnitOfWork>();
        }

        public Test.Model.Author GetAuthor(int id)
        {
            var obj =  unitOfWork.Authors.Get(id);
            var temp =  unitOfWork.Authors.GetAuthorWithCourses(id);

            return obj;
        } 
        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
