using EfCore.Query.Data.Configurations;
using EfCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Query.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //LazyLoading
            //optionsBuilder.UseLazyLoadingProxies()
            //    .UseSqlServer("server=LEGEN\\MSSQLSERVER01;database=BlogContext;integrated security=true; Trust Server Certificate=true;");

            optionsBuilder.UseSqlServer("server=LEGEN\\MSSQLSERVER01;database=BlogContext;integrated security=true; Trust Server Certificate=true;");

            optionsBuilder.LogTo(Console.WriteLine,
                Microsoft.Extensions.Logging.LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
