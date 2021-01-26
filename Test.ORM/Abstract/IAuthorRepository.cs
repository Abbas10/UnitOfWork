using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ORM;
using Test.Model;


namespace Test.ORM
{
    public interface IAuthorRepository: IRepository<Author, Model.Author>
    {
        Model.Author GetAuthorWithCourses(int id);
    }
}
