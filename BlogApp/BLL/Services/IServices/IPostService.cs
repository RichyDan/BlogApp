using BlogApp.DAL.Models;

namespace BlogApp.BLL.Services.IServices
{
    public interface IPostService
    {
        Task<PostCreateViewModel> CreatePost();
        Task<Guid> CreatePost(PostCreateViewModel model);
        Task<PostEditViewModel> EditPost(Guid Id);
        Task EditPost(PostEditViewModel model, Guid Id);
        Task RemovePost(Guid id);
        Task<List<Post>> GetPosts();
        Task<Post> ShowPost(Guid id);
    }
}
