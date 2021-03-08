
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles
{
    // Makale detayları
    public class GetArticlesById
    {
        public class Query : IRequest<UserArticleDTO> {
            public Guid Id { get; set; }
         }
        public class Handler : IRequestHandler<Query, UserArticleDTO>
        {
             private readonly ArticleContext _articleContext;
            public Handler(ArticleContext articleContext)
            {
                _articleContext = articleContext;
            }
            public Task<UserArticleDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var articles = ( from user in _articleContext.Users
                join article in _articleContext.Articles
                on user.Id equals (article.UserId).ToString()
                where article.Id == request.Id
                select new UserArticleDTO {
                    ArticleId = article.Id,
                   UserName = user.UserName,
                   UserId = user.Id.ToString(),
                   Title = article.Title,
                   Date = article.Date,
                   ArticleContent = article.ArticleContent,
                   ArticleImage = article.ArticleImage
                });
                
               var a = articles.SingleOrDefaultAsync();
                return a;
            }
        }
    }
}

