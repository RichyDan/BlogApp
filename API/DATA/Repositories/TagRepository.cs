using API.DATA.Models;
using API.DATA.Models.Response;
using API.DATA.Repositories.IRepositories;

namespace API.DATA.Repositories
{
    public class TagRepository : ITagRepository
    {
        private BlogDbContext _context;

        public TagRepository(BlogDbContext context)
        {
            _context = context;
        }

        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTag(Guid id)
        {
            return _context.Tags.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await SaveChangesAsync();
        }

        public async Task UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            await SaveChangesAsync();
        }

        public async Task RemoveTag(Guid id)
        {
            _context.Tags.Remove(GetTag(id));
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
