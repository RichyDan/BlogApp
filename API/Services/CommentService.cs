﻿using API.DATA.Models.Request.Comments;
using API.DATA.Models.Response;
using API.DATA.Repositories.IRepositories;
using API.Services.IServices;
using AutoMapper;

namespace API.Services
{
    public class CommentService : ICommentService
    {
        public IMapper _mapper;
        private ICommentRepository _commentRepo;

        public CommentService(IMapper mapper, ICommentRepository commentRepo)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
        }

        public async Task<Guid> CreateComment(CommentCreateRequest model)
        {
            Comment comment = new Comment
            {
                Title = model.Title,
                Body = model.Description,
                Author = model.Author,
                PostId = model.PostId,
                AuthorId = Guid.Empty,
            };

            await _commentRepo.AddComment(comment);
            return comment.Id;
        }

        public async Task<int> EditComment(CommentEditRequest model)
        {
            var comment = _commentRepo.GetComment(model.Id);

            if (comment == null)
                return 0;

            comment.Title = model.Title;
            comment.Body = model.Description;
            comment.Author = model.Author;

            await _commentRepo.UpdateComment(comment);
            return 1;
        }

        public async Task RemoveComment(Guid id)
        {
            await _commentRepo.RemoveComment(id);
        }

        public async Task<List<Comment>> GetComments()
        {
            return _commentRepo.GetAllComments().ToList();
        }
    }
}
