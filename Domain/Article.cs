using System;

namespace Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ArticleContent { get; set; }
        public byte[] ArticleImage { get; set; }
    }
}