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
            private readonly IHttpContextAccessor contextAccessor;
            public Handler(ArticleContext articleContext, IHttpContextAccessor contextAccessor)
            {
                this.contextAccessor = contextAccessor;
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
                request.Article.UserId = Guid.Parse(contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                request.Article.Date = DateTime.Now.ToString();

                _articleContext.Articles.Add(request.Article);
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