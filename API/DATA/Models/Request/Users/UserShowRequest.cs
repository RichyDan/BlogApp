﻿namespace API.DATA.Models.Request.Users
{
    public class UserShowRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Guid> Posts { get; set; }
    }
}
