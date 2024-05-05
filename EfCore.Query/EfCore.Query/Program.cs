using EfCore.Query.Data.Context;
using EfCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

            //var blogs =context.Blogs.AsEnumerable();
            //AsEnumerable olunca database üzerine tekrar gidip sorgu atmıyor.
            //blogs = blogs.Where(x => x.Title.Contains("Blog-1") || x.Title.Contains("Blog-2"));

            //var blogs = context.Blogs.AsQueryable();

            //var query = blogs.Where(x => x.Title.Contains("Blog-1") || 
            //x.Title.Contains("Blog-2")).ToList();

            //foreach (var item in blogs)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //var updatedBlog = context.Blogs.SingleOrDefault(x=>x.Id==1);

            //updatedBlog.Title = "Güncellendi";

            //var updatedBlogState= context.Entry(updatedBlog).State;

            //context.SaveChanges();

            //var updatedBlog = context.Blogs.AsNoTracking().SingleOrDefault(x => x.Id == 2);

            //updatedBlog.Title = "Güncellendi";

            //var updatedBlogState = context.Entry(updatedBlog).State;

            //context.SaveChanges();

            //lazy ,eager ,explicit

           //var blogs= context.Blogs.Include(x=>x.Comments
           //.Where(x=>x.Content.Contains("Yorum-1"))).ToList();

           // foreach (var blog in blogs)
           // {
           //     Console.WriteLine($"{blog.Title} blogun yorumları");
           //     foreach (var comment in blog.Comments) 
           //     {
           //         Console.WriteLine($"\t\t {comment.Content}");
           //     }
           // }

            var blog=context.Blogs.SingleOrDefault(x => x.Id == 1);

            context.Entry(blog).Collection(x => x.Comments).Load();

            foreach (var item in blog.Comments)
            {
                Console.WriteLine(item.Content);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
