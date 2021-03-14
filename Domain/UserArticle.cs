using System;

namespace Domain
{
    public class UserArticle
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid ArticleId { get; set; } 
        public Article Article { get; set; }
        public bool isHost { get; set; }
    }
}