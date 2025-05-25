using AutoMapper;
using BlogApp.BLL.Services.IServices;
using BlogApp.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IPostRepository _postRepository;
        public IMapper _mapper;

        // конструктор для аккаунта
        public AccountService(IPostRepository postRepository, RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _postRepository = postRepository;
        }

        // блок для регистрации нового пользователя
        public async Task<IdentityResult> Register(UserRegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                var userRole = new Role() { Name = "Пользователь", SecurityLvl = 0 };
                await _roleManager.CreateAsync(userRole);

                var currentUser = await _userManager.FindByIdAsync(Convert.ToString(user.Id));
                await _userManager.AddToRoleAsync(currentUser, userRole.Name);

                return result;
            }
            else
            {
                return result;
            }
        }

        // блок для логина пользователя
        public async Task<SignInResult> Login(UserLoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            return result;
        }

        // блок для редактирования пользователя по идент. номеру
        public async Task<UserEditViewModel> EditAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var allRolesName = _roleManager.Roles.ToList();

            UserEditViewModel model = new UserEditViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                NewPassword = string.Empty,
                Id = id,
                Roles = allRolesName.Select(r => new RoleViewModel() { Id = new Guid(r.Id), Name = r.Name }).ToList(),
            };

            return model;
        }

        // блок для редактирования по модели
        public async Task<IdentityResult> EditAccount(UserEditViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());

            if (model.FirstName != null)
            {
                user.FirstName = model.FirstName;
            }
            if (model.LastName != null)
            {
                user.LastName = model.LastName;
            }
            if (model.Email != null)
            {
                user.Email = model.Email;
            }
            if (model.NewPassword != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            }
            if (model.UserName != null)
            {
                user.UserName = model.UserName;
            }

            foreach (var role in model.Roles)
            {
                var roleName = _roleManager.FindByIdAsync(role.Id.ToString()).Result.Name;

                if (role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        // блок удаления пользователя
        public async Task RemoveAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            await _userManager.DeleteAsync(user);
        }

        //блок по получению списка пользователей
        public async Task<List<User>> GetAccounts()
        {
            var accounts = _userManager.Users.Include(u => u.Posts).ToList();

            foreach (var user in accounts)
            {
                var roles = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    var newRole = new Role { Name = role };
                    user.Roles.Add(newRole);
                }
            }

            return accounts;
        }

        // блок выхода пользователя из аккаунта
        public async Task LogoutAccount()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
