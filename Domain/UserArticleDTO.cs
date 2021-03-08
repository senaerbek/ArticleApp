using System;

namespace Domain
{
    public class UserArticleDTO
    {
         public Guid ArticleId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; } 
        public string ArticleContent { get; set; }
        public byte[] ArticleImage { get; set; }
    }
}