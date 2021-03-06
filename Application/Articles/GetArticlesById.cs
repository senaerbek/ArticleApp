
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Articles
{
    // Makale detayları
    public class GetArticlesById
    {
        public class Query : IRequest<Article> {
            public Guid Id { get; set; }
         }
        public class Handler : IRequestHandler<Query, Article>
        {
             private readonly ArticleContext _articleContext;
            public Handler(ArticleContext articleContext)
            {
                _articleContext = articleContext;
            }
            public async Task<Article> Handle(Query request, CancellationToken cancellationToken)
            {
                var article = await _articleContext.Articles.FindAsync(request.Id);
                return article;
            }
        }
    }
}

