using BlogApp.DAL.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL
{
    public class Blog2DbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public Blog2DbContext(DbContextOptions<Blog2DbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
