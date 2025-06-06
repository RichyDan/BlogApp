using AutoMapper;
using BlogApp.BLL;
using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.Services;
using BlogApp.DAL.Models;
using BlogApp.DAL.Repositories.IRepositories;
using BlogApp.DAL.Repositories;
using BlogApp.DAL;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

namespace BlogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var mapperConfig = new MapperConfiguration((v) => {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("Need to connect to database");
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, Role>(opts =>
                {
                    opts.Password.RequiredLength = 6;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<BlogDbContext>();

            builder.Services
                            .AddSingleton(mapper)
                            .AddTransient<ICommentRepository, CommentRepository>()
                            .AddTransient<ITagRepository, TagRepository>()
                            .AddTransient<IPostRepository, PostRepository>()
                            .AddTransient<IAccountService, AccountService>()
                            .AddTransient<ICommentService, CommentService>()
                            .AddTransient<IHomeService, HomeService>()
                            .AddTransient<IPostService, PostService>()
                            .AddTransient<ITagService, TagService>()
                            .AddTransient<IRoleService, RoleService>();

            builder.Logging
                            .ClearProviders()
                            .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                            .AddConsole()
                            .AddNLog("nlog");

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
