using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Test.BusinessLayer;
using Test.Common;
using Test.Model;

namespace TestApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TestService1 : ITestService1
    {
        public string GetData(int value)
        {
            #region of Extension method
            var bytes ="abcdefghtml".GetQRCode();
            #endregion

            var s = Convert.ToBase64String(bytes, 0, bytes.Length);
            
            using (var blogManager = new BlogManager())
            using (var authorManager = new AuthorManager())
            {
                var blog = blogManager.GetBlog(value);
                var author = authorManager.GetAuthor(value); 
                return string.Format("Author Name: {0} and Blog Title: {1}", author.Name, blog.Title);
            }
        }
    }
}
