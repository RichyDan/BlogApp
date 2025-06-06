﻿namespace API.DATA.Models.Response
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public string AuthorId { get; set; } = String.Empty;

        public DateTime CreatedData { get; set; } = DateTime.Now;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
