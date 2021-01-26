using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Course
    {
        public Course()
        {
            
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}
