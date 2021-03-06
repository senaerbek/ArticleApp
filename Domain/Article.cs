using System;

namespace Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; } 
        public string ArticleContent { get; set; }
        public string ArticleImage { get; set; }
    }
}