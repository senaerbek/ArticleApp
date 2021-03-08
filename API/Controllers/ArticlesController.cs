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

        public async Task<ActionResult<List<UserArticleDTO>>> GetArticles()
        {

            return await _mediator.Send(new List.Query());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserArticleDTO>> GetArticleById(Guid Id)
        {
            return await _mediator.Send(new GetArticlesById.Query { Id = Id });
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<Unit>> Add([FromForm] Article article , [FromForm(Name = "ArticleImage")]IEnumerable<IFormFile> File)
        {
            return await _mediator.Send(new AddArticle.Command { Article = article, File = File });
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