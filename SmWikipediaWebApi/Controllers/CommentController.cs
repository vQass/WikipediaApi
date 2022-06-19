using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmWikipediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var comments = _commentService.GetAllComments();

            return Ok(comments);
        }

        // GET: api/<CommentController>/byArticle/5
        [HttpGet("byArticle/{id}")]
        public IActionResult GetByArticleId(int id)
        {
            var comments = _commentService.GetByArticleId(id);

            return Ok(comments);
        }

        // GET api/<CommentController>/byComment/5
        [HttpGet("byComment/{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _commentService.GetById(id);

            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentCreateDto commentDto)
        {
            var id = _commentService.Add(commentDto);

            return Created($"/api/comment/byComment/{id}", null);
        }

        // PUT api/<CommentController>/5
        [HttpPatch("{id}")]
        public IActionResult Put(int id)
        {
            _commentService.Accept(id);
            return Ok();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.Delete(id);
            return NoContent();
        }
    }
}
