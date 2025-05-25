using AutoMapper;
using BlogApp.BLL.Services.IServices;
using BlogApp.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.BLL.Services
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public IMapper _mapper;

        public HomeService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task GenerateUsers()
        {
            var testUser = new UserRegisterViewModel { UserName = "FirstUser", Email = "FirstUser@gmail.com", 
                                                       Password = "1234aB", FirstName = "IvanFirst", LastName = "Rog" };

            var testUser2 = new UserRegisterViewModel { UserName = "SecondUser", Email = "SecondUser@gmail.com", 
                                                        Password = "12343aB", FirstName = "MichailSecond", LastName = "Smog" };

            var testUser3 = new UserRegisterViewModel { UserName = "ThirdUser", Email = "ThirdUser@gmail.com", 
                                                        Password = "12342aB", FirstName = "JavaThird", LastName = "Bog" };

            var user = _mapper.Map<User>(testUser);
            var user1 = _mapper.Map<User>(testUser2);
            var user2 = _mapper.Map<User>(testUser3);

            var userRole = new Role() { Name = "Пользователь", SecurityLvl = 0 };
            var moderRole = new Role() { Name = "Модератор", SecurityLvl = 1 };
            var adminRole = new Role() { Name = "Администратор", SecurityLvl = 3 };

            await _userManager.CreateAsync(user, testUser.Password);
            await _userManager.CreateAsync(user1, testUser2.Password);
            await _userManager.CreateAsync(user2, testUser3.Password);

            await _roleManager.CreateAsync(userRole);
            await _roleManager.CreateAsync(moderRole);
            await _roleManager.CreateAsync(adminRole);

            await _userManager.AddToRoleAsync(user, userRole.Name);
            await _userManager.AddToRoleAsync(user1, moderRole.Name);
            await _userManager.AddToRoleAsync(user2, adminRole.Name);
        }
    }
}
