using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Articles
{
    public class DeleteArticle
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ArticleContext _articleContext;
            public Handler(ArticleContext articleContext)
            {
                _articleContext = articleContext;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = await _articleContext.Articles.FindAsync(request.Id);
                if(article == null){
                    throw new Exception ("Makale Bulunamadı");
                }
                _articleContext.Remove(article);
                var success = await _articleContext.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("silinemedi");
            }
        }
    }
}