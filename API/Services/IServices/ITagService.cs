using API.DATA.Models.Request.Comments;
using API.DATA.Models.Request.Tags;
using API.DATA.Models.Response;

namespace API.Services.IServices
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
