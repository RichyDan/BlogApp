using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.ViewModels.Roles;
using BlogApp.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;


        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;

        }

        public async Task<Guid> CreateRole(RoleCreateViewModel model)
        {
            var role = new Role() { Name = model.Name, SecurityLvl = model.SecurityLvl };
            await _roleManager.CreateAsync(role);

            return Guid.Parse(role.Id);
        }

        public async Task EditRole(RoleEditViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) && model.SecurityLvl == null)
                return;

            var role = await _roleManager.FindByIdAsync(model.Id.ToString());

            if (!string.IsNullOrEmpty(model.Name))
                role.Name = model.Name;
            if (model.SecurityLvl != null)
                role.SecurityLvl = model.SecurityLvl;

            await _roleManager.UpdateAsync(role);
        }

        public async Task RemoveRole(Guid Id)
        {
            var role = await _roleManager.FindByIdAsync(Id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<List<Role>> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
