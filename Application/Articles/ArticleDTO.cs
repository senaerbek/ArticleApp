using System;
using System.Collections.Generic;
using Application.Profiles;

namespace Application.Articles
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ArticleContent { get; set; }
        public byte[] ArticleImage { get; set; }
        public ICollection<UserLike> UserArticles { get; set; }
    }
}