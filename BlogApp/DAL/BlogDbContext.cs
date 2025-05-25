using BlogApp.DAL.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
