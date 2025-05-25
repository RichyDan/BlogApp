using BlogApp.DAL.Models;

namespace BlogApp.BLL.Services.IServices
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateViewModel model);
        Task EditTag(TagEditViewModel model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
