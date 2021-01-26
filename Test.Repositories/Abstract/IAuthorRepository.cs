using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ORM;
//using Test.Model;

namespace Test.Repositories
{
    public interface IAuthorRepository: IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}
