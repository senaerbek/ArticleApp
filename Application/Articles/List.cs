using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class List
    {
        public class Query : IRequest<List<Article>> { }

        public class Handler : IRequestHandler<Query, List<Article>>
        {
            private readonly ArticleContext _articleContext;
            public Handler(ArticleContext articleContext)
            {
                _articleContext = articleContext;
            }

            public async Task<List<Article>> Handle(Query request, CancellationToken cancellationToken)
            {
                var articles = await _articleContext.Articles.ToListAsync();
                return articles;
            }
        }
    }
}