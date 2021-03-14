
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Articles
{
    // Makale detayları
    public class GetArticlesById
    {
        public class Query : IRequest<ArticleDTO>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, ArticleDTO>
        {
            private readonly ArticleContext _articleContext;
            private readonly IMapper _mapper;
            public Handler(ArticleContext articleContext, IMapper mapper)
            {
                _mapper = mapper;
                _articleContext = articleContext;
            }
            public async Task<ArticleDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var article = await _articleContext.Articles.Include(x => x.UserArticles).ThenInclude(y => y.User)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

                var map = _mapper.Map<Article, ArticleDTO>(article);
                return map;

            }
        }
    }
}

