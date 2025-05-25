using BlogApp.DAL.Models;

namespace BlogApp.BLL.Services.IServices
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateViewModel model, Guid UserId);
        Task EditComment(CommentEditViewModel model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
