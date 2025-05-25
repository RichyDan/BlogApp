using BlogApp.DAL.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogApp.DAL
{
    public class BlogDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            Database.Migrate();
        }

    }
}
