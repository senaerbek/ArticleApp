using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System;
using AutoMapper;

namespace Application.Articles
{
    //Tüm makaleler ana sayfa için
    public class List
    {
        public class Query : IRequest<List<ArticleDTO>> { }

        public class Handler : IRequestHandler<Query, List<ArticleDTO>>
        {
            private readonly ArticleContext _articleContext;
            private readonly IMapper _mapper;
            public Handler(ArticleContext articleContext, IMapper mapper)
            {
                _mapper = mapper;
                _articleContext = articleContext;
            }

            public async Task<List<ArticleDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _articleContext.Articles.Include(x => x.UserArticles).ThenInclude(y => y.User).ToListAsync();
                var map = _mapper.Map<List<Article>,List<ArticleDTO>>(user);
                return map;
            }
        }
    }
}