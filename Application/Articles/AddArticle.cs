using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Articles
{
    public class AddArticle
    {
        public class Command : IRequest
        {
            public Article Article { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ArticleContext _articleContext;
            private readonly IHttpContextAccessor contextAccessor;
            public Handler(ArticleContext articleContext, IHttpContextAccessor contextAccessor)
            {
                this.contextAccessor = contextAccessor;
                _articleContext = articleContext;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var newArticle = new Article{
                    UserId = Guid.Parse(contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    Title = request.Article.Title,
                    Date = request.Article.Date,
                    ArticleContent = request.Article.ArticleContent,
                    ArticleImage = request.Article.ArticleImage
                };

                _articleContext.Articles.Add(newArticle);
                var success = await _articleContext.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("eklenemedi");
            }
        }
    }
}