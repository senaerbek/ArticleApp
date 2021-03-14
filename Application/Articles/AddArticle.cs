using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles
{
    public class AddArticle
    {
        public class Command : IRequest
        {
            public Article Article { get; set; }
            public IEnumerable<IFormFile> File { get; set; }
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
                foreach (var item in request.File)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            request.Article.ArticleImage = stream.ToArray();
                        }
                    }
                }
              
                request.Article.Date = DateTime.Now.ToString();

                _articleContext.Articles.Add(request.Article);

                var user = await _articleContext.Users.SingleOrDefaultAsync(x=>x.UserName == _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));

                var like = new UserArticle{
                    User =user,
                    Article = request.Article,
                    isHost = true
                };
                _articleContext.UserArticles.Add(like);

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