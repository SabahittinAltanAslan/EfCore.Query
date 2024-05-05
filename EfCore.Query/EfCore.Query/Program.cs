using EfCore.Query.Data.Context;
using EfCore.Query.Data.Entities;

namespace EfCore.Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context =new BlogContext();

            //context.Add(new Blog
            //{
            //    Title = "Blog-1",
            //    Url="ysk.com/blog-1"
            //});
            //context.Add(new Blog
            //{
            //    Title = "Blog-2",
            //    Url = "ysk.com/blog-2"
            //});
            //context.Add(new Blog
            //{
            //    Title = "Blog-3",
            //    Url = "ysk.com/blog-3"
            //});
            //context.Add(new Blog
            //{
            //    Title = "Blog-4",
            //    Url = "ysk.com/blog-4"
            //});
            //context.SaveChanges();

            // IEnumarable && IQueryable

            var blogs =context.Blogs.AsEnumerable();

            blogs = blogs.Where(x => x.Title.Contains("Blog-1") || x.Title.Contains("Blog-2"));

            foreach (var item in blogs)
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
