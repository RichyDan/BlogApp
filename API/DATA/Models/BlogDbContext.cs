using API.DATA.Models.Response;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.DATA.Models
{
    public class BlogDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.Migrate();
            }
        }
    }
}

