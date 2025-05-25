using BlogApp.BLL.ViewModels.Roles;
using BlogApp.DAL.Models;

namespace BlogApp.BLL.Services.IServices
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateViewModel model);
        Task EditRole(RoleEditViewModel model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}
