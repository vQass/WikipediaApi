using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;


namespace SmWikipediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleContentController : ControllerBase
    {
        private readonly IArticleContentService _articleContentService;
        public ArticleContentController(IArticleContentService articleContentService)
        {
            _articleContentService = articleContentService;
        }

        // GET: api/<CommentController>/byArticle/5
        [HttpGet("byArticle/{id}")]
        public IActionResult GetByArticleId(int id)
        {
            var articleContent = _articleContentService.GetByArticleId(id);

            return Ok(articleContent);
        }

        // GET api/<CommentController>/byContent/5
        [HttpGet("byContent/{id}")]
        public IActionResult GetById(int id)
        {
            var articleContent = _articleContentService.GetById(id);

            return Ok(articleContent);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Create([FromBody] ArticleContentCreateDto articleContentDto)
        {
            var id = _articleContentService.Add(articleContentDto);

            return Created($"/api/gallery/byComment/{id}", null);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ArticleContentCreateDto articleContentDto)
        {
            _articleContentService.Update(id, articleContentDto);

            return Ok();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleContentService.Delete(id);
            return NoContent();
        }
    }
}
