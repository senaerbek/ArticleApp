using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    /// Giriş yapan kullanıcının makaleleri
    public class GetArticleListById
    {
        public class Query : IRequest<List<Article>>
        {
        }
        public class Handler : IRequestHandler<Query, List<Article>>
        {
            private readonly ArticleContext _articleContext;
            private readonly IHttpContextAccessor accessor;
            public Handler(ArticleContext articleContext, IHttpContextAccessor accessor)
            {
                this.accessor = accessor;
                _articleContext = articleContext;
            }
            public async Task<List<Article>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Id = Guid.Parse(accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var articles = await _articleContext.Articles.Where(x => x.UserId == Id).ToListAsync();
                return articles;
            }
        }
    }
}