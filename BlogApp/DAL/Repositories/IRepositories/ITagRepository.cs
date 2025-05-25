using BlogApp.DAL.Models;

namespace BlogApp.DAL.Repositories.IRepositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Task AddTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task RemoveTag(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
