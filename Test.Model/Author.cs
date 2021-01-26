using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
     public class Author
    {
        public Author()
        {
            Courses = new HashSet<Course>();
        }

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
