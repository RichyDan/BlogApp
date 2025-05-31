using API.DATA.Models.Response;

namespace API.DATA.Repositories.IRepositories
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
