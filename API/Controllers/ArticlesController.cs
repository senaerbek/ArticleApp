using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Articles;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    public class ArticlesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<List<Article>>> GetArticles()
        {

            return await _mediator.Send(new List.Query());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticleById(Guid Id)
        {
            return await _mediator.Send(new GetArticlesById.Query { Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Add(Article article)
        {
            return await _mediator.Send(new AddArticle.Command { Article = article });
        }

        [HttpGet("articles")]
        public async Task<ActionResult<List<Article>>> GetArticlesById()
        {
            return await _mediator.Send(new GetArticleListById.Query());
        }

          [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteArticle(Guid id){
            return await _mediator.Send(new DeleteArticle.Command{Id = id});
        }

    }
}