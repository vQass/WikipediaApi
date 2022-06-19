using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;
using System;
using System.Collections.Generic;

namespace SmWikipediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        readonly IArticleService _articleService;


        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var articles = _articleService.GetAll();
            return articles;
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public ArticleDisplayDto Get(short id)
        {
            var article = _articleService.GetById(id);
            return article;
        }

        // POST api/<ArticleController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] ArticleCreateDto articleDto)
        {
            var id = _articleService.Create(articleDto);

            return Created($"/api/article/{id}", null);
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(short id, [FromBody] ArticleCreateDto articleDto)
        {
            _articleService.Update(id, articleDto);
            return Ok();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(short id)
        {
            _articleService.Delete(id);
            return NoContent();
        }
    }
}
