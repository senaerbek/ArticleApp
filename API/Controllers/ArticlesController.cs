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

namespace API.Controllers
{
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
    }
}