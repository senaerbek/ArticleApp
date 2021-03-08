using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System;

namespace Application.Articles
{
    //Tüm makaleler ana sayfa için
    public class List
    {
        public class Query : IRequest<List<UserArticleDTO>> { }

        public class Handler : IRequestHandler<Query, List<UserArticleDTO>>
        {
            private readonly ArticleContext _articleContext;
            public Handler(ArticleContext articleContext)
            {
                _articleContext = articleContext;
            }

            public  Task<List<UserArticleDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var articles =  from user in _articleContext.Users
                join article in _articleContext.Articles
                on user.Id equals (article.UserId).ToString()
                select new UserArticleDTO {

                    ArticleId = article.Id,
                   UserName = user.UserName,
                   UserId = user.Id.ToString(),
                   Title = article.Title,
                   Date = article.Date,
                   ArticleContent = article.ArticleContent,
                   ArticleImage = article.ArticleImage
                };
               
                return articles.ToListAsync();
            }
        }
    }
}