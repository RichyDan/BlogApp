namespace API.Services.IServices
{
    public interface ITagService
    {
        Task<Guid> CreateComment(CommentCreateRequest model);
        Task<int> EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
