using AutoMapper;
using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.ViewModels.Tags;
using BlogApp.DAL.Models;
using BlogApp.DAL.Repositories.IRepositories;

namespace BlogApp.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repo;
        private IMapper _mapper;

        public TagService(ITagRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTag(TagCreateViewModel model)
        {
            var tag = _mapper.Map<Tag>(model);
            await _repo.AddTag(tag);

            return tag.Id;
        }

        public async Task EditTag(TagEditViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return;

            var tag = _repo.GetTag(model.Id);
            tag.Name = model.Name;
            await _repo.UpdateTag(tag);
        }

        public async Task RemoveTag(Guid id)
        {
            await _repo.RemoveTag(id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return _repo.GetAllTags().ToList();
        }
    }
}
