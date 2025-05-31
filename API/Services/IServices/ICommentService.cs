using API.DATA.Models.Request.Comments;
using API.DATA.Models.Response;

namespace API.Services.IServices
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model);
        Task<int> EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
