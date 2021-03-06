using System;
using System.Collections.Generic;

namespace Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; } 
        public string ArticleContent { get; set; }
        public byte[] ArticleImage { get; set; }
        public ICollection<UserArticle> UserArticles { get; set; }
    }
}