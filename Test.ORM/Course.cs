//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
    
        public virtual Author Author { get; set; }
    }
}