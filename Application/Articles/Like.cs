using System;
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
    public class Like
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ArticleContext _articleContext;
            private readonly IHttpContextAccessor _contextAccessor;
            public Handler(ArticleContext articleContext, IHttpContextAccessor contextAccessor)
            {
                _contextAccessor = contextAccessor;
                _articleContext = articleContext;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = await _articleContext.Articles.FindAsync(request.Id);
                var user = await _articleContext.Users.SingleOrDefaultAsync(x=>x.UserName == _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));

                var like = await _articleContext.UserArticles.SingleOrDefaultAsync(x=>x.ArticleId==article.Id &&x.UserId == user.Id);

                if(like != null){
                    throw new Exception("beğendin");
                }

                like = new UserArticle{
                    User = user,
                    Article = article,
                    isHost = false
                };

                _articleContext.UserArticles.Add(like);              
                var success = await _articleContext.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("--");
            }
        }
    }
}